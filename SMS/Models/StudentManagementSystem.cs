using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class StudentManagement
    {
        [Display(Name = "Student Id")]
        public string StudentId
        {
            get
            {
                string hexTicks = DateTime.Now.Ticks.ToString("X");
                return hexTicks.Substring(hexTicks.Length - 15, 9);
            }

            set { }
        }

        // add student
        [Required]
        [Display(Name = "Student Id")]
        public string ViewId { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ic")]
        public string IC { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Age")]
        public string Age { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Personal Email")]
        public string PersonalEmail { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string studentEmail { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string Course { get; set; }



        [Display(Name = "Course Name")]
        public string courseName { get; set; }

        // Dict department

        [Display(Name = "Course Department")]
        public int IndexDept { get; set; }
        public int courseDept { get; set; }
        public IDictionary<int, string> DictDept
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    {0, "Electrical Engineering" },
                    {1, "Mechanical Engineering" },
                    {2, "Computer And Information" }

                };
            }

            set { }
        }

        // Dict Intake
        [Required]
        [Display(Name = "Intake")]
        public int Intake { get; set; }

        [Required]
        [Display(Name = "Intake")]
        public IDictionary<int, string> DictIntake
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    {0, "2012" },
                    {1, "2013" },
                    {2, "2014" },
                    {3, "2015" },
                    {4, "2016" },
                    {5, "2017" },
                    {6, "2018" },
                    {7, "2019" },
                    {8, "2020" },
                    {9, "2021" },
                    {10, "2022" },
                    {11, "2023" },
                    {12, "2024" }
                };
            }
            set { }
        }

        //Dict course
        [Required]
        [Display(Name = "Course")]
        public string studentCourse { get; set; }

        [Display(Name = "Course")]
        public IDictionary<int, string> DictCourse
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    {0, "" },
                    {1, "BSE" },
                    {2, "NVM" },  //dummy data
                    {3, "IDK" },
                    {4, "TRY" },
                    {5, "HARD" }
                };
            }
            set { }
        }

        

    }
    
}
