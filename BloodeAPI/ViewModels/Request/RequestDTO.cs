using System;
namespace BloodeAPI.ViewModels.Request
{
    public class RequestDTO
    {
        public int State { get; set; }
        public int City { get; set; }
        public string? Location { get; set; }
        public int UserId { get; set; }
        public int BloodGroup { get; set; }
        public int RequestId { get; set; }
    }

}

