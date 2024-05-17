using Cqrs.CQRS.Commands;
using Cqrs.Data;
using MediatR;

namespace Cqrs.CQRS.Handlers
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = _studentContext.Students.Find(request.Id);
            _studentContext.Students.Remove(deletedEntity);
            await _studentContext.SaveChangesAsync();
            return Unit.Value;
        }

        //public void Handle(RemoveStudentCommand command)
        //{
        //    var deletedEntity = _studentContext.Students.Find(command.Id);
        //    _studentContext.Students.Remove(deletedEntity);
        //    _studentContext.SaveChanges();
        //}


    }
}
