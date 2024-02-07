using MediatR;

namespace CqrsProject.Api.Commands
{
    public class DeleteDriverCommand : IRequest<bool>
    {
        public Guid DriverId;
        public DeleteDriverCommand(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}
