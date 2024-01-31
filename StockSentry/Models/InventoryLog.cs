namespace StockSentry.Models
{
    public class InventoryLog
    {
        public int Id { get; set; }
        public int InventoryItemId { get; set; }
        public InventoryItem? InventoryItem { get; set; }
        public int QuantityChange { get; set; }
        public DateTime ChangeDate { get; set; }
        public string? Reason { get; set; }
    }
}
