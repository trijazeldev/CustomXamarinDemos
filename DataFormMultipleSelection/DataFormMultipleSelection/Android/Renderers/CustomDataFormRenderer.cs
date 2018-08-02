using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Com.Telerik.Widget.Autocomplete;
using Com.Telerik.Widget.Dataform.Visualization.Core;
using Com.Telerik.Widget.Dataform.Visualization.Editors;
using DataFormMultipleSelection.Portable.DataModels;
using Telerik.XamarinForms.Input.DataForm;
using Telerik.XamarinForms.InputRenderer.Android;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Input.RadDataForm), typeof(DataFormMultipleSelection.Android.Renderers.CustomDataFormRenderer))]
namespace DataFormMultipleSelection.Android.Renderers
{
    public class CustomDataFormRenderer : DataFormRenderer
    {
        private static List<string> _selectedTokens;

        public CustomDataFormRenderer(Context context) : base(context)
        {
            _selectedTokens = new List<string>();
        }

        protected override void UpdateEditor(EntityPropertyEditor editor, IEntityProperty property)
        {
            base.UpdateEditor(editor, property);

            if (property.PropertyName == "ContactTimePreference")
            {
                var autoCompleteEditor = (DataFormRadAutoCompleteEditor)editor;

                if (autoCompleteEditor.AutoCompleteView != null)
                {
                    autoCompleteEditor.AutoCompleteView.DisplayMode = Com.Telerik.Widget.Autocomplete.DisplayMode.Tokens;
                    autoCompleteEditor.AutoCompleteView.TokensLayoutMode = Com.Telerik.Widget.Autocomplete.LayoutMode.Horizontal;

                    autoCompleteEditor.AutoCompleteView.AddTokenAddedListener(new PreferenceTokenAddedListenerImpl());
                    autoCompleteEditor.AutoCompleteView.RemoveTokenRemovedListener(new PreferenceTokenRemovedListenerImpl());
                }
            }

            // TODO - Uncomment after enum approach works
            //if (property.PropertyName == "Topic")
            //{
            //    var autoCompleteEditor = (DataFormRadAutoCompleteEditor)editor;

            //    if (autoCompleteEditor.AutoCompleteView != null)
            //    {
            //        autoCompleteEditor.AutoCompleteView.DisplayMode = Com.Telerik.Widget.Autocomplete.DisplayMode.Tokens;
            //        autoCompleteEditor.AutoCompleteView.TokensLayoutMode = Com.Telerik.Widget.Autocomplete.LayoutMode.Horizontal;

            //        autoCompleteEditor.AutoCompleteView.AddTokenAddedListener(new TopicTokenAddedListenerImpl());
            //        autoCompleteEditor.AutoCompleteView.RemoveTokenRemovedListener(new TopicTokenRemovedListenerImpl());
            //    }
            //}
        }

        #region Enum list event listeners


        internal class PreferenceTokenAddedListenerImpl : Java.Lang.Object, ITokenAddedListener
        {
            public void OnTokenAdded(RadAutoCompleteTextView p0, TokenModel p1)
            {
                var enumValue = (TimePreference)Enum.Parse(typeof(TimePreference), p1.Text);

                var names = p0.Tokens.Select(t => t.Model.Text).ToList();

                var oldValue = GetTimePreferenceValues(names);
                
                if (oldValue != null)
                {
                    // add item to flagged enum
                    enumValue = enumValue | (TimePreference)oldValue;
                }

                p0.Text = enumValue.ToString();
            }
        }

        internal class PreferenceTokenRemovedListenerImpl : Java.Lang.Object, ITokenRemovedListener
        {
            public void OnTokenRemoved(RadAutoCompleteTextView p0, TokenModel p1)
            {
                var newEnumValue = (TimePreference)Enum.Parse(typeof(TimePreference), p1.Text);

                var names = p0.Tokens.Select(t => t.Model.Text).ToList();
                var oldEnumValue = GetTimePreferenceValues(names);
                oldEnumValue = oldEnumValue & ~newEnumValue;

                p0.Text = oldEnumValue.ToString();
            }
        }

        // This works as expected, see MainPage.xaml.cs Line 51
        private static TimePreference? GetTimePreferenceValues(IList<string> stringNames)
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

        #endregion

        // TODO - Uncomment after enum approach works
        //#region string list event listners

        //private class TopicTokenAddedListenerImpl : Java.Lang.Object, ITokenAddedListener
        //{
        //    public void OnTokenAdded(RadAutoCompleteTextView p0, TokenModel p1)
        //    {
        //        if (_selectedTokens != null)
        //        {
        //            _selectedTokens.Add(p1.Text);
        //            p0.Text = string.Join(", ", _selectedTokens);
        //        }
        //    }
        //}

        //private class TopicTokenRemovedListenerImpl : Java.Lang.Object, ITokenRemovedListener
        //{
        //    public void OnTokenRemoved(RadAutoCompleteTextView p0, TokenModel p1)
        //    {
        //        if (_selectedTokens != null)
        //        {
        //            _selectedTokens.Remove(p1.Text);
        //            p0.Text = string.Join(", ", _selectedTokens);
        //        }
        //    }
        //}

        //#endregion
    }
}