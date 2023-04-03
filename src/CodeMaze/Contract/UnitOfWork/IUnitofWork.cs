namespace Contract.UnitOfWork
{
    public interface IUnitofWork :IDisposable
    {
        void Savechange();
    }
}
