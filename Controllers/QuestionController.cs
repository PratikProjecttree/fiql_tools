using fiql_tools.Data;
using fiql_tools.Models;
using fiql_tools.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace fiql_tools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : Controller
    {
        private readonly IOptionService optionService;

        public QuestionController(IOptionService optionService)
        {
            this.optionService = optionService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? fiqlQuery)
        {
            var data = optionService.GetOption(fiqlQuery);
            return Ok(data);
        }
    }
}
