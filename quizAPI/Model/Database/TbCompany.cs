using System;
using System.Collections.Generic;

namespace quizAPI.Model.Database;

public partial class TbCompany
{
    public int CompId { get; set; }

    public string? CompCode { get; set; }

    public string? CompName { get; set; }

    public string? CompAddress { get; set; }

    public string? Description { get; set; }

    public string? Remark { get; set; }

    public int? RegionId { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TbUser> TbUsers { get; set; } = new List<TbUser>();
}
