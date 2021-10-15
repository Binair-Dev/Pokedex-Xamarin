using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using XamarinSample.Models;
using XamarinSample.Tools;

namespace XamarinSample.Services
{
    public class PokemonService
    {
        private PokemonPage _ppage;

        public PokemonPage PPage
        {
            get { return _ppage; }
            set { _ppage = value; }
        }

        public List<Pokemon> ListPokemon { get; set; }

        public PokemonService()
        {
            _ppage = new PokemonPage();
            ListPokemon = new List<Pokemon>();
        }

        private void LoadPokemons(string url)
        {
            RestClient client = new RestClient();
            if (url == null)
                client.BaseUrl = new Uri("https://pokeapi.co/api/v2/pokemon/");
            else
                client.BaseUrl = new Uri(url);
            IRestResponse res = client.Execute(new RestRequest(Method.GET));
            string response = res.Content;

            JObject requestResponse = JObject.Parse(response);
            _ppage.next = (string)requestResponse["next"];
            _ppage.previous = (string)requestResponse["previous"];
            JArray array = (JArray)requestResponse["results"];

            foreach (JObject item in array)
            {
                RestClient tclient = new RestClient();
                tclient.BaseUrl = new Uri((string)item["url"]);
                IRestResponse tres = tclient.Execute(new RestRequest(Method.GET));
                string tresponse = tres.Content;

                JObject trequestResponse = JObject.Parse(tresponse);
                JObject tsprites = (JObject)trequestResponse["sprites"];

                AddPokemon(new Pokemon()
                {
                    name = (string)trequestResponse["name"],
                    weight = (int)trequestResponse["weight"],
                    back_default = (string)tsprites["back_default"],
                    front_default = (string)tsprites["front_default"]
                });
            }
        }

        public List<Pokemon> GetAll(string url)
        {
            ListPokemon.Clear();
            LoadPokemons(url);
            return ListPokemon;
        }
        public void AddPokemon(Pokemon p) => ListPokemon.Add(p);
    }
}
