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

    public string? Gender { get; set; }

    public DateTime Dob { get; set; }

    public string State { get; set; } = null!;

    public string District { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? BloodGroup { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<DeviceInfo> DeviceInfos { get; } = new List<DeviceInfo>();

    public virtual ICollection<RequestDonar> RequestDonars { get; } = new List<RequestDonar>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
