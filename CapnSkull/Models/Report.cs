namespace CapnSkull.Models
{
    public class Report
    {
        public Report()
        {
            FirstNameReport = new NameSection();
            MiddleNameReport = new NameSection();
            LastNameReport = new NameSection();
            NickanmeReport = new NameSection();
        }

        public Person Person { get; set; }
        public NameSection FirstNameReport { get; set; }
        public NameSection MiddleNameReport { get; set; }
        public NameSection LastNameReport { get; set; }
        public NameSection NickanmeReport { get; set; }
    }
}