using AutoMapper;
using CqrsProject.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CqrsProject.Api.Controllers
{
    public class AchievementsController : BaseController
    {
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
