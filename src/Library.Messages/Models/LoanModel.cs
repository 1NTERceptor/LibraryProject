namespace Library.Messages.Models
{
    public class LoanModel
    {
        public Guid Key { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime DueDate { get; set; }

        public LoanModel() { }
    }
}
