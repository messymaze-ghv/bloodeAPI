using System;
using System.Collections.Generic;

namespace BloodeAPI.Models;

public partial class DeviceInfo
{
    public int Id { get; set; }

    /// <summary>
    /// This device is for which user
    /// </summary>
    public int UserId { get; set; }

    public string DeviceId { get; set; } = null!;

    public int Ostype { get; set; }

    public bool IsActive { get; set; }

    public virtual User User { get; set; } = null!;
}
