namespace TipSoGo.Models
{
    public class Comment
    {
        public int CommentsIdx { get; set; }
        public int UserIdx { get; set; }
        public int BulletinIdx { get; set; }
        public string Contents { get; set; }
        public string CreatedDate { get; set; }
    }
}