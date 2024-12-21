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
        public string? created_by { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public string? updated_by { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
