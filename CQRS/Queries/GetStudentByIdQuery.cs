using Cqrs.CQRS.Results;
using MediatR;

namespace Cqrs.CQRS.Queries
{
    // Atilacak istekte bulunacak property
    // MediatR'da donecek result'u IRequest icerisinde belirttik (eger varsa)
    public class GetStudentByIdQuery : IRequest<GetStudentsByIdQueryResult>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
