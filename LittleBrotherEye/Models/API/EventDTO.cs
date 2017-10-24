using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.Models.API
{
    public class EventDTO
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public CodeValueDTO Character_CD { get; set; }
        public DateTime EndTime { get; set; }
        public CodeValueDTO RewardType_CD { get; set; }
    }
}