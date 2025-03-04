using Enes_Api.Helpers;
using Enes_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;
        private readonly LoggerService _loggerService;

        public EstateAgentDashboardStatisticController(IStatisticRepository statisticRepository, LoggerService loggerService)
        {
            _statisticRepository = statisticRepository;
            _loggerService = loggerService;
        }

        [HttpGet("ProductCountByEmployeeId")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            return Ok(_statisticRepository.ProductCountByEmployeeId(id));
        }

        [HttpGet("ProductCountByStatusTrue")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusTrue(id));
        }

        [HttpGet("ProductCountByStatusFalse")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusFalse(id));
        }

        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            _loggerService.LogInformation("AllProductCount method started.");

            try
            {
                var productCount = _statisticRepository.AllProductCount();
                _loggerService.LogInformation("AllProductCount method executed successfully.");
                return Ok(productCount);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("An error occurred while executing AllProductCount method.", ex);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
