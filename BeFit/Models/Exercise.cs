using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BeFit.Models
{
	public class Exercise
	{
        public int Id { get; set; }
        [Range(1, 500)]
        public float Weight { get; set; }
        [Display(Name = "Number Of Sessions")]
        [Range(1, 500)]
        public int NumOfSessions { get; set; }
        [Display(Name = "Number Of Reps")]
        [Range(1, 500)]
        public int NumOfReps { get; set; }
        [Display(Name = "Session Id")]
        public int SessionId { get; set; }
        public virtual Session? Session { get; set; }
        public int ExerciseTypeId { get; set; }
        [Display(Name = "Exercise Type")]
        public virtual ExerciseType? ExerciseType { get; set; }
    }
}

