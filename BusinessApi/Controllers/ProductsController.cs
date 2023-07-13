using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessApi.Dtos;
using BusinessApi.Interfaces;
using BusinessApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IInventory _inventory;
        private readonly IMapper _mapper;

        public ProductsController(IInventory inventory,IMapper mapper)
        {
            _inventory = inventory;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetProducts() 
        {
            try
            {
                var result = await _inventory.GetProducts();
                return Ok(_mapper.Map<IEnumerable<ProductReadDTO>>(result));
            }
            catch (System.Exception)
            {
                throw;
            }
           
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<ProductReadDTO>> GetProductsById([FromRoute] string id)
        {
            try
            {
                var result = await _inventory.GetProductById(id);
                return Ok(_mapper.Map<ProductReadDTO>(result));
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }

        [HttpPost("new-product")]
        public async Task<ActionResult<ProductReadDTO>> AddProducts([FromBody] ProductCreateDTO product)
        {             
            try
            {
                if(product is null) return BadRequest();

                var productModel = _mapper.Map<Product>(product);

                await _inventory.AddProduct(productModel);
                return Ok(productModel);  // : BadRequest( new { message = "nothing was saved" })
            }
            catch (System.Exception)
            {
                
                throw;
            }                       
        }

        [HttpPut("update-product/{id}")]
        public ActionResult UpdateProducts([FromRoute] string id,[FromBody] Product product)
        {            
            if(id != product.Id) return BadRequest();  
            try
            {
                var response = _inventory.UpdateProduct(product);                
                return Ok(response);
            }
            catch (Exception)
            {                
                throw;
            }                                  
        }

        [HttpDelete("delete-product/{id}")]
        public ActionResult DeleteProduct([FromRoute] string id)
        {
            return Ok(_inventory.DeleteProduct(id)) ?? Ok("None");            
        }
    }
}