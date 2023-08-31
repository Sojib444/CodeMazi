namespace Entities.ErrorModel
{
    public class CompanyNotFoundException : NotFoundException
    {
        public CompanyNotFoundException(Guid Id) : base($"The is comany id {Id} didn't not find in the database")
        {
            
        }
    }
}
