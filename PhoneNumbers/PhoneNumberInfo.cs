namespace OTS.Ticketing.Win.PhoneNumbers
{
    public class PhoneNumberInfo
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public long CompanyId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
