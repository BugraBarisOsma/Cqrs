using Cqrs.CQRS.Commands;
using Cqrs.Data;

namespace Cqrs.CQRS.Handlers
{
    public class UpdateStudentCommandHandler
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(UpdateStudentCommand command) {
         var updatedStudent = _studentContext.Students.Find(command.Id);
            updatedStudent.Age= command.Age; 
            updatedStudent.Name= command.Name;  
            updatedStudent.Surname= command.Surname;
            _studentContext.SaveChanges();
        
        }

    }
}
