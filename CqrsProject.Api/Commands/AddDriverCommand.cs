using CqrsProject.Entities.DTO.Requests;
using CqrsProject.Entities.DTO.Responses;
using MediatR;

namespace CqrsProject.Api.Commands
{
    public class AddDriverCommand : IRequest<GetDriverResponse>
    {
        public CreateDriverRequest DriverRequest { get; }

        public AddDriverCommand(CreateDriverRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }
    }
}
