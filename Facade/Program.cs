namespace Facade;

class VideoFile
{
    public string Name { get; set; }
    public VideoFile(string name)
    {
        Name = name;
    }
}

class OggCompressionCodec
{
    public string CodecName => "Ogg";
}

class Mp4CompressionCodec
{
    public string CodecName => "MP4";
}

class CodecFactory
{
    public static object Extract(VideoFile file)
    {
        if (file.Name.EndsWith(".mp4"))
        {
            return new Mp4CompressionCodec();
        }
        else
        {
            return new OggCompressionCodec();
        }
    }
}

class BitrateReader
{
    public static void Read(VideoFile file, object codec)
    {
        Console.WriteLine($"Reading {file.Name} using {codec.GetType().Name} codec.");
    }
}

class AudioMixer
{
    public static void Fix(VideoFile file)
    {
        Console.WriteLine($"Fixing audio for {file.Name}.");
    }
}

class VideoConverter
{
    public VideoFile Convert(string filename, string format)
    {
        Console.WriteLine($"VideoConverter: Converting '{filename}' to format '{format}'.");

        // Extract the file extension
        VideoFile file = new VideoFile(filename);
        object sourceCodec = CodecFactory.Extract(file);
        object destinationCodec;

        if (format == "mp4")
        {
            destinationCodec = new Mp4CompressionCodec();
        }
        else
        {
            destinationCodec = new OggCompressionCodec();
        }

        BitrateReader.Read(file, sourceCodec);
        BitrateReader.Read(file, destinationCodec);

        AudioMixer.Fix(file);

        return new VideoFile($"{filename.Split('.')[0]}.{format}");
    }
}

class Application
{
    public void Run()
    {
        VideoConverter converter = new VideoConverter();
        VideoFile mp4Video = converter.Convert("example.ogg", "mp4");
        Console.WriteLine($"Conversion completed: {mp4Video.Name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Application app = new Application();
        app.Run();
    }
}
