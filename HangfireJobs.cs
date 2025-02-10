namespace OneSourceSharedLibrary
{
    public class HangfireJobs
    {
        public static Func<Task> handleEmailMessages;

        public static Func<Task> deleteOldEmailMessages;

        public static Func<int,int,Task> runScheduledTask;

        public async Task HandleEmailMessages()
        {
            if (handleEmailMessages != null)
                await handleEmailMessages();
        }

        public async Task DeleteOldEmailMessages()
        {
            if (deleteOldEmailMessages != null)
                await deleteOldEmailMessages();
        }

        public async Task RunScheduledTask(int taskId, int scheduleId)
        {
            if (runScheduledTask != null)
                await runScheduledTask(taskId, scheduleId);
        }
    }
}
