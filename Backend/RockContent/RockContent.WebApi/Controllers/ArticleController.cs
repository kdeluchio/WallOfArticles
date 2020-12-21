using Microsoft.AspNetCore.Mvc;
using RockContent.Application.Interfaces;
using RockContent.Application.ViewModel;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RockContent.WebApi.Controllers
{
    [Route("Api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly IArticleAppService _articleAppService;

        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _articleAppService.GetAll();
                return Ok(result);
            }
            catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById/{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _articleAppService.GetById(id);
                if (result == null || result?.Id == Guid.Empty )
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] NewArticleViewModel articleViewModel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _articleAppService.Create(articleViewModel);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remove/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _articleAppService.Remove(id);
                return Ok();

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Liked/{id:Guid}")]
        public async Task<IActionResult> Liked(Guid id)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _articleAppService.Liked(id);
                var result = await _articleAppService.GetById(id);
                return Ok(result?.Likes.ToString());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
