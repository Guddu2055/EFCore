namespace EFCoreOperation.Data.Model
{
    public class BookPrice
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
    }
}
