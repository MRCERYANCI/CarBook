using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            return Ok(await _mediator.Send(new GetCarCountQuery()));
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            return Ok(await _mediator.Send(new GetLocationCountQuery()));
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            return Ok(await _mediator.Send(new GetAuthorCountQuery()));
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            return Ok(await _mediator.Send(new GetBlogCountQuery()));
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            return Ok(await _mediator.Send(new GetBrandCountQuery()));
        }

        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            return Ok(await _mediator.Send(new GetAvgRentPriceForDailyQuery()));
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            return Ok(await _mediator.Send(new GetAvgRentPriceForWeeklyQuery()));
        }

        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            return Ok(await _mediator.Send(new GetAvgRentPriceForMonthlyQuery()));
        }

        [HttpGet("GetCarCountByTranmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTranmissionIsAuto()
        {
            return Ok(await _mediator.Send(new GetCarCountByTranmissionIsAutoQuery()));
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            return Ok(await _mediator.Send(new GetBrandNameByMaxCarQuery()));
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            return Ok(await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery()));
        }

        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen1000()
        {
            return Ok(await _mediator.Send(new GetCarCountByKmSmallerThen1000Query()));
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            return Ok(await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery()));
        }

        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            return Ok(await _mediator.Send(new GetCarCountByFuelElectricQuery()));
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            return Ok(await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery()));
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            return Ok(await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery()));
        }
    }
}
