using fiql_tools.Data;
using fiql_tools.Models;
using fiql_tools.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace fiql_tools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionODataController : ODataController
    {
        private readonly GssContext gssContext;

        public QuestionODataController(GssContext gssContext)
        {
            this.gssContext = gssContext;
        }
        [HttpGet]
        [EnableQuery()]
        public ActionResult<IEnumerable<QuestionResponse>> Get()
        {
            return Ok(gssContext.Questions.Include(questionType => questionType.QuestionType).Select(x => new QuestionResponse
            {
                QuestionId = x.QuestionId,
                QuestionText = x.QuestionText,
                QuestionTypeId = x.QuestionTypeId,
                QuestionType = new QuestionType
                {
                    QuestionTypeId = x.QuestionType.QuestionTypeId,
                    QuestionTypeCode = x.QuestionType.QuestionTypeCode,
                    QuestionTypeName = x.QuestionType.QuestionTypeName
                }
            }).AsQueryable());
        }
        [HttpGet("GetTest")]
        [EnableQuery()]
        public ActionResult<IEnumerable<QuestionResponse>> GetTest()
        {
            return Ok(gssContext.Questions.Select(x => new QuestionResponse
            {
                QuestionId = x.QuestionId,
                QuestionText = x.QuestionText,
                QuestionTypeId = x.QuestionTypeId,
                //QuestionType = new QuestionType
                //{
                //    QuestionTypeId = x.QuestionType.QuestionTypeId,
                //    QuestionTypeCode = x.QuestionType.QuestionTypeCode,
                //    QuestionTypeName = x.QuestionType.QuestionTypeName
                //}
            }).AsQueryable());
        }
    }
}
