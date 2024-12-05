using System.Text;

namespace T9_Spelling.Services
{
    public static class WordsToPhoneService
    {
        private static Dictionary<char, string> phone = new Dictionary<char, string>()
        {
            { 'a', "2" },
            { 'b', "22" },
            { 'c', "222" },
            { 'd', "3" },
            { 'e', "33" },
            { 'f', "333" },
            { 'g', "4" },
            { 'h', "44" },
            { 'i', "444" },
            { 'j', "5" },
            { 'k', "55" },
            { 'l', "555" },
            { 'm', "6" },
            { 'n', "66" },
            { 'o', "666" },
            { 'p', "7" },
            { 'q', "77" },
            { 'r', "777" },
            { 's', "7777" },
            { 't', "8" },
            { 'u', "88" },
            { 'v', "888" },
            { 'w', "9" },
            { 'x', "99" },
            { 'y', "999" },
            { 'z', "9999" },
            { ' ', "0" }
        };

        public static string ConvertToPhoneButtons(string text)
        {
            StringBuilder result = new StringBuilder();
            char? lastButton = null;

            foreach (char c in text.ToLower())
            {
                if (phone.ContainsKey(c))
                {
                    string currentSequence = phone[c];
                    char currentButton = currentSequence[0];

                    if (lastButton == currentButton)
                    {
                        result.Append(" ");
                    }

                    result.Append(currentSequence);
                    lastButton = currentButton;
                }
            }

            return result.ToString();
        }
    }
}
