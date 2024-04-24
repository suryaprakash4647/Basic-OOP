using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //static class
    public static class Operations
    {
        static StudentDetails currentLoggedInStudent;
        //Static List Creation
        static List<StudentDetails> studentList=new List<StudentDetails>();
        static List<DepartmentDetails> departmentList=new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList=new List<AdmissionDetails>();

        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("****************** Welcom to Syncfusion College ******************");

            string mainChoice="yes";
            do
            {
                //Need to show the main menu option
                Console.WriteLine("Main Menu \n1.Registration\n2.Login\n3.Department wise seat availability\n4.Exit");
                //Need to get an input from user and validate.
                Console.WriteLine("Select an Option : ");
                int mainOption = int.Parse(Console.ReadLine());
                //Need to create main memu structure
                //need to iterate untill the option is exit.
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("**********  Student Registration  **********");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("**********  Student Login  **********");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("**********  Department wise seat availability  **********");
                            DepartmentWiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Application exit successfully");
                            mainChoice="no";
                            break;
                        }
                }
            } while (mainChoice=="yes");
        }//MainMenu ends

        //Student Registration
        public static void StudentRegistration()
        {
            //Need to get required details
            //need to create an object
            //need to add in the list
            //need to display conformation message and ID.
            Console.Write("Enter your name :");
            string studentName = Console.ReadLine();
            Console.Write("Enter your Father name :");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your Date of Birth as DD/MM/YYYY :");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your Gender (male/Female):");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your Physics mark :");
            int physics=int.Parse(Console.ReadLine());
            Console.Write("Enter your Chemistry mark :");
            int Chemistry=int.Parse(Console.ReadLine());
            Console.Write("Enter your Maths mark :");
            int maths=int.Parse(Console.ReadLine());
            StudentDetails studentDetails=new StudentDetails(studentName,fatherName,dob,gender,physics,Chemistry,maths);
            studentList.Add(studentDetails);
            Console.WriteLine($"You are Successfully Registered, your ID is {studentDetails.StudentID}");
        }
        //Student Login 
        public static void StudentLogin()
        {
            //Need to get ID input 
            Console.Write("Enter you Student ID : ");
            string loginID=Console.ReadLine().ToUpper();
            //Validate by its presence in the list.
            bool flag=true;
            foreach(StudentDetails student in studentList)
            {
                if(loginID.Equals(student.StudentID))
                {
                    flag = false;
                    currentLoggedInStudent=student;
                    Console.WriteLine("Logged in Successfully");
                    //Need to call Sub Menu
                    SubMenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID or ID is not present");
            }
            //if not-Invalid 
        }
        //Sub menu
        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                Console.WriteLine("********** Sub Menu **********");
                //need to show sub menu
                Console.WriteLine("Sub Menu \n1.Check Eligibility\n2.Show Details\n3.Take Admission\n4.Cancel Admission \n5.Show Admission Details\n6.Exit");
                //getting user option
                Console.Write("Enter your Option : ");
                int subOption = int.Parse(Console.ReadLine());
                //Itrerate till the option is exit.
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine("********** Check Eligibility **********");
                        CheckEligibility();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("********** Show Details **********");
                        ShowDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("********** Take Admission **********");
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("********** Cancel Admission **********");
                        CancelAdmission();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("********** Show Admission Details **********");
                        ShowAdmissionDetails();
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine("Taking Back to Main menu");
                        subChoice="no";
                        break;
                    }
                }
            }while(subChoice=="yes");
        }//sub menu ends

        //Check Eligibility
        public static void CheckEligibility()
        {
            //Get the cutoff value as input
            Console.Write("Enter the cutoff value : ");
            double cutOff = double.Parse(Console.ReadLine());
            if(currentLoggedInStudent.CheckEligibility(cutOff))
            {
                Console.WriteLine("Student is Eligible");
            }
            else{
                Console.WriteLine("Student is Not Eligible");
            }
        }//Check Eligibility ends
        
        //Show Details
        public static void ShowDetails()
        {
            //need to show current student Details
            Console.WriteLine("|StudentID|StudentName|FatherName|DOB|Gender|Physics Mark|Chemistry Mark| Maths Mark|");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.Physics}|{currentLoggedInStudent.Chemistry}|{currentLoggedInStudent.Maths}|");
        }//Show Details ends

        //Take Admission

        public static void TakeAdmission()
        {
            //Need to show available department details
            DepartmentWiseSeatAvailability();
            //Ask department ID from user
            Console.Write("Select a department ID : ");
            string departmentID=Console.ReadLine().ToUpper();
            //check the ID is present or not
            bool flag=true;
            foreach(DepartmentDetails department in departmentList)
            {
                if(departmentID.Equals(department.DepartmentID))
                {
                    flag=false;
                    //Check the student is eligible or not
                    if(currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        // check the seat availability
                        if(department.NumberOfSeats>0)
                        {
                            //check student already taken any admission
                            int count=0;
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }
                            if(count==0)
                            {
                                //create admission object 
                                AdmissionDetails admissionTaken=new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartmentID,DateTime.Now, AdmissionStatus.Admitted);
                                //Reduce seat count
                                department.NumberOfSeats--;
                                //Add to the admission list
                                admissionList.Add(admissionTaken);
                                //Display admission Successful message
                                Console.WriteLine($"You have taken admission taken successfully. Admission ID : {admissionTaken.AdmissionID}");
                            }
                            else
                            {
                                Console.WriteLine("You have Already taken an Admission");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Seats are Not Available");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You are Not eligible due to low cutoff");
                    }
                    
                    
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID or ID not present");
            }
            

        }

        //Cancel Admission
        public static void CancelAdmission()
        {
            //check the student is taken any admission and display it.
            bool flag=true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    //cancel the found admission
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    //return the seat to department
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }
                    }
                    break;

                }
            }
            if(flag)
            {
                Console.WriteLine("You have not admission to cancel");
            }
            
        }

        //Show Admission Details
        public static void ShowAdmissionDetails()
        {
            //Need to show current loggin student's admission
            Console.WriteLine();
            foreach(AdmissionDetails admission in admissionList)
            {
                Console.WriteLine("|AdmissionID|StudentID|AdmissionDate|AdmissionStatus|");
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                {
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}");
                }
            }
        }//Show Admission Details ends

        //Department Wise Seat Availability
        public static void DepartmentWiseSeatAvailability()
        {
            Console.WriteLine("|DepartmentID|DepartmentName|NumberOfSeats|");
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"|{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}");
            }
            Console.WriteLine();
        }


        //Adding default Data
        public static void AddDeafultData()
        {
            StudentDetails student1=new StudentDetails("Ravichandran","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentDetails student2=new StudentDetails("Baskaran","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            studentList.AddRange(new List<StudentDetails>{student1,student2});
            
            DepartmentDetails department1=new DepartmentDetails("EEE",29);
            DepartmentDetails department2=new DepartmentDetails("CSE",29);
            DepartmentDetails department3=new DepartmentDetails("MECH",29);
            DepartmentDetails department4=new DepartmentDetails("ECE",29);
            departmentList.AddRange(new List<DepartmentDetails>{department1,department2,department3,department4});

            AdmissionDetails admission1=new AdmissionDetails(student1.StudentID,department1.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
            AdmissionDetails admission2=new AdmissionDetails("SF3002","DID102",new DateTime(2022,05,12),AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissionDetails>{admission1,admission2});

            
        }

    
    }
}