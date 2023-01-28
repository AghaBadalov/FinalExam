using System.ComponentModel.DataAnnotations;

namespace Medicio.Models
{
    public class Profession
    {
        public int Id { get; set; }
        [StringLength(maximumLength:25)]
        public string Name { get; set; }
        public List<Doctor>? Doctors { get; set; }
    }
}
