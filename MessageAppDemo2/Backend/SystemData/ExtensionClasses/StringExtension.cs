namespace MessageAppDemo2.Backend.SystemData.ExtensionClasses
{
    public static class StringExtension
    {
        /// <summary>
        /// All letters in the value check whether it meets the given criteria.
        /// </summary>
        /// <param name="ControlType">Which controls you want to apply to the given textual expression.</param>
        /// <returns>Returns true if all letters in the given value meet the given condition, false if they do not meet the condition, are null or contain white spaces.</returns>
        public static bool IsSuitableForGivenType(this string value, StringControlTypes ControlType)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            bool ControlOfTheValue = false;

            for (int i = 0; i < value.Length; i++)
            {
                switch (ControlType)
                {
                    case StringControlTypes.IsLetter:
                        ControlOfTheValue = char.IsLetter(value, i);
                        break;
                    case StringControlTypes.IsDigit:
                        ControlOfTheValue = char.IsDigit(value, i);
                        break;
                    case StringControlTypes.IsLetterOrDigit:
                        ControlOfTheValue = char.IsLetterOrDigit(value, i);
                        break;
                }

                if (!ControlOfTheValue)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Checks whether the given textual value contains a value with certain criteria.
        /// </summary>
        /// <param name="Type">Check if it contains the value in the given criterion.</param>
        /// <returns>Returns true if the given criterion contains at least one letter, false if no letter matches or the value is null or whitespace.</returns>
        public static bool IsContainsGivenType(this string value, LetterTypes Type)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            value = value.RemoveExtraWhiteSpaces(WhiteSpaceOptions.DeleteAllWhiteSpaces);

            bool Control = false;
            for (int i = 0; i < value.Length; i++)
            {
                switch (Type)
                {
                    case LetterTypes.Letter:
                        Control = char.IsLetter(value, i);
                        break;
                    case LetterTypes.LetterOrDigit:
                        Control = char.IsLetterOrDigit(value, i);
                        break;
                    case LetterTypes.Digit:
                        Control = char.IsDigit(value, i);
                        break;
                    case LetterTypes.Lower:
                        Control = char.IsLower(value, i);
                        break;
                    case LetterTypes.Upper:
                        Control = char.IsUpper(value, i);
                        break;
                    default:
                        break;
                }
                if (Control)
                {
                    return true;
                }

            }

            return false;
        }
        /// <summary>
        /// Allows operations about spaces in string expressions.
        /// </summary>
        /// <param name="WhiteSpacesDesicion">Action to be taken regarding spaces in String expression.</param>
        /// <returns>Returns the processed string expression.</returns>
        public static string RemoveExtraWhiteSpaces(this string value, WhiteSpaceOptions WhiteSpacesDesicion)
        {
            switch (WhiteSpacesDesicion)
            {
                case WhiteSpaceOptions.DeleteAllWhiteSpaces:
                    value = value.Replace(" ", "");
                    break;

                case WhiteSpaceOptions.ReduceMultipleSpacesToOneAndTrim:
                    while (value != value.Replace("  ", " "))
                    {
                        value = value.Replace("  ", " ");
                    }
                    value = value.Trim();
                    break;

                case WhiteSpaceOptions.Trim:
                    value = value.Trim();
                    break;
            }
            return value;
        }


    }
    /// <summary>
    /// Control types of string value.
    /// </summary>
    public enum StringControlTypes
    {
        IsLetter, IsLetterOrDigit, IsDigit
    }
    /// <summary>
    /// Options about white spaces
    /// </summary>
    public enum WhiteSpaceOptions
    {
        DeleteAllWhiteSpaces, ReduceMultipleSpacesToOneAndTrim, Trim
    }
    /// <summary>
    /// Types about letters
    /// </summary>
    public enum LetterTypes
    {
        Letter, LetterOrDigit, Digit, Lower, Upper
    }


}