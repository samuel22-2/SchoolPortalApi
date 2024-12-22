namespace SchoolPortalApi.Models
{
    public class PassMark
    {

        public static double CutOff(int departmentId)
        {
            double cutoff = 0;
            if (departmentId == 1)
            {
                cutoff = 82.00;
            }

            else if (departmentId == 2)
            {
                cutoff = 77.00;
            }

            else if (departmentId == 3)
            {
                cutoff = 77.00;
            }

            else if (departmentId == 4)
            {
                cutoff = 74.00;
            }

            else if (departmentId == 5)
            {
                cutoff = 72.50;
            }

            else if (departmentId == 6)
            {
                cutoff = 71.50;
            }

            else if (departmentId == 7)
            {
                cutoff = 72.00;
            }

            else if (departmentId == 8)
            {
                cutoff = 71.00;
            }

            else if (departmentId == 9)
            {
                cutoff = 55.00;
            }

            else if (departmentId == 10)
            {
                cutoff = 75.00;
            }

            else if (departmentId == 11)
            {
                cutoff = 71.70;
            }

            else if (departmentId == 12)
            {
                cutoff = 67.00;
            }

            else if (departmentId == 13)
            {
                cutoff = 65.70;
            }

            else if (departmentId == 14)
            {
                cutoff = 63.70;
            }

            else if (departmentId == 15)
            {
                cutoff = 70.70;
            }

            else if (departmentId == 16)
            {
                cutoff = 62.70;
            }

            else if (departmentId == 17)
            {
                cutoff = 70.70;
            }

            else if (departmentId == 18)
            {
                cutoff = 77.00;
            }

            else if (departmentId == 19)
            {
                cutoff = 60.50;
            }

           

            return cutoff;

        }
    }
}
