namespace Blashing.Server.Jobs;

/// <summary>
/// Represents a scheduled job that executes periodically.
/// Implement this interface to define a background job for the dashboard scheduler,
/// similar to how Dashing/Smashing jobs work (e.g. SCHEDULER.every '5s').
/// </summary>
public interface IJob
{
    /// <summary>Gets the interval at which this job should run.</summary>
    TimeSpan Period { get; }

    /// <summary>Executes the job logic.</summary>
    /// <param name="stoppingToken">A token that signals when the host is shutting down.</param>
    Task ExecuteAsync(CancellationToken stoppingToken);
}
