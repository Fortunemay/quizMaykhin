using System;
using System.Collections.Generic;

namespace quizAPI.Model.Database;

public partial class TbUser
{
    public int UserId { get; set; }

    public string? UserCode { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Description { get; set; }

    public string? Remark { get; set; }

    public string? Signature { get; set; }

    public int? PositionId { get; set; }

    public int? CompId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsLogin { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TbCompany? Comp { get; set; }

    public virtual TbPosition? Position { get; set; }

    public virtual ICollection<TbAccessControl> TbAccessControls { get; set; } = new List<TbAccessControl>();
}
