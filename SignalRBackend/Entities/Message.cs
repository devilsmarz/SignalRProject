using System;

namespace SignalRBackend.Entities
{
    public class Message
    {
        public Int32 Id { get; set; }
        public String MessageText { get; set; }
        public DateTime? ActivityDate { get; set; }
        public Int32 UserId { get; set; }
        public User User { get; set; }
        public Int32 ChatId { get; set; }
        public Chat Chat { get; set; }

    }
}
