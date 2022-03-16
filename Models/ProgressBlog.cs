namespace MiniPaintingWebsite.Models
{
    public class ProgressBlog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public DateTime DateOfEntry { get; set; }
        public string TextBody { get; set; }
        public byte[] ImageData { get; set; }
    }
}
