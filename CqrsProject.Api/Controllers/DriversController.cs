using AutoMapper;
using CqrsProject.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CqrsProject.Api.Controllers
{
    public class DriversController : BaseController
    {
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
