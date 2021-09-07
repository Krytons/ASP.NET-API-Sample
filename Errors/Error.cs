using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Errors
{
    public class Error
    {
        public Error(string text)
        {
            Text = text;
        }

        [JsonProperty("message")]
        public string Text { get; set; }

    }
}
