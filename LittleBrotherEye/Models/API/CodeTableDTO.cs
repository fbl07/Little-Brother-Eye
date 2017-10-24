
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.Models.API
{
    public class CodeTableDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<CodeValueDTO> Values { get; set; }
    }
}