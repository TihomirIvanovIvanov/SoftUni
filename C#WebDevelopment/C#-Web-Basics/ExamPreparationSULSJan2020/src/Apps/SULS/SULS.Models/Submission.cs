using System;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class Submission
    {
        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Code { get; set; }

        [Required]
        [Range(0, 300)]
        public int AchievedResult { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string ProblemId { get; set; }

        public Problem Problem { get; set; }
    }
}
