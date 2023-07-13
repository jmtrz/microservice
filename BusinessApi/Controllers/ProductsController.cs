using System.Net;
using AutoMapper;
using BusinessApi.Dtos;
using BusinessApi.Exceptions;
using BusinessApi.Interfaces;
using BusinessApi.Models;
using Microsoft.AspNetCore.Mvc;
using NotImplementedException = BusinessApi.Exceptions.NotImplementedException;

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
            catch (System.Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
           
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<ProductReadDTO>> GetProductsById([FromRoute] string id)
        {
            try
            {
                var result = await _inventory.GetProductById(id) ?? throw new NotFoundException("Invalid ID Not Found");
                return Ok(_mapper.Map<ProductReadDTO>(result));
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
            
        }

        [HttpPost("new-entry")]
        public async Task<ActionResult<ProductReadDTO>> AddProducts([FromBody] ProductCreateDTO product)
        {             
            try
            {
                if(product is null) throw new NotImplementedException("Invalid Body Content");

                var productModel = _mapper.Map<Product>(product);

                await _inventory.AddProduct(productModel);
                return Ok(productModel); 
            }
            catch (System.Exception ex)
            {
                throw new BadRequestException(ex.Message);
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
            catch (Exception ex)
            {                
                throw new BadRequestException(ex.Message);
            }                                  
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] string id)
        {
            try
            {
                var result = await _inventory.DeleteProduct(id);
                              
                if (result)
                {
                    return Ok(
                        new
                        {
                            details = $"Data has been Deleted for item:{id}",
                            status = HttpStatusCode.OK
                        });
                }
                else
                {
                    return NotFound(
                        new
                        {
                            details = $"Product with id:{id} not found",
                            status = HttpStatusCode.NotFound
                        });
                }  
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
                     
        }
    }
}