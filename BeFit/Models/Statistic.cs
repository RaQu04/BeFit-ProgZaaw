using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BeFit.Models
{
    public class Statistic
	{
        public int Id { get; set; }
        [Display(Name = "Best Result")]
        public float BestResult { get; set; }
        [Display(Name = "Number Of Sessions")]
        public int NumOfSesssion { get; set; }
        public int ExerciseTypeId { get; set; }
        [Display(Name = "Exercise Type")]
        public virtual ExerciseType? ExerciseType { get; set; }
    }
}

