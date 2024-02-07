using AutoMapper;
using CqrsProject.Api.Commands;
using CqrsProject.Api.Query;
using CqrsProject.DataAccess.Repositories.Interfaces;
using CqrsProject.Entities.Dbset;
using CqrsProject.Entities.DTO.Responses;
using MediatR;

namespace CqrsProject.Api.Handlers
{
    public class AddDriverHandler : IRequestHandler<AddDriverCommand,GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetDriverResponse> Handle(AddDriverCommand request, CancellationToken cancellationToken)
        {
            var resultToDb = _mapper.Map<Driver>(request.DriverRequest);

            await _unitOfWork.Drivers.Add(resultToDb);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<GetDriverResponse>(resultToDb);
        }
    }
}
