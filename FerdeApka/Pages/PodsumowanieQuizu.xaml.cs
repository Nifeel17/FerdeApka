using System.Runtime.CompilerServices;

namespace FerdeApka.Pages;

public partial class PodsumowanieQuizu : ContentPage
{
	public PodsumowanieQuizu()
	{
		InitializeComponent();
	}

    public PodsumowanieQuizu(string NazwaQuizu, int PunktyGracza)
    {
        InitializeComponent();
        LabelUkonczonoQuiz.Text = $"{NazwaQuizu}!";
        LabelWynik.Text = $"Wynik: {PunktyGracza}";
        if (PunktyGracza > Preferences.Default.Get(NazwaQuizu, 0))
        {
            Preferences.Default.Set(NazwaQuizu, PunktyGracza);
        }
    }

    private void PowrotDoStronyQuizow(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
}
