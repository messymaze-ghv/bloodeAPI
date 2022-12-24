using System;
using System.Collections.Generic;

namespace BloodeAPI.Models;

/// <summary>
/// All of the basic user info stores here
/// </summary>
public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Gender { get; set; }

    public DateTime Dob { get; set; }

    public string? Address { get; set; }

    public int State { get; set; }

    public int City { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<DeviceInfo> DeviceInfos { get; } = new List<DeviceInfo>();

    public virtual ICollection<RequestDonar> RequestDonars { get; } = new List<RequestDonar>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
