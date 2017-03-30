using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using PugCreator.Models;

namespace PugCreator.PugClient
{
    public class PugClient
    {
        private readonly WebClient _client;

        public PugClient()
        {
            _client = new WebClient();
            _client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
        }

        public IEnumerable<Pug> GetPugs()
        {
            try
            {
                var rawPugs = _client.DownloadString(ConfigurationManager.AppSettings["serverUrl"] + "Pugs/");
                return JsonConvert.DeserializeObject<List<Pug>>(rawPugs);
            }
            catch
            {
                return null;
            }
        }

        public Pug GetPug(Guid id)
        {
            try
            {
                var rawPug = _client.DownloadString(ConfigurationManager.AppSettings["serverUrl"] + $"Pugs/{id}");
                return JsonConvert.DeserializeObject<Pug>(rawPug);
            }
            catch
            {
                return null;
            }
        }

        public bool CreatePug(Pug newPug)
        {
            try
            {
                var serialPug = JsonConvert.SerializeObject(newPug);
                _client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                _client.UploadString(ConfigurationManager.AppSettings["serverUrl"] + "Pugs/", serialPug);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
