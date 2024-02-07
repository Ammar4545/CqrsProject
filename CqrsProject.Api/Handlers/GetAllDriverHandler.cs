using AutoMapper;
using CqrsProject.Api.Query;
using CqrsProject.DataAccess.Repositories.Interfaces;
using CqrsProject.Entities.DTO.Responses;
using MediatR;

namespace CqrsProject.Api.Handlers
{
    public class GetAllDriverHandler : IRequestHandler<GetAllDriverQuery, IEnumerable<GetDriverResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriverQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _unitOfWork.Drivers.GetAll();

            return _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
        }
    }
}
