namespace FerdeApka.Pages;

public partial class StronaClicker : ContentPage
{
    char[] wykupioneBonusy = Preferences.Default.Get("wykupionebonusy","000").ToCharArray();
    int punkty = Preferences.Default.Get("punktyClicker", 0);

	public StronaClicker()
	{
		InitializeComponent();
        wyswietlPunkty.Text = $"Punkty: {punkty}";
        if (wykupioneBonusy[0] == '1')
        {
            zakup0.IsEnabled = false;
            zakup0.Text = "Zakupiono";
        }
        if (wykupioneBonusy[1] == '1')
        {
            zakup1.IsEnabled = false;
            zakup1.Text = "Zakupiono";
        }
        if (wykupioneBonusy[2] == '1')
        {
            zakup2.IsEnabled = false;
            zakup2.Text = "Zakupiono";
        }

    }

    private async void ClickedClickerButton(object sender, EventArgs e)
    {
        ObliczIlePunktow();
        wyswietlPunkty.Text = $"Punkty: {punkty}";
        clickerButton.HeightRequest = clickerButton.HeightRequest - 10;
        await Task.Delay(200);
        clickerButton.HeightRequest = clickerButton.HeightRequest + 10;
        Preferences.Default.Set("punktyClicker", punkty);

    }

    public void ObliczIlePunktow()
    {
        punkty++;
        if (punkty % 5 == 0 && wykupioneBonusy[0]=='1')
        {
            punkty++;
        }
        if (wykupioneBonusy[1]=='1')
        {
            Random rnd = new Random();
            if(rnd.Next(1, 10) == 7)
            {
                punkty = punkty + 3;
            }
        }
    }

    private async void KupionoBonus(object sender, EventArgs e)
    {
        Button wybrane = (Button)sender;
        if (wybrane.IsEnabled == false)
        {
            return;
        }
        if (punkty >= Int32.Parse(wybrane.Text))
        {
            punkty = punkty - Int32.Parse(wybrane.Text);
            wyswietlPunkty.Text = $"Punkty: {punkty}";
            Preferences.Default.Set("punktyClicker", punkty);
            switch (wybrane.Text)
            {
                case "2000":
                    wykupioneBonusy[0] = '1';
                    Preferences.Default.Set("wykupionebonusy", new string(wykupioneBonusy));
                    break;
                case "4000":
                    wykupioneBonusy[1] = '1';
                    Preferences.Default.Set("wykupionebonusy", new string(wykupioneBonusy));
                    break;
                case "10000":
                    wykupioneBonusy[2] = '1';
                    Preferences.Default.Set("wykupionebonusy", new string(wykupioneBonusy));
                    break;
                default:
                    break;
            }
            wybrane.Text = "Zakupiono";
            wybrane.BackgroundColor= Color.FromArgb("#00cc0e");
            await Task.Delay(1500);
            wybrane.IsEnabled = false;
        }
        else
        {
            wybrane.BackgroundColor = Color.FromArgb("#e3021c");
            await Task.Delay(1500);
            wybrane.BackgroundColor = Color.FromArgb("#FC44FC");
        }
    }

    private async void KupionoFerdePunkty(object sender, EventArgs e)
    {
        var x = Preferences.Default.Get("FerdePunkty", 0)+5;
        if (punkty>=1000)
        {
            punkty = punkty - 1000;
            Preferences.Default.Set("punktyClicker", punkty);
            Preferences.Default.Set("FerdePunkty", x);
            wyswietlPunkty.Text = $"Punkty: {punkty}";
            KupowanieFerdePunktow.BackgroundColor = Color.FromArgb("#00cc0e");
            await Task.Delay(500);
            KupowanieFerdePunktow.BackgroundColor = Color.FromArgb("#FC44FC");
        }
        else
        {
            KupowanieFerdePunktow.BackgroundColor = Color.FromArgb("#e3021c");
            await Task.Delay(1500);
            KupowanieFerdePunktow.BackgroundColor = Color.FromArgb("#FC44FC");
        }
    }
}