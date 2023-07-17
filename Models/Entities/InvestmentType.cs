namespace New_folder.Models.Entities
{
    public class InvestmentType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double MinimumInvestMent { get; set; }
        public double MaximumInvestMent { get; set; }
        public string Months { get; set; }
        public double Rate { get; set; }
    }
}
