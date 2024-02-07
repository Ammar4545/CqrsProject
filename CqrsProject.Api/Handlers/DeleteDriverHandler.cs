using AutoMapper;
using CqrsProject.Api.Commands;
using CqrsProject.DataAccess.Repositories.Interfaces;
using CqrsProject.Entities.Dbset;
using MediatR;

namespace CqrsProject.Api.Handlers
{
    public class DeleteDriverHandler : IRequestHandler<DeleteDriverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetById(request.DriverId);

            if (driver is null)
                return false;

            await _unitOfWork.Drivers.Delete(driver.Id);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
