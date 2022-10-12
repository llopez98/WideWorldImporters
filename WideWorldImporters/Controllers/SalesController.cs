using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WideWorldImporters.Repository;

namespace WideWorldImporters.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IApplicationRepository _appRepo;

        public SalesController(IApplicationRepository appRepo)
        {
            _appRepo = appRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var customer = await _appRepo.GetCustomer(id);

                if (customer == null)
                    return NotFound();

                return Ok(customer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await _appRepo.GetAllCustomers();

                if (customers == null)
                    return NotFound();

                return Ok(customers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("transactions/{id}")]
        public async Task<IActionResult> GetCustomerTransaction(int id)
        {
            try
            {
                var customerTransactions = await _appRepo.GetCustomerTransactions(id);

                if (customerTransactions == null)
                    return NotFound();

                return Ok(customerTransactions);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            try
            {
                var orderDetails = await _appRepo.GetOrderDetails(id);

                if (orderDetails == null)
                    return NotFound();

                return Ok(orderDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("orders/{id}")]
        public async Task<IActionResult> GetCustomerOrders(int id)
        {
            try
            {
                var customerOrders = await _appRepo.GetCustomerOrders(id);

                if (customerOrders == null)
                    return NotFound();

                return Ok(customerOrders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("customer")]
        public async Task<IActionResult> NewCustomer([FromBody] Customer customer) {
            if (customer == null)
                return BadRequest();

            await _appRepo.NewCustomer(customer);

            return Created("", customer);
        }
    }
}
