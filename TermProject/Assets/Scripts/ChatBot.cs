using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;

public class ChatBot : MonoBehaviour
{
    protected OpenAIApi openAI;
    protected string apiKey;
    protected List<ChatMessage> messages = new List<ChatMessage>();
    // Start is called before the first frame update
    public virtual void Start()
    {
        apiKey = System.Environment.GetEnvironmentVariable("YOUR_API_KEY");
        if (string.IsNullOrEmpty(apiKey))
        {
            Debug.LogError("API KEY 설정이 안되어 있음, 설정해도 오류가 난다면 재부팅 해보길 바람");
            return;
        }

        openAI = new OpenAIApi(apiKey);
        //CallGPT(prompt);
    }
    public OpenAIApi getOpenAI()
    {
        return openAI;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public async void CallOpenAI(string prompt)
    {
        var askMessage = new ChatMessage()
        {
            Role = "user",
            Content = prompt
        };

        Debug.Log(prompt);
        messages.Add(askMessage);
        var completionResponse = await openAI.CreateChatCompletion(new CreateChatCompletionRequest()
        {
            Model = "gpt-3.5-turbo-0613",
            Messages = messages
        });
        string response = completionResponse.Choices[0].Message.Content;
        Debug.Log(response);
    }

}
