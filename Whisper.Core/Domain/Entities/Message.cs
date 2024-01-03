using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whisper.Core.Domain.Models;

namespace Whisper.Core.Domain.Entities
{
    public class Message : IEntity
    {
        public Guid Id { get; set; }
        public string SenderId { get; set; }
        public AppUser SenderUser { get; set; }
        public string ReceiverId { get; set; }
        public AppUser ReceiverUser { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime ReceivedAt { get; set; }
        public DateTime ReadAt { get; set; }
    }
}
