using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MpesaSdk;
using MpesaSdk.Interfaces;
using Newtonsoft.Json;
using Swarovski_Apis.Models;
using System.Text;

namespace Swarovski_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MpesaPaymentController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public MpesaPaymentController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        //Get AccessToken
        [HttpGet("getAccessToken")]
        public async Task<string> GetToken()
        {
            var client = _clientFactory.CreateClient("mpesa");

            var authString = "1AFLFfjhIFTg4kEiXAIwgJ2dERa22Cy8jm3xoRuFY0CuRkIZ:XC8N5sKQp2PJ0jWGAhkAWylAJZe3snsGOoNvEIgpRi28toppugx0rAyk1Lurs1c2";

            var encodedString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authString));

            var _url = "/oauth/v1/generate?grant_type=client_credentials";

            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            request.Headers.Add("Authorization", $"Basic {encodedString}");

            var response = await client.SendAsync(request);
            var mpesaResponse = await response.Content.ReadAsStringAsync(); 

            TokenResponseDto tokenObject = JsonConvert.DeserializeObject<TokenResponseDto>(mpesaResponse);
            
            return tokenObject.access_token;
        }
        // Register URL
        [HttpGet("register-urls")]
        public async Task<string> RegisterMpesaUrls()
        {
            // Prepare the JSON body for registration
            var jsonBody = JsonConvert.SerializeObject(new
            {
                ValidationURL = "https://mydemo-url.com/validation",
                ConfirmationURL = "https://mydemo-url.com/confirmation",
                ResponseType = "Completed",
                ShortCode = "600986"
            });

            var jsonReadyBody = new StringContent
            (
                jsonBody,
                Encoding.UTF8,
                "application/json"
            );

            // Get the access token
            var token = await GetToken();

            var client = _clientFactory.CreateClient("mpesa");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}"); // Add space after Bearer

            var url = "/mpesa/c2b/v1/registerurl";

            // Send POST request to register URL
            var response = await client.PostAsync(url, jsonReadyBody);

            var registerResponse = await response.Content.ReadAsStringAsync();

            // Log the response for debugging
            Console.WriteLine("Register Response: " + registerResponse);

            return registerResponse;
        }



    }
}
