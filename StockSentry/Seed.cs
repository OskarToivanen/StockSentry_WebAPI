using StockSentry.Data;
using StockSentry.Models;

namespace StockSentry
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Electronics", Description = "Electronic items" },
                    new Category { Name = "Clothing", Description = "Apparel and accessories" }
                    // Add more categories as needed
                };

                dataContext.Categories.AddRange(categories);
            }

            if (!dataContext.Suppliers.Any())
            {
                var suppliers = new List<Supplier>
                {
                    new Supplier { Name = "Tech Supplies Inc.", ContactInfo = "Contact details" },
                    new Supplier { Name = "Apparel World", ContactInfo = "Contact details" }
                    // Add more suppliers as needed
                };

                dataContext.Suppliers.AddRange(suppliers);
            }

            if (!dataContext.InventoryItems.Any())
            {
                var inventoryItems = new List<InventoryItem>
                {
                    new InventoryItem { Name = "Laptop", Description = "High performance laptop", Quantity = 10, Price = 1200.00M, CategoryId = 1 },
                    new InventoryItem { Name = "T-shirt", Description = "Cotton T-shirt", Quantity = 50, Price = 20.00M, CategoryId = 2 }
                    // Add more items as needed
                };

                dataContext.InventoryItems.AddRange(inventoryItems);
            }

            dataContext.SaveChanges();
        }
    }
}
