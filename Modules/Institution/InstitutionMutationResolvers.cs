using Insti.Modules.Institution.DTOs;

namespace Insti.Modules.Institution
{
    [ExtendObjectType("Mutation")]
    public class InstitutionMutationResolvers{
        private readonly InstitutionServices _services;
        public InstitutionMutationResolvers(InstitutionServices services)=>_services=services;

        public async Task<InstitutionEditDTO?> editInstitution(Guid id,string name){
             try{
                return await _services.editInstitution(id,name);
            }catch(Exception e){Console.WriteLine(e); return null;}
            
        }   
        public async Task<InstitutionFindDTO?> addInstitution(string name){
            try{
                return await _services.addInstitution(name);
            }catch(Exception e){Console.WriteLine(e); return null;}
        }

         public async Task<InstitutionFindDTO?> deleteInstitution(Guid id){
            try{
                return await _services.deleteInstitution(id);
            }catch(Exception e){Console.WriteLine(e); return null;}
        }
    }
}