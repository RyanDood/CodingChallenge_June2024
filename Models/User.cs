using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool isAdmin { get; set; }

        public User()
        {
        }

        public User(int userID, string userName, string password, string name, bool isAdmin)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            Name = name;
            this.isAdmin = isAdmin;
        }
    }
}
