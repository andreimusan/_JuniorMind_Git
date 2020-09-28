using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (input is null)
            {
                return false;
            }

            return input[0] == '"' && input[^1] == '"';
        }
    }
}
