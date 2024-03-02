using FerdeApka.Classes;
using Newtonsoft.Json;

namespace FerdeApka.Pages;

public partial class StronaQuizu : ContentPage
{

    private List<PytaniaIOdpowiedzi> WydobytePytania;
    private Random losowa = new Random();
    private int ktorePytanie = 0;
    private int poprawnaOdpowiedz = 1;
    private int punktyGracza = 0;
    private bool czyOdpowiedzial = false;
    string nazwaQuizu="";
    Dictionary<int, Button> Przyciski;


    public StronaQuizu()
    {
        InitializeComponent();
    }

    public StronaQuizu(string NazwaQuizu)
    {
        PobierzJsona(NazwaQuizu);
        InitializeComponent();
        nazwaQuizu = NazwaQuizu;
        LabelPytania.Text = NazwaQuizu;
        Przyciski = new Dictionary<int, Button>()
        {
            { 1, ButtonAnswer1 },
            { 2, ButtonAnswer2 },
            { 3, ButtonAnswer3 },
            { 4, ButtonAnswer4 }
        };
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        WydobytePytania = null;
        losowa = null;
        ktorePytanie = default(int);
        poprawnaOdpowiedz = default(int);
        punktyGracza = default(int);
        nazwaQuizu = null;
    }

    private async void PobierzJsona(string NazwaQuizu)
    {
        string KtoregoJsona;
        switch (NazwaQuizu)
        {
            case "Quiz o odcinkach":
                KtoregoJsona = "JsonyDoQuizow/PytaniaDoOdcinkow.json";
                break;
            case "Quiz o postaciach":
                KtoregoJsona = "JsonyDoQuizow/PytaniaDoPostaci.json";
                break;
            case "Quiz o tworzeniu serialu":
                KtoregoJsona = "JsonyDoQuizow/PytaniaDoTworzeniaSerialu.json";
                break;
            default:
                KtoregoJsona = "JsonyDoQuizow/PytaniaDoPostaci.json";
                break;
        }

        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(KtoregoJsona);
            using var reader = new StreamReader(stream);
            string fileContent = await reader.ReadToEndAsync();
            WydobytePytania = JsonConvert.DeserializeObject<List<PytaniaIOdpowiedzi>>(fileContent);
            NastepnePytanie();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private void NastepnePytanie()
    {
        foreach(var x in Przyciski)
        {
            x.Value.ClassId = "blad";
        }
        LabelPunkty.Text = $"Punkty: {punktyGracza}";
        ktorePytanie++;
        LabelKtorePytanie.Text = $"Pytanie {ktorePytanie}";
        int jakiePytanie = losowa.Next(0, WydobytePytania.Count);
        LabelPytania.Text = WydobytePytania[jakiePytanie].Question;
        List<string> odpowiedzi = new List<string> { WydobytePytania[jakiePytanie].CorrectAnswer, WydobytePytania[jakiePytanie].Answer2, WydobytePytania[jakiePytanie].Answer3, WydobytePytania[jakiePytanie].Answer4};
        odpowiedzi = odpowiedzi.OrderBy(_ => losowa.Next()).ToList();
        for(int i=0; i<4; i++)
        {
            Przyciski[i + 1].Text = odpowiedzi[i];
        }
        poprawnaOdpowiedz = 1 + odpowiedzi.FindIndex(x => x == WydobytePytania[jakiePytanie].CorrectAnswer);
        Przyciski[poprawnaOdpowiedz].ClassId = "PoprawnaOdpowiedz";
        WydobytePytania.RemoveAt(jakiePytanie);
    }

    private async void AnswerClicked(object sender, EventArgs e)
    {
        if (czyOdpowiedzial == true)
        {
            return;
        }
        czyOdpowiedzial = true;
        Button WcisnietyGuziol = sender as Button;
        Przyciski[poprawnaOdpowiedz].BackgroundColor = Color.FromArgb("#00cc0e");
        if (WcisnietyGuziol.ClassId == "PoprawnaOdpowiedz")
        {
            punktyGracza++;
            await Task.Delay(2000);
        }
        else
        {
            ((Button)sender).BackgroundColor = Color.FromArgb("#ed2e0c");
            await Task.Delay(2000);
            ((Button)sender).BackgroundColor = Color.FromArgb("#FC44FC");
        }
        Przyciski[poprawnaOdpowiedz].BackgroundColor = Color.FromArgb("#FC44FC");
        await Task.Delay(500);
        NastepnePytanie();
        czyOdpowiedzial = false;
        if (ktorePytanie > 10)
        {
            await Navigation.PushAsync(new PodsumowanieQuizu(nazwaQuizu,punktyGracza));
        }
    }
}