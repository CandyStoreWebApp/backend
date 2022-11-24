using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models;
using SweetIncApi.Models.DTO.Box;
using SweetIncApi.Models.DTO.Product;
using SweetIncApi.Repository;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxesController : ControllerBase
    {
        private readonly IBoxRepository _boxRepository;
        private readonly IMapper _mapper;

        public BoxesController(IBoxRepository boxRepository, IMapper mapper)
        {
            _boxRepository = boxRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_boxRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("with_query")]
        public IActionResult GetAll(BoxPagingVM queries)
        {
            try
            {
                return Ok(_boxRepository.GetAll(queries));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            var box = _boxRepository.GetByPrimaryKey(id);

            if (box == null)
            {
                return NotFound();
            }

            return Ok(box);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BoxUpdateVM boxVM)
        {
            var box = _mapper.Map<Box>(boxVM);

            if (id != box.Id)
            {
                return BadRequest();
            }
            try
            {
                var result = _boxRepository.Update(box);
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

        [HttpPost]
        public IActionResult Add(BoxVM boxVM)
        {
            var box = _mapper.Map<Box>(boxVM);
            _boxRepository.Add(box);
            return Ok(box);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _boxRepository.DeleteByPrimaryKey(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
