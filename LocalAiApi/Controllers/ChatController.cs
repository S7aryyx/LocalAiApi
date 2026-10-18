using LocalAiApi.Models;
using LocalAiApi.Services;

using Microsoft.AspNetCore.Mvc;
//Папка Controllers -> Файл : ChatController.cs
namespace LocalAiApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class ChatController(PromptProvider promptProvider 
        , OllamaService ollamaService) : ControllerBase
    {
        //health 
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok();
        }
        //prompts 
        [HttpGet("prompts")]
        public IActionResult GetPrompts()
        {
            return Ok(promptProvider.GetKeys());
        }

        //Можно как вариант сделать API для раздела PROMPTS, которая будет дополнять
        //Ключи и значения в Dictionary (что-то типо пост запросов)

        //chat
        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody]ChatRequest request , CancellationToken cancellationToken)
        {
            if (request.Message == null || string.IsNullOrWhiteSpace(request.Message))
            {
                return BadRequest("Сообщение для Чата , не может быть пустым");
            }
            try
            {
                var UserMSG = await ollamaService.ChatAsync
                    (
                    request.Message,
                    request.Prompt,
                    cancellationToken
                    );

                return Ok(UserMSG);
            } catch (HttpRequestException ex)
            {
                return StatusCode(502, "ИИ недоступна(Ollama не ответила на запрос)");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(502, "ИИ Вернула неккоректный ответ");
            }
        }

    }
}
