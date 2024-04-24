using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class DepartmentDetails
    {
        // Field
        private static int s_departmentID=100;
        //Proprty
        public string DepartmentID {get;}
        public string DepartmentName {get;set;}
        public int NumberOfSeats{get; set;}
        //conreuctor
       public  DepartmentDetails(string departmentName,int numberOfSeats)
       {
            s_departmentID++;
            DepartmentID="DID"+s_departmentID;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;

       }

    }
}