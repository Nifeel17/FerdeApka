namespace FerdeApka.Pages;

public partial class SoundbarMenu : TabbedPage
{
	public SoundbarMenu()
	{
		InitializeComponent();
	}

    private void SoundbarDzwiekCoWTymSmisznegoZagraj(object sender, EventArgs e)
    {
        if (DzwiekCoWTymSmiesznego.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            DzwiekCoWTymSmiesznego.Stop();
            DzwiekCoWTymSmiesznego.SeekTo(TimeSpan.Zero);
            DzwiekCoWTymSmiesznego.Play();
        }
        else if (DzwiekCoWTymSmiesznego.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused || DzwiekCoWTymSmiesznego.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Stopped)
        {
            DzwiekCoWTymSmiesznego.SeekTo(TimeSpan.Zero);
            DzwiekCoWTymSmiesznego.Play();
        }
    }

    private void SoundbarDzwiekFakJuZagraj(object sender, EventArgs e)
    {
        if (DzwiekFakJu.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            DzwiekFakJu.Stop();
            DzwiekFakJu.SeekTo(TimeSpan.Zero);
            DzwiekFakJu.Play();
        }
        else if(DzwiekFakJu.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused || DzwiekFakJu.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Stopped)
        {
            DzwiekFakJu.SeekTo(TimeSpan.Zero);
            DzwiekFakJu.Play();
        }
    }

    private void SoundbarDzwiekCoWTymSmiesznegoZagraj(object sender, EventArgs e)
    {
        if (DzwiekGoloneczkiBysChcial.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            DzwiekGoloneczkiBysChcial.Stop();
            DzwiekGoloneczkiBysChcial.SeekTo(TimeSpan.Zero);
            DzwiekGoloneczkiBysChcial.Play();
        }
        else if (DzwiekGoloneczkiBysChcial.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused || DzwiekGoloneczkiBysChcial.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Stopped)
        {
            DzwiekGoloneczkiBysChcial.SeekTo(TimeSpan.Zero);
            DzwiekGoloneczkiBysChcial.Play();
        }
    }

    private void SoundbarDzwiekJakNieMogeToPrzezNogeZagraj(object sender, EventArgs e)
    {
        if (DzwiekJakNieMogeToPrzezNoge.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            DzwiekJakNieMogeToPrzezNoge.Stop();
            DzwiekJakNieMogeToPrzezNoge.SeekTo(TimeSpan.Zero);
            DzwiekJakNieMogeToPrzezNoge.Play();
        }
        else if (DzwiekJakNieMogeToPrzezNoge.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused || DzwiekJakNieMogeToPrzezNoge.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Stopped)
        {
            DzwiekJakNieMogeToPrzezNoge.SeekTo(TimeSpan.Zero);
            DzwiekJakNieMogeToPrzezNoge.Play();
        }
    }

    private void SoundbarDzwiekWstydzSieZagraj(object sender, EventArgs e)
    {
        if (DzwiekWstydzSie.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            DzwiekWstydzSie.Stop();
            DzwiekWstydzSie.SeekTo(TimeSpan.Zero);
            DzwiekWstydzSie.Play();
        }
        else if (DzwiekWstydzSie.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused || DzwiekWstydzSie.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Stopped)
        {
            DzwiekWstydzSie.SeekTo(TimeSpan.Zero);
            DzwiekWstydzSie.Play();
        }
    }

    private void SoundbarDzwiekNiePekajZagraj(object sender, EventArgs e)
    {
        if (DzwiekNiePekaj.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            DzwiekNiePekaj.Stop();
            DzwiekNiePekaj.SeekTo(TimeSpan.Zero);
            DzwiekNiePekaj.Play();
        }
        else if (DzwiekNiePekaj.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused || DzwiekNiePekaj.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Stopped)
        {
            DzwiekNiePekaj.SeekTo(TimeSpan.Zero);
            DzwiekNiePekaj.Play();
        }
    }
}