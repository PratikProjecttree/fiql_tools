using fiql_tools.Models;
using System;
using System.Collections.Generic;

namespace fiql_tools.Response;

public partial class QuestionResponse
{
    public int QuestionId { get; set; }

    public string QuestionText { get; set; } = null!;

    public int? QuestionTypeId { get; set; }

    public QuestionType QuestionType { get; set; }
}
