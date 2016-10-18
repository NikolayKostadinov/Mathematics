namespace Mathematics.Infrastructure.Contracts
{
    public interface IProgressRegistrator
    {
        void ResetProgress();
        void RegisterProgress(int value);
    }
}
