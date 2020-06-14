namespace JobApplying.Models.Repositories
{
    public class PartialApplier
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
        public double ExpectedSalary { set; get; }
        public string Position { set; get; }
        public string Phone { set; get; }
        public bool IsSeen { set; get;}
    }
}