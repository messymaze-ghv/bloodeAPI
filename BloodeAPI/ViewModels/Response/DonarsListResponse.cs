using System;
namespace BloodeAPI.ViewModels.Response
{
	public class DonarsListResponse
	{
        public List<Donar> donars = new List<Donar>();
	}
	public class Donar
	{
		String? DonarName { get; set; }
		String? PhoneNumber { get; set; }

		public Donar(String? dname, String? pnum)
		{
			this.DonarName = dname;
			this.PhoneNumber = pnum;
		}
	}
}

