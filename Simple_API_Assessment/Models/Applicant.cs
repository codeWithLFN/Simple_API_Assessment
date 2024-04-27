namespace Simple_API_Assessment.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property for aplicant skills
        public ICollection<Skill> Skills { get; set; }
    }
}
