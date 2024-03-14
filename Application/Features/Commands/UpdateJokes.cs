using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands
{
    public record UpdateJokes : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string JokeName { get; set; }
        public string JokeDescription { get; set; }
        public string JokeOwner { get; set; }
    }

    public class UpdateJokesHandler : IRequestHandler<UpdateJokes, Response<int>>
    {
        private readonly IBaseRepoAsync<Joke> _repo;
        private readonly IMapper _mapper;

        public UpdateJokesHandler(IBaseRepoAsync<Joke> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateJokes request, CancellationToken cancellationToken)
        {
            var joke = await _repo.GetByIdAsync(request.Id);

            if (joke == null)
            {
                throw new KeyNotFoundException($"Joke not found with id {joke.Id}");
            }
            else
            {
                joke.JokeName = request.JokeName;
                joke.JokeDescription = request.JokeDescription;
                joke.JokeOwner = request.JokeOwner;
                await _repo.UpdateAsync(joke);
                return new Response<int>(joke.Id);
            }
        }
    }
}
