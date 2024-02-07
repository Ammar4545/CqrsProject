using AutoMapper;
using CqrsProject.DataAccess.Repositories.Interfaces;
using CqrsProject.Entities.Dbset;
using CqrsProject.Entities.DTO.Requests;
using CqrsProject.Entities.DTO.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CqrsProject.Api.Controllers
{
    public class DriversController : BaseController
    {
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var driver =await _unitOfWork.Drivers.GetById(driverId);

            if (driver == null)
                return NotFound("no Driver for this id");

            var result = _mapper.Map<GetDriverResponse>(driver);

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Driver>(driver);

            await _unitOfWork.Drivers.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
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

        [HttpGet]
        public async Task<IActionResult> GetAllDriver()
        {
            var drivers = await _unitOfWork.Drivers.GetAll();

            var result = _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);

            return Ok(result);

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
