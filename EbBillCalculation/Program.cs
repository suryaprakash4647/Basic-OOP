using System;
using System.Collections.Generic;
namespace EbBillCalculation;
public class Program
{
    public static void Main(string[] args)
    {
        List<EbBill> bills=new List<EbBill>();
        bool exit=false;
        while(!exit)
        {
            Console.WriteLine("---------------- Welcome to TNEB ----------------");
            Console.WriteLine("1.Registration \n2.Login \n3.Exit \nEnter the Above Option");
            int menuOption=int.Parse(Console.ReadLine());
            switch(menuOption)
            {
                case 1:
                {
                    Console.WriteLine("---------------- Registration Form ----------------");
                    Console.WriteLine("Enter your name : ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter your Phone Number : ");
                    long phoneNumber = long.Parse(Console.ReadLine());

                    Console.WriteLine("Enter your Mail Id : ");
                    string mailId = Console.ReadLine();

                    Console.WriteLine("Enter How many unit used : ");
                    int unitUsed = int.Parse(Console.ReadLine());
                    
                    EbBill EbDetails = new EbBill(name,phoneNumber,mailId,unitUsed);
        
                    bills.Add(EbDetails);
                    Console.WriteLine("You have Successfully Registered. Your Meter Id is : "+ EbDetails.MeterID);
                    break;
                }
                case 2:
                {
                    login();
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
        void login()
        {
            Console.WriteLine("---------- Login ----------");
            Console.Write("Enter your Employee Id : ");
            string userMeterId=Console.ReadLine().ToUpper();
            foreach(EbBill d in bills)
            {
                if(d.MeterID==userMeterId)
                { 
                        while(true)
                        {
                            Console.WriteLine($"--- Welcome {d.UserName } ---");
                            Console.WriteLine("Select the below option \n 1.Amount Calculation \n 2.Display Details \n 3.Exit ");
                            int subMenuOption=int.Parse(Console.ReadLine());
                            switch(subMenuOption)
                            {
                                case 1:
                                {
                                    d.CalculateAmount();
                                    Console.WriteLine("Your EB bill Ammount : "+d.CalculateAmount());
                                    break;
                                }      
                                case 2:
                                {
                                    // DisplayDetails
                                    Console.WriteLine("Meter ID      : "+d.MeterID);
                                    Console.WriteLine("User Name     : "+d.UserName);
                                    Console.WriteLine("Phone number  : "+d.PhoneNumber);
                                    Console.WriteLine("Mail Id       : "+d.MailId);
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
                    Console.WriteLine("Invalid Meter Id");
                }      
            }   
            
        }  
        
    }
}



