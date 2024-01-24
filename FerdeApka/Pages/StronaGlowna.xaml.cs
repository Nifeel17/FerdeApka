using CommunityToolkit.Maui.Views;
using FerdeApka.Pages.Popuppages;

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

    private void PokazPopupOAplikacji(object sender, EventArgs e)
    {
        this.ShowPopup(new PopupInfoOAplikacji());
    }

    private void LogoFerdkaKlikniete(object sender, EventArgs e)
    {
        if (DzwiekNaGlownymEkranie.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused || DzwiekNaGlownymEkranie.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Stopped)
        {
            DzwiekNaGlownymEkranie.SeekTo(TimeSpan.Zero);
            DzwiekNaGlownymEkranie.Play();
        }
    }
}