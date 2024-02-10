using CommunityToolkit.Maui.Views;

namespace FerdeApka.Pages.Popuppages;

public partial class PopupPotrzebnyInternet : Popup
{
	public PopupPotrzebnyInternet()
	{
		InitializeComponent();
	}

    private void Zamknij_Popup_Internet(object sender, EventArgs e)
    {
        Close();
    }
}