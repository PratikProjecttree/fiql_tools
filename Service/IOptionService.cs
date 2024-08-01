using fiql_tools.Data;
using fiql_tools.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using fiql_tools.Response;
using Newtonsoft.Json;

namespace fiql_tools.Service
{
    public interface IOptionService
    {
        List<QuestionResponse>? GetOption(string fiqlQuery);
    }
    public class OptionService : IOptionService
    {
        private readonly GssContext _context;
        public OptionService(GssContext context)
        {
            _context = context;
        }
        public List<QuestionResponse>? GetOption(string fiqlQuery)
        {
            //fiqlQuery = "QuestionId==1,QuestionId==2;QuestionId==3,QuestionId==4,QuestionId==5";
            IQueryable<Question> query = _context.Questions.Include(i => i.QuestionType);

            if (!string.IsNullOrEmpty(fiqlQuery))
            {
                string dynamicLinqQuery = ConvertFiqlToLinq.FiqlToLinq(fiqlQuery);
                query = query.Where(dynamicLinqQuery);
            }

            List<QuestionResponse> products = query.Select(x => new QuestionResponse
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
            }).ToList();

            return products;
        }
    }
}

/*
A= QuestionId==1
B = QuestionId==2
C = QuestionId==3
D = QuestionId==4
E = QuestionId==5
 */

/*
A AND B OR C
A;B,C
QuestionId=in=(1,2,3);QuestionId==2,QuestionId==3
(QuestionId in new [] { 1, 2, 3 } AND (QuestionId == 2 OR QuestionId == 3))

(A;B),C
(A AND B) OR C
(QuestionId=in=(1,2,3);QuestionId==2),QuestionId==3
((QuestionId in new [] { 1, 2, 3 } AND QuestionId == 2) OR QuestionId == 3)

A,B;C
A OR B AND C
QuestionId=in=(1,2,3),QuestionId==2;QuestionId==3
((QuestionId in new [] { 1, 2, 3 } OR QuestionId == 2) AND QuestionId == 3)

A, B;C
A OR (B AND C)
QuestionId==1,(QuestionId==2;QuestionId==3)
(QuestionId == 1 OR (QuestionId == 2 AND QuestionId == 3))

A OR B AND C OR D
A, B;C,D
A OR (B AND C) OR D
QuestionId==1,(QuestionId==2;QuestionId==3),QuestionId==4
(QuestionId == 1 OR (QuestionId == 2 AND QuestionId == 3) OR QuestionId == 4)

A OR B AND C OR D AND E
A OR (B AND C) OR (D AND E)
QuestionId==1,(QuestionId==2;QuestionId==3),(QuestionId==4;QuestionId==5)
(QuestionId == 1 OR (QuestionId == 2 AND QuestionId == 3) OR (QuestionId == 4 AND QuestionId == 5))
*/