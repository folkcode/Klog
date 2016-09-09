using AutoMapper;
using Klog.Models;
using Klog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Klog.Controllers.Api
{
    [Route("api/posts")]
    public class BlogController : Controller
    {
        private ILogger<BlogController> _logger;
        private IBlogRepository _repository;

        public BlogController(IBlogRepository repository, ILogger<BlogController> logger) {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("{postCount?}")]
        public JsonResult Get(string postCount) {
            int pCount = 0;

            if (postCount!="" && postCount != null) {
                try {
                    pCount = int.Parse(postCount);
                }catch(Exception E) {
                    _logger.LogError("Error converting post count in API GET" + E.ToString());
                    Response.StatusCode = (int)HttpStatusCode.NoContent;
                    return Json("{}");           
                }
            }
           
            var trips = _repository.getPosts(pCount);
            var results = Mapper.Map<IEnumerable<BlogViewModel>>(trips);

            return Json(results);
        }
    }
}
