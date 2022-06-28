using PeriodicTimerLab.ConsoleApp;

Console.WriteLine("Hello to WeatherForecastBackgroundService");
Console.WriteLine("Press any button to start the service");
Console.ReadKey();

WeatherForecastBackgroundService weatherForecastBackgroundService = new (TimeSpan.FromMilliseconds(1000));
weatherForecastBackgroundService.Start();

Console.WriteLine("Press any button to stop the service");
Console.ReadKey();

await weatherForecastBackgroundService.StopAsync();
