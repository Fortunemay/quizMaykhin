using System;
using System.Collections.Generic;

namespace quizAPI.Model.Database;

public partial class TbFile
{
    public int FileId { get; set; }

    public string? FileName { get; set; }

    public long? FileSize { get; set; }

    public string? ContentType { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
