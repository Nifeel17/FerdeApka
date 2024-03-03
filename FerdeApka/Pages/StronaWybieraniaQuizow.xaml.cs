using FerdeApka.Classes;

namespace FerdeApka.Pages;

public partial class StronaWybieraniaQuizow : ContentPage
{
	public StronaWybieraniaQuizow()
	{
		InitializeComponent();
        WypiszWyniki();
	}

    public void WypiszWyniki()
    {
        WynikQuizuOOdcinkach.Text = $"{Preferences.Default.Get("Quiz o odcinkach", 0)}/10";
        WynikQuizuOPostaciach.Text = $"{Preferences.Default.Get("Quiz o postaciach", 0)}/10";
        WynikQuizuOTworzeniuSerialu.Text = $"{Preferences.Default.Get("Quiz o tworzeniu serialu", 0)}/10";
    }

    private async void PrzejdzDoStronyzQuziem(object sender, EventArgs e)
    {
        var parametr = (Button)sender;
        var tekstParametru =parametr.CommandParameter.ToString();
        await Navigation.PushAsync(new StronaQuizu(tekstParametru));
    }
}