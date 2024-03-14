using Application.DTOs;
using Application.Services;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Queries
{
    public record GetJokeWithOptionalParam : IRequest<Response<JokeDto>>
    {
        public string? param { get; set; }
    }

    public class GetJokeHandler : IRequestHandler<GetJokeWithOptionalParam, Response<JokeDto>>
    {
        private readonly HttpClient _httpClient;
        private readonly GetApiResponses _api;

        public GetJokeHandler(IHttpClientFactory httpClientFactory, GetApiResponses api)
        {
            _httpClient = httpClientFactory.CreateClient();
            _api = api;
        }

        public async Task<Response<JokeDto>> Handle(GetJokeWithOptionalParam request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(request.param))
            {
                var random = new Random();
                if (random.Next(1,3) == (int)Enums.JokeTypes.Dad)
                {
                    return new Response<JokeDto>(await _api.GetJokeDad());
                }
                else 
                {
                    return new Response<JokeDto>(await _api.GetJokeChuck());
                }
            }
            else if (request.param.Equals("Chuck"))
            {
                return new Response<JokeDto>(await _api.GetJokeChuck());
            }
            else if (request.param.Equals("Dad"))
            {
                return new Response<JokeDto>(await _api.GetJokeDad());
            }
            else
            {
                throw new KeyNotFoundException("That type of joke does not exists");
            }
        }
    }
}
