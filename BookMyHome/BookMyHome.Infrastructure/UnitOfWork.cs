using BookMyHome.Application.Helpers;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookMyHome.Infrastructure
{
    public class UnitOfWork<dbContext> : IUnitOfWork where dbContext : DbContext  // UnitOfWork takes as argument type dbContext, which is constrained to DbContext
    {
        private readonly DbContext _db;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(dbContext db)
        {
            _db = db;
        }

        void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
        {
            if (_db.Database.CurrentTransaction != null) return;
            _transaction = _db.Database.BeginTransaction(isolationLevel);
        }

        void IUnitOfWork.Commit()
        {
            if (_transaction == null) throw new Exception("You must call 'Begin Transaction' before Commit() is called");
            _transaction.Commit();
            _transaction.Dispose();
        }

        void IUnitOfWork.Rollback()
        {
            if (_transaction == null) throw new Exception("You must call 'Begin Transaction' before Rollback() is called");
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
