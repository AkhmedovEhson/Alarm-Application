using Application.Common.Interfaces.IRepositories;
using Domain.Entities;
using System.Net.Mail;
using System.Text.Json;

namespace WebTimer.Worker
{
    public class AlarmJob : BackgroundService
    {
        private ICurrentUserService _currentUserService;
        public AlarmJob(ICurrentUserService currentUserService) => _currentUserService = currentUserService;
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                // note: 3_600_000 ms is 1 hour
                AlarmEntity alarm = JsonSerializer.Deserialize<List<AlarmEntity>>(_currentUserService.GetAlarms())!.First();
                var milliseconds = 3_600_000 * (24 - alarm.RingAt.Day);

                await Task.Delay(milliseconds,cancellationToken);

                Console.WriteLine($"Alarm occured :: UserId[{_currentUserService.GetId()}]");

            }
        }
    }
}
