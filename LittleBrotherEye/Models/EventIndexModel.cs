using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.Models
{
    public class EventIndexModel : BaseWithCodeTables
    {
        public EventIndexModel()
        {
            PastDays = 1;
        }

        public int PastDays { get; set; }
    }
}