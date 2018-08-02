using System;
using System.Collections.Generic;
using DataFormMultipleSelection.Portable.Data;
using DataFormMultipleSelection.Portable.DataModels;
using DataFormMultipleSelection.Portable.Helpers;
using Telerik.XamarinForms.Input;
using Xamarin.Forms;

namespace DataFormMultipleSelection.Portable
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

		    dataForm.Source = new ContactModel();
		    dataForm.PropertyDataSourceProvider = new DataFormSourceProvider();
		    dataForm.CommitMode = CommitMode.Manual;

		    dataForm.RegisterEditor(nameof(ContactModel.Email), EditorType.TextEditor);
            dataForm.RegisterEditor(nameof(ContactModel.ContactTimePreference), EditorType.AutoCompleteEditor);

		    // TODO - Uncomment after enum approach works
            //dataForm.RegisterEditor(nameof(ContactModel.Topic), EditorType.AutoCompleteEditor);

        }

        private void CommitButtonClicked(object sender, EventArgs e)
	    {
            dataForm.CommitAll();

            var sourceItem = (ContactModel)dataForm.Source;

            SelectedPreferenceLabel.Text = "Preferences: " + sourceItem.ContactTimePreference;

            // TODO - Uncomment after enum approach works
            //if (sourceItem.Topic != null)
            //{
            //    SelectedTopicsLabel.Text = "Topics: " + string.Join(", ", sourceItem.Topic);
            //}


            // --- PARSING LOGIC TEST ---
            // Enumerate TimePreference values as a List<string>
            var names = new List<string>(Enum.GetNames(typeof(TimePreference)));

            // Parse list back into single enunm
            var result = EnumHelpers.GetTimePreferenceValues(names);

            TestOutputLabel.Text = $"Enum.Parse Test: " + result;
        }
        
    }
}
