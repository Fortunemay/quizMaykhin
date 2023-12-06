using System;
using System.Collections.Generic;

namespace quizAPI.Model.Database;

public partial class TbUserRole
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TbAccessControl> TbAccessControls { get; set; } = new List<TbAccessControl>();
}
