using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entropy.JsonAbstraction.UnitTests.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
   public class DeclarationModel
    {
        [JsonProperty(PropertyName ="id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }
    }
}