namespace BankingSystemAssignment.Tasks7_14.Exceptions
{
    internal class OverDraftLimitExceededException : Exception
    {
        public OverDraftLimitExceededException(string message) : base(message)
        {
        }
    }
}
