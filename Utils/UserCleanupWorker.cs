using System;
using System.Threading;
using System.Threading.Tasks;
using ims.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ims.Utils
{
    public class UserCleanupWorker(ILogger<UserCleanupWorker> logger, UserService userService) : BackgroundService
    {
        private readonly ILogger<UserCleanupWorker> _logger = logger;
        private readonly UserService _userService = userService;
        private readonly TimeSpan _period = TimeSpan.FromHours(24);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("User Cleanup Worker starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _userService.CleanupExpiredUsersAsync();
                    _logger.LogInformation("Expired users cleanup completed.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred during expired users cleanup.");
                }

                // Wait for the next period
                await Task.Delay(_period, stoppingToken);
            }
        }
    }
}