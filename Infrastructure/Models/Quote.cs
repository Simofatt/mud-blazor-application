using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Quote : AuditableEntity<int>
    {
        
        public string Content{ get; set; }
        public Book Book { get; set; }



    }
}
