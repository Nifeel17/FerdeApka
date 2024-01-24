using CommunityToolkit.Maui.Views;

namespace FerdeApka.Pages.Popuppages;

public partial class PopupInfoOAplikacji : Popup
{
	public PopupInfoOAplikacji()
	{
		InitializeComponent();
	}

    private void Zamknij_Popup_Informacji(object sender, EventArgs e)
    {
		Close();
    }
}