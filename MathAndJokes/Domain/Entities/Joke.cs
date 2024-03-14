using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Joke : BaseEntity
    {
        public int Id { get; set; }
        public string JokeName { get; set; }
        public string JokeDescription { get; set; }
        public string JokeOwner { get; set; }
    }
}
