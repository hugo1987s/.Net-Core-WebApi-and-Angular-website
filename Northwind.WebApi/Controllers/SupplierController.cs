using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.UnitOfWork;

namespace Northwind.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Supplier")]
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly IUnitOfWork _unitOrWork;
        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOrWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOrWork.Supplier.GetById(id));
        }

        [HttpGet]
        [Route("GetPaginateSupplier/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedSupplier(int page, int rows)
        {
            return Ok(_unitOrWork.Supplier.SupplierPagedList(page, rows));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Supplier supplier)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_unitOrWork.Supplier.Insert(supplier));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Supplier supplier)
        {
            if(ModelState.IsValid && _unitOrWork.Supplier.Update(supplier))
            {
                return Ok(new { Message = "The supplier was updated" });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Supplier supplier)
        {
            if (supplier.Id > 0)
                return Ok(_unitOrWork.Supplier.Delete(supplier));
            return BadRequest();
        }




    }
}