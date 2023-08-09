using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Book : AuditableEntity<int>
    {
        
        public string Title { get; set; }
        public string Synopsis{ get; set; }
        public Author Author { get; set; }
        public ICollection<Quote> Quotes { get; set; }        


    }
}
