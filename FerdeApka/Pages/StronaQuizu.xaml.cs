using FerdeApka.Classes;
using Newtonsoft.Json;

namespace FerdeApka.Pages;

public partial class StronaQuizu : ContentPage
{

    private List<PytaniaIOdpowiedzi> WydobytePytania;
    private Random losowa = new Random();
    private int iloscPytan = 0;
    private int ktorePytanie = 1;
    private int jakiePytanie = 0;

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
        iloscPytan = default(int);
        ktorePytanie = default(int);
    }

    private async void PobierzJsona(string NazwaQuizu)
    {
        string KtoregoJsona;
        switch (NazwaQuizu)
        {
            case "Quiz o odcinkach":
                KtoregoJsona = "PytaniaDoPostaci.json";//dolozyc wiecej quziow
                break;
            default:
                KtoregoJsona = "PytaniaDoPostaci.json";
                break;
        }

        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(KtoregoJsona);
            using var reader = new StreamReader(stream);
            string fileContent = await reader.ReadToEndAsync();
            WydobytePytania = JsonConvert.DeserializeObject<List<PytaniaIOdpowiedzi>>(fileContent);
            iloscPytan = WydobytePytania.Count;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private void NastepnePytanie(object sender, EventArgs e)
    {
        ktorePytanie++;
        LabelKtorePytanie.Text = $"Pytanie {ktorePytanie}";
        jakiePytanie = losowa.Next(0, iloscPytan);
        LabelPytania.Text = WydobytePytania[jakiePytanie].Question;
    }
}