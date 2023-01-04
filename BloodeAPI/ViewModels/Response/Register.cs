using System;
namespace BloodeAPI.ViewModels.Response
{
	public class RegisterResponse
	{
        private string? _firstName;
        private string? _lastName;
        private DateTime _dob;

        public string? FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != null)
                    _firstName = char.ToUpper(value.First()) + value[1..].ToLower(); ;
            }
        }

        public string? LastName
        {
            get { return _lastName; }
            set
            {
                if (value != null)
                    _lastName = char.ToUpper(value.First()) + value[1..].ToLower(); ;
            }
        }
        public String? Gender { get; set; }

        public DateTime Dob
        {
            get { return _dob; }
            set
            {
                _dob = DateTime.Parse(value.ToString(), null, System.Globalization.DateTimeStyles.RoundtripKind);
            }
        }

        public String State { get; set; }

        public String City { get; set; }

        public String District { get; set; }

        public string? PhoneNumber { get; set; }

        public string? BloodGroup { get; set; }

        public int Id { get; set; }
    }
}

