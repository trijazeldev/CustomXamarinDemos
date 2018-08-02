using System;

namespace DataFormMultipleSelection.Portable.DataModels
{
[Flags]
public enum TimePreference
{
    Morning = 1,
    Afternoon = 2,
    Evening = 4,
    Weekend = 8
}
}
