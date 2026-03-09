using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BlogApiPrev.Models
{
    public class BlogModel
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public string? PublishedName {get; set;}
        public string? Date {get; set;}
        public string? Title {get; set;}
        public string? Image {get; set;}
        public string? Description {get; set;}
        public string? Category {get; set;}
        public bool IsPublished {get; set;}
        public bool IsDeleted {get; set;}
    }
}