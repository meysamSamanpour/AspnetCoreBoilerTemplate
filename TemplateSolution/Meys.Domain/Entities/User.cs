namespace Meys.Domain.Entities
{
    public class User : BaseIdEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
