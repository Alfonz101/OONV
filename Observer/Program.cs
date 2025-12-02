namespace Observer;

// =============================
// Observer interface
// =============================

// This interface must be implemented by all observers.
// The Subject calls Update() whenever its state changes.
// Each observer decides what to do with the new data.
public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}



// =============================
// Subject interface
// =============================

// The Subject manages a list of observers and notifies them on state change.
public interface ISubject
{
    // Attach an observer to the subject
    void RegisterObserver(IObserver observer);

    // Detach an observer from the subject
    void RemoveObserver(IObserver observer);

    // Notify all observers that the subject's state has changed
    void NotifyObservers();
}



// =============================
// Concrete Subject
// =============================

// WeatherData is the *Subject* in the Observer Pattern.
// It stores weather values and notifies all observers whenever
// new measurements are set.
public class WeatherData : ISubject
{
    // List of subscribed observers
    private readonly List<IObserver> observers;

    // Internal weather state
    private float temperature;
    private float humidity;
    private float pressure;

    public WeatherData()
    {
        observers = new List<IObserver>();
    }

    // Adds an observer to the subscription list
    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    // Removes an observer so it no longer receives updates
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    // Loops through observers and sends them the latest weather data
    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            // Every observer receives the same data
            observer.Update(temperature, humidity, pressure);
        }
    }

    // This method simulates the weather station receiving new values.
    // Once values change, NotifyObservers() is called,
    // which is the core of the Observer pattern.
    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;

        // Notify all observers immediately after data changes
        NotifyObservers();
    }

    // Not used in this version, but represents a point where the
    // Subject decides its state has changed and notifies observers.
    private void MeasurementsChanged()
    {
        NotifyObservers();
    }
}



// =============================
// Concrete Observer #1
// =============================

// PhoneDisplay listens for updates from WeatherData.
// When Update() is triggered, it stores values and displays them.
public class PhoneDisplay : IObserver
{
    private float temperature;
    private float humidity;
    private float pressure;

    // Subject pushes the updated data into this method
    public void Update(float temperature, float humidity, float pressure)
    {
        // Save the new state
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;

        // React to the update
        Display();
    }

    // A simple output showing the current weather on a "phone"
    public void Display()
    {
        Console.WriteLine($"Phone Display - Temperature: {temperature}, Humidity: {humidity}, Pressure: {pressure}");
    }
}



// =============================
// Concrete Observer #2
// =============================

// WindowDisplay only cares about the temperature.
// This demonstrates that different observers can react differently.
public class WindowDisplay : IObserver
{
    private float temperature;
    private float humidity;
    private float pressure;

    // Receives updates from the subject
    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;

        // Only temperature matters here
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Window Display - Temperature: {temperature}");
    }
}



// =============================
// Program demonstrating the pattern
// =============================
class Program
{
    static void Main(string[] args)
    {
        // Create the subject (weather station)
        WeatherData weatherData = new WeatherData();

        // Create observers
        PhoneDisplay phoneDisplay = new PhoneDisplay();
        WindowDisplay windowDisplay = new WindowDisplay();

        // Attach observers to the subject
        weatherData.RegisterObserver(phoneDisplay);
        weatherData.RegisterObserver(windowDisplay);

        // First update – both observers get notified
        weatherData.SetMeasurements(25.0f, 65.0f, 1013.0f);

        // Second update – both still get notified
        weatherData.SetMeasurements(30.0f, 70.0f, 1012.0f);

        // Unsubscribe the WindowDisplay (runtime removal)
        weatherData.RemoveObserver(windowDisplay);

        // Third update – only PhoneDisplay receives updates
        weatherData.SetMeasurements(28.0f, 90.0f, 1011.0f);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
