using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    // Clase base para todos los controladores de la API
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        // Mediator para manejar comandos y consultas
        private IMediator _mediator;

        // Propiedad protegida para acceder al Mediator
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
