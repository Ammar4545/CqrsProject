using CqrsProject.Entities.DTO.Responses;
using MediatR;

namespace CqrsProject.Api.Queries
{
    public class GetDriverQuery:IRequest<GetDriverResponse>
    {
        public Guid DriverId { get; }
        public GetDriverQuery(Guid driverId)
        {
            this.DriverId = driverId;
        }
    }
}
