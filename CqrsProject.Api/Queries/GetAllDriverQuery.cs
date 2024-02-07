using CqrsProject.Entities.DTO.Responses;
using MediatR;

namespace CqrsProject.Api.Query
{
    public class GetAllDriverQuery : IRequest<IEnumerable<GetDriverResponse>>
    {
    }
}
