using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Models
{
    public class OneEmailModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        public string Application_Name { get; set; }
        public int VarCode { get; set; }
        
    }
}
