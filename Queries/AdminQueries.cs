using Insti.Modules.Admin;
using Insti.Modules.Admin.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Insti.Queries
{
    public class AdminQueries { 
        private readonly AdminServices adminServices;

        public AdminQueries(AdminServices _adminServices)
        {
            this.adminServices = _adminServices;
        }
    
        public async Task<IEnumerable<AdminModel>> findAllAdmins()
        {
      
          
                var theAdmins = await adminServices.findAllAdmins();
                return theAdmins;
         
            
        }

        public async Task<AdminModel?>findAdmin(Guid id){
            return await adminServices.findAdmin(id);
        }
    }
}
