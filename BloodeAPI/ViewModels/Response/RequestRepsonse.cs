using System;
namespace BloodeAPI.ViewModels.Response
{
	public class RequestResponse
	{
		public string? RecipientName { get; set; }
		public int RequestId { get; set; }
        public int BloodGroup { get; set; }
		public string? Location { get; set; }
		public int CreatedUserId { get; set; }
		public bool isUserResponded { get; set; } = false;
		public bool isCreatedByLoggedInUser { get; set; } = false;
        public IDictionary<string, string?> respondersList = new Dictionary<string, string?>();
    }
}