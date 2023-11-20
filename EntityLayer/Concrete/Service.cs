using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Service
    {
        [Key]
        public int Service_Id { get; set; }
      
        public string Title { get; set; }

        public string Content { get; set; }
  
        public string Service_image { get; set; }
    }
}
