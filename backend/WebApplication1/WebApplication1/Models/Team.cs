using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace WebApplication1.Models
{
    [Table("Teams")]
    public class Team
    {
        public Team()
        {
            // Initialize collection
            Bowlers = new HashSet<Bowler>();
        }

        [Key]
        public int TeamID { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }

        public int? CaptainID { get; set; }

        // Navigation property
        public virtual ICollection<Bowler> Bowlers { get; set; }
    }
}
