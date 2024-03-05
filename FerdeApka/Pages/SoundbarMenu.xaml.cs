using CommunityToolkit.Maui.Views;
using FerdeApka.Pages.Popuppages;

namespace FerdeApka.Pages;

public partial class SoundbarMenu : TabbedPage
{
    
    Dictionary<int, MediaElement> SlownikMediaElement;
    Dictionary<int, Button> SlownikPrzyciskow;
	
    public SoundbarMenu()
	{
		InitializeComponent();
        SlownikMediaElement = new Dictionary<int, MediaElement>()
        {
            { 1, DzwiekCoWTymSmiesznego },
            { 2, DzwiekFakJu },
            { 3, DzwiekGoloneczkiBysChcial },
            { 4, DzwiekJakNieMogeToPrzezNoge },
            { 5, DzwiekWstydzSie },
            { 6, DzwiekNiePekaj },
            { 7, DzwiekKtoZRentOkradl },
            { 8, DzwiekGebeSeZamknij },
            { 9, DzwiekNieInteresujSie },
            { 10, DzwiekObiecanka }
        };

        SlownikPrzyciskow = new Dictionary<int, Button>()
        {
            { 1, SoundbarButtonDzwiekCoWTymSmiesznego },
            { 2, SoundbarButtonDzwiekFakJu },
            { 3, SoundbarButtonDzwiekGoloneczkiBysChcial },
            { 4, SoundbarButtonDzwiekJakNieMogeToPrzezNoge },
            { 5, SoundbarButtonDzwiekWstydzSie},
            { 6, SoundbarButtonDzwiekNiePekaj },
            { 7, SoundbarButtonDzwiekKtoZRentOkradl },
            { 8, SoundbarButtonDzwiekGebeSeZamknij },
            { 9, SoundbarButtonDzwiekNieInteresujSie },
            { 10, SoundbarButtonDzwiekObiecanka }
        };

        Preferences.Default.Set("OdblokowaneSoundbary",Preferences.Default.Get("OdblokowaneSoundbary", "01100000000"));
        char[] tablicaOdbnlokowanych = Preferences.Default.Get("OdblokowaneSoundbary", "01100000000").ToString().ToCharArray();

        for (int i=1; i<SlownikPrzyciskow.Count()+1; i++)
        {
            if (tablicaOdbnlokowanych[i]=='0')
            {
                SlownikPrzyciskow[i].BackgroundColor = Color.FromArgb("#03BAFC");
            }
        }
	}

        private async void ZagrajDzwiek(object sender, EventArgs e)
    {
        int index = 1;
        foreach(var x in SlownikPrzyciskow)
        {
            if(x.Value.ClassId == ((Button)sender).ClassId)
            {
                if (((Button)sender).BackgroundColor.ToHex()=="#03BAFC")
                {
                    var czyKupil = await this.ShowPopupAsync(new PopupKupnoDzwieku(index));
                    if (czyKupil is bool boolWynik)
                    {
                        if (boolWynik)
                        {
                            ((Button)sender).BackgroundColor = Color.FromArgb("#FC44FC");
                        }
                    }
                }
                else
                {
                    SlownikMediaElement[index].Play();
                    if (SlownikMediaElement[index].CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
                    {
                        SlownikMediaElement[index].Stop();
                        SlownikMediaElement[index].SeekTo(TimeSpan.Zero);
                        SlownikMediaElement[index].Play();
                    }
                    else if (SlownikMediaElement[index].CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused || SlownikMediaElement[index].CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Stopped)
                    {
                        SlownikMediaElement[index].SeekTo(TimeSpan.Zero);
                        SlownikMediaElement[index].Play();
                    }
                }
                break;
            }
            index++;
        }
    }
}