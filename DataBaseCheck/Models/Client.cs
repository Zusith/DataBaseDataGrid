using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCheck.Models
{
    //Класс для создания entity из бд
    class Client 
    {      
        [Key]
        
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Post { get; set; }
    }
}
