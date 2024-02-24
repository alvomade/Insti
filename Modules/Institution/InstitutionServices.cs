using Insti.Context;
using Insti.Modules.Institution.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Insti.Modules.Institution
{
    public class InstitutionServices
    {
        private readonly InstiDb _context;
        public InstitutionServices(InstiDb context) {
            _context=context;
        }

        public async Task<InstitutionFindDTO?> addInstitution(string name) {
            if (name == null) return null;

            var institution = new InstitutionModel {
                name = name
            };

             _context.Institutions.Add(institution);
            await _context.SaveChangesAsync();
            return new InstitutionFindDTO{
                name=institution.name,
                adminInstitutions=null
            };
        }

        public async Task<InstitutionFindDTO?> findInstitution(Guid id)
        {
            var institution = await _context.Institutions
                .Include(insti=>insti.adminInstitutuions)
                .ThenInclude(ai=>ai.Admin)
                .FirstOrDefaultAsync(insti => insti.id == id);


            if (institution == null) return null;

            var institutionDTO = new InstitutionFindDTO
            {
                name = institution.name,
                id = institution.id,
                adminInstitutions=institution.adminInstitutuions
            };

            return institutionDTO;
        }

        public async Task<IEnumerable<InstitutionFindDTO>> findAllInstitutions()
        {
            var institutions = await _context.Institutions
                .Include(insti=>insti.adminInstitutuions)
                .ThenInclude(ai=>ai.Admin)
                .ToListAsync();

            //var result = (ICollection<dynamic>)institutions.Select(a => new institutionDTO(a).defaultModel());
            var allinstitutions = institutions.Select(institution => new InstitutionFindDTO
            {
                name = institution.name,
                id = institution.id,
                adminInstitutions = institution.adminInstitutuions
            });
            return allinstitutions;


        }
        public async Task<InstitutionFindDTO?> deleteInstitution(Guid id)
        {
            var institution = await _context.Institutions
            .Include(i=>i.adminInstitutuions)
            .ThenInclude(ai=>ai.Admin)
            .FirstOrDefaultAsync(i=>i.id==id);

            if (institution == null) return null;

            _context.Institutions.Remove(institution);
            await _context.SaveChangesAsync();

            return new InstitutionFindDTO{
                name=institution.name,
                adminInstitutions=institution.adminInstitutuions
            };
        }

        public async Task<IEnumerable<InstitutionFindDTO>> findInstitutionByDate(DateTime? startDate, DateTime? endDate)
        {
            var institutions = _context.Institutions.Include(insti=>insti.adminInstitutuions);
            if (startDate != null && endDate != null)
                institutions.Where(institution => institution.createdAt >= startDate && institution.createdAt <= endDate);
            else if (startDate != null)
                institutions.Where(institution => institution.createdAt >= startDate);
            else if (endDate != null)
                institutions.Where(institution => institution.createdAt <= endDate);

            if (institutions == null) return [];
            var institutionList = (await institutions.ToListAsync());
            return institutionList.Select(institution => new InstitutionFindDTO
            {
                name = institution.name,
                id = institution.id,
                adminInstitutions=institution.adminInstitutuions
            });
        }

        public async Task<InstitutionEditDTO?> editInstitution(Guid id,string name)
        {
            var institution = await _context.Institutions.FindAsync(id);
            if (institution == null) return null;

            institution.name = name;

            await _context.SaveChangesAsync();
            
            return new InstitutionEditDTO{
                name=institution.name

            };
        }
    }
}
