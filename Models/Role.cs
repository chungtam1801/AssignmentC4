namespace Assignment.Models
{
    public class Role
    {
        public Guid ID { get; set; }
        public string RolenName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}
