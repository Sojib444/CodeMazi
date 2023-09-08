namespace Entities.Exceptions
{
    public class IdParameterBadRequstException : BadRequestException
    {
        public IdParameterBadRequstException() : base("parameter ids is null")
        {
            
        }
    }
}
