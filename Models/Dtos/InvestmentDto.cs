using New_folder.Models.Entities;

namespace New_folder.Models.Dtos
{
    public class InvestmentDto : BaseEntity
    {
        public string ReferenceNumber { get; set; }
        public double Principal { get; set; }
        public DateTime InvestmentDate { get; set; }
        public double Amount { get; set; }
        public string InvestorId { get; set; }
        public Investor Investor { get; set; }
        public string BrokerCode { get; set; }
        public string InvestmentTypeId { get; set; }
    }
    public class CreateInvestmentRequestModel
    {
        public string ReferenceNumber { get; set; }
        public double Principal { get; set; }
        public DateTime InvestmentDate { get; set; }
        public double Amount { get; set; }
        public string InvestorId { get; set; }
        public Investor Investor { get; set; }
        public string BrokerCode { get; set; }
        public string InvestmentTypeId { get; set; }
    }
}
