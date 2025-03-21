using System.Transactions;

namespace Tumble.Application.Helper
{
    public static class TransactionScopeAsync
    {
        public static TransactionScope CreateAsyncTransactionScope(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = isolationLevel,
                Timeout = TransactionManager.MaximumTimeout
            };
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}
