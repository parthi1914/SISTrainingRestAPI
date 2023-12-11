using System;
using System.Collections.Generic;

namespace SISTrainingRestAPI.Models;

public partial class TrainingStudent
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long? StaffId { get; set; }

    public virtual TrainingStaff? Staff { get; set; }
}
