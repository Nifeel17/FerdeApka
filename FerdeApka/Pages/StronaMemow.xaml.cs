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
        if (KtoreMemyJuzByly.Count() > 46)
        {
            MemySieSkonczylyLabel.IsVisible = true;
            ButtonNastepneMemy.IsVisible = false;
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                int numerMema = losowa.Next(1, 51);
                while(KtoreMemyJuzByly.Contains(numerMema))
                {
                    numerMema = losowa.Next(1, 51);
                }
                KtoreMemyJuzByly.Add(numerMema);
                string nazwaMema = "https://raw.githubusercontent.com/ResourcesForMyApp/ResourcesFA/main/FerdeMem" + numerMema.ToString()+".png";
                int gdziePrzycisk = GlownyStackLayout.Children.IndexOf(ButtonNastepneMemy);
                if (gdziePrzycisk != -1)
                {
                    var noweMeme = new Image
                    {
                        Source = nazwaMema,
                        Margin = new Thickness(10, 30, 10, 20)
                    };

                    GlownyStackLayout.Children.Insert(gdziePrzycisk, noweMeme);
                }
            }
        }
    }
}