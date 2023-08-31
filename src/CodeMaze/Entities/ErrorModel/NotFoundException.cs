namespace Entities.ErrorModel
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string massage) : base(massage)
        {
            
        }
    }
}
