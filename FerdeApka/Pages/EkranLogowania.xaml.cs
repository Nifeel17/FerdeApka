
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

    //utworzyc popup do drugiego przycisku
}