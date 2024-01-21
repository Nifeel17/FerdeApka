namespace FerdeApka.Pages;

public partial class EkranWstepny : ContentPage
{
	public EkranWstepny()
	{
		InitializeComponent();
	}

    private async void LoginWithAccount(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new EkranLogowania());
    }
}