using Microsoft.EntityFrameworkCore;
using System;

namespace SchoolPortalApi.Models
{
    public class GenerateID
    {

        private readonly TestContext _context;

        //public GenerateID(TestContext context)
        //{
        //    _context = context;
        //}
        private Dictionary<string, int> yearCounters = new Dictionary<string, int>();
        private Random random = new Random();

        private int currentId = 0;
        public int currentCounter = 1;  // Initialize the counter, starting from 1
        public string currentYear = DateTime.Now.Year.ToString().Substring(2, 2);  // Track the last two digits of the current year


        //public string GenerateApplicantID()
        //{
        //    // Get the last two digits of the current year (e.g., 2024 -> "24")
        //    string year = DateTime.Now.Year.ToString().Substring(2, 2);

        //    // Initialize the counter for the current year if it doesn't exist
        //    if (!yearCounters.ContainsKey(year))
        //    {
        //        // If the counter for the year does not exist, generate an initial ID
        //        if (currentId == 0)
        //        {
        //            currentId = random.Next(100, 1000);
        //            //currentId = 1;  // Start from 1 for the first applicant
        //        }
        //        yearCounters[year] = currentId;  // Assign currentId as the first ID for the year
        //    }
        //    else
        //    {
        //        // Increment the counter for this year for subsequent generations

        //        currentId++;
        //        //yearCounters[year]++;
        //    }

        //    // Get the counter value and format it as a four-digit number (e.g., 0001, 0002)
        //    string counter = yearCounters[year].ToString("D4");

        //    // Combine year and counter to form the 6-digit applicant ID
        //    return $"{year}{counter}";
        //}



        public string GenerateApplicantID()
        {
            // Get the last two digits of the current year (e.g., 2025 -> "25")
            string year = DateTime.Now.Year.ToString().Substring(2, 2);

            // If the year has changed (new year), reset the counter and update the current year
            if (year != currentYear)
            {
                currentYear = year;
                currentCounter = 1;  // Reset the counter for the new year
            }

            // Format the counter as a 4-digit number (e.g., 0001, 0002)
            string counter = currentCounter.ToString("D4");

            // Combine the last two digits of the year and the counter to form the applicant ID
            string applicantID = $"{year}{counter}";

            // Increment the counter for the next applicant
            currentCounter++;

            return applicantID;
        }


        //public string GenerateApplicantID()
        //{
        //    // Get the last two digits of the current year (e.g., 2024 -> "24")
        //    string year = DateTime.Now.Year.ToString().Substring(2, 2);

        //    // Initialize the counter for the current year if it doesn't exist
        //    if (!yearCounters.ContainsKey(year))
        //    {
        //        yearCounters[year] = 1;  // Start from 1 for each year
        //    }
        //    else
        //    {
        //        // Increment the counter for this year
        //        yearCounters[year]++;
        //    }

        //    // Get the counter value and format it as a four-digit number (e.g., 0001, 0002)
        //    string counter = yearCounters[year].ToString("D4");

        //    // Combine year and counter to form the 6-digit applicant ID
        //    return $"{year}{counter}";
        //}



        //public string GenerateApplicantID()
        //{
        //    // Get the last two digits of the current year (e.g., 2024 -> "24")
        //    string year = DateTime.Now.Year.ToString().Substring(2, 2);

        //    // Fetch the last ApplicantId from the database to ensure uniqueness
        //    var lastApplicant = _context.Registrations
        //        .Where(r => r.ApplicantId.StartsWith(year))
        //        .OrderByDescending(r => r.ApplicantId)
        //        .FirstOrDefault();

        //    int lastCounter = 0;

        //    // If there is a previous applicant from the same year, extract the counter value
        //    if (lastApplicant != null)
        //    {
        //        string lastApplicantId = lastApplicant.ApplicantId;
        //        lastCounter = int.Parse(lastApplicantId.Substring(2, 4));  // Get the last 4 digits of the ID
        //    }

        //    // Increment the counter
        //    lastCounter++;

        //    // Format the new applicant ID with the incremented counter
        //    string counter = lastCounter.ToString("D4");  // Ensure it's a 4-digit number

        //    // Combine year and counter to form the 6-digit applicant ID
        //    return $"{year}{counter}";
        //}


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
