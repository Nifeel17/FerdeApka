using FerdeApka.Classes;
using Microsoft.Maui.Graphics.Text;
using Newtonsoft.Json;

namespace FerdeApka.Pages;

public partial class StronaDaily : ContentPage
{
    int numerMemaDnia = Preferences.Default.Get("MemDnia", 0);
    int numerCytatDnia = Preferences.Default.Get("CytatDnia", 0);
    int dataZapisu = Preferences.Default.Get("DataOstatniegoDnia", 0);
    List<CytatyDaily> WydobyteCytaty = new List<CytatyDaily>();

    private async void PobierzJsona()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("PozostaleJsony/CytatyDoDaily.json");
            using var reader = new StreamReader(stream);
            string fileContent = await reader.ReadToEndAsync();
            WydobyteCytaty = JsonConvert.DeserializeObject<List<CytatyDaily>>(fileContent);
            Wczytaj();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private void Wczytaj()
    {
        Random losowa = new Random();
        DateTime today = DateTime.Today;
        string dzisiejszaDataSTR = today.ToString("yyMMdd");
        int dzisiejszaDataINT = Int32.Parse(dzisiejszaDataSTR);
        if (dzisiejszaDataINT > dataZapisu)
        {
            Preferences.Default.Set("DataOstatniegoDnia", dzisiejszaDataINT);
            numerCytatDnia = losowa.Next(1, 49);
            numerMemaDnia = losowa.Next(1, 49);
            Preferences.Default.Set("CytatDnia", numerCytatDnia);
            Preferences.Default.Set("MemDnia", numerMemaDnia);
            Preferences.Default.Set("FerdePunkty",Preferences.Default.Get("FerdePunkty",0)+5);
        }
        LabelCytatDnia.Text = WydobyteCytaty[numerCytatDnia].Cytat;
        MemDnia.Source = "https://raw.githubusercontent.com/ResourcesForMyApp/ResourcesFA/main/FerdeMem" + numerMemaDnia + ".png";

    }


    public StronaDaily()
	{
		InitializeComponent();
        PobierzJsona();
    }
}
