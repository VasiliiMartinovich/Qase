namespace Qase.Tests.Utilities;

public static class RandomDataGenerator
{
    private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string GenerateProjectCode()
    {
        var random = new Random();
        var length = random.Next(2, 11);

        return new string(Enumerable.Range(0, length).Select(_ => Characters[random.Next(Characters.Length)]).ToArray());
    }
}