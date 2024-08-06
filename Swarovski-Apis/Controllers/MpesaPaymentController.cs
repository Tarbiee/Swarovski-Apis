using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MpesaSdk;
using MpesaSdk.Interfaces;

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



            return mpesaResponse;
        }

        

    }
}
