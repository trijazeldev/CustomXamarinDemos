using System;
using System.Collections.Generic;
using DataFormMultipleSelection.Portable.DataModels;
using Telerik.XamarinForms.Common.iOS;
using Telerik.XamarinForms.InputRenderer.iOS;
using TelerikUI;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Input.RadDataForm), typeof(DataFormMultipleSelection.iOS.Renderers.CustomDataFormRenderer))]
namespace DataFormMultipleSelection.iOS.Renderers
{
    public class CustomDataFormRenderer : DataFormRenderer
    {
        protected override void UpdateEditor(TelerikUI.TKDataFormEditor editor, Telerik.XamarinForms.Input.DataForm.IEntityProperty property)
        {
            base.UpdateEditor(editor, property);

            if (property.PropertyName == "ContactTimePreference")
            {
                var autoCompleteEditor = (TKDataFormAutoCompleteInlineEditor)editor;
                if (autoCompleteEditor.AutoCompleteView.Delegate == null)
                {
                    autoCompleteEditor.AutoCompleteView.Delegate = new CustomAutoCompleteEnumDelegate(autoCompleteEditor);
                    autoCompleteEditor.AutoCompleteView.DisplayMode = TKAutoCompleteDisplayMode.Tokens;
                }
            }
            if (property.PropertyName == "Topic")
            {
                var autoCompleteEditor = (TKDataFormAutoCompleteInlineEditor)editor;
                if (autoCompleteEditor.AutoCompleteView.Delegate == null)
                {
                    autoCompleteEditor.AutoCompleteView.Delegate = new CustomAutoCompleteListDelegate(autoCompleteEditor);
                    autoCompleteEditor.AutoCompleteView.DisplayMode = TKAutoCompleteDisplayMode.Tokens;
                }
            }
        }

        public class CustomAutoCompleteEnumDelegate : TKAutoCompleteDelegate
        {
            private readonly TKDataFormAutoCompleteInlineEditor tKDataFormAutoCompleteInlineEditor;

            public CustomAutoCompleteEnumDelegate(TKDataFormAutoCompleteInlineEditor tKDataFormAutoCompleteInlineEditor)
            {
                this.tKDataFormAutoCompleteInlineEditor = tKDataFormAutoCompleteInlineEditor;
            }

            public override void DidAddToken(TKAutoCompleteTextView autocomplete, TKAutoCompleteToken token)
            {
                var enumValue = (TimePreference)Enum.Parse(typeof(TimePreference), token.Text);
                var oldValue = (TimePreference?)tKDataFormAutoCompleteInlineEditor.Value.ToObject();

                if (oldValue != null)
                {
                    // add item to flagged enum
                    enumValue = enumValue | (TimePreference)oldValue;
                }

                tKDataFormAutoCompleteInlineEditor.Value = enumValue.ToNSObject();
            }

            public override void DidRemoveToken(TKAutoCompleteTextView autocomplete, TKAutoCompleteToken token)
            {
                var newEnumValue = (TimePreference)Enum.Parse(typeof(TimePreference), token.Text);
                var oldEnumValue = ((TimePreference)tKDataFormAutoCompleteInlineEditor.Value.ToObject());

                // remove item from flagged enum
                oldEnumValue = oldEnumValue & ~newEnumValue;

                tKDataFormAutoCompleteInlineEditor.Value = oldEnumValue.ToNSObject();
            }
        }

        public class CustomAutoCompleteListDelegate : TKAutoCompleteDelegate
        {
            private readonly TKDataFormAutoCompleteInlineEditor tKDataFormAutoCompleteInlineEditor;
            private readonly List<string> tokens = new List<string>();

            public CustomAutoCompleteListDelegate(TKDataFormAutoCompleteInlineEditor tKDataFormAutoCompleteInlineEditor)
            {
                this.tKDataFormAutoCompleteInlineEditor = tKDataFormAutoCompleteInlineEditor;
            }

            public override void DidAddToken(TKAutoCompleteTextView autocomplete, TKAutoCompleteToken token)
            {
                this.tokens.Add(token.Text);
                tKDataFormAutoCompleteInlineEditor.Value = this.tokens.ToNSObject();
            }

            public override void DidRemoveToken(TKAutoCompleteTextView autocomplete, TKAutoCompleteToken token)
            {
                this.tokens.Remove(token.Text);
                tKDataFormAutoCompleteInlineEditor.Value = this.tokens.ToNSObject();
            }
        }
    }
}