using System;
using System.Collections.Generic;

namespace quizAPI.Model.Database;

public partial class TbAccessControl
{
    public int ControlId { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TbUserRole? Role { get; set; }

    public virtual TbUser? User { get; set; }
}
