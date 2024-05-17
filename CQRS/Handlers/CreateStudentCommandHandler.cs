using Cqrs.CQRS.Commands;
using Cqrs.Data;
using MediatR;

namespace Cqrs.CQRS.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public CreateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _studentContext.Students.Add(new Student { Age = request.Age, Name = request.Name, Surname = request.Surname });
            await _studentContext.SaveChangesAsync();
            return Unit.Value;
        }

        //public void Handle(CreateStudentCommand command)
        //{
        //    _studentContext.Students.Add(new Student { Age = command.Age, Name=command.Name, Surname=command.Surname});
        //    _studentContext.SaveChanges();  
        //}
    }
}
