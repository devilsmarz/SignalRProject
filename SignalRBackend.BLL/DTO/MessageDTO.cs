using System;

namespace SignalRBackend.BLL.DTO
{
    public class MessageDTO
    {
        public Int32? Id { get; set; }
        public Int32 ChatId { get; set; }
        public Int32 UserId { get; set; }
        public Int32? ReceiverId { get; set; }
        public Int32? RepliedMessageId { get; set; }
        public String UserName { get; set; }
        public Boolean IsDeletedOnlyForCreator { get; set; }
        public String MessageText { get; set; }
        public DateTime? ActivityDate { get; set; }
        public UserDTO Receiver { get; set; }
        public MessageDTO RepliedMessage { get; set; }
        public UserDTO User { get; set; }
        public ChatDTO Chat { get; set; }
    }
}
