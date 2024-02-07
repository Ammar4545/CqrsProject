using CqrsProject.Entities.DTO.Requests;
using MediatR;

namespace CqrsProject.Api.Commands
{
    public class UpdateDriverCommand : IRequest<bool>
    {
        public UpdateDriverRequest DriverRequest;
        public UpdateDriverCommand(UpdateDriverRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }
    }
}
