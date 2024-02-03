using Insti.Modules.AdminInstitution;

namespace Insti.Modules.Admin.DTOs
{
    public class AdminFindDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }   
        
        public IEnumerable<AdminInstitutionModel>? adminInstitutions { get; set; } 
    }
}
