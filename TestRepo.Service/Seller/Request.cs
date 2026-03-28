namespace TestRepo.Service.Seller;

public class Request
{
    public class CreateSellerRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string TaxCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
    }
}