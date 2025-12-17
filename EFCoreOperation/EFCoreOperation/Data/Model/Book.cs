namespace EFCoreOperation.Data.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public string Description { get; set; }
        public int NoOfPage { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LanguageId { get; set; }

        public virtual Language Languages { get; set; }

        //public ICollection<BookPrice> BookPrices { get; set; }
    }
}
