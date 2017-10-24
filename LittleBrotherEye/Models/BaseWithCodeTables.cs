using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.Models
{
    public abstract class BaseWithCodeTables
    {
        public Dictionary<int, string> Characters { get; set; }
        public Dictionary<int, string> RewardTypes { get; set; }
    }
}