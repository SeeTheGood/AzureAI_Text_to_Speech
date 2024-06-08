using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

// Import namespaces
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
class Program
{
    private static SpeechConfig speechConfig;
    static async Task Main(string[] args)
    {
        try
        {
            string svcKey = "De6ccffd779146abb0524c7c37c0c717";
            string svcRegion = "westus";

            // Configure speech service
            speechConfig = SpeechConfig.FromSubscription(svcKey, svcRegion);

            // Synthesize text to speech
            await TellTime();
            // await SpeakText(@"This is a test of the emergency broadcast system. This is only a test.
            // Had this been a real emergency, you would have been directed to do something important.");

            // await SpeakSSML();

            // await SpeakUsingFile();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static async Task TellTime()
    {
        var now = DateTime.Now;
        string responseText = "Your attention please. The time is " + now.Hour.ToString() + ":" + now.Minute.ToString("D2");

        // Configure speech synthesis
        speechConfig.SpeechSynthesisVoiceName = "en-ZA-LukeNeural";
        using SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer(speechConfig);

        // Synthesize spoken output
        SpeechSynthesisResult speak = await speechSynthesizer.SpeakTextAsync(responseText);
        if (speak.Reason != ResultReason.SynthesizingAudioCompleted)
        {
            Console.WriteLine(speak.Reason);
        }

        // Print the response
        Console.WriteLine(responseText);
    }
    static async Task SpeakText(string strInput)
    {
        // Configure speech synthesis
        speechConfig.SpeechSynthesisVoiceName = "de-DE-KatjaNeural";
        using SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer(speechConfig);

        // Synthesize spoken output
        SpeechSynthesisResult speak = await speechSynthesizer.SpeakTextAsync(strInput);

        if (speak.Reason != ResultReason.SynthesizingAudioCompleted)
        {
            Console.WriteLine(speak.Reason);
        } 