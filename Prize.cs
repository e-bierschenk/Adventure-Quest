using System;

namespace Quest
{
    public class Prize
    {
        private string _text;

        public Prize(string prizeText)
        {
            _text = prizeText;
        }

        public void ShowPrize(Adventurer gandalf)
        {
            if (gandalf.Awesomeness >= 0)
            {
                for(int i = 0; i < gandalf.Awesomeness; i++)
                {
                    Console.WriteLine(_text);
                }
            } else 
            {
                Console.WriteLine($"Sorry {gandalf.Name}, your princess is in another castle.");
            }
        }
    }
}