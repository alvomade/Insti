using Insti.Modules.Admin;
using Insti.Modules.AdminInstitution.DTOs;
using Insti.Modules.Institution;
using System.ComponentModel.DataAnnotations;

namespace Insti.Modules.AdminInstitution
{
    public class AdminInstitutionModel
    {
        public Guid id { get; set; }
        public AdminModel Admin { get; set; } = null!;
        public InstitutionModel Institution { get; set; } = null!;

        public static implicit operator AdminInstitutionModel(AdminInstitutionFindDTO v)
        {
            throw new NotImplementedException();
        }
    }
}
