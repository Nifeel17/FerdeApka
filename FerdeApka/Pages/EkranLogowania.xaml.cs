
using CommunityToolkit.Maui.Views;
using FerdeApka.Pages.Popuppages;

namespace FerdeApka.Pages;

public partial class EkranLogowania : ContentPage
{
	public EkranLogowania()
	{
		InitializeComponent();
	}

    private async void PowrotDoWstepu(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void PopupInfoOLogowaniu(object sender, EventArgs e)
    {
        this.ShowPopup(new PopupInformacjaLogowanie());
    }

    private void ZalogowanieUzytkownika(object sender, EventArgs e)
    {
        //utworzyc logike do logowania, dluzsze zadanie, tymczasowo zostawione na potem
       Application.Current.MainPage = new NavigationPage(new StronaGlowna());
    }
}