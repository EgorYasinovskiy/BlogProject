using System.ComponentModel.DataAnnotations;

namespace Blog.IdentityServer4.ViewModels
{
	public class Login
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = $"{nameof(Email)} can't be empty!")]
		[EmailAddress(ErrorMessage = "That's not correct e-mail address!")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = $"{nameof(Password)} can't be empty!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
