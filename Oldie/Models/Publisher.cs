using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matis_Ligia_Estera_ProiectExamen.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
