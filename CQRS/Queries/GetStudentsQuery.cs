using Cqrs.CQRS.Results;
using MediatR;

namespace Cqrs.CQRS.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>> 
    {

    }
}
