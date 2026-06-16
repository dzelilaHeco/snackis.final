using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snackis.Domain.Entities
{
    public class PrivateMessage
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime SentAt { get; set; }

        public string SenderId { get; set; }
        public MyUser Sender { get; set; }

        public string ReceiverId { get; set; }
        public MyUser Receiver { get; set; }
    }
}
