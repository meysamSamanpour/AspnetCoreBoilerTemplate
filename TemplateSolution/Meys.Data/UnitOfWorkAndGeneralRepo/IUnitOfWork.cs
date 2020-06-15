using System;

namespace Meys.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges(); //this is a test
    }    
}
