﻿using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WideWorldImporters.Purchasing.Repository;

namespace WideWorldImporters.Purchasing.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingController : ControllerBase
    {
        private readonly IPurchasingRepository _appRepo;

        public PurchasingController(IPurchasingRepository appRepo)
        {
            _appRepo = appRepo;
        }

        [HttpGet("suppliers")]
        public async Task<IActionResult> GetAllSupplier()
        {
            try
            {
                var supplier = await _appRepo.GetAllSupplier();

                if (supplier == null)
                    return NotFound();

                return Ok(supplier);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("supplier/transactions/{id}")]
        public async Task<IActionResult> GetSupplierTransaction(int id)
        {
            try
            {
                var transaction = await _appRepo.GetSupplierTransactions(id);

                if (transaction == null)
                    return NotFound();

                return Ok(transaction);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("orders/{id}")]
        public async Task<IActionResult> GetPuschaseOrders(int id)
        {
            try
            {
                var orders = await _appRepo.GetPurchasingOrders(id);

                if (orders == null)
                    return NotFound();

                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("supplier")]
        public async Task<IActionResult> NewSupplier(Supplier supplier) {
            if (supplier == null)
                return BadRequest();

            await _appRepo.NewSupplier(supplier);

            return Created("", supplier);
        }

        [HttpPost("purchase/order")]
        public async Task<IActionResult> NewPurchaseOrder(PurchaseOrder order) {
            if (order == null)
                return BadRequest();

            await _appRepo.NewPurchaseOrder(order);

            return Created("", order);
        }
    }
}
