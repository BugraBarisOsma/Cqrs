using Cqrs.CQRS.Commands;
using Cqrs.Data;
using MediatR;

namespace Cqrs.CQRS.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        //public void Handle(UpdateStudentCommand command) {
        // var updatedStudent = _studentContext.Students.Find(command.Id);
        //    updatedStudent.Age= command.Age; 
        //    updatedStudent.Name= command.Name;  
        //    updatedStudent.Surname= command.Surname;
        //    _studentContext.SaveChanges();
        
        //}

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updatedStudent = _studentContext.Students.Find(request.Id);
            updatedStudent.Age = request.Age;
            updatedStudent.Name = request.Name;
            updatedStudent.Surname = request.Surname;
            await _studentContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
