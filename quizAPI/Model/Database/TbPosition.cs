using System;
using System.Collections.Generic;

namespace quizAPI.Model.Database;

public partial class TbPosition
{
    public int PositionId { get; set; }

    public string PositionName { get; set; } = null!;

    public bool IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TbUser> TbUsers { get; set; } = new List<TbUser>();
}
