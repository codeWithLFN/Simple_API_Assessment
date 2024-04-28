using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public interface IApplicantRepository
    {
        // Define the methods that will be implemented in the ApplicantRepo class
        Task<List<Applicant>> GetAllApplicantsAsync();
        Task<Applicant> GetApplicantAsync(int id);
        Task CreateApplicantAsync(Applicant applicant);
        Task UpdateApplicantAsync(Applicant applicant);
        Task DeleteApplicantAsync(int id);
    }
}
