using System;
using System.Collections.Generic;

namespace BloodeAPI.Models;

public partial class RequestDonar
{
    public int Id { get; set; }

    public int RequestId { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
