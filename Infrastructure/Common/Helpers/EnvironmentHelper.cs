namespace Infrastructure.Common.Helpers; 

public static class EnvironmentHelper {
    public static T GetValue<T>(string key) {
        ArgumentException.ThrowIfNullOrEmpty(key);

        string? value = Environment.GetEnvironmentVariable(key);

        try {
            return (T)Convert.ChangeType(value, typeof(T))!;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error converting environment variable: {ex.Message}");
            throw new InvalidCastException($"Unable to convert env var: {nameof(value)}");
        }
    }
}