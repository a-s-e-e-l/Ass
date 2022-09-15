using System.Text;

namespace Quiz.Extentions
{
    public static class Capitalize
    {
        public static string capitalizeFirstChar(this string str)
        {
            var value = str.Trim();
            var sb = new StringBuilder();
            for (var i = 0; i < value.Length; i++)
            {
                if (value[i] == ' ')
                {
                    sb.Append(' ');
                    continue;
                }

                if (i == 0 || value[i - 1] == ' ')
                {
                    sb.Append(char.ToUpper(value[i]));
                    continue;
                }
                sb.Append(char.ToLower(value[i]));
            }
            return sb.ToString();
        }
    }
}
