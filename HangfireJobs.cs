namespace OneSourceSharedLibrary
{
    public class HangfireJobs
    {
        public static Func<Task> handleEmailMessages;

        public static Func<Task> deleteOldEmailMessages;

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
    }
}
