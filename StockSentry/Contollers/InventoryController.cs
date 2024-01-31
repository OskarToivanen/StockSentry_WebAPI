using Microsoft.AspNetCore.Mvc;
using StockSentry.Data;
using StockSentry.Models;

namespace StockSentry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryItemController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<InventoryItemController> _logger;

        public InventoryItemController(DataContext context, ILogger<InventoryItemController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetInventoryItems")]
        public ActionResult<IEnumerable<InventoryItem>> Get()
        {
            var inventoryItems = _context.InventoryItems.ToList();
            if (inventoryItems == null || !inventoryItems.Any())
            {
                return NotFound("No inventory items found.");
            }

            return Ok(inventoryItems);
        }

        // New method to get an inventory item by ID
        [HttpGet("{id}", Name = "GetInventoryItemById")]
        public ActionResult<InventoryItem> GetById(int id)
        {
            var inventoryItem = _context.InventoryItems.FirstOrDefault(item => item.Id == id);
            if (inventoryItem == null)
            {
                _logger.LogInformation($"Inventory item with ID {id} not found.");
                return NotFound($"Inventory item with ID {id} not found.");
            }

            return Ok(inventoryItem);
        }

        // Additional methods (GET by ID, POST, PUT, DELETE) can be added here
    }
}
