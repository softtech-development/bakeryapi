using api.Data;
using api.Dtos;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            IList<Customer> customers = await context.Customers.ToListAsync();
            return Ok(new{Success=true, Data=customers});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            Customer? customer = await context.Customers.FindAsync(id);
            if(customer is null) return NotFound();
            
            return Ok(new{Success=true, Data=customer});
        }

        [HttpPost]
        public async Task<IActionResult>AddCustomer(CustomerPostDto model)
        {
            Customer customer = new()
            {
                Name = model.Name,
                StoreNumber = model.StoreNumber,
                AddressLine = model.AddressLine,
                PostalCode = model.PostalCode,
            };

            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return StatusCode(201);
        }
    }
}
