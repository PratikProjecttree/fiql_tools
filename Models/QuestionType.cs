using System;
using System.Collections.Generic;

namespace fiql_tools.Models;

public partial class QuestionType
{
    public int QuestionTypeId { get; set; }

    public string QuestionTypeName { get; set; } = null!;

    public string QuestionTypeCode { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
