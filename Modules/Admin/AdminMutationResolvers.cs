

using Insti.Modules.Admin.DTOs;

namespace Insti.Modules.Admin
{
    [ExtendObjectType("Mutation")]
    public class AdminMutationResolvers{
        private readonly AdminServices _services;
        public AdminMutationResolvers(AdminServices services)=>_services=services;

        public async Task<AdminModel?> addAdmin(string name){
          
            try{
                 var addAdmin= new AdminAddDTO{
                name=name
                };
            
            return await _services.addAdmin(addAdmin);
        
            }catch(Exception e){Console.WriteLine(e); return null;}
        }

        public async Task<AdminModel?>deleteAdmin(Guid id){
            try{
                var admin=await _services.deleteAdmin(id);
                return admin;
        
            }catch(Exception e){Console.WriteLine(e); return null;}
            
        }

        public async Task<AdminModel?>editAdmin(Guid id,string name){
            
            return await _services.editAdmin(id,name);
        }
    }
}