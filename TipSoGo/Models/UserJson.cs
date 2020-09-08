namespace TipSoGo.Models
{
    public class UserJson : Models.User, IJson
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}