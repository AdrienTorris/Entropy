namespace PeriodicTimerLab.ConsoleApp
{
    internal class WeatherForecastBackgroundService
    {
        private readonly PeriodicTimer timer;
        private readonly CancellationTokenSource cts = new();
        private Task? timerTask;

        public WeatherForecastBackgroundService(TimeSpan timerInterval)
        {
            timer = new(timerInterval);
        }

        public void Start()
        {
            timerTask = DoWorkAsync();
            Console.WriteLine("WeatherForecastBackgroundService just started");
        }

        private async Task DoWorkAsync()
        {
            try
            {
                while(await timer.WaitForNextTickAsync(cts.Token))
                {
                    Console.WriteLine(string.Concat("WeatherForecastBackgroundService: ", DateTime.Now.ToString("O")));
                    await Task.Delay(500);
                }
            }
            catch (OperationCanceledException)
            {

            }
        }

        public async Task StopAsync()
        {
            if(timerTask is null)
            {
                return;
            }

            cts.Cancel();
            await timerTask;
            cts.Dispose();
            Console.WriteLine("WeatherForecastBackgroundService just stopped");
        }
    }
}
