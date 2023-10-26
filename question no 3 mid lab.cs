using System;
using System.Text;
using System.Linq;

class PasswordGenerator
{
    static void Main()
    {
        // Your personal information
        string firstName = "Muhammad";
        string lastName = "Zubair";
        string registrationNumber = "fa20-bcs-041";

        // Generate the password
        string password = GeneratePassword(firstName, lastName, registrationNumber);

        Console.WriteLine("Generated Password: " + password);
    }

    static string GeneratePassword(string firstName, string lastName, string registrationNumber)
    {
        Random random = new Random();
        StringBuilder password = new StringBuilder();

        // Initials (Uppercase)
        password.Append(char.ToUpper(firstName[0]));
        password.Append(char.ToUpper(lastName[0]));

        // Random letters (lowercase)
        for (int i = 0; i < 14; i++)
        {
            password.Append((char)random.Next('a', 'z' + 1));
        }

        // Special characters
        string specialCharacters = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/";
        for (int i = 0; i < 2; i++)
        {
            password.Append(specialCharacters[random.Next(specialCharacters.Length)]);
        }

        // Numbers
        for (int i = 0; i < 2; i++)
        {
            password.Append(random.Next(10));
        }

        // Last two digits of registration number
        password.Append(registrationNumber.Substring(registrationNumber.Length - 2));

        // Shuffle the characters in the password for added security
        string shuffledPassword = new string(password.ToString().ToCharArray().OrderBy(s => (random.Next(2) % 2) == 0).ToArray());

        return shuffledPassword;
    }
}
