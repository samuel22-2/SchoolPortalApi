namespace SchoolPortalApi.Models
{
    public class GenerateID
    {
        private Dictionary<string, int> yearCounters = new Dictionary<string, int>();

        public  string GenerateApplicantID()
        {
            // Get the last two digits of the current year (e.g., 2024 -> "24")
            string year = DateTime.Now.Year.ToString().Substring(2, 2);

            // Initialize the counter for the current year if it doesn't exist
            if (!yearCounters.ContainsKey(year))
            {
                yearCounters[year] = 1;  // Start from 1 for each year
            }
            else
            {
                // Increment the counter for this year
                yearCounters[year]++;
            }

            // Get the counter value and format it as a four-digit number (e.g., 0001, 0002)
            string counter = yearCounters[year].ToString("D4");

            // Combine year and counter to form the 6-digit applicant ID
            return $"{year}{counter}";
        }


        public static string GenerateMatricNo(int lastId)
        {
            string MatricNo = string.Empty;
            var prefix = string.Empty;
            //get the current year
            string yearcode = DateTime.Now.Year.ToString();
            //get the length of the year 
            int length = yearcode.Length;
            int num = length - 2;
            int length2 = length - num;
            //get the last 2 part of the year e.g. 23 in 2023
            yearcode = yearcode.Substring(num, length2);
            string strlastId = lastId.ToString();
            length = strlastId.Length;
            num = 4 - length;

            if (num > 0)
            {
                //appending the prefix of 0s to complete the length of fours
                for (var i = 0; i < num; i++)
                {
                    prefix += "0";
                }



            }
            MatricNo = $"{yearcode}/{prefix}{lastId}";
            return MatricNo;
        }
    }
}
