using System.ComponentModel.DataAnnotations;

namespace MyLibrary.BLL.Models.Request.CreateRequest
{
    public class AuthorCreateRequestModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

    }
}
