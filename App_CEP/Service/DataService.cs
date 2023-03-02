﻿using App_CEP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App_CEP.Service
{
    public class DataService
    {
        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            Endereco end;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/endereco/by-cep?cep=");

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return end;
        }

        public static async Task<List<Bairro>> GetBairroByIdCidade(int id_cidade)
        {
            List<Bairro> arr_bairros = new List<Bairro>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/bairro/by-cidade?id_cidade=");

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return arr_bairros;
        }

        public static async Task<List<Cidade>> GetCidadesByEstado(string estado_selecionado)
        {
            List<Cidade> arr_cidades = new List<Cidade>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/cidade/by-uf?uf=");

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_cidades = JsonConvert.DeserializeObject<List<Cidade>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return arr_cidades;
        }
        public static async Task<List<Logradouro>> GetLogradourosByBairroAndIdCidade(string bairro, int id_cidade)
        {
            List<Logradouro> arr_logradouro = new List<Logradouro>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/logradouro/by-bairro?id_cidade=4874&bairro=Jardim%20America");

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_logradouro = JsonConvert.DeserializeObject<List<Logradouro>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return arr_logradouro;
        }
    }
}
