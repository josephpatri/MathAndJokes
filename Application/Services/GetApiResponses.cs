using Application.DTOs;
using Application.Wrappers;
using System.Text.Json;

namespace Application.Services
{
    public class GetApiResponses
    {

        private readonly IHttpClientFactory _clientFactory;

        public GetApiResponses(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        public async Task<JokeDto> GetJokeDad()
        {
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://icanhazdadjoke.com/");
            request.Headers.Add("Accept", "application/json");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jokeJson = await response.Content.ReadAsStringAsync();
                var jokeResponse = JsonSerializer.Deserialize<icanhazdadjokeResponse>(jokeJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var jokeDtoResponse = new JokeDto
                {
                    Id = jokeResponse.Id,
                    JokeDescription = jokeResponse.joke,
                    JokeName = "Joke from DadJokes",
                };

                return jokeDtoResponse;
            }
            else
            {
                throw new Exception("Error getting dad joke");
            }
        }

        public async Task<JokeDto> GetJokeChuck()
        {
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.chucknorris.io/jokes/random");
            request.Headers.Add("Accept", "application/json");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jokeJson = await response.Content.ReadAsStringAsync();
                var jokeResponse = JsonSerializer.Deserialize<ChuckJokeResponse>(jokeJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var jokeDtoResponse = new JokeDto
                {
                    Id = jokeResponse.id,
                    JokeName = "Joke from Chuck!",
                    JokeDescription = jokeResponse.value
                };

                return jokeDtoResponse;
            }
            else
            {
                throw new Exception("Error getting Chuck joke");
            }
        }
    }
}
