using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.Models
{
    public class EventList : BaseWithCodeTables
    {
        public EventList()
        {
            Events = new List<EventModel>();
        }

        public List<EventModel> Events { get; set; }
    }
}