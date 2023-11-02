using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechLib;
using System.Speech.Recognition;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Globalization;
using System.Diagnostics;
using System.Net;

namespace WhyNot
{
    internal class Proccess
    {
        string[] sentences;
        string sentence;

        public Proccess()
        {
            sentences = new string[2];

        }

        public void Speak()
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine(new CultureInfo("en-US"));
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            try
            {
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();
                sentence = res.Text;
                if (sentence.ToLower() == "open" || sentence.ToLower() == "write")
                    sentences[0] = sentence;
                else
                    sentences[1] = sentence;

                Console.WriteLine(sentence);
                Console.WriteLine();
                Console.WriteLine("0 : " + sentences[0]);
                Console.WriteLine("1 : " + sentences[1]);
                Console.WriteLine();

                if (sentences[0].ToLower() == "open")
                    Open();
                if (sentences[0].ToLower() == "write")
                    Write();

            }
            catch (Exception ex)
            {
                sentence = "";
                Console.WriteLine(ex.Message);
            }
        }
        public void Write()
        {
            try
            {
                SpeechRecognitionEngine sr = new SpeechRecognitionEngine(new CultureInfo("en-US"));
                Grammar g = new DictationGrammar();
                sr.LoadGrammar(g);
                Console.Write("Name : ");
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();
                string Name = res.Text;
                Console.WriteLine(Name);
                Console.WriteLine();
                Console.Write("Text : ");

                StringBuilder Text = new();

                bool check = true;
                while (check)
                {
                    sr.SetInputToDefaultAudioDevice();
                    RecognitionResult res2 = sr.Recognize();
                    Text.Append(res2.Text + " ");


                    if (Console.ReadLine().ToLower() == "false")
                        check = false;
                    else
                        Console.Clear();

                    Console.WriteLine("Name : " + Name);
                    Console.WriteLine();
                    Console.WriteLine("Text : " + Text);

                }


                File.AppendAllText(@"C:\Users\User\Desktop\Text" + "\\" + Name + ".txt", Text.ToString());
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Try Again.");
                Console.WriteLine();
                Write();
            }
        }

        public void Open()
        {
          

            if (sentences[1].ToLower().Contains("chrome"))
            {
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
            }
            else if (sentences[1].ToLower().Contains("notepad"))
            {
                Process.Start("notepad.exe");
            }
            else if (sentences[1].ToLower().Contains("calculator"))
            {
                Process.Start("calc.exe");
            }
        }


    }
}
