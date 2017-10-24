using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.Models.API
{
    public class CodeValueDTO
    {
        public int CodeValue { get; set; }
        public int CodeTableId { get; set; }
        public string Description { get; set; }
    }
}