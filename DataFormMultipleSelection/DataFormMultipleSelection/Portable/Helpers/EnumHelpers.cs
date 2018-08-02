using System;
using System.Collections.Generic;
using DataFormMultipleSelection.Portable.DataModels;

namespace DataFormMultipleSelection.Portable.Helpers
{
    public static class EnumHelpers
    {
        public static TimePreference? GetTimePreferenceValues(IList<string> stringNames)
        {
            TimePreference? oldValue = null;

            foreach (var name in stringNames)
            {
                var enumVal = Enum.Parse(typeof(TimePreference), name) as TimePreference?;

                if (enumVal == null)
                    continue;

                oldValue = oldValue == null ? enumVal : oldValue | enumVal;
            }

            return oldValue;
        }

        public static List<string> GetTimePreferenceNames()
        {
            return new List<string>(Enum.GetNames(typeof(TimePreference)));
        }
    }
}
