using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entropy.JsonAbstraction.UnitTests.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ImplementationModel
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "content")]
        public IEnumerable<IImplementationContent> Content { get; set; }
    }

    public interface IImplementationContent
    {

    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BlogPostDetailsImplementationContent : IImplementationContent
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "short_desc")]
        public string ShortDescription { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BlogPostListImplementationContent : IImplementationContent
    {
        [JsonProperty(PropertyName = "page_number")]
        public int PageNumber { get; set; }

        [JsonProperty(PropertyName = "page_size")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "posts")]
        public IEnumerable<BlogPostSnapshot> Posts { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BlogPostSnapshot
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "short_desc")]
        public string ShortDescription { get; set; }

        [JsonProperty(PropertyName = "position")]
        public int Position { get; set; }
    }
}