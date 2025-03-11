using System;

namespace TestHub.DAL
{
    public class DBInteraction : IDisposable
    {
        private static ITestingSystemContextDbContext _context = new TestingSystemContext();
        private bool _disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~DBInteraction()
        {
            Dispose(false);
        }
    }
}






