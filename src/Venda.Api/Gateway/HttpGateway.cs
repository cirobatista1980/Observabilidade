using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Venda.Api.Gateway.Interfaces;
using Venda.Api.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace Venda.Api.Gateway
{
    public class HttpGateway<TI, TR> : IHttpGateway<TI, TR>
    {
        private readonly IHttpClientFactory _factory;

        public HttpGateway(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<ResponseModel<List<TR>>> GetAllAsync(string url)
        {
            var cliente = _factory.CreateClient();
            var dados = new StringContent("", Encoding.UTF8, "application/json");

            var response = await cliente.GetAsync($"{url}");

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseModel<List<TR>>()
                {
                    Sucesso = false,
                    MessagemErro = await response.Content.ReadAsStringAsync()
                };
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            return new ResponseModel<List<TR>>()
            {
                Sucesso = true,
                ObjectToSerialize = JsonSerializer.Deserialize<List<TR>>(responseContent)
            };
        }

        public async Task<ResponseModel<TR>> GetAsync(string url, Guid id)
        {
            var cliente = _factory.CreateClient();
            var dados = new StringContent("", Encoding.UTF8, "application/json");

            var response = await cliente.GetAsync($"{url}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseModel<TR>()
                {
                    Sucesso = false,
                    MessagemErro = await response.Content.ReadAsStringAsync()
                };
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            return new ResponseModel<TR>()
            {
                Sucesso = true,
                ObjectToSerialize = JsonSerializer.Deserialize<TR>(responseContent)
            };
        }

        public async Task<ResponseModel<TR>> PostAsync(string url, TI signature)
        {
            var cliente = _factory.CreateClient();
            string json = JsonSerializer.Serialize(signature);
            var dados = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync(url, dados);

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseModel<TR>()
                {
                    Sucesso = false,
                    MessagemErro = await response.Content.ReadAsStringAsync()
                };
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            return new ResponseModel<TR>()
            {
                Sucesso = true,
                ObjectToSerialize = JsonSerializer.Deserialize<TR>(responseContent)
            };
        }

        public async Task<ResponseModel<TR>> PutAsync(string url, Guid id, TI signature)
        {
            var cliente = _factory.CreateClient();
            var json = JsonSerializer.Serialize(signature);
            var dados = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"{url}/{id}", dados);

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseModel<TR>()
                {
                    Sucesso = false,
                    MessagemErro = await response.Content.ReadAsStringAsync()
                };
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            return new ResponseModel<TR>()
            {
                Sucesso = true,
                ObjectToSerialize = JsonSerializer.Deserialize<TR>(responseContent)
            };
        }
    }
}