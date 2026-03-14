namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? ThirdName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {SecondName} {ThirdName} {LastName}";
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string Address { get; set; } = null!;
        DateTime CreateAt {  get; set; }
        public ICollection<AccountStatement>AccountStatements { get; set; } = new List<AccountStatement>();
    }
}
