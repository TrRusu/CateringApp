using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public enum Status
    {
        Available,
        Unavailable,
        Busy,
        Waiting
    }

    public class Session
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public bool Paid { get; set; }
        public Status Status { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
