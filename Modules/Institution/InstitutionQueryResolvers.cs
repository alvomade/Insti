using Insti.Modules.Institution.DTOs;

namespace Insti.Modules.Institution
{
    [ExtendObjectType("Query")]
    public class InstitutionQueryResolvers{
        private readonly InstitutionServices _services;

        public InstitutionQueryResolvers(InstitutionServices services)=>_services=services;
        public async Task<IEnumerable<InstitutionFindDTO>?> findInstitutions(){
            try{
                return await _services.findAllInstitutions();
            }catch(Exception e){Console.WriteLine(e); return null;}
            

        }

        public async Task<InstitutionFindDTO?>findInstitution(Guid id){
            try{
                return await _services.findInstitution(id);
            }catch(Exception e){Console.WriteLine(e); return null;}
        }
    }
}