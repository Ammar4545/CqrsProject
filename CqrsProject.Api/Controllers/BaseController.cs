﻿using AutoMapper;
using CqrsProject.DataAccess.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;
        public BaseController(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}
