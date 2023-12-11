using System;
using System.Collections.Generic;

namespace SISTrainingRestAPI.Models;

public partial class TrainingStaff
{
    public long StaffId { get; set; }

    public string? StaffName { get; set; }

    public string? Course { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<TrainingStudent> TrainingStudents { get; set; } = new List<TrainingStudent>();
}
