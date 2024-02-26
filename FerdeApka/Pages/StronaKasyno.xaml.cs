using CommunityToolkit.Maui.Views;
using FerdeApka.Pages.Popuppages;

namespace FerdeApka.Pages;

public partial class StronaKasyno : ContentPage
{
    bool czyMoznaKrecic = true;

	public StronaKasyno()
	{
		InitializeComponent();
        wyswietlanieFerdePunktow.Text = $"FerdePunkty: {Preferences.Default.Get("FerdePunkty", 0)}";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        wyswietlanieFerdePunktow.Text = $"FerdePunkty: {Preferences.Default.Get("FerdePunkty", 0)}";
    }

    private async void ZakrecFotuneWheel(object sender, EventArgs e)
    {
        if (czyMoznaKrecic==false)
        {
            return;
        }
        if (Preferences.Default.Get("FerdePunkty", 0)<15)
        {
            czyMoznaKrecic = false;
            krecenieKolem.BackgroundColor = Color.FromArgb("#ed2e0c");
            await Task.Delay(2000);
            krecenieKolem.BackgroundColor = Color.FromArgb("#FC44FC");
            czyMoznaKrecic = true;
            return;
        }
        Preferences.Default.Set("FerdePunkty",Preferences.Default.Get("FerdePunkty",15)-15);
        wyswietlanieFerdePunktow.Text = $"FerdePunkty: {Preferences.Default.Get("FerdePunkty",0)}";
        czyMoznaKrecic=false;
        var losowa = new Random();
        int oIleZmieniac = 20;
        int coIle = losowa.Next(5,10);
        int rotacja = 0;
        while (oIleZmieniac > 0)
        {
            rotacja = rotacja + oIleZmieniac;
            if (rotacja >= 360)
            {
                rotacja = rotacja - 360;
            }
            FortuneWheel.Rotation = rotacja;
            if (coIle < 1)
            {
                coIle = losowa.Next(5,15);
                oIleZmieniac--;
            }
            else
            {
                coIle--;
            }
            await Task.Delay(1);
        }
        if (FortuneWheel.Rotation>270)
        {
            
            char[] tab = Preferences.Default.Get("OdblokowaneSoundbary","011000000").ToCharArray();
            tab[0] = '1';
            if (tab.Contains('0')) 
            {
                while (true)
                {
                    int s = losowa.Next(1, tab.Count());
                    if (tab[s] == '0')
                    {
                        tab[s] = '1';
                        break;
                    }
                }
                Preferences.Default.Set("OdblokowaneSoundbary", new string(tab));
                this.ShowPopup(new PopupKasynoNagrody("Nowy dŸwiêk do soundbara!"));
            }
            else
            {
                this.ShowPopup(new PopupKasynoNagrody("Posiadasz juz wszystkie dŸwiêki, dlatego otrzymujesz 20 FerdePunktów!"));
                Preferences.Default.Set("FerdePunkty",Preferences.Default.Get("FerdePunkty",0)+20);
                wyswietlanieFerdePunktow.Text = $"FerdePunkty: {Preferences.Default.Get("FerdePunkty", 0)}";
            }
            
        }
        else if (FortuneWheel.Rotation > 180 || FortuneWheel.Rotation < 90)
        {
            int nagroda = losowa.Next(0,6);
            nagroda = nagroda * 5;
            Preferences.Default.Set("FerdePunkty", Preferences.Default.Get("FerdePunkty", 0) + nagroda);
            this.ShowPopup(new PopupKasynoNagrody(nagroda));
            await Task.Delay(5500);
            wyswietlanieFerdePunktow.Text = $"FerdePunkty: {Preferences.Default.Get("FerdePunkty",0)}";
        }
        czyMoznaKrecic = true;
    }
}