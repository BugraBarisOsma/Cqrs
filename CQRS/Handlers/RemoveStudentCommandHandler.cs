using Cqrs.CQRS.Commands;
using Cqrs.Data;

namespace Cqrs.CQRS.Handlers
{
    public class RemoveStudentCommandHandler
    {
        private readonly StudentContext _studentContext;

        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(RemoveStudentCommand command)
        {
            var deletedEntity = _studentContext.Students.Find(command.Id);
            _studentContext.Students.Remove(deletedEntity);
            _studentContext.SaveChanges();
        }

        public static implicit operator RemoveStudentCommandHandler(RemoveStudentCommand v)
        {
            throw new NotImplementedException();
        }
    }
}
