using CommunityToolkit.Maui.Views;

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
            { 8, DzwiekGebeSeZamknij }
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
            { 8, SoundbarButtonDzwiekGebeSeZamknij }
        };
	}

    private void ZagrajDzwiek(object sender, EventArgs e)
    {
        int index = 1;
        foreach(var x in SlownikPrzyciskow)
        {
            if(x.Value.ClassId == ((Button)sender).ClassId)
            {
                SlownikMediaElement[index].Play();
                if (SlownikMediaElement[index].CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
                {
                    SlownikMediaElement[index].Stop();
                    SlownikMediaElement[index].SeekTo(TimeSpan.Zero);
                    SlownikMediaElement[index].Play();
                }
                else if (DzwiekFakJu.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused || SlownikMediaElement[index].CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Stopped)
                {
                    SlownikMediaElement[index].SeekTo(TimeSpan.Zero);
                    SlownikMediaElement[index].Play();
                }
                break;
            }
            index++;
        }
    }
}