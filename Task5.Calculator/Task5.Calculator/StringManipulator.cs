namespace Task5.Calculator
{
    public static class StringManipulator
    {
        public static string RemoveFirstAndLastOccurrence(this string input, char charToRemoveStart, char charToRemoveEnd)
        {
            int startIndex = input.IndexOf(charToRemoveStart);
            int endIndex = input.LastIndexOf(charToRemoveEnd);

            if (startIndex != -1 && endIndex != -1)
            {
                return input.Remove(endIndex, input.Length - endIndex).Remove(startIndex, 1);
            }

            return input;
        }

        public static string ReplaceFirstOccurrence(this string input, string substringToReplace, string replacement)
        {
            int index = input.IndexOf(substringToReplace);

            var result = input.Remove(index, substringToReplace.Length);

            result = result.Insert(index, replacement);

            return result;
        }
    }
}
