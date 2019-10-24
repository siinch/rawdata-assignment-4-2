using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement4
{
    // [Table("categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}