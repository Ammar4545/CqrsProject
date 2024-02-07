using AutoMapper;
using CqrsProject.Api.Commands;
using CqrsProject.DataAccess.Repositories.Interfaces;
using CqrsProject.Entities.Dbset;
using CqrsProject.Entities.DTO.Requests;
using MediatR;

namespace CqrsProject.Api.Handlers
{
    public class UpdateDriverHandler : IRequestHandler<UpdateDriverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Driver>(request.DriverRequest);

            await _unitOfWork.Drivers.Update(result);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
