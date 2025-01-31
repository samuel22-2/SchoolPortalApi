using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolPortalApi;
using Microsoft.EntityFrameworkCore;
using SchoolPortalApi.Models;
using Org.BouncyCastle.Asn1.IsisMtt.X509;

namespace SchoolPortalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        //private readonly GenerateID _idGenerator;

        //public StudentController(GenerateID idGenerator)
        //{
        //    _idGenerator = idGenerator;
        //}
        private readonly TestContext _context;


        public StudentController(TestContext context)
        {
            _context = context;
        }


        [HttpGet("GetAllApplicants")]
        public async Task<ActionResult<IEnumerable<object>>> GetRegistrations()
        {
            if (_context.Registrations == null)
            {
                return NotFound();
            }

            // Project the Registrations to return only the specified fields
            var result = await _context.Registrations
                .Select(r => new
                {
                    r.FirstName,
                    r.MiddleName,
                    r.LastName,
                    r.PhoneNumber,
                    r.Email,
                    r.Address,
                    r.DOB,
                    r.Gender,
                    r.MaritalStatus,
                    r.Nationality,
                    r.StateOfOrigin,
                    r.Denomination,
                    r.GuardianName,
                    r.GuardianPhoneNumber,
                    r.GuardianEmail,
                    r.GuardianAddress,
                    r.SecondarySchool,
                    r.SchoolAddress,
                    r.JambScore,
                    r.CourseOfStudy,
                    r.Score
                })
                .ToListAsync();

            return Ok(result);
        }



        [HttpGet("GetApplicants{ApplicantId}")]
        public async Task<ActionResult<object>> GetRegistrationByApplicantId(string applicantId)
        {
            // Find the registration by ApplicantId
            var registration = await _context.Registrations
                .Where(x => x.ApplicantId == applicantId)
                .Select(r => new
                {
                    r.FirstName,
                    r.MiddleName,
                    r.LastName,
                    r.PhoneNumber,
                    r.Email,
                    r.Address,
                    r.DOB,
                    r.Gender,
                    r.MaritalStatus,
                    r.Nationality,
                    r.StateOfOrigin,
                    r.Denomination,
                    r.GuardianName,
                    r.GuardianPhoneNumber,
                    r.GuardianEmail,
                    r.GuardianAddress,
                    r.SecondarySchool,
                    r.SchoolAddress,
                    r.JambScore,
                    r.CourseOfStudy,
                    r.Score
                })
                .FirstOrDefaultAsync();

            // Check if the registration exists
            if (registration == null)
            {
                return NotFound();
            }

            // Return the selected fields
            return Ok(registration);
        }


        //[HttpPost("Register")]
        //public async Task<IActionResult> PostRegistration([FromBody] ModelDto register)
        //{
        //    // Step 1: Lookup Department by CourseOfStudy
        //    var department = _context.Departments.FirstOrDefault(d => d.DepartmentName == register.CourseOfStudy);
        //    if (department == null)
        //    {
        //        return BadRequest(new { message = "Invalid course of study selected.", statusCode = 400 });
        //    }

        //    // Step 2: Extract DepartmentName and DepartmentId
        //    string courseOfStudy = department.DepartmentName;
        //    int departmentId = department.DepartmentId;

        //    // Step 3: Calculate Applicant's Age
        //    int age = DateTime.Now.Year - register.DOB.Year;

        //    // Step 4: Calculate WAEC/Exam Score and Total Aggregate
        //    double sum = 0;
        //    if (register.ExamList.Count > 0)
        //    {
        //        foreach (var exam in register.ExamList)
        //        {
        //            sum += GradeConversion.SendScore(exam.Grade);
        //        }
        //    }

        //    //double totalScore = (sum / 25 * 35) + (register.JambScore / 400 * 65);
        //    double totalScore = (sum / 25 * 35) + ((double)register.JambScore / 400 * 65);


        //    // Step 5: Generate and Hash Password
        //    var passwordService = new GeneratePassword();  // Assuming you renamed the class as GeneratePassword
        //    string generatedPassword = passwordService.GenerateRandomPassword(12);  // Generates a random 12-character password
        //    string hashedPassword = passwordService.HashPassword(generatedPassword);  // Hashes the password

        //    // Step 6: Save Applicant Data to Registrations Table

        //    //var idGenerator = new GenerateID(_context);

        //    var registration = new Registration
        //    {

        //        FirstName = register.FirstName,
        //        MiddleName = register.MiddleName,
        //        LastName = register.LastName,
        //        PhoneNumber = register.PhoneNumber,
        //        Email = register.Email,
        //        DOB = register.DOB,
        //        Gender = register.Gender,
        //        MaritalStatus = register.MaritalStatus,
        //        Nationality = register.Nationality,
        //        StateOfOrigin = register.StateOfOrigin,
        //        Denomination = register.Denomination,
        //        Address = register.Address,
        //        GuardianName = register.GuardianName,
        //        GuardianEmail = register.GuardianEmail,
        //        GuardianPhoneNumber = register.GuardianPhoneNumber,
        //        GuardianAddress = register.GuardianAddress,
        //        JambScore = register.JambScore,
        //        SecondarySchool = register.SecondarySchool,
        //        SchoolAddress = register.SchoolAddress,
        //        CourseOfStudy = register.CourseOfStudy,  // Store the course of study name
        //        Score = totalScore,
        //        PasswordHash = hashedPassword  // Save the hashed password in the database
        //    };
        //    _context.Registrations.Add(registration);
        //    await _context.SaveChangesAsync();  // Save registration data for all applicants

        //    // Step 7: Save Exam Data to Exams Table
        //    if (register.ExamList.Count > 0)
        //    {
        //        foreach (var exam in register.ExamList)
        //        {
        //            var examEntry = new Exam
        //            {
        //                ApplicantId = registration.ApplicantId,  // Save the ApplicantId
        //                Subject = exam.Subject,
        //                Grade = exam.Grade
        //            };
        //            _context.Exams.Add(examEntry);
        //        }
        //        await _context.SaveChangesAsync();  // Save all the exams for the applicant
        //    }

        //    // Step 8: Check Conditions for Age, JAMB Score, and Cutoff
        //    if (age < 16)
        //    {
        //        return BadRequest(new { message = "Applicant is too young.", statusCode = 400 });
        //    }

        //    if (register.JambScore < 160)
        //    {
        //        return BadRequest(new { message = "JAMB score is too low.", statusCode = 400 });
        //    }

        //    double requiredCutoff = PassMark.CutOff(departmentId);  // Get the cutoff for the department
        //    if (totalScore < requiredCutoff)
        //    {
        //        return BadRequest(new { message = "Total score is below the cutoff for the selected course of study.", statusCode = 400 });
        //    }

        //    // Step 9: Save to WaitingLists table if all conditions are met
        //    var waitingList = new WaitingList
        //    {

        //        ApplicantId = registration.ApplicantId,
        //        FirstName = register.FirstName,
        //        MiddleName = register.MiddleName,
        //        LastName = register.LastName,
        //        PhoneNumber = register.PhoneNumber,
        //        Email = register.Email,
        //        Address = register.Address,
        //        DOB = register.DOB,
        //        Gender = register.Gender,
        //        MaritalStatus = register.MaritalStatus,
        //        Nationality = register.Nationality,
        //        StateOfOrigin = register.StateOfOrigin,
        //        Denomination = register.Denomination,
        //        GuardianName = register.GuardianName,
        //        GuardianEmail = register.GuardianEmail,
        //        GuardianPhoneNumber = register.GuardianPhoneNumber,
        //        GuardianAddress = register.GuardianAddress,
        //        JambScore = register.JambScore,
        //        CourseOfStudy = courseOfStudy,  // Store the department name
        //        Score = totalScore
        //    };
        //    _context.WaitingLists.Add(waitingList);
        //    await _context.SaveChangesAsync();

        //    //// Step 10: Send Email to Applicant
        //    //string emailBody = $"Dear {registration.FirstName},\n\n" +
        //    //                   "Thank you for applying to YRN University. We have successfully received your application for admission. " +
        //    //                   "The screening process will begin shortly, and the admission list will be out soon.\n\n" +
        //    //                   $"You can log in to your student portal using the following credentials:\n" +
        //    //                   $"Username: {registration.Email}\n" +
        //    //                   $"Password: {generatedPassword}\n\n" +
        //    //                   "Please ensure to change Your Password.\n\n" +
        //    //                   "Best regards,\n" +
        //    //                   "YRN University Admissions Team";

        //    //Email.SendEmail(register.Email, register.FirstName, "YRN University Admissions", emailBody);

        //    var subject = "Admissions!";
        //    var body = $"Dear {register.FirstName} {register.LastName},Thank you for applying to YRN University. We have successfully received your application for admission. "  +
        //               " The screening process will begin shortly, and the admission list will be out soon.\n\n " +
        //               $"You can log in to your student portal using the following credentials:\n" +
        //                $"Username: {registration.Email}\n" +
        //                $"Password: {generatedPassword}\n\n" +
        //                "Please ensure to change Your Password.\n\n" +
        //                "Best regards,\n" +
        //                "YRN University Admissions Team";




        //    // Final response for successful registration and waiting list entry
        //    return Ok(new
        //    {
        //        message = "Registration successful and acknowledgment email sent.",
        //        ApplicantId = registration.ApplicantId,
        //        statusCode = 200
        //    });
        //}


        [HttpPost("Register")]
        public async Task<IActionResult> PostRegistration([FromBody] ModelDto register)
        {
            // Step 1: Lookup Department by CourseOfStudy
            var department = _context.Departments.FirstOrDefault(d => d.DepartmentName == register.CourseOfStudy);
            if (department == null)
            {
                return BadRequest(new { message = "Invalid course of study selected.", statusCode = 400 });
            }

            // Step 2: Extract DepartmentName and DepartmentId
            string courseOfStudy = department.DepartmentName;
            int departmentId = department.DepartmentId;

            // Step 3: Calculate Applicant's Age
            int age = DateTime.Now.Year - register.DOB.Year;

            // Step 4: Calculate WAEC/Exam Score and Total Aggregate
            double sum = 0;
            if (register.ExamList.Count > 0)
            {
                foreach (var exam in register.ExamList)
                {
                    sum += GradeConversion.SendScore(exam.Grade);
                }
            }

            // Ensure JambScore is cast to double for floating-point division
            double totalScore = (sum / 25 * 35) + ((double)register.JambScore / 400 * 65);

            // Step 5: Generate and Hash Password
            var passwordService = new GeneratePassword();
            string generatedPassword = passwordService.GenerateRandomPassword(12);
            string hashedPassword = passwordService.HashPassword(generatedPassword);

            // Step 6: Save Applicant Data to Registrations Table
            var registration = new Registration
            {
                FirstName = register.FirstName,
                MiddleName = register.MiddleName,
                LastName = register.LastName,
                PhoneNumber = register.PhoneNumber,
                Email = register.Email,
                DOB = register.DOB,
                Gender = register.Gender,
                MaritalStatus = register.MaritalStatus,
                Nationality = register.Nationality,
                StateOfOrigin = register.StateOfOrigin,
                Denomination = register.Denomination,
                Address = register.Address,
                GuardianName = register.GuardianName,
                GuardianEmail = register.GuardianEmail,
                GuardianPhoneNumber = register.GuardianPhoneNumber,
                GuardianAddress = register.GuardianAddress,
                JambScore = register.JambScore,
                SecondarySchool = register.SecondarySchool,
                SchoolAddress = register.SchoolAddress,
                CourseOfStudy = register.CourseOfStudy,
                Score = totalScore,
                PasswordHash = hashedPassword
            };

            // Save Registration first, so ApplicantId is generated
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync(); // ApplicantId will now be generated

            // Step 7: Save Exam Data to Exams Table
            if (register.ExamList.Count > 0)
            {
                foreach (var exam in register.ExamList)
                {
                    var examEntry = new Examss
                    {
                        ApplicantId = registration.ApplicantId,  // Now ApplicantId is populated
                        Subject = exam.Subject,
                        Grade = exam.Grade
                    };
                    _context.Examsss.Add(examEntry);
                }
                await _context.SaveChangesAsync();  // Save all the exams for the applicant
            }

            // Step 8: Check Conditions for Age, JAMB Score, and Cutoff
            if (age < 16)
            {
                return Ok(new { message = "Applicant is too young.", success = false, statusCode = 200 });
            }

            if (register.JambScore < 160)
            {
                return Ok(new { message = "JAMB score is too low.", success = false, statusCode = 200 });
            }

            double requiredCutoff = PassMark.CutOff(departmentId);  // Get the cutoff for the department
            if (totalScore < requiredCutoff)
            {
                return Ok(new { message = "Total score is below the cutoff for the selected course of study.", success = false, statusCode = 200 });
            }

            // Step 9: Save to WaitingLists table if all conditions are met
            var waitingList = new WaitingList
            {
                ApplicantId = registration.ApplicantId,
                FirstName = register.FirstName,
                MiddleName = register.MiddleName,
                LastName = register.LastName,
                PhoneNumber = register.PhoneNumber,
                Email = register.Email,
                Address = register.Address,
                DOB = register.DOB,
                Gender = register.Gender,
                MaritalStatus = register.MaritalStatus,
                Nationality = register.Nationality,
                StateOfOrigin = register.StateOfOrigin,
                Denomination = register.Denomination,
                GuardianName = register.GuardianName,
                GuardianEmail = register.GuardianEmail,
                GuardianPhoneNumber = register.GuardianPhoneNumber,
                GuardianAddress = register.GuardianAddress,
                JambScore = register.JambScore,
                CourseOfStudy = courseOfStudy,
                Score = totalScore
            };
            _context.WaitingLists.Add(waitingList);
            await _context.SaveChangesAsync();


            // Send acknowledgment email (code commented out)

            string emailBody = $"Dear {registration.FirstName},\n\n" +
                                   "Thank you for applying to YRN University. We have successfully received your application for admission. " +
                                   "The screening process will begin shortly, and the admission list will be out soon.\n\n" +
                                   $"You can log in to your student portal using the following credentials:\n" +
                                   $"Username: {registration.Email}\n" +
                                   $"Password: {generatedPassword}\n\n" +
                                   "Please ensure to change Your Password.\n\n" +
                                   "Best regards,\n" +
                                   "YRN University Admissions Team";

            Email.SendEmail(register.Email, register.FirstName, "YRN University Admissions", emailBody);

            var subject = "Admissions!";
            var body = $"Dear {register.FirstName} {register.LastName},Thank you for applying to YRN University. We have successfully received your application for admission. " +
                       " The screening process will begin shortly, and the admission list will be out soon.\n\n " +
                       $"You can log in to your student portal using the following credentials:\n" +
                        $"Username: {registration.Email}\n" +
                        $"Password: {generatedPassword}\n\n" +
                        "Please ensure to change Your Password.\n\n" +
                        "Best regards,\n" +
                        "YRN University Admissions Team";

            return Ok(new
            {
                message = "Registration successful and acknowledgment email sent.",
                ApplicantId = registration.ApplicantId,
                statusCode = 200
            });
        }

        [HttpPost("AdmitStudent/{ApplicantId}")]
        public async Task<IActionResult> AdmitStudent(string ApplicantId)
        {
            //if (_context.WaitingLists == null || _context.AdmittedStudents == null)
            //{
            //    return NotFound(new { message = "WaitingLists or AdmittedStudents table not found.", statusCode = 404 });
            //}

            // Fetch the applicant from the WaitingLists table using the provided ApplicantId
            var applicant = await _context.WaitingLists.SingleOrDefaultAsync(w => w.ApplicantId == ApplicantId);
            if (applicant == null)
            {
                return NotFound(new { message = "Applicant not found in WaitingLists.", statusCode = 404 });
            }

            // Generate MatricNo for the admitted student using the GenerateID class
            int lastMatricId = await _context.AdmittedStudents.CountAsync();  // Assuming matric number increments based on count
            string matricNo = GenerateID.GenerateMatricNo(lastMatricId + 1);  // Use GenerateID class to generate matric number

            // Create a new AdmittedStudent record using the applicant's details
            var admittedStudent = new AdmittedStudent
            {
                MatricNo = matricNo,
                ApplicantId = applicant.ApplicantId,
                FirstName = applicant.FirstName,
                MiddleName = applicant.MiddleName,
                LastName = applicant.LastName,
                PhoneNumber = applicant.PhoneNumber,
                Email = applicant.Email,
                Address = applicant.Address,
                DOB = applicant.DOB,
                Gender = applicant.Gender,
                MaritalStatus = applicant.MaritalStatus,
                Nationality = applicant.Nationality,
                StateOfOrigin = applicant.StateOfOrigin,
                Denomination = applicant.Denomination,
                GuardianName = applicant.GuardianName,
                GuardianPhoneNumber = applicant.GuardianPhoneNumber,
                GuardianEmail = applicant.GuardianEmail,
                GuardianAddress = applicant.GuardianAddress,
                Score = applicant.Score
            };

            // Add the new admitted student to the AdmittedStudents table
            await _context.AdmittedStudents.AddAsync(admittedStudent);

            // Remove the applicant from the WaitingLists table since they've been admitted
            _context.WaitingLists.Remove(applicant);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Applicant successfully admitted.",
                matricNo = matricNo,
                statusCode = 200
            });
        }


        //[HttpDelete("{ApplicantId}")]
        //public async Task<IActionResult> DeleteApp(string? ApplicantId)
        //{
        //    if (_context.Registrations == null)
        //    {
        //        return NotFound();
        //    }
        //    var emp = await _context.Registrations.FindAsync(ApplicantId);
        //    if (emp == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Registrations.Remove(emp);
        //    await _context.SaveChangesAsync();

        //    return Ok(new
        //    {
        //        message = "Applicant Deleted successfully",

        //        statusCode = 200
        //    });
        //}

        [HttpDelete("{ApplicantId}")]
        public async Task<IActionResult> DeleteApp(string? ApplicantId)
        {
            if (_context.Registrations == null || _context.WaitingLists == null)
            {
                return NotFound();
            }

            // Find the applicant in the Registrations table
            var applicantInRegistrations = await _context.Registrations.FindAsync(ApplicantId);
            if (applicantInRegistrations == null)
            {
                return NotFound(new { message = "Applicant not found in Registrations.", statusCode = 404 });
            }

            // Find and remove the applicant in the WaitingLists table based on the foreign key
            var applicantInWaitingLists = await _context.WaitingLists
                .Where(w => w.ApplicantId == ApplicantId)
                .ToListAsync();  // Use ToListAsync in case there are multiple entries for the same applicant

            if (applicantInWaitingLists.Any())
            {
                // Remove all entries from WaitingLists where ApplicantId matches
                _context.WaitingLists.RemoveRange(applicantInWaitingLists);
            }

            // Remove the applicant from Registrations table
            _context.Registrations.Remove(applicantInRegistrations);

            // Save changes for both deletions
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Applicant deleted successfully.",
                statusCode = 200
            });
        }


    }
}
