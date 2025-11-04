namespace Proxy;

public interface IVideo // Subject interface
{
    void Display();
}

public class RealVideo : IVideo // Real Subject - loads and displays the video
{
    private string _filename;

    public RealVideo(string filename)
    {
        _filename = filename;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine($"Loading video {_filename} from disk...");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying video {_filename}");
    }
}

public class VideoProxy(string filename) : IVideo
{
    private RealVideo _realVideo;
    private string _filename = filename;

    public void Display()
    {
        if (_realVideo == null)
        {
            _realVideo = new RealVideo(_filename);
        }
        _realVideo.Display();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IVideo video = new VideoProxy("example_video.mp4");

        // Video will be loaded from disk only when Display is called
        video.Display();

        // Subsequent calls to Display will not load the video again
        video.Display();
    }
}
