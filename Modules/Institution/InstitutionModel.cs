using Insti.Modules.AdminInstitution;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insti.Modules.Institution
{
    public class InstitutionModel
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        [Required]

        public IEnumerable<AdminInstitutionModel> adminInstitutuions { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; set; }

       
    }
}
