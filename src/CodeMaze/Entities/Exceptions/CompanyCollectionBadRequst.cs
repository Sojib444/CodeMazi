namespace Entities.Exceptions
{
    public class CompanyCollectionBadRequst : BadRequestException
    {
        public CompanyCollectionBadRequst() : base("Company collections sent from client is null")
        {
            
        }
    }
}
