using System;
using System.Collections.Generic;

namespace BloodeAPI.Models;

public partial class Request
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public string Location { get; set; } = null!;

    public int City { get; set; }

    public int State { get; set; }

    public int BloodGroup { get; set; }

    public virtual ICollection<RequestDonar> RequestDonars { get; } = new List<RequestDonar>();

    public virtual ICollection<RequestHistory> RequestHistories { get; } = new List<RequestHistory>();

    public virtual User User { get; set; } = null!;
}
