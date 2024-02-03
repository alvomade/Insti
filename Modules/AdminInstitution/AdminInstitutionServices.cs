using Insti.Context;

namespace Insti.Modules.AdminInstitution
{
    public class AdminInstitutionServices
    {
        private readonly InstiDb _context;
        public AdminInstitutionServices( InstiDb context ) { 
            _context = context;
        }

        public async Task assignInstitution(Guid adminId, Guid institutionId) { 

            var admin=await _context.Admins.FindAsync(adminId);
            var institution=await _context.Institutions.FindAsync(institutionId);
            if (admin == null || institution == null) return;

            var adminInstitutionRecord=new AdminInstitutionModel
            {
                Admin = admin,
                Institution = institution
            };
            _context.AdminInstitutions.Add(adminInstitutionRecord);
            await _context.SaveChangesAsync();
        
        }
    }
}
