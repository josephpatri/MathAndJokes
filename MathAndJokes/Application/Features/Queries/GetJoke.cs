using Application.DTOs;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Net.Http;
using System.Net;
using System;
using System.Net.Http.Json;
using Application.Services;

namespace Application.Features.Queries
{
    public class GetJokeWithOptionalParam : IRequest<Response<JokeDto>>
    {
        public string? param { get; set; }
    }

    public class GetJokeHandler : IRequestHandler<GetJokeWithOptionalParam, Response<JokeDto>>
    {
        private readonly HttpClient _httpClient;
        private readonly GetApiResponses _api;

        public GetJokeHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<Response<JokeDto>> Handle(GetJokeWithOptionalParam request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(request.param))
            {
                var random = new Random();
                if (random.Next(1,2) == (int)Enums.JokeTypes.Dad)
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
