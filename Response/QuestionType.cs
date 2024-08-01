using System;
using System.Collections.Generic;

namespace fiql_tools.Response;

public class QuestionTypeResponse
{
    public int QuestionTypeId { get; set; }

    public string QuestionTypeName { get; set; } = null!;

    public string QuestionTypeCode { get; set; } = null!;
}
