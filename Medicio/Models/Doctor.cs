using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicio.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public int ProfessionId { get; set; }
        [StringLength(maximumLength:25)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        [StringLength(maximumLength: 125)]

        public string? ImageUrl { get; set; }
        [StringLength(maximumLength: 105)]

        public string? TTUrl { get; set; }
        [StringLength(maximumLength: 105)]

        public string? FBUrl { get; set; }
        [StringLength(maximumLength: 105)]

        public string? IGUrl { get; set; }
        [StringLength(maximumLength: 105)]

        public string? LNUrl { get; set; }


        public Profession? Profession { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
