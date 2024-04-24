using System;
using System.Collections.Generic;
namespace Bank;
public class Program
{
    public static void Main(string[] args)
    {
        //List to store registered customer
        List<CustomerDetails> customers=new List<CustomerDetails>();
        bool exit=false;
        Console.WriteLine("-----Welcome to HDFC Bank-----");
        
        while(!exit)
        {
            Console.WriteLine("1.Registration \n2.Login \n3.Exit ");
            Console.Write("Enter your option : ");
            int menuOption=int.Parse(Console.ReadLine());
            switch(menuOption)
            {
                case 1:
                {
                    
                    // Register a new customer
                    Console.WriteLine("Bank Registration Form");

                    Console.WriteLine("Enter your Name : ");
                    string name=Console.ReadLine();

                    Console.WriteLine("Enter your Balance : ");
                    long balance=int.Parse(Console.ReadLine());
                    Console.WriteLine("1.male \n2.female \n3.other \nEnter your Gender in above option : ");
                    Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);

                    Console.WriteLine("Enter your Phone number : ");
                    long phone=long.Parse(Console.ReadLine());

                    Console.WriteLine("Enter your Mail Id : ");
                    string mailId=Console.ReadLine();

                    Console.WriteLine("Enter your Date Of Birth dd/MM/yyyy : ");
                    DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

                    CustomerDetails Details=new CustomerDetails(name,balance,gender,phone, mailId,dob);

                    Console.WriteLine("You have successfully registered. Your Customer ID is "+Details.CustomerId);

                    customers.Add(Details);
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
                    Console.WriteLine("Invalid option. Please Try again.");
                    break;
                }
                
            }
        }
        void Login()
        {   
            Console.Write("Enter you customer Id : ");
            string userCustomerId=Console.ReadLine().ToUpper();
            bool flag=false;
            foreach(CustomerDetails cd in customers)
            {
                flag=true;
                if(cd.CustomerId==userCustomerId)
                { 
                        while(true)
                        {
                            Console.WriteLine($"--- Welcome {cd.CustomerName } ---");
                            Console.WriteLine("Select the below option \n 1.Deposit \n 2.Withdrawl \n 3.Balance Check \n 4.Exit ");
                            int subMenuOption=int.Parse(Console.ReadLine());
                            switch(subMenuOption)
                            {
                                case 1:
                                {
                                    cd.Deposit();
                                    Console.WriteLine("Your Current Balance : "+cd.Balance);
                                    break;
                                }
                                case 2:
                                {
                                    cd.Withdraw();
                                    Console.WriteLine("Your Current Balance : "+cd.Balance);
                                    break;
                                }
                                case 3:
                                {
                                    Console.Write("Your Balance : ");
                                    Console.WriteLine(cd.Balance);
                                    break;
                                }                                    
                                case 4:
                                {
                                    
                                    return;
                                }
                            }            
                        }
                }    
                else
                {
                    Console.WriteLine("Invalid User Id");
                    break;
                }      
                
            }   
            if(flag==false)
            {
                Console.WriteLine("You are not Registered, please registered and Login");
            }
        }
    }
}