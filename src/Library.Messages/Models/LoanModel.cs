namespace Library.Messages.Models
{
    public class LoanModel
    {
        public Guid Key { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public LoanModel() { }
    }
}
