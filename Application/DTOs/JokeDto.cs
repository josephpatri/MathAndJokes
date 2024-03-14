using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record JokeDto
    {
        public string Id { get; set; }
        public string JokeName { get; set; }
        public string JokeDescription { get; set; }
    }
}