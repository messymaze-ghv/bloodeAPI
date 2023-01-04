using System;
namespace BloodeAPI.ViewModels.Request.RequestDTO
{
    public class RequestDTO
    {
        public String? State { get; set; }
        public String? District { get; set; }
        public String? City { get; set; }
        public String? Location { get; set; }
        public int UserId { get; set; }
        public String? BloodGroup { get; set; }
        public int RequestId { get; set; }
    }

}

