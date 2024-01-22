using CommunityToolkit.Maui.Views;

namespace FerdeApka.Pages.Popuppages;

public partial class PopupInformacjaLogowanie : Popup
{
	public PopupInformacjaLogowanie()
	{
		InitializeComponent();
	}

    private void Zamknij_Popup_Logowania(object sender, EventArgs e)
    {
		Close();
    }
}