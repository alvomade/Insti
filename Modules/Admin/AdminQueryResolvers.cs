

namespace Insti.Modules.Admin
{
    [ExtendObjectType("Query")]
    public class AdminQueryResolvers { 
        private readonly AdminServices adminServices;

        public AdminQueryResolvers(AdminServices _adminServices)
        {
            this.adminServices = _adminServices;
        }
    
        public async Task<IEnumerable<AdminModel>> findAdmins()
        {
      
          
                var theAdmins = await adminServices.findAllAdmins();
                return theAdmins;
         
            
        }

        public async Task<AdminModel?>findAdmin(Guid id){
            return await adminServices.findAdmin(id);
        }
    }
}
