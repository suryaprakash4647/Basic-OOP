
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Class CustomerDetails used to create instance for customer <see cref="CustomerDetails"/>
    /// Refer documentation on <see href="www.syncfusion.com"/> 
    /// </summary>
    public class CustomerDetails
    {
        /// <summary>
        /// Static Field s_customerId used to autoincremented CustomerID of the instance of <see cref="CustomerDetails"/>
        /// </summary>
        private static int s_customerId=1001; //Auto-incremented customer ID strating From 1001
        /// <summary>
        /// CustomerId property used to hold a Customer's ID of instance of <see cref="CustomerDetails"/>
        /// </summary>
        public string  CustomerId{get;} 
        /// <summary>
        /// CustomerName proper used to hold CustomerName of instance of <see cref="CustomerDetails"/>
        /// </summary>
        public string CustomerName{get;set;}
        public double Balance{get;set;}
        /// <summary>
        /// 
        /// </summary>
        public Gender Gender{get;set;}
        public long Phone{get;set;}
        public string MailId{get; set;}
        public DateTime DOB{get;set;}
        /// <summary>
        /// Method Deposit used to check wheather the instance of <see cref="CustomerDetails"/>
        /// Deposit for adding ammount to bank account
        /// </summary>
        /// <returns>Returns Balance if ammount added </returns>
        public double Deposit()
        {
            Console.Write("How much ammount you want to deposit : ");
            double depositAmmount=double.Parse(Console.ReadLine());
            Balance=Balance+depositAmmount;
            return Balance;
        }
        public double Withdraw()
        {
            double withdrawlAmmount;
                Console.Write("How much ammount you want to withdrawl : ");
                withdrawlAmmount=double.Parse(Console.ReadLine());
                if(withdrawlAmmount<=Balance && withdrawlAmmount>0 )
                {
                    Balance=Balance-withdrawlAmmount;
                }
                else
                {
                    Console.WriteLine("Insufficient Balance");
                }        
            return Balance;
        }
        /// <summary>
        /// Constructor CustomerDetails used to initilize parameter values to its properties.
        /// </summary>
        /// <param name="name">name parameter used to assign its value to associated property</param> 
        /// <param name="balance"></param>
        /// <param name="gender"></param>
        /// <param name="phone"></param>
        /// <param name="mailId"></param>
        /// <param name="dob"></param> <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="balance"></param>
        /// <param name="gender"></param>
        /// <param name="phone"></param>
        /// <param name="mailId"></param>
        /// <param name="dob"></param>
        public CustomerDetails(string name,double balance,Gender gender, long phone,string mailId,DateTime dob )
        {
            CustomerName=name;
            Balance=balance;
            Gender=gender;
            Phone=phone;
            MailId=mailId;
            DOB=dob;
            s_customerId++;
            CustomerId="HDFC"+s_customerId;
        }
    }
    /// <summary>
    /// DataType Gender used to select a instance of <see cref="CustomerDetails"/> Gender Information 
    /// </summary>
    public enum Gender
    {
        Select,
        Male,
        Female
    }
}