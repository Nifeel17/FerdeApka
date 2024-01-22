using CommunityToolkit.Maui.Views;

namespace FerdeApka.Pages.Popuppages;

public partial class PopupLogowanieZFacebooka : Popup
{
	public PopupLogowanieZFacebooka()
	{
		InitializeComponent();
	}

    private void Zamknij_Popup_Facebooka(object sender, EventArgs e)
    {
		Close();
    }
}