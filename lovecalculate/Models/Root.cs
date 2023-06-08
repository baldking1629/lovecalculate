using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lovecalculate.Models
{
    public class Root
    {

        [JsonProperty("first name: ")]
        public string firstname { get; set; }

        [JsonProperty("second name: ")]
        public string secondname { get; set; }

        [JsonProperty("percentage match: ")]
        public double percentagematch { get; set; }

        [JsonProperty("result: ")]
        public string result { get; set; }

    }
}