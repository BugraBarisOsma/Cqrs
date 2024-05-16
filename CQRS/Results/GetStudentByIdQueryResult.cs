namespace Cqrs.CQRS.Results
{
    // Almak istedigimiz cevapta bulunacak propertyler (Result)
    public class GetStudentsByIdQueryResult
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

    }
}
