using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int Message_Id { get; set; }

        public string Name { get; set; }
    
        public string Surname { get; set; }
     
        public string Subject { get; set; }
        public string Content { get; set; }
      
        public string Mail { get; set; }
        public DateTime? Message_date { get; set; }
        public bool Message_Status { get; set; }

    }
}
