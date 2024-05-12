
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

    private async void ZalogowanieUzytkownika(object sender, EventArgs e)
    {
        if (email_uzytkownika_entry.Text == null || email_uzytkownika_entry.Text == "" || haslo_uzytkownika_entry==null || haslo_uzytkownika_entry.Text=="")
            return;

        HttpClient klient = new HttpClient();

        var dictToPost = new Dictionary<string, string> { { "login", email_uzytkownika_entry.Text }, { "haslo", haslo_uzytkownika_entry.Text } };

        var dataToPost = new FormUrlEncodedContent(dictToPost);

        var checkData = await klient.PostAsync("http://localhost/FerdeApi/", dataToPost);//tak, localhost. Gdyby by³ to projekt wart rozwiajania to szuka³bym hostingu, ale to projekt na którym uczy³em sie podstaw maui. Poprostu dodam logowanie i uciekam

        var content = await checkData.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(content))
            return;
        else
            Application.Current.MainPage = new NavigationPage(new StronaGlowna());//sprawdzam tylko czy uzytkownik istnieje, jego nazwa pozniej nie ma znaczenia
    }
}