namespace Contracts
{
    public interface IUnitofWork : IDisposable
    {
        void SaveChage();        
    }
}
