var gulp = require('gulp'),
    del = require('del'),
    babel = require('gulp-babel'),
    sourcemaps = require('gulp-sourcemaps'),
    uglify = require('gulp-uglify'),
    rename = require('gulp-rename'),
    eslint = require('gulp-eslint'),
    header = require('gulp-header'),
    pkg = require('./package.json'),
    mocha = require('gulp-mocha');

var paths = {
  scripts: ['src/**/JG-edge.js'],
  tests: ['tests/**/*.js']
};

var banner = ['/**',
  ' * <%= pkg.name %> - <%= pkg.description %>',
  ' * @version v<%= pkg.version %>',
  ' * @link <%= pkg.homepage %>',
  ' * @license <%= pkg.license %>',
  ' */',
  ''].join('\n');

gulp.task('clean', function(cb) {
  del('./dist/JG-edge*', cb);
});

gulp.task('build', ['build-full'], function() {
   return gulp.src('dist/JG-edge.js')
     .pipe(uglify())
     .pipe(rename('JG-edge.min.js'))
     .pipe(header(banner, { pkg : pkg } ))
     .pipe(gulp.dest('dist'));
});

gulp.task('build-full', ['lint', 'clean'], function(){
  return gulp.src(paths.scripts)
    .pipe(sourcemaps.init())
    .pipe(babel())
    .pipe(header(banner, { pkg : pkg } ))
    .pipe(sourcemaps.write('.'))
    .pipe(gulp.dest('dist'));
});

gulp.task('watch', function() {
  gulp.watch(paths.scripts, ['test']);
  gulp.watch(paths.tests, ['test']);
});

gulp.task('lint', function () {
  return gulp.src(paths.scripts)
    .pipe(eslint())
    .pipe(eslint.format())
    .pipe(eslint.failOnError());
});

gulp.task('test', ['build'], function() {
  return gulp.src(['tests/*.js', 'dist/JG-edge.js'])
    .pipe(mocha());
});

gulp.task('default', ['watch', 'test'], function() {});
