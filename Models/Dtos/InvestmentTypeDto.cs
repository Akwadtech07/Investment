using New_folder.Models.Entities;

namespace New_folder.Models.Dtos
{
    public class InvestmentTypeDto : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double MinimumInvestMent { get; set; }
        public double MaximumInvestMent { get; set; }
        public string Months { get; set; }
        public double Rate { get; set; }
    }

    public class CreateInvestmentTypeRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double MinimumInvestMent { get; set; }
        public double MaximumInvestMent { get; set; }
        public string Months { get; set; }
        public double Rate { get; set; }
    }
}
