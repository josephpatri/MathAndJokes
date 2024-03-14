using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands
{
    public record CreateJokes : IRequest<Response<int>>
    {
        public string JokeName { get; set; }
        public string JokeDescription { get; set; }
        public string JokeOwner { get; set; }
    }

    public class CreateCustomerHandler : IRequestHandler<CreateJokes, Response<int>>
    {
        private readonly IBaseRepoAsync<Joke> _repo;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(IBaseRepoAsync<Joke> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateJokes request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Joke>(request);
            var data = await _repo.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
    }
}
