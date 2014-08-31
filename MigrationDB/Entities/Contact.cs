namespace MigrationDB.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Owner { get; set; }
        public string ContactName { get; set; }
    }
}