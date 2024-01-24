namespace FerdeApka.Pages;

public partial class SoundbarMenu : TabbedPage
{
	public SoundbarMenu()
	{
		InitializeComponent();
	}

    private void SoundbarDzwiekCoWTymSmisznegoZagraj(object sender, EventArgs e)
    {
        if (DzwiekCoWTymSmiesznego.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused || DzwiekCoWTymSmiesznego.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Stopped)
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
}