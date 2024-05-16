using Cqrs.CQRS.Queries;
using Cqrs.CQRS.Results;
using Cqrs.Data;
using MediatR;

namespace Cqrs.CQRS.Handlers
{
    // MediatR'i implemente ettikten sonra interfacedeki methodlari override ediyoruz ve yazdigimiz methoda artik gerek kalmiyor
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentsByIdQueryResult>
    {
        private readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        // asenkron gerceklesecegi icin async koymayi unutma
        public async Task<GetStudentsByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Set<Student>().FindAsync(request.Id);

            return new GetStudentsByIdQueryResult
            {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname,
            };
           
        }
        //public GetStudentsQueryResult Handle(GetStudentByIdQuery query)
        //{
        //    var student = _context.Set<Student>().Find(query.Id);

        //    return new GetStudentsQueryResult
        //    {
        //        Age = student.Age,
        //        Name = student.Name,
        //        Surname = student.Surname,
        //    };
        //}
    }
}
