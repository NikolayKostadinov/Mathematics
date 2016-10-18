namespace Mathematics.Infrastructure.Contracts
{
    public interface IProgressMessage
    {
        int ProgressValue { get; set; }

        string Message { get; set; }
    }
}
