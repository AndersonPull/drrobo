using System;
using System.Threading.Tasks;
using DrRobo.Utils;
using DrRobo.Utils.Constants;
using Xamarin.Forms;

namespace DrRobo.Modules.Access.Views
{
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();
            Entry_Message.Placeholder = Enums.TypeMessageEnum.CPF.Description();
            Entry_Message.Mask = Mask.CPF;
        }

        private void StackLayout_ChildAdded(object sender, ElementEventArgs args)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (Device.RuntimePlatform == Device.Android)
                    await ScrollChat.ScrollToAsync(0, StackLayoutChat.Height, true);
                else
                {
                    await Task.Delay(10);
                    await ScrollChat.ScrollToAsync(StackLayoutChat, ScrollToPosition.End, true);
                }

            });
        }
        private void Send_Clicked(object sender, EventArgs args)
        {
            if (Entry_Message.Placeholder == Enums.TypeMessageEnum.CPF.Description())
            {
                Entry_Message.Mask = null;
                Entry_Message.Keyboard = Keyboard.Text;
                Entry_Message.Placeholder = Enums.TypeMessageEnum.NAME.Description();
            }
            else if (Entry_Message.Placeholder == Enums.TypeMessageEnum.NAME.Description())
            {
                Entry_Message.Keyboard = Keyboard.Numeric;
                Entry_Message.MaxLength = 4;
                Entry_Message.IsPassword = true;
                Entry_Message.Placeholder = Enums.TypeMessageEnum.PASSWORD.Description();
            }
            else if (Entry_Message.Placeholder == Enums.TypeMessageEnum.PASSWORD.Description())
            {
                Entry_Message.Keyboard = Keyboard.Email;
                Entry_Message.IsPassword = false;
                Entry_Message.MaxLength = 100;
                Entry_Message.Placeholder = Enums.TypeMessageEnum.EMAIL.Description();
            }
        }

        void Button_Back_Clicked(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}