using Insti.Modules.Admin;
using Insti.Modules.Institution;
using System.ComponentModel.DataAnnotations;

namespace Insti.Modules.AdminInstitution.DTOs
{
    public class AdminInstitutionFindDTO
    {
        public Guid id { get; set; }
        [Required]
        public AdminModel Admin { get; set; } = null!;
        [Required]
        public InstitutionModel Institution { get; set; } = null!;
    }
}
