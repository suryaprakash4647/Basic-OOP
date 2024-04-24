using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
    public enum WorkLocation{Select , Chennai , Bangalore}
    public enum Gender{Select , Male, Female}
    public class EmployeeDetails
    {
        public int _employeeId=1000;
        private string name;
        private string workLocation;
        private DateTime dateOfJoining;
        private int numberOfLeaveTaken;

        public string EmployeeID{get;set;}
        public string EmployeeName{get;set;}
        public string Role{get;set;}
        public WorkLocation Location{get; set;}
        public string TeamName {get;set;}
        public DateTime JoiningDate {get;set;}
        public int NumberOfWorkingDaysInMonth{get;set;}
        public int Leave{get;set;}
        public Gender Gender{get;set;}
        
        public double SalaryCalculation()
        {
            
            double salary=500*(NumberOfWorkingDaysInMonth - Leave);
            return salary;
        }
        public EmployeeDetails(string name,string role,WorkLocation workLocation,string teamName,DateTime joiningDate,int numberOfWorkingDaysInMonth,int leave,Gender gender)
        {
            _employeeId++;
            EmployeeID="SF"+_employeeId;
            EmployeeName=name;
            Role=role;
            Location=workLocation;
            TeamName=teamName;
            JoiningDate=joiningDate;
            NumberOfWorkingDaysInMonth=numberOfWorkingDaysInMonth;
            Leave=leave;
            Gender=gender;
            
        }

        public EmployeeDetails(string name, string role, string workLocation, string teamName, DateTime dateOfJoining, int numberOfWorkingDaysInMonth, int numberOfLeaveTaken, Gender gender)
        {
            this.name = name;
            Role = role;
            this.workLocation = workLocation;
            TeamName = teamName;
            this.dateOfJoining = dateOfJoining;
            NumberOfWorkingDaysInMonth = numberOfWorkingDaysInMonth;
            this.numberOfLeaveTaken = numberOfLeaveTaken;
            Gender = gender;
        }
    }
}