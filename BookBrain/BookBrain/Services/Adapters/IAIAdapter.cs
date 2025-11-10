namespace BookBrain.Services.Adapters
{
    public interface IAIAdapter
    {
        Task<string> GetBookSummaryAsync(string description);
    }
}
