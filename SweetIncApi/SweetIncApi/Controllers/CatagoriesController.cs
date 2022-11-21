using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Category;
using SweetIncApi.Repository;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _catagoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository catagoryRepository, IMapper mapper)
        {
            _catagoryRepository = catagoryRepository;
            _mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_catagoryRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            var catagory = _catagoryRepository.GetByPrimaryKey(id);

            if (catagory == null)
            {
                return NotFound();
            }

            return Ok(catagory);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCategoryVM updateCategory)
        {
            if (id != updateCategory.Id)
            {
                return BadRequest();
            }

            try
            {
                var catagory = _mapper.Map<Category>(updateCategory);
                var result = _catagoryRepository.Update(catagory);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Add(CategoryVM catagoryVM)
        {
            var catagory = _mapper.Map<Category>(catagoryVM);
                _catagoryRepository.Add(catagory);
            return Ok(catagory);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _catagoryRepository.DeleteByPrimaryKey(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
