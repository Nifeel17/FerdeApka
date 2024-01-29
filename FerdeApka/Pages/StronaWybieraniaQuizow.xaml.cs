using FerdeApka.Classes;

namespace FerdeApka.Pages;

public partial class StronaWybieraniaQuizow : ContentPage
{
	public StronaWybieraniaQuizow()
	{
		InitializeComponent();
	}

    private async void PrzejdzDoStronyzQuziemOPostaciach(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StronaQuizu("Quiz o postaciach"));
    }

    private async void PrzejdzDoStronyzQuziemOAutorach(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StronaQuizu("Quiz o autorach"));
    }

}