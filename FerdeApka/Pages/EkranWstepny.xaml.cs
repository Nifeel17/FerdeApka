using CommunityToolkit.Maui.Views;
using FerdeApka.Pages.Popuppages;

namespace FerdeApka.Pages;

public partial class EkranWstepny : ContentPage
{
	public EkranWstepny()
	{
		InitializeComponent();
	}

    private async void LoginWithAccount(object sender, EventArgs e)
    {
        if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            await Navigation.PushAsync(new EkranLogowania());
        else
            this.ShowPopup(new PopupPotrzebnyInternet());
    }

    private void LoginWithFacebook(object sender, EventArgs e)
    {
        this.ShowPopup(new PopupLogowanieZFacebooka());
    }

    private void PassedLogin(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new StronaGlowna());
    }
}