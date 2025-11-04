namespace Adapter;

public interface IMediaPlayer // Target interface - client works with this
{
    void Play(string audioType, string fileName);
}

public class LegacyMediaPlayer // Adaptee - existing functionality (incompatible with Target)
{
    public void PlayVlc(string fileName)
    {
        Console.WriteLine("LEGACY: Playing vlc file. Name: " + fileName);
    }

    public void PlayMp4(string fileName)
    {
        Console.WriteLine("LEGACY: Playing mp4 file. Name: " + fileName);
    }
}

public class MediaAdapter : IMediaPlayer // Adapter - makes Adaptee compatible with Target
{
    private readonly LegacyMediaPlayer _legacyMediaPlayer;

    public MediaAdapter()
    {
        _legacyMediaPlayer = new LegacyMediaPlayer();
    }

    public void Play(string audioType, string fileName)
    {
        if (audioType.Equals("vlc", StringComparison.OrdinalIgnoreCase))
        {
            _legacyMediaPlayer.PlayVlc(fileName);
        }
        else if (audioType.Equals("mp4", StringComparison.OrdinalIgnoreCase))
        {
            _legacyMediaPlayer.PlayMp4(fileName);
        }
        else
        {
            Console.WriteLine("Invalid media. " + audioType + " format not supported");
        }
    }
}

public class AudioPlayer : IMediaPlayer // Client - uses Target interface
{
    private MediaAdapter _mediaAdapter;

    public void Play(string audioType, string fileName)
    {
        if (audioType.Equals("mp3", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Playing mp3 file. Name: " + fileName);
        }
        else if (audioType.Equals("vlc", StringComparison.OrdinalIgnoreCase) ||
                 audioType.Equals("mp4", StringComparison.OrdinalIgnoreCase))
        {
            _mediaAdapter = new MediaAdapter();
            _mediaAdapter.Play(audioType, fileName);
        }
        else
        {
            Console.WriteLine("Invalid media. " + audioType + " format not supported");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        AudioPlayer audioPlayer = new AudioPlayer();

        audioPlayer.Play("mp3", "song1.mp3");
        audioPlayer.Play("mp4", "video1.mp4");
        audioPlayer.Play("vlc", "movie1.vlc");
        audioPlayer.Play("avi", "clip1.avi");
    }
}