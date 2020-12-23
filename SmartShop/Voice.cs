using System;
using System.Linq;
using System.Speech.Synthesis;

namespace SmartShop
{
    public static class Voice
    {
        public static void Speech(string message)
        {

            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            // synthesizer.Volume = 100;  // 0...100
            // synthesizer.Rate = -2;     // -10...10
            synthesizer.SetOutputToDefaultAudioDevice();
            synthesizer.Speak(message);
        }
    }
}
