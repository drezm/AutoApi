using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practice.Contracts.Model
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateModalDto : ControllerBase
    {
        public int ModelId { get; set; }
        public string Model1 { get; set; } = null!;
        public string Brand { get; set; } = null!;
    }
}
