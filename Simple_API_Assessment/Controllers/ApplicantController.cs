using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_API_Assessment.Data.Repository;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository _repository;

        public ApplicantController(IApplicantRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetAllApplicantsAsync()
        {
            return await _repository.GetAllApplicantsAsync(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Applicant>> GetApplicantAsync(int id)
        {
            return await _repository.GetApplicantAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Applicant>> CreateApplicantAsync(Applicant applicant)
        {
            await _repository.CreateApplicantAsync(applicant);
            return CreatedAtAction(nameof(GetApplicantAsync), new { id = applicant.Id }, applicant);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateApplicantAsync(int id, Applicant applicant)
        {
            await _repository.UpdateApplicantAsync(applicant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApplicantAsync(int id)
        {
            await _repository.DeleteApplicantAsync(id);
            return NoContent();
        }
    }
}
