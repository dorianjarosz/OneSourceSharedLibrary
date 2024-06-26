namespace OneSourceSharedLibrary
{
    public class HangfireJobs
    {
        public async Task ExecuteRecurringJobAsync(Task recurringJob)
        {
            await recurringJob;
        }
    }
}
