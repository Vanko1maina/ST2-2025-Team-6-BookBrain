using BookBrain.Services.Adapters;

namespace BookBrain.Services
{
    public class AIService
    {
        private static AIService? _instance;
        private static readonly object _lock = new();
        private readonly IAIAdapter _adapter;

        private AIService(IAIAdapter adapter)
        {
            _adapter = adapter;
        }

        public static AIService GetInstance(IAIAdapter adapter)
        {
            lock (_lock)
            {
                _instance ??= new AIService(adapter);
                return _instance;
            }
        }

        public async Task<string> SummarizeBookAsync(string description)
        {
            return await _adapter.GetBookSummaryAsync(description);
        }
    }
}
