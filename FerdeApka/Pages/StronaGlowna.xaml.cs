using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using FerdeApka.Classes;
using FerdeApka.Pages.Popuppages;

namespace FerdeApka.Pages;

public partial class StronaGlowna : ContentPage
{

    public StronaGlowna()
	{
        InitializeComponent();
        wyswietlanieFerdePunktow.Text = $"FerdePunkty: {Preferences.Default.Get("FerdePunkty",0)}";
        List<ModelKaruzela> Karuzelka = new List<ModelKaruzela>()
        {
            new ModelKaruzela() { Nazwa="Soundbar", Opis="Najlepsze dŸwiêki z serialu!", Strona=new SoundbarMenu(), Obrazek="ferdekmuzyk.png"},
            new ModelKaruzela() { Nazwa="Quizy", Opis="Czy odpowiesz poprrawnie na wszystkie?", Strona=new StronaWybieraniaQuizow(), Obrazek="ferdekrece.png"},
            new ModelKaruzela() { Nazwa="Przegladaj memy", Opis="Dobre meme, powa¿nie!", Strona=new StronaMemow(), Obrazek="ferdeklampa.png"},
            new ModelKaruzela() { Nazwa="Clicker", Opis="Poklikaj sobie", Strona=new StronaClicker(), Obrazek="ferdekpiwko.png"},
            new ModelKaruzela() { Nazwa="Kasyno", Opis="Przewal ca³y swój maj¹tek (FerdePunktów) ju¿ dzisiaj!", Strona=new StronaKasyno(), Obrazek="ferdekkasyno.png"},
            new ModelKaruzela() { Nazwa="Daily", Opis="Dzienny cytat i mem", Strona=new StronaDaily(), Obrazek="ferdekgangsta.png"}
        };
        karuzela.ItemsSource=Karuzelka;
    }

    public StronaGlowna(string doKad)
    {
        InitializeComponent();
        wyswietlanieFerdePunktow.Text = $"FerdePunkty: {Preferences.Default.Get("FerdePunkty", 0)}";
        if (doKad == "StronaWybieraniaQuizow")
        {
            PrzejdzmyDoStronyQuizow();
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();


        wyswietlanieFerdePunktow.Text = $"FerdePunkty: {Preferences.Default.Get("FerdePunkty", 0)}";
    }

    public async void PrzejdzmyDoStronyQuizow()
    {
        await Navigation.PushAsync(new StronaWybieraniaQuizow());
    }

    
    private void PokazPopupOAplikacji(object sender, EventArgs e)
    {
        this.ShowPopup(new PopupInfoOAplikacji());
    }

  

    private async void PrzejdzDoStronyMemow(object sender, EventArgs e)
    {
        NetworkAccess czyJestNet = Connectivity.Current.NetworkAccess;

        if (czyJestNet == NetworkAccess.Internet)
        {
            await Navigation.PushAsync(new StronaMemow());
        }
        else
        {
            this.ShowPopup(new PopupPotrzebnyInternet());
        }
        
    }

    private async void PrzejdzDoStronyDaily(object sender, EventArgs e)
    {
        NetworkAccess czyJestNet = Connectivity.Current.NetworkAccess;

        if (czyJestNet == NetworkAccess.Internet)
        {
            await Navigation.PushAsync(new StronaDaily());
        }
        else
        {
            this.ShowPopup(new PopupPotrzebnyInternet());
        }
    }

    private void NacisnietoFerdePunkty(object sender, TappedEventArgs e)
    {
        this.ShowPopup(new PopupFerdePunkty());
    }
    //potem moge wywalic
    private void DodajFerdePunkty(object sender, EventArgs e)
    {
        Preferences.Default.Set("FerdePunkty",Preferences.Default.Get("FerdePunkty",0)+100);
    }

    private void OdejmijFerdePunkty(object sender, EventArgs e)
    {

        Preferences.Default.Set("FerdePunkty", 0);
    }

    private void zabierzsuondbary(object sender, EventArgs e)
    {
        Preferences.Default.Set("OdblokowaneSoundbary","00000000000000");
    }
    //az tutaj
    private async void KliknietaKaruzela(object sender, TappedEventArgs e)
    {
        var item = e.Parameter as ModelKaruzela;
        if (item != null)
        {
            if(item.Nazwa=="Przegladaj memy" || item.Nazwa == "Daily")
            {
                NetworkAccess czyJestNet = Connectivity.Current.NetworkAccess;

                if (czyJestNet == NetworkAccess.Internet)
                {
                    await Navigation.PushAsync(item.Strona);
                }
                else
                {
                    this.ShowPopup(new PopupPotrzebnyInternet());
                }
            }
            else
            {
                await Navigation.PushAsync(item.Strona);
            }
        }
    }


}