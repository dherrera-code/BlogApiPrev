using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiPrev.Models
{
    public class FakeBlogModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? PublishedName { get; set; }
        [MaxLength(100)]
        public string? Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}