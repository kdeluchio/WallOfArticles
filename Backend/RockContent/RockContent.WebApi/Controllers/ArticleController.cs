using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RockContent.Application.Interfaces;
using RockContent.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockContent.WebApi.Controllers
{
    [Route("Api/Article")]
    //[EnableCors("AllowOrigin")]
    public class ArticleController : Controller
    {
        private readonly IArticleAppService _articleAppService;

        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var result = _articleAppService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _articleAppService.GetById(id);
            if (result== null || result.Id == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] NewArticleViewModel articleViewModel)
        {
            try
            {
                var id = _articleAppService.Create(articleViewModel);
                return Json(new { success = true, message = "Succefull", result = id.ToString() });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message, result = "0" });
            }
        }


        [HttpDelete]
        [Route("Remove/{id:int}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _articleAppService.Remove(id);
                return Json(new { success = true, message = "Succefull"});
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message});
            }
        }


        [HttpPut]
        [Route("Liked/{id:int}")]
        public IActionResult Liked(int id)
        {
            try
            {
                 _articleAppService.Liked(id);

                var result = _articleAppService.GetById(id);

                return Json(new { success = true, message = "Succefull", result = result?.Likes.ToString() });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message, result = "0" });
            }
        }

    }
}
