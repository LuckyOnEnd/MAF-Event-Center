using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.Entities
{
    public class eventsList
    {
        public eventsList() { }
        public List<Event> events = new List<Event>()
        {
            new Event("First event",DateTime.Now, DateTime.Now.AddDays(1), new Game("CS:GO", "https/:google.com"),"asd.com")
        };
    }
}
