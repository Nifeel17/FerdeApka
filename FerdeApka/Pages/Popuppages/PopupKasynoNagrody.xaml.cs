using CommunityToolkit.Maui.Views;

namespace FerdeApka.Pages.Popuppages;

public partial class PopupKasynoNagrody : Popup
{
	public PopupKasynoNagrody(int nagroda)
	{
		InitializeComponent();
		LosujNagrode(nagroda);
	}

	public async void LosujNagrode(int nagroda)
	{
        var losowa = new Random();
        for (int i = 0; i < 60; i++)
        {
            LosowanaNagroda.Text = $"{losowa.Next(0, 6) * 5}";
            await Task.Delay((i * 3));
        }
        LosowanaNagroda.Text = $"{nagroda}";
        buttonZamknijPopup.IsEnabled = true;
    }

    private void ZamknijPopup(object sender, EventArgs e)
    {
		Close();
    }
}