using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiPrev.Models
{
    public class UserModel
    {
        public int Id {get; set;}
        public string? Username {get; set;}
        // [Length(10)]
        public string? Email { get; set;}
        public DateTime? LogDate {get; set;}
        public string Salt {get; set;}
        public string Hash {get; set;}
    }
}