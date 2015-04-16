using System;
using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Account.Response
{
    public class GetContentFeedResponse
    {
        public AtomFeed Feed { get; set; }
    }

    public class AtomFeed
    {
        public string Xmlns { get; set; }
        public AtomType Title { get; set; }
        public AtomType Subtitle { get; set; }
        public AtomType Rights { get; set; }
        public DateTime? Updated { get; set; }
        public string Generator { get; set; }
        public List<AtomLink> Link { get; set; }
        public List<AtomEntry> Entry { get; set; } 
    }

    public class AtomType
    {
        public string Type { get; set; }
        public string Text { get; set; }
    }

    public class AtomLink
    {
        public string Rel { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
    }

    public class AtomEntry
    {
        public string Id { get; set; }
        public AtomType Title { get; set; }
        public DateTime? Updated { get; set; }
        public AtomAuthor Author { get; set; }
        public AtomLink Link { get; set; }
        public AtomContent Content { get; set; }
        public AtomDataType Datatype { get; set; }
        public AtomDataType PageShortName { get; set; }
        public AtomDataType JgApiId { get; set; }
        public AtomImageCollection Images { get; set; }
    }

    public class AtomAuthor
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Email { get; set; }
    }

    public class AtomContent
    {
        public string Type { get; set; }
        public string Text { get; set; }
    }

    
    public class AtomDataType
    {
        public string Xmlns { get; set; }
        public string Text { get; set; }
    }

    public class AtomImageCollection
    {
        public string Xmlns { get; set; }
        public List<AtomImage> Image { get; set; } 
    }

    public class AtomImage
    {
        public string Xmlns { get; set; }
        public string Size { get; set; }
        public string Uri { get; set; }
    }
}
