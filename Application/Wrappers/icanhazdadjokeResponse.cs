using System.Net;

namespace Application.Wrappers
{
    public record icanhazdadjokeResponse
    {
        public string Id { get; set; }
        public string joke { get; set; }
        public int status { get; set; }
    }
}
