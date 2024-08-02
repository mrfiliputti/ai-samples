using System.Threading.Tasks;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = Kernel.CreateBuilder();

        builder.AddAzureOpenAIChatCompletion(
                 "",  // Azure OpenAI Deployment Name
                 "",  // Azure OpenAI Endpoint
                 ""); // Azure OpenAI Key
                 
        var kernel = builder.Build();

        var prompt = @"{{$input}}

One line TLDR with the fewest words.";

        var summarize = kernel.CreateFunctionFromPrompt(prompt, executionSettings: new OpenAIPromptExecutionSettings { MaxTokens = 100 });

        string text1 = 
        @"Topspin in tennis is a technique where the ball rotates forward as it travels through the air, achieved by brushing up the back of the ball with an upward and forward racket motion. This spin causes the ball to dip quickly after crossing the net and bounce higher upon hitting the ground, making it more challenging for opponents to return. The topspin effect is created by the top of the ball moving in the same direction as the shot, while the bottom moves in the opposite direction12. This forward rotation allows players to hit with more power and control, as the ball’s downward dip helps keep it within the court boundaries1. Topspin can be applied to various shots, including forehands, backhands, and serves, adding versatility to a player’s game2. The higher bounce and increased margin for error make it easier to sustain rallies and apply pressure on opponents2. Mastering topspin involves practicing the upward brushing motion and ensuring a complete follow-through to maintain control and power.";        

         
         Console.WriteLine(await kernel.InvokeAsync(summarize, new() { ["input"] = text1 }));
    }
}