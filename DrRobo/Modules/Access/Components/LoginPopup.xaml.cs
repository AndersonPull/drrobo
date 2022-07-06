using System;
using System.Threading.Tasks;
using DrRobo.Modules.Access.Models;
using DrRobo.Utils;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace DrRobo.Modules.Access.Components
{
    public partial class LoginPopup : PopupPage
    {
        public LoginPopup()
        {
            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Entry_login.Focus();
            Button_login.Style = Util.GetResource<Style>("PrimaryButton");
            Button_login.Style = Util.GetResource<Style>("DisabledButton");
            Button_login.IsEnabled = false;
        }

        protected override void OnDisappearing()
        {
            Entry_login.Text = string.Empty;
            Entry_password.Text = string.Empty;
            Grid_login.IsVisible = true;
            Grid_password.IsVisible = false;
        }

        private void Entry_password_Focus(object sender, EventArgs e)
        {
            Entry_password.Focus();
        }

        private void Entry_login_TextChanged(object sender, TextChangedEventArgs args)
        {
            if (Entry_login.Text != null)
            {
                if (Util.ValidateCPF(Entry_login.Text))
                {
                    Label_CPF_error.IsVisible = false;
                    Button_next.IsEnabled = true;
                    Button_next.Style = Util.GetResource<Style>("PrimaryButton");
                }
                else
                {
                    Label_CPF_error.IsVisible = true;
                    Button_next.IsEnabled = false;
                    Button_next.Style = Util.GetResource<Style>("DisabledButton");
                }
            }
        }

        private void Entry_password_TextChanged(object sender, TextChangedEventArgs args)
        {
            if (Entry_password.Text != null)
            {
                if (Entry_password.Text.Length is 4)
                {
                    Button_login.IsEnabled = true;
                    Button_login.Style = Util.GetResource<Style>("PrimaryButton");
                }
                else
                {
                    Button_login.IsEnabled = false;
                    Button_login.Style = Util.GetResource<Style>("DisabledButton");
                }

                switch (Entry_password.Text.Length)
                {
                    case 1:
                        Frame_password_one.BackgroundColor = Util.GetResource<Color>("DrRoboSecondaryColor");
                        Frame_password_two.BackgroundColor = Util.GetResource<Color>("Disabled");
                        Frame_password_three.BackgroundColor = Util.GetResource<Color>("Disabled");
                        Frame_password_four.BackgroundColor = Util.GetResource<Color>("Disabled");
                        break;
                    case 2:
                        Frame_password_one.BackgroundColor = Util.GetResource<Color>("DrRoboSecondaryColor");
                        Frame_password_two.BackgroundColor = Util.GetResource<Color>("DrRoboSecondaryColor");
                        Frame_password_three.BackgroundColor = Util.GetResource<Color>("Disabled");
                        Frame_password_four.BackgroundColor = Util.GetResource<Color>("Disabled");
                        break;
                    case 3:
                        Frame_password_one.BackgroundColor = Util.GetResource<Color>("DrRoboSecondaryColor");
                        Frame_password_two.BackgroundColor = Util.GetResource<Color>("DrRoboSecondaryColor");
                        Frame_password_three.BackgroundColor = Util.GetResource<Color>("DrRoboSecondaryColor");
                        Frame_password_four.BackgroundColor = Util.GetResource<Color>("Disabled");
                        break;
                    case 4:
                        Frame_password_one.BackgroundColor = Util.GetResource<Color>("DrRoboSecondaryColor");
                        Frame_password_two.BackgroundColor = Util.GetResource<Color>("DrRoboSecondaryColor");
                        Frame_password_three.BackgroundColor = Util.GetResource<Color>("DrRoboSecondaryColor");
                        Frame_password_four.BackgroundColor = Util.GetResource<Color>("DrRoboSecondaryColor");
                        break;
                    default:
                        Frame_password_one.BackgroundColor = Util.GetResource<Color>("Disabled");
                        Frame_password_two.BackgroundColor = Util.GetResource<Color>("Disabled");
                        Frame_password_three.BackgroundColor = Util.GetResource<Color>("Disabled");
                        Frame_password_four.BackgroundColor = Util.GetResource<Color>("Disabled");
                        break;
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs args)
        {
            Grid_login.IsVisible = false;
            Grid_password.IsVisible = true;
            Entry_password.Focus();
        }

        private void Cleen_entry_login_Clicked(object sender, EventArgs args)
        {
            Entry_login.Text = "";
            Entry_login.Focus();
        }

        private async Task Close()
        {
            Entry_login.Text = "";
            Entry_password.Text = "";
            Grid_login.IsVisible = true;
            Grid_password.IsVisible = false;
            await PopupNavigation.Instance.PopAsync();
        }

        private void Button_login_Clicked(object sender, EventArgs args)
        {
            var login = new AccessModel()
            {
                CPF = Entry_login.Text,
                Password = Entry_password.Text,
            };

            MessagingCenter.Send<AccessModel>(login, "Login");

            Close();
        }
    }
}