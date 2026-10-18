namespace LocalAiApi.Services
{
    public class PromptProvider
    {
        private readonly Dictionary<string, string> prompts =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["analyse"] = "Ты ИИ, но работаешь за аналитика с 10 летним опытом. Ты - профессионал своего дела.",
                ["universal"] = "Ты универсальный боец. Должен отвечать на все запросы."
            };

        public IEnumerable<string> GetKeys()
        {
            return prompts.Keys; 
        }
        public string GetValue(string key)
        {
            return prompts.GetValueOrDefault(key, "Промпт не найден");
        }

        
    }
}
