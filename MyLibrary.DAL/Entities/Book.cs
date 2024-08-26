namespace MyLibrary.DAL.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author AuthorId { get; set; }
        public List<Category> Categories { get; set;}
    }
}
