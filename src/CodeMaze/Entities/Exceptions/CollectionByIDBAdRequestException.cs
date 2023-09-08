namespace Entities.Exceptions
{
    public class CollectionByIDBAdRequestException : BadRequestException
    {
        public CollectionByIDBAdRequestException() : base("Collection count mismatch compare to ids")
        {
            
        }
    }
}
