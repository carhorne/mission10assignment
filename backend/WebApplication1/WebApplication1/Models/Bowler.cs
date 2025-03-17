using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    [Table("Bowlers")]
    public class Bowler
    {
        [Key]
        public int BowlerID { get; set; }

        [Required]
        [StringLength(50)]
        public string BowlerLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string BowlerFirstName { get; set; }

        [StringLength(1)]
        public string BowlerMiddleInit { get; set; }

        [StringLength(50)]
        public string BowlerAddress { get; set; }

        [StringLength(50)]
        public string BowlerCity { get; set; }

        [StringLength(2)]
        public string BowlerState { get; set; }

        [StringLength(10)]
        public string BowlerZip { get; set; }

        [StringLength(14)]
        public string BowlerPhoneNumber { get; set; }

        [ForeignKey("Team")]
        public int? TeamID { get; set; }

        // Navigation property
        public virtual Team Team { get; set; }
    }
}
