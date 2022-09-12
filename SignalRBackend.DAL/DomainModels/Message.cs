using System;

namespace SignalRBackend.DAL.DomainModels
{
    public class Message
    {
        public Int32? Id { get; set; }
        public Int32 ChatId { get; set; }
        public Int32 UserId { get; set; }
        public Int32? ReceiverId { get; set; }
        public String UserName { get; set; }
        public  Int32? RepliedMessageId { get; set; }
        public Boolean IsDeletedOnlyForCreator { get; set; }
        public String MessageText { get; set; }
        public DateTime? ActivityDate { get; set; }
        public Message RepliedMessage { get; set; }
        public User Receiver { get; set; }
        public User User { get; set; }
        public Chat Chat { get; set; }

    }
}
