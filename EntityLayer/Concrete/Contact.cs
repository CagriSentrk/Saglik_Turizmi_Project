using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int Contact_Id { get; set; }
      
        public string Mail { get; set; }

        public int Phone_number { get; set; }
    
        public string Address { get; set; }
    }
}
