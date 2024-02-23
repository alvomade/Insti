using Insti.Context;
using Insti.Modules.Admin.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Insti.Modules.AdminInstitution.DTOs;
using Insti.Modules.AdminInstitution;
namespace Insti.Modules.Admin
{
    public class AdminServices
    {
        private readonly InstiDb _context;
        public AdminServices(InstiDb context)
        {
            _context = context;
        }
        public async Task<AdminModel> addAdmin(AdminAddDTO addAdmin)
        {
            var admin = new AdminModel
            {
                name = addAdmin.name,
                adminInstitutions = []
            };
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return admin;
        }


        public async Task<AdminModel?> findAdmin(Guid id)
        {
            var admin = await _context.Admins
                .Include(a => a.adminInstitutions)
                .ThenInclude(ai=>ai.Institution)
                .FirstOrDefaultAsync(a => a.id == id);

            
            if(admin == null) return null;

           
            return admin;
        }

        public async Task<IEnumerable<AdminModel>> findAllAdmins()
        {
            var admins = await _context.Admins
                .Include(admin=>admin.adminInstitutions)
                .ThenInclude(ai=>ai.Institution)
                .ToListAsync();

            //var result = (ICollection<dynamic>)admins.Select(a => new AdminDTO(a).defaultModel());
            // var allAdmins = admins.Select(admin => new AdminFindDTO
            // {
            //     name = admin.name,
            //     id = admin.id,
            //     adminInstitutions=(IEnumerable<AdminInstitutionModel>)admin.adminInstitutions
            //     .Select(ai=>ai=new AdminInstitutionModel{
            //         Institution=ai.Institution
            //     })
            //     .ToList()
            //     // adminInstitutions = (IEnumerable<AdminInstitutionModel>)admin.adminInstitutions.
            //     // Select(ai => new AdminInstitutionModel
            //     // {
            //     //     Admin = ai.Admin, 
            //     //     Institution = ai.Institution
            //     // }).ToList()
            // }) ;
            // Console.WriteLine(allAdmins);
            return admins;


        }

        public async Task<AdminModel?> deleteAdmin(Guid id)
        {
            Console.WriteLine("IMEFIKA HAPA");
            var admin = await _context.Admins.FindAsync(id);

            if(admin == null) return null;

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<IEnumerable<AdminFindDTO>> findAdminByDate(DateTime? startDate, DateTime? endDate)
        {
            var admins = _context.Admins;
            if (startDate != null && endDate != null)
                    admins.Where(admin => admin.createdAt >= startDate && admin.createdAt <= endDate);
            else if (startDate != null)
                admins.Where(admin => admin.createdAt >= startDate);
            else if (endDate != null)
                admins.Where(admin => admin.createdAt <= endDate);

            if (admins == null) return [];
            var adminList = (await admins.ToListAsync());
            return adminList.Select(admin => new AdminFindDTO { 
                    name=admin.name,
                    id=admin.id,    
            });
        }

        public async Task<AdminModel?> editAdmin(Guid id, string name) {
            var admin=await _context.Admins.FindAsync(id);
            if(admin == null) return null;
            var editedAdmin=new AdminEditDTO{
                name=name
            };

            admin.name = editedAdmin.name;
            
            await _context.SaveChangesAsync();
            return admin;
        }
    }
}
