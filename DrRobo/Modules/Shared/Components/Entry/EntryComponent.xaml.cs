using System.Linq;
using DrRobo.Modules.Shared.Components.ComponentModel.EntryModel;
using DrRobo.Utils;
using Xamarin.Forms;

namespace DrRobo.Modules.Shared.Components.Entry
{
    public partial class EntryComponent : Xamarin.Forms.Entry
    {
        public static readonly BindableProperty MaskProperty = BindableProperty.Create(nameof(Mask), typeof(string), typeof(EntryComponent), string.Empty, propertyChanged:
            (bindable, value, newValue)=>
            {
                var entry = (EntryComponent)bindable;
                if (newValue == null)
                {
                    var maskbehavior = entry.Behaviors.FirstOrDefault(mask => mask is MaskedBehavior);
                    if (maskbehavior != null)
                        entry.Behaviors.Remove(maskbehavior);

                    var validatebehavior = entry.Behaviors.FirstOrDefault(validate => validate is ValidateCPFBehavior);
                    if (validatebehavior != null)
                        entry.Behaviors.Remove(validatebehavior);

                    entry.TextColor = Util.GetResource<Color>("BlackColor");
                }
                else
                {
                    var mask = newValue?.ToString();
                    entry = (EntryComponent)bindable;
                    entry.Behaviors.Add(new MaskedBehavior() { Mask = mask });

                    if (mask is Utils.Constants.Mask.CPF)
                        entry.Behaviors.Add(new ValidateCPFBehavior());
                }
            });

        public EntryComponent()
        {
            InitializeComponent();
        }

        public string Mask
        {
            get => (string)GetValue(MaskProperty);
            set => SetValue(MaskProperty, value);
        }
    }
}