using System;
using System.Collections.Generic;

namespace BloodeAPI.Models;

public partial class RequestHistory
{
    public int Id { get; set; }

    public int? RequestId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Request? Request { get; set; }
}
