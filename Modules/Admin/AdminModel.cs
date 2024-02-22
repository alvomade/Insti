using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Insti.Modules.AdminInstitution;

namespace Insti.Modules.Admin
{
    public class AdminModel
    {
        [Key]
        public Guid id { get; set; }
        public  string name { get; set; }
        public required IEnumerable<AdminInstitutionModel> adminInstitutions { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; set; }

       
    }
}
