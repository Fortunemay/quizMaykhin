using System;
using System.Collections.Generic;

namespace quizAPI.Model.Database;

public partial class TbMember
{
    public int MemberId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Address { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
