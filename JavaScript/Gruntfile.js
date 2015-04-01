module.exports = function(grunt) {

  // Project configuration.
  grunt.initConfig({
    pkg: grunt.file.readJSON('package.json'),
      bower_concat: {
        all: {
          dest: 'build/_bower.js',
          bowerOptions: {
            relative: false
          }
        }
      },
	  concat: {
        options: {
          separator: ';'
        },
        dist: {
          src: ['build/**/*.js', 'src/**/*.js'],
          dest: 'dist/<%= pkg.name %>.js'
        }
      },
	  uglify: {
      options: {
        banner: '/*! <%= pkg.name %> <%= grunt.template.today("yyyy-mm-dd") %> */\n'
      },
	  build: {
        src: 'dist/<%= pkg.name %>.js',
        dest: 'dist/<%= pkg.name %>.min.js'
      }
	}
      
    
	
  });

  grunt.loadNpmTasks('grunt-bower');
  grunt.loadNpmTasks('grunt-contrib-concat');
  grunt.loadNpmTasks('grunt-bower-concat');
  grunt.loadNpmTasks('grunt-contrib-uglify');

  // Default task(s).
  grunt.registerTask('default', ['bower_concat', 'concat', 'uglify']);

};