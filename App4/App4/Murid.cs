using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace App4
{
    public class Murid
    {
        private string _id;
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private string _age;
        [JsonProperty(PropertyName = "age")]
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}
