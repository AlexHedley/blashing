using Blashing.Server.Jobs;

namespace Blashing.Server.Services;

/// <summary>
/// A hosted background service that runs all registered <see cref="IJob"/> implementations
/// on their specified periods, comparable to the Dashing/Smashing scheduler.
/// </summary>
public class SchedulerService : BackgroundService
{
    private readonly IEnumerable<IJob> _jobs;
    private readonly ILogger<SchedulerService> _logger;

    public SchedulerService(IEnumerable<IJob> jobs, ILogger<SchedulerService> logger)
    {
        _jobs = jobs;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var jobList = _jobs.ToList();
        if (jobList.Count == 0)
        {
            _logger.LogWarning("No jobs registered with {ServiceName}", nameof(SchedulerService));
            return;
        }

        var tasks = jobList.Select(job => RunJobAsync(job, stoppingToken));
        await Task.WhenAll(tasks);
    }

    private async Task RunJobAsync(IJob job, CancellationToken stoppingToken)
    {
        _logger.LogInformation("Starting job {JobName} with period {Period}", job.GetType().Name, job.Period);

        using PeriodicTimer timer = new(job.Period);

        while (!stoppingToken.IsCancellationRequested &&
               await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                _logger.LogInformation("Executing job {JobName}", job.GetType().Name);
                await job.ExecuteAsync(stoppingToken);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                _logger.LogError(ex, "Error occurred executing job {JobName}", job.GetType().Name);
            }
        }
    }
}
