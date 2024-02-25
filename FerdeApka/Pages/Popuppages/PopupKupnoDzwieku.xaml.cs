using System;
using CommunityToolkit.Maui.Views;

namespace FerdeApka.Pages.Popuppages;

public partial class PopupKupnoDzwieku : Popup
{
    int indexG = 0;
	public PopupKupnoDzwieku(int index)
	{
		InitializeComponent();
        indexG = index;
		
	}

    private async void Kupujemy(object sender, EventArgs e)
    {
        if (Preferences.Default.Get("FerdePunkty", 0) >= 20)
        {
            Preferences.Default.Set("FerdePunkty", Preferences.Default.Get("FerdePunkty", 0) - 20);
            char[] odblokowane = Preferences.Default.Get("OdblokowaneSoundbary", "011000000").ToCharArray();
            odblokowane[indexG] = '1';
            Preferences.Default.Set("OdblokowaneSoundbary", new string(odblokowane));
            await CloseAsync(true);
        }
        else
        {
            buttonKup.BackgroundColor = Color.FromArgb("#ed2e0c");
            await Task.Delay(2000);
            buttonKup.BackgroundColor = Color.FromArgb("#FC44FC");
        }
        
    }

    private async void Zamknij(object sender, EventArgs e)
    {
        await CloseAsync(false);
    }
}