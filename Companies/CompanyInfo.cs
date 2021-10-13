namespace OTS.Ticketing.Win.Companies
{
    public class CompanyInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public long BranchId { get; set; }
        public bool IsDeleted { get; set; }


    }
}
