using System;
using System.Collections.Generic;

namespace fiql_tools.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string QuestionText { get; set; } = null!;

    public int? QuestionTypeId { get; set; }

    public virtual QuestionType? QuestionType { get; set; }
}
