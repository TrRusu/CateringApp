using CateringApp;


namespace DTO
{
    public enum CookStatus
    {
        Preparing,
        Cooking,
        Ready
    }

    public class ItemOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public CookStatus Status { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
    }
}
