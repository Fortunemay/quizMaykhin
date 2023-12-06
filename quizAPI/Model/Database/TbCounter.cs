using System;
using System.Collections.Generic;

namespace quizAPI.Model.Database;

public partial class TbCounter
{
    public int CounterId { get; set; }

    public int? CountNumber { get; set; }
}
