using System.ComponentModel.DataAnnotations;

namespace AuthApi.Models
{
    public class Auth
    {
        [Key]
        public int id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
