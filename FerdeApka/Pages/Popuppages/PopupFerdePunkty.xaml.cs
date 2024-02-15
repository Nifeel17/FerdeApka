using CommunityToolkit.Maui.Views;
namespace FerdeApka.Pages.Popuppages;

public partial class PopupFerdePunkty : Popup
{
	public PopupFerdePunkty()
	{
		InitializeComponent();
        IloscFerdePunktow.Text = $"{Preferences.Default.Get("FerdePunkty",0)}";
	}

    private void Zamknij_Popup_FerdePunktow(object sender, EventArgs e)
    {
        Close();
    }
}