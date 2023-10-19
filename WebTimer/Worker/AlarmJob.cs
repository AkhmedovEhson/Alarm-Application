using System.Net.Mail;

namespace WebTimer.Worker
{
    public class AlarmJob : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                // note: 3_600_000 ms is 1 hour
                var milliseconds = 3_600_000 * (24 - DateTime.UtcNow.Hour);

                await Task.Delay(milliseconds,cancellationToken);

                Console.WriteLine("Hello in 12:00");


                // todo: just realize smtp client ... 
                var smtp = new SmtpClient();

            }
        }
    }
}
