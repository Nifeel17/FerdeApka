using FerdeApka.Classes;
using Newtonsoft.Json;

namespace FerdeApka.Pages;

public partial class StronaQuizu : ContentPage
{

    private List<PytaniaIOdpowiedzi> WydobytePytania;
    private Random losowa = new Random();
    private int iloscPytan = 0;

    public StronaQuizu()
    {
        InitializeComponent();
    }

    public StronaQuizu(string NazwaQuizu)
    {
        PobierzJsona();
        InitializeComponent();
        LabelNazwyQuizu.Text = NazwaQuizu;
        
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        WydobytePytania = null;
        losowa = null;
        iloscPytan = default(int);
    }

    private async void PobierzJsona()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("PytaniaDoZadania.json");
            using var reader = new StreamReader(stream);
            string fileContent = await reader.ReadToEndAsync();
            WydobytePytania = JsonConvert.DeserializeObject<List<PytaniaIOdpowiedzi>>(fileContent);
            iloscPytan = WydobytePytania.Count;
            LabelNazwyQuizu.Text = WydobytePytania[losowa.Next(0,iloscPytan)].Question;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}