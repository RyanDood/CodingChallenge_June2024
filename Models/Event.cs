using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public string Location { get; set; }
        public int MaxAttendees { get; set; }
        public int RegistrationFee { get; set; }

        public Event()
        {
        }

        public Event(int eventID, string title, string description, DateTime? date, string location, int maxAttendees, int registrationFee)
        {
            EventID = eventID;
            Title = title;
            Description = description;
            Date = date;
            Location = location;
            MaxAttendees = maxAttendees;
            RegistrationFee = registrationFee;
        }
    }
}
