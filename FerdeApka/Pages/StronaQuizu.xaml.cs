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

    public StronaQuizu()
    {
        InitializeComponent();
    }

    public StronaQuizu(string NazwaQuizu)
    {
        PobierzJsona(NazwaQuizu);
        InitializeComponent();
        LabelPytania.Text = NazwaQuizu;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        WydobytePytania = null;
        losowa = null;
        ktorePytanie = default(int);
        poprawnaOdpowiedz = default(int);
        punktyGracza = default(int);
    }

    private async void PobierzJsona(string NazwaQuizu)
    {
        string KtoregoJsona;
        switch (NazwaQuizu)
        {
            case "Quiz o odcinkach":
                KtoregoJsona = "JsonyDoQuizow/PytaniaDoPostaci.json";//dolozyc wiecej quziow
                break;
            default:
                KtoregoJsona = "JsonyDoQuizow/PytaniaDoPostaci.json";//zwiekszyc ilosc pytan
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
        ButtonAnswer1.ClassId = "blad";
        ButtonAnswer2.ClassId = "blad";
        ButtonAnswer3.ClassId = "blad";
        ButtonAnswer4.ClassId = "blad";
        LabelPunkty.Text = $"Punkty: {punktyGracza}";
        ktorePytanie++;
        LabelKtorePytanie.Text = $"Pytanie {ktorePytanie}";
        int jakiePytanie = losowa.Next(0, WydobytePytania.Count);
        LabelPytania.Text = WydobytePytania[jakiePytanie].Question;
        List<string> odpowiedzi = new List<string> { WydobytePytania[jakiePytanie].CorrectAnswer, WydobytePytania[jakiePytanie].Answer2, WydobytePytania[jakiePytanie].Answer3, WydobytePytania[jakiePytanie].Answer4};
        odpowiedzi = odpowiedzi.OrderBy(_ => losowa.Next()).ToList();
        ButtonAnswer1.Text = odpowiedzi[0];
        ButtonAnswer2.Text = odpowiedzi[1];
        ButtonAnswer3.Text = odpowiedzi[2];
        ButtonAnswer4.Text = odpowiedzi[3];
        poprawnaOdpowiedz = 1 + odpowiedzi.FindIndex(x => x == WydobytePytania[jakiePytanie].CorrectAnswer);
        switch (poprawnaOdpowiedz)
        {
            case 1:
                ButtonAnswer1.ClassId = "PoprawnaOdpowiedz";
                break;
            case 2:
                ButtonAnswer2.ClassId = "PoprawnaOdpowiedz";
                break;
            case 3:
                ButtonAnswer3.ClassId = "PoprawnaOdpowiedz";
                break;
            case 4:
                ButtonAnswer4.ClassId = "PoprawnaOdpowiedz";
                break;
            default:
                break;
        }
    }

    private void AnswerClicked(object sender, EventArgs e)
    {
        Button WcisnietyGuziol = sender as Button;
        if (WcisnietyGuziol.ClassId == "PoprawnaOdpowiedz")
        {
            punktyGracza++;
        }
        else
        {
            //przy zlej odpoiwiedzi przycisk zaznaczonej zmieni sie na czerwon a dobrej na zielony
        }
        NastepnePytanie(); //stworzyc na stronie wybierania quizow przy przyciskach do rozpoczecia label z maksymalnym wynikiem uzyskanym z quizu
    }
}