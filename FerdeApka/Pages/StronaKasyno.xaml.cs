namespace FerdeApka.Pages;

public partial class StronaKasyno : ContentPage
{
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
}