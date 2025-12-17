namespace EFCoreOperation.Data.Model
{
    public class CurrencyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<BookPrice>  BookPrices { get; set; }
    }
}
