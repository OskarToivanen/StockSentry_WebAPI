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

        [HttpPost]
        [HttpPost]
        public ActionResult<InventoryItem> Post(InventoryItem inventoryItem)
        {
            inventoryItem.Category = null;
            inventoryItem.InventoryLogs = null;

            _context.InventoryItems.Add(inventoryItem);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = inventoryItem.Id }, inventoryItem);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return BadRequest("ID mismatch");
            }

            var itemToUpdate = _context.InventoryItems.FirstOrDefault(item => item.Id == id);
            if (itemToUpdate == null)
            {
                return NotFound($"Inventory item with ID {id} not found.");
            }

            // Update properties
            itemToUpdate.Name = inventoryItem.Name;
            itemToUpdate.Description = inventoryItem.Description;
            itemToUpdate.Quantity = inventoryItem.Quantity;
            itemToUpdate.Price = inventoryItem.Price;
            itemToUpdate.CategoryId = inventoryItem.CategoryId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemToDelete = _context.InventoryItems.FirstOrDefault(item => item.Id == id);
            if (itemToDelete == null)
            {
                return NotFound($"Inventory item with ID {id} not found.");
            }

            _context.InventoryItems.Remove(itemToDelete);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
