using System;
using System.Collections.Generic;
namespace EmployeePayrollManagement;
public class Program
{
    public static void  Main(string[] args)
    {   
        //EmployeeDetails Employee=new EmployeeDetails(employeeID,name, role,workLocation,teamName,dateOfJoining,numberOfWorkingDaysInMonth,numberOfLeaveTaken,gender);
        List<EmployeeDetails> Employees=new List<EmployeeDetails>();
        bool exit=false;
        
        while(!exit)
        {
            Console.WriteLine("1.Registration \n2.Login \n3.Exit ");
            Console.Write("Enter your option : ");
            int menuOption=int.Parse(Console.ReadLine());
            switch(menuOption)
            {
                case 1:
                {
                    
                    Console.WriteLine("----------Registration Form----------");

                    Console.WriteLine("Enter your Name : ");
                    string name=Console.ReadLine();

                    Console.WriteLine("Enter your Role : ");
                    string role=Console.ReadLine();
                    
                    Console.WriteLine("1.Chennai \n2.Banglore \nEnter your Work Location in above option : ");
                    WorkLocation workLocation=Enum.Parse<WorkLocation>(Console.ReadLine());

                    Console.WriteLine("Enter your Team name : ");
                    string teamName=Console.ReadLine();
                    
                    Console.WriteLine("Enter your Date Of Joining dd/MM/yyyy : ");
                    DateTime dateOfJoining=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    
                    Console.WriteLine("Enter Number of working day in month : ");
                    int numberOfWorkingDaysInMonth=int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Number of leave taken : ");
                    int numberOfLeaveTaken=int.Parse(Console.ReadLine());

                    Console.WriteLine("1.male \n2.female \nEnter your Gender in above option : ");
                    Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);

                    EmployeeDetails Details=new EmployeeDetails(name, role,workLocation,teamName,dateOfJoining,numberOfWorkingDaysInMonth,numberOfLeaveTaken,gender);
                    Employees.Add(Details);
                    Console.WriteLine("You have successfully registered.\n Your Employee ID is "+ Details.EmployeeID);

                    
                    break;
                }
                case 2:
                {
                    Login(); //Call the method to login
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Thank you come again...");
                    exit=true; //exit the application
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
                }
                
            }
        }
        void Login()
        {   
            Console.WriteLine("---------- Login ----------");
            Console.Write("Enter your Employee Id : ");
            string userEmployeeId=Console.ReadLine().ToUpper();
            foreach(EmployeeDetails ed in Employees)
            {
                if(ed.EmployeeID==userEmployeeId)
                { 
                        while(true)
                        {
                            Console.WriteLine($"--- Welcome {ed.EmployeeName } ---");
                            Console.WriteLine("Select the below option \n 1.Salary Calculation \n 2.Display Details \n 3.Exit ");
                            int subMenuOption=int.Parse(Console.ReadLine());
                            switch(subMenuOption)
                            {
                                case 1:
                                {
                                    ed.SalaryCalculation();
                                    Console.WriteLine("Your Salary : "+ed.SalaryCalculation());
                                    break;
                                }      
                                case 2:
                                {
                                    DisplayDetails();
                                    break;
                                }                             
                                case 3:
                                {
                                    
                                    return;
                                }
                                default:
                                {
                                    Console.WriteLine("Invalid option. Please choose again.");
                                    break;
                                }
                            }            
                        }
                }    
                else
                {
                    Console.WriteLine("Invalid User Id");
                }      
            }   
            
        }  
        void DisplayDetails() 
        {
                foreach(EmployeeDetails details in Employees)
                {
                    Console.WriteLine("Employee ID         : "+details.EmployeeID);
                    Console.WriteLine("Employee Name       : "+details.EmployeeName);
                    Console.WriteLine("Employee Role       : "+details.Role);
                    Console.WriteLine("Work Location       : "+details.Location);
                    Console.WriteLine("Team Name           : "+details.TeamName);
                    Console.WriteLine("Date Of Joining     : "+details.JoiningDate);
                    Console.WriteLine("No. of Days Working : "+details.NumberOfWorkingDaysInMonth);
                    Console.WriteLine("No. of leave taken  : "+details.Leave);
                    Console.WriteLine("Gender              : "+details.Gender);
                }
        }
    }
}
