using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Net;
using System.Speech.Synthesis;
using DevExpress.XtraEditors;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmSpeech : DevExpress.XtraEditors.XtraForm
    {
        public frmSpeech()
        {
            InitializeComponent();
            Voice.Speech("");
            //speech();
        }

        private void speech()
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            foreach (InstalledVoice voice in
                synthesizer.GetInstalledVoices(new CultureInfo("en-US")))
            {
                VoiceInfo info = voice.VoiceInfo;
                Voice.Speech("আমি এখানে" + info);
                XtraMessageBox.Show("আমি এখানে" + info);
            }

            Voice.Speech("আমি এখানে");
            // Voice.Speech("I am here");
        }

        public static void LanguageMap(Dictionary<string, string> language)

        {

            language.Add("Afrikaans", "af");

            language.Add("Albanian", "sq");

            language.Add("Arabic", "ar");

            language.Add("Armenian", "hy");

            language.Add("Azerbaijani", "az");

            language.Add("Basque", "eu");

            language.Add("Belarusian", "be");

            language.Add("Bengali", "bn");

            language.Add("Bulgarian", "bg");

            language.Add("Catalan", "ca");

            language.Add("Chinese", "zh-CN");

            language.Add("Croatian", "hr");

            language.Add("Czech", "cs");

            language.Add("Danish", "da");

            language.Add("Dutch", "nl");

            language.Add("English", "en");

        }
    }

}
