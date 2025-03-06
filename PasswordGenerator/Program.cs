using System;
using System.Text;

class PasswordGenerator
{
    private static Random random = new Random();

    public static string GeneratePassword(int length, bool useUpper, bool useLower, bool useDigits, bool useSpecial)
    {
        const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        const string digitChars = "0123456789";
        const string specialChars = "!@#$%^&*";

        StringBuilder charPool = new StringBuilder();
        if (useUpper) charPool.Append(upperChars);
        if (useLower) charPool.Append(lowerChars);
        if (useDigits) charPool.Append(digitChars);
        if (useSpecial) charPool.Append(specialChars);

        if (charPool.Length == 0)
        {
            throw new ArgumentException("Трябва да избереш поне един вид символи!");
        }

        StringBuilder password = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            int index = random.Next(charPool.Length);
            password.Append(charPool[index]);
        }

        return password.ToString();
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Въведи дължина на паролата: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Използване на главни букви? (yes/no): ");
        bool useUpper = Console.ReadLine().ToLower() == "yes";

        Console.Write("Използване на малки букви? (yes/no): ");
        bool useLower = Console.ReadLine().ToLower() == "yes";

        Console.Write("Използване на цифри? (yes/no): ");
        bool useDigits = Console.ReadLine().ToLower() == "yes";

        Console.Write("Използване на специални символи? (yes/no): ");
        bool useSpecial = Console.ReadLine().ToLower() == "yes";

        try
        {
            string password = PasswordGenerator.GeneratePassword(length, useUpper, useLower, useDigits, useSpecial);
            Console.WriteLine($"🔐 Генерирана парола: {password}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Грешка: {ex.Message}");
        }
    }
}
