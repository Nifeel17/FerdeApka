namespace FerdeApka.Pages;

public partial class StronaGlowna : ContentPage
{
	public StronaGlowna()
	{
		InitializeComponent();
	}

    private async void PrzejdzDoStronySoundbarow(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavigationPage(new SoundbarMenu()));
    }
}