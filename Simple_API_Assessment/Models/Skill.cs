namespace Simple_API_Assessment.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Foreign Key property for Applicant
        public int ApplicantId { get; set; }

        //Navigation Property for Applicant
        public Applicant Applicant { get; set; }
    }
}
