using System;
namespace SignalRBackend.Entities
{
    public class Chat
    {
        public Int32 Id { get; set; }
        public Int32 UserId { get; set; }
        public User User { get; set; }
        public String Name { get; set; }
    }
}
