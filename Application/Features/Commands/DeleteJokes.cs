using Application.Interface;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class DeleteJokes : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteJokesHandler : IRequestHandler<DeleteJokes, Response<int>>
    {
        private readonly IBaseRepoAsync<Joke> _repo;

        public DeleteJokesHandler(IBaseRepoAsync<Joke> repositoryAsync)
        {
            _repo = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteJokes request, CancellationToken cancellationToken)
        {
            var cliente = await _repo.GetByIdAsync(request.Id);

            if (cliente == null)
            {
                throw new KeyNotFoundException($"Joke not found {request.Id}");
            }
            else
            {
                await _repo.DeleteAsync(cliente);
                return new Response<int>(cliente.Id);
            }
        }
    }
}
