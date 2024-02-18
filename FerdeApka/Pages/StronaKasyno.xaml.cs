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
            //logika dla otrzymywania dzwiekow
        }
        else if (FortuneWheel.Rotation > 180 || FortuneWheel.Rotation < 90)
        {
            //moze jakis popup z losowaniem ilosci ferdepunktow
        }
        czyMoznaKrecic = true;
    }
}