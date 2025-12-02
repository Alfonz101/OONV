namespace Observer;

public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class WeatherData : ISubject
{
    private readonly List<IObserver> observers;
    private float temperature;
    private float humidity;
    private float pressure;

    public WeatherData()
    {
        observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature, humidity, pressure);
        }
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        NotifyObservers();
    }

    private void MeasurementsChanged()
    {
        NotifyObservers();
    }
}

public class PhoneDisplay : IObserver
{
    private float temperature;
    private float humidity;
    private float pressure;

    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Phone Display - Temperature: {temperature}, Humidity: {humidity}, Pressure: {pressure}");
    }
}

public class WindowDisplay : IObserver
{
    private float temperature;
    private float humidity;
    private float pressure;

    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Window Display - Temperature: {temperature}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        WeatherData weatherData = new WeatherData();

        PhoneDisplay phoneDisplay = new PhoneDisplay();
        WindowDisplay windowDisplay = new WindowDisplay();

        weatherData.RegisterObserver(phoneDisplay);
        weatherData.RegisterObserver(windowDisplay);

        weatherData.SetMeasurements(25.0f, 65.0f, 1013.0f);
        weatherData.SetMeasurements(30.0f, 70.0f, 1012.0f);

        weatherData.RemoveObserver(windowDisplay);

        weatherData.SetMeasurements(28.0f, 90.0f, 1011.0f);

        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
