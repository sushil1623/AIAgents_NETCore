// See https://aka.ms/new-console-template for more information
using OpenAI.Chat;

string openAIKey = Environment.GetEnvironmentVariable("OPEN_API_KEY");
var aiClient = new OpenAI.OpenAIClient(openAIKey);

var chatClient = aiClient.GetChatClient("gpt-4o-mini");
Console.WriteLine("Please provide your Input");
while (true)
{
    string userInput=Console.ReadLine().ToString();
    List<ChatMessage> messages = new List<ChatMessage>
    {
        //1. new SystemChatMessage("You are an expert in English, and your task is to only correct grammar of provide sentance. Please correct the grammar"),
         new SystemChatMessage("You are an expert in .NET, and your task is to only create c# code, so please generate C# code"),
        new UserChatMessage(userInput)
    };

    ChatCompletion chatResult=chatClient.CompleteChat(messages);
    foreach(var chatMessage in chatResult.Content)
    {
        Console.WriteLine($"{chatMessage.Text}");
    }
}