using Insti.Modules.Admin;
using Insti.Modules.Institution;
namespace insti.Schema
{
    public class QueryType{
                private readonly InstitutionServices institutionServices;

        public QueryType(InstitutionServices _institutionServices)
        {
            this.institutionServices = _institutionServices;
        }
    
        public async Task<IEnumerable<InstitutionModel>> findAllInsti()
        {
      
          
                var theInsti = await institutionServices.findAllInstitutions();
                return theInsti;
         
            
        }
        
    }
}