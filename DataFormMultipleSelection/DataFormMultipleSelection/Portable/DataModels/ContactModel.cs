using System.Collections.Generic;
using Telerik.XamarinForms.Common.DataAnnotations;

namespace DataFormMultipleSelection.Portable.DataModels
{
    public class ContactModel
    {
        [DisplayOptions(Header = "Email")]
        public string Email { get; set; }

        [DisplayOptions(Header = "Contact Preference")]
        public TimePreference? ContactTimePreference { get; set; }

        //[DisplayOptions(Header = "Topic")]
        //public List<string> Topic { get; set; }
    }
}
