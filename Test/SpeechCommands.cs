using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Test
{
    class SpeechCommands: Form
    {
        Form1 f;
        public void SCommands()
        {
            SpeechSynthesizer sSynth = new SpeechSynthesizer();
            PromptBuilder pBuilder = new PromptBuilder();
            SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();

            Choices sList = new Choices();
            sList.Add(new string[] {"login","signin","register","user","password","forgot"});
            Grammar gr = new Grammar(new GrammarBuilder(sList));
            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(gr);
                sRecognize.SpeechRecognized += sRecognize_speech;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
                sRecognize.Recognize();                
            }catch(Exception ex)
            {

            }
        }

        public void sRecognize_speech(object sender, SpeechRecognizedEventArgs e)
        {
           //MessageBox.Show("HEARED AS----------->>"+e.Result.Text);

            f = new Form1();
            switch (e.Result.Text)
            {
                case "login":f.LogingIn();
                                break;
                case "register":f.Register();
                                break;
                case "user":f.username();
                                break;
                case "password":f.passWord();
                                break;
                case "forgot":f.Forget();
                                break;
            }
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "SpeechCommands";
            this.Load += new System.EventHandler(this.SpeechCommands_Load);
            this.ResumeLayout(false);
        }

        private void SpeechCommands_Load(object sender, EventArgs e)
        {
        }
    }
}
