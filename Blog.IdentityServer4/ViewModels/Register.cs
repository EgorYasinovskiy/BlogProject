using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;

namespace Blog.IdentityServer4.ViewModels
{
	public class Register
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = $"{nameof(Email)} can't be empty!")]
		[EmailAddress(ErrorMessage = "That's not correct e-mail address!")]
		public string Email { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = $"{nameof(Password)} can't be empty!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = $"{nameof(Password)} can't be empty!")]
		[DataType(DataType.Password)]
		[Compare(otherProperty: "Password", ErrorMessage = "Passwords does not match!")]
		public string ConfirmPassword { get; set; }
		[Required(AllowEmptyStrings = false,ErrorMessage ="Please, write your first name here!")]
		public string FirstName { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Please, write your last name here!")]
		public string LastName { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Please, write your nickname here!")]
		public string UserName { get; set; }

	}
}
