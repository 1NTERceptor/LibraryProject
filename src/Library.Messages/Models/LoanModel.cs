namespace Library.Messages.Models
{
    public class LoanModel
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public LoanModel() { }

        public LoanModel(Guid bookId, Guid userId, DateTime dateFrom, DateTime dateTo)
        {
            BookId = bookId;
            UserId = userId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}
