using Microsoft.Identity.Client;

namespace MyLibrary.BLL.Models.Request.CreateRequest
{
    public class BookCreateRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorSurname { get; set; }
        public int AuthorId { get; set; }
        public IList<string> CategoryNames { get; set; }
        public IList<int> CategoryIds { get; set; }

    }
}
