using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDetailsRepo customerDetailsRepo;
        public CustomerController()
        {
            customerDetailsRepo = new CustomerDetailsRepo();
        }


        //INSERT
        [HttpPost]
        public void Post([FromBody] CustomerDetails customer)
        {
            if (ModelState.IsValid)
            {
                customerDetailsRepo.Add(customer);
            }
        }


        //UPDATE
        [HttpPut]
        public void Put(int id, [FromBody] CustomerDetails customer)
        {
            customer.Id = id;
            if (ModelState.IsValid)
            {
                customerDetailsRepo.Add(customer);
            }

        }

        //Get All
        [HttpGet]
        [Route("Get")]
        public IEnumerable<CustomerDetails>GetAll()
        {
            return customerDetailsRepo.GetAll();
        }

        //Get By ID
        [HttpGet]
        [Route("Get/{id}")]
        public CustomerDetails GetById(int id)
        {
            return customerDetailsRepo.GetByID(id);
        }

        //DELETE
        [HttpDelete]
        public void Delete(int id)
        {
            customerDetailsRepo.Delete(id);
        }

    }
}