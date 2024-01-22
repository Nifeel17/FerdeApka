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
		await Navigation.PushAsync(new EkranLogowania());
    }

    private void LoginWithFacebook(object sender, EventArgs e)
    {
        this.ShowPopup(new PopupLogowanieZFacebooka());
    }
}