using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallenge.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User? User { get; set; }
        public int EventID { get; set; }
        [ForeignKey("EventID")]
        public Event? Event { get; set; }

        public Registration()
        {
        }

        public Registration(int registrationID, int userID, int eventID)
        {
            RegistrationID = registrationID;
            UserID = userID;
            EventID = eventID;
        }
    }
}
