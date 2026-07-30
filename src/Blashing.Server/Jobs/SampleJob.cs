namespace Blashing.Server.Jobs;

/// <summary>
/// A sample job that demonstrates how to implement <see cref="IJob"/>.
/// Runs every 30 seconds and logs a message, similar to a Dashing/Smashing job
/// that sends periodic data events to dashboard widgets.
/// </summary>
public class SampleJob : IJob
{
    private readonly ILogger<SampleJob> _logger;

    public TimeSpan Period => TimeSpan.FromSeconds(30);

    public SampleJob(ILogger<SampleJob> logger)
    {
        _logger = logger;
    }

    public Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Executing {JobName} at: {Time}", nameof(SampleJob), DateTimeOffset.UtcNow);
        return Task.CompletedTask;
    }
}
