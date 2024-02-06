using AutoMapper;
using CqrsProject.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CqrsProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
