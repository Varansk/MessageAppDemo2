namespace MessageAppDemo2.Backend.SystemData.ExtensionClasses
{
    public static class IntExtension
    {
        /// <summary>
        /// Checks whether the value is within the given value range.
        /// </summary>
        /// <param name="ValueBiggerThan">The Value must be Bigger than or equal to ValueBiggerThan according to the selected option.</param>
        /// <param name="ValueSmallerThan">The value must be smaller or equal to ValueSmallerThan according to the selected option.</param>
        public static bool IsBetween(this int value, int ValueBiggerThan, int ValueSmallerThan, IncludeOptions IsValueBiggerThanIncludes = IncludeOptions.NotIncluding, IncludeOptions IsValueSmallerThanIncludes = IncludeOptions.NotIncluding)
        {
            if (IsValueBiggerThanIncludes == IncludeOptions.Including && IsValueSmallerThanIncludes == IncludeOptions.Including)
            {
                return value >= ValueBiggerThan && value <= ValueSmallerThan;
            }
            else if (IsValueBiggerThanIncludes == IncludeOptions.Including && IsValueSmallerThanIncludes == IncludeOptions.NotIncluding)
            {
                return value >= ValueBiggerThan && value < ValueSmallerThan;
            }
            else if (IsValueBiggerThanIncludes == IncludeOptions.NotIncluding && IsValueSmallerThanIncludes == IncludeOptions.Including)
            {
                return value > ValueBiggerThan && value <= ValueSmallerThan;
            }
            else if (IsValueBiggerThanIncludes == IncludeOptions.NotIncluding && IsValueSmallerThanIncludes == IncludeOptions.NotIncluding)
            {
                return value > ValueBiggerThan && value < ValueSmallerThan;
            }
            return false;
        }
        /// <summary>
        /// Checks whether the value is within the given value range.
        /// </summary>
        /// <param name="ValueBiggerThan">Value must be bigger than ValueBiggerThan.</param>
        /// <param name="ValueSmallerThan">Value must be smaller than ValueSmallerThan.</param>
        public static bool IsBetween(this int value, int ValueBiggerThan, int ValueSmallerThan)
        {
            return value > ValueBiggerThan && value < ValueSmallerThan;
        }
        public enum IncludeOptions
        {
            Including,
            NotIncluding
        }
    }
}
