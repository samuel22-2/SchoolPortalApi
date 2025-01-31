namespace SchoolPortalApi.Models
{
    public class GeneratePassword
    {

        private static readonly Random random = new Random();
        private const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string Symbols = "!@#$%^&*()-_+=<>?";

        public string GenerateRandomPassword(int length)
        {
            const string allChars = LowercaseLetters + UppercaseLetters + Digits + Symbols;

            // Ensure minimum length
            if (length < 8)
                throw new ArgumentException("Password length must be at least 8 characters.");

            // Ensure length of at least 1 character from each category
            if (length < 12)
                throw new ArgumentException("Password length must include at least 1 character from each category.");

            // Generate at least one character from each category
            string password = GetRandomCharacter(LowercaseLetters) +
                              GetRandomCharacter(UppercaseLetters) +
                              GetRandomCharacter(Digits) +
                              GetRandomCharacter(Symbols);

            // Generate remaining characters randomly
            for (int i = 4; i < length; i++)
            {
                password += allChars[random.Next(allChars.Length)];
            }

            // Shuffle the password characters
            password = ShuffleString(password);

            return password;
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        private string GetRandomCharacter(string characterSet)
        {
            return characterSet[random.Next(characterSet.Length)].ToString();
        }

        private string ShuffleString(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = chars.Length - 1; i > 0; i--)
            {
                int randIndex = random.Next(i + 1);
                char temp = chars[i];
                chars[i] = chars[randIndex];
                chars[randIndex] = temp;
            }
            return new string(chars);
        }
    }
}
