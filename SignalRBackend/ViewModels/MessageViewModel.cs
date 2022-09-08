using SignalRBackend.DAL.DomainModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace SignalRBackend.WEB.ViewModels
{
    public class MessageViewModel
    {
        public Int32? Id { get; set; }
        [Required]
        public Int32 ChatId { get; set; }
        [Required]
        public Int32 UserId { get; set; }
        [Required]
        [MinLength(1),MaxLength(4096)]
        public String MessageText { get; set; }
        public DateTime? ActivityDate { get; set; }

        public UserViewModel User{ get; set; }
        public UserViewModel Receiver { get; set; }
        public ChatViewModel Chat { get; set; }
    }
}
