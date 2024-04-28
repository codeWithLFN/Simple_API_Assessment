using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public class ApplicantRepo : IApplicantRepository
    {
        private readonly DataContext _context;

        public ApplicantRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Applicant>> GetAllApplicantsAsync()
        {
            // Include the Skills navigation property to return the related skills for each applicant
            return await _context.Applicants.Include(a => a.Skills).ToListAsync();
        }

        public async Task<Applicant> GetApplicantAsync(int id)
        {
            // Include the Skills navigation property to return the related skills for the applicant
            return await _context.Applicants.Include(a => a.Skills).FirstOrDefaultAsync(a => a.Id == id);
            
        }

        public async Task CreateApplicantAsync(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateApplicantAsync(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteApplicantAsync(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant != null)
            {
                _context.Applicants.Remove(applicant);
                await _context.SaveChangesAsync();
            }
        }
    }
}