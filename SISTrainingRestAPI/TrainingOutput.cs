using System;
using System.Collections.Generic;

namespace SISTrainingRestAPI.Models;

public partial class TrainingOutput
{
    public long StaffId { get; set; }

    public string? StaffName { get; set; }

    public string? Course { get; set; }

    public string Email { get; set; }

    public long StudentId { get; set; }

    public string StudentName { get; set; }
}
