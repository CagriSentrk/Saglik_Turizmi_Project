using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class HomePage
    {
        [Key]
        public int HomePage_Id { get; set; }
  
        public String Title { get; set; }
      
        public String Content { get; set; }
      
        public String Homepage_Image { get; set; }
    }
}
