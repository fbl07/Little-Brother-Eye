using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.Models
{
    public class EventModel : BaseWithCodeTables, IValidatableObject
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int? Character_Cd { get; set; }

        [DisplayFormat(DataFormatString = "hh\\:mm")]
        public TimeSpan? TimeToEnd { get; set; }
        public string DisplayForTimeToEnd { get; set; }

        public int TimeToEndHours { get; set; }
        public int TimeToEndMinutes { get; set; }

        public DateTime? EndTime { get; set; }
        public int RewardType_Cd { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var list = new List<ValidationResult>();

            if (this.TimeToEndHours <= 0 && this.TimeToEndMinutes <= 0)
                list.Add(new ValidationResult("Time To End is required", new string[] { "TimeToEndHours" }));

            return list;

        }
    }
}