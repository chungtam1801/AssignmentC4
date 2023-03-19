namespace Assignment.Models
{
    public class Bill
    {
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserID { get; set; }
        public int Status { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<BillDetail> BillDetails { get; set; }
}
}
