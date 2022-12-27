using System;
namespace BloodeAPI.ViewModels.Request
{
    public class RequestDTO
    {
        public String? State { get; set; }
        public String? City { get; set; }
        public string? Location { get; set; }
        public int UserId { get; set; }
        public int BloodGroup { get; set; }
        public int RequestId { get; set; }
    }

}

