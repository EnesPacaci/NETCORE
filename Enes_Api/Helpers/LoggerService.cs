using Serilog;
namespace Enes_Api.Helpers
{
    public class LoggerService
    {
        public void LogInformation(string message)
        {
            Log.Information(message);
        }

        public void LogWarning(string message)
        {
            Log.Warning(message);
        }

        public void LogError(string message, Exception ex)
        {
            Log.Error(ex, message);
        }
    }
}
