using System.Collections;
using System.Collections.Generic;
using DataFormMultipleSelection.Portable.Helpers;
using Telerik.XamarinForms.Input.DataForm;

namespace DataFormMultipleSelection.Portable.Data
{
    public class DataFormSourceProvider : PropertyDataSourceProvider
    {
        public override IList GetSourceForKey(object key)
        {
            if (key.ToString().Equals("ContactTimePreference"))
            {
                return EnumHelpers.GetTimePreferenceNames();
            }
            
            if (key.ToString().Equals("Topic"))
            {
                return new List<string> { "Sign in Problem", "Subscription", "Billing", "Technical Support" };
            }

            return null;
        }
    }
}
