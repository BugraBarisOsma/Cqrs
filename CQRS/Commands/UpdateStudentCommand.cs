namespace Cqrs.CQRS.Commands
{
    public class UpdateStudentCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public UpdateStudentCommand(int id, string name, string surname, int age)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
        }
        public UpdateStudentCommand()
        {
               
        }





    }
}
