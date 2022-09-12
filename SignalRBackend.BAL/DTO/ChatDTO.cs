using SignalRBackend.DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.BLL.DTO
{
    public class ChatDTO
    {
        public Int32? Id { get; set; }
        public String Name { get; set; }
        public Int32 ChatType { get; set; }
        public IEnumerable<UserDTO> Users { get; set; }
        public IEnumerable<MessageDTO> Messages { get; set; }
    }
}
