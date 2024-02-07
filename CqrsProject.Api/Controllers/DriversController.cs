using AutoMapper;
using CqrsProject.Api.Commands;
using CqrsProject.Api.Queries;
using CqrsProject.Api.Query;
using CqrsProject.DataAccess.Repositories.Interfaces;
using CqrsProject.Entities.Dbset;
using CqrsProject.Entities.DTO.Requests;
using CqrsProject.Entities.DTO.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace CqrsProject.Api.Controllers
{
    public class DriversController : BaseController
    {
        private readonly IMediator _mediator;
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
            : base(unitOfWork, mapper)
        {
            _mediator=mediator;
        }
        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var query = new GetDriverQuery(driverId);

            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDriver()
        {
            var query = new GetAllDriverQuery();

            var result = await _mediator.Send(query);

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new AddDriverCommand(driver);
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetDriver),
                new { driverId = result.DriverId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Driver>(driver);

            await _unitOfWork.Drivers.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var driver = await _unitOfWork.Drivers.GetById(driverId);

            if (driver is null)
                return NotFound();

            await _unitOfWork.Drivers.Delete(driverId);
            await _unitOfWork.CompleteAsync();

            return NoContent();

        }
    }
}
