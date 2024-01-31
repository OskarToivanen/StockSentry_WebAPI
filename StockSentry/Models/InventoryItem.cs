﻿namespace StockSentry.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<InventoryLog>? InventoryLogs { get; set; }
    }
}
