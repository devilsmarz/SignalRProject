using SignalRBackend.BLL.Interfaces;
using System;

namespace SignalRBackend.WEB.Validators
{
    public class IsUserInChatValidator
    {
        private readonly IMessageService _messageService;
        public IsUserInChatValidator(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public Boolean IsValid(Int32 chatId, Int32 userId)
        {
            
        }

    }
}
