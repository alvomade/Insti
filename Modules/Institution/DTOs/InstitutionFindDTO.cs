using Insti.Modules.AdminInstitution;

namespace Insti.Modules.Institution.DTOs
{
    public class InstitutionFindDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }

        public IEnumerable<AdminInstitutionModel>? adminInstitutions { get; set; }
    }
}
