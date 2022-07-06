using System;
using DrRobo.Modules.Shared.Components.Entry;
using DrRobo.Modules.Shared.ViewModels;
using DrRobo.Utils;
using Xamarin.Forms;

namespace DrRobo.Modules.Shared.Components.ComponentModel.EntryModel
{
    public class ValidateCPFBehavior : Behavior<EntryComponent>
    {
        public int MaxLength { get; set; } = 14;
        public int MinLength { get; set; } = 14;

        protected override void OnAttachedTo(EntryComponent bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(EntryComponent bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (EntryComponent)sender;
            if (entry.Text != null)
            {
                if (entry.Text.Length > this.MaxLength)
                {
                    string entryText = entry.Text;

                    entryText = entryText.Remove(entryText.Length - 1);

                    entry.Text = entryText;
                }

                if (MinLength >= 0)
                {
                    if (entry.Text.Length < this.MinLength || !Util.ValidateCPF(entry.Text))
                        ((EntryComponent)sender).TextColor = Util.GetResource<Color>("InvalidColor");
                    else
                        ((EntryComponent)sender).TextColor = Util.GetResource<Color>("BlackColor");
                }
            }
            
        }
    }
}