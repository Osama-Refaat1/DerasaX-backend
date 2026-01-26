using DerasaX.Domain.Entities.Base;
using DerasaX.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class StudentInsight :BaseEntity
    {
        public PerformanceLevel Performance { get; set; }
        public double ConfidenceScore { get; set; }
        public InsightPeriod Period { get; set; } = InsightPeriod.Weekly;
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
        public DateTime PeriodStart { get; set; }       
        public DateTime PeriodEnd { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
