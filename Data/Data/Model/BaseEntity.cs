using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public string? Created_By { get; set; }
        public DateTime? Created_At { get; set; } = DateTime.UtcNow;
        public string? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
