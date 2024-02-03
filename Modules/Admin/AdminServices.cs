using Insti.Context;
using Insti.Modules.Admin.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
namespace Insti.Modules.Admin
{
    public class AdminServices
    {
        private readonly InstiDb _context;
        public AdminServices(InstiDb context)
        {
            _context = context;
        }
        public async Task addAdmin(AdminAddDTO addAdmin)
        {
            var admin = new AdminModel
            {
                name = addAdmin.name,
                adminInstitutuions = []
            };
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }


        public async Task<string>? findAdmin(Guid id)
        {
            var admin = await _context.Admins
                .Include(a => a.adminInstitutuions)
                .FirstOrDefaultAsync(a => a.id == id);

            
            if(admin == null) return null;

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 64 // Set the maximum depth to an appropriate value
            };

            
            var adminDTO = new AdminFindDTO
            { 
                name= admin.name,   
                id=admin.id,
                adminInstitutions=admin.adminInstitutuions
            };
            var jsonString = JsonSerializer.Serialize(adminDTO, jsonOptions);
            return jsonString;
        }

        public async Task<IEnumerable<AdminFindDTO>> findAllAdmins()
        {
            var admins = await _context.Admins.ToListAsync();
            
            //var result = (ICollection<dynamic>)admins.Select(a => new AdminDTO(a).defaultModel());
            var allAdmins = admins.Select(admin => new AdminFindDTO{ 
                name=admin.name,
                id=admin.id,
                adminInstitutions = admin.adminInstitutuions
            });
            return allAdmins;


        }

        public async Task deleteAdmin(Guid id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if(admin == null) return;

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

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

        public async Task editAdmin(Guid id, AdminEditDTO editedAdmin) {
            var admin=await _context.Admins.FindAsync(id);
            if(admin == null) return;

            admin.name = editedAdmin.name;
            
            await _context.SaveChangesAsync();
        }
    }
}
