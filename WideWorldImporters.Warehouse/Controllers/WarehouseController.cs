using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WideWorldImporters.Warehouse.Repository;

namespace WideWorldImporters.Warehouse.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository _appRepo;

        public WarehouseController(IWarehouseRepository appRepo)
        {
            _appRepo = appRepo;
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetAllStockItems() {
            try { 
                var stockItems = await _appRepo.GetAllStockItems();

                if (stockItems == null)
                    return NotFound();

                return Ok(stockItems);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("item/transactions/{id}")]
        public async Task<IActionResult> GetItemTransaction(int id)
        {
            try {
                var transaction = await _appRepo.GetStockItemTransactions(id);

                if (transaction == null)
                    return NotFound();

                return Ok(transaction);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
