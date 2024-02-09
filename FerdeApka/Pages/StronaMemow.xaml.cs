using System.ComponentModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace FerdeApka.Pages;

public partial class StronaMemow : ContentPage
{
	public StronaMemow()
	{
		InitializeComponent();
        NastepneMemy(new object(), new EventArgs());
	}

    List<int> KtoreMemyJuzByly = new List<int>();
    Random losowa = new Random();

    private void NastepneMemy(object sender, EventArgs e)
    {
        if (KtoreMemyJuzByly.Count() > 49)
        {
            MemySieSkonczylyLabel.IsVisible = true;
            ButtonNastepneMemy.IsVisible = false;
        }
        else
        {
            int numerMema = losowa.Next(1, 51);
            while(KtoreMemyJuzByly.Contains(numerMema))
            {
                numerMema = losowa.Next(1, 51);
            }
            KtoreMemyJuzByly.Add(numerMema);
            string nazwaMema = "https://raw.githubusercontent.com/ResourcesForMyApp/ResourcesFA/main/FerdeMem" + numerMema.ToString()+".png";
            ImageMem.Source = ImageSource.FromUri(new Uri(nazwaMema));
        }
    }
}