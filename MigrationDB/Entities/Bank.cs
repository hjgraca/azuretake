namespace MigrationDB.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string SortCode { get; set; }
        public string AccountName { get; set; }
        public decimal? ConnectionFee { get; set; }
        public string InvoiceEmail { get; set; }
        public string Iban { get; set; }
        public string LegalName { get; set; }
    }
}