using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbBillCalculation
{

    public class EbBill
    {
        private static int _meterId=1000;
        

        public string MeterID{get;set;}
        public string UserName{get;set;}
        public long PhoneNumber{get;set;}
        public string MailId{get;set;} 
        public int UnitUsed{get;set;} 

        public double CalculateAmount()
        {
            double Amount;
            Amount=UnitUsed*5;
            return Amount;
        }
        

        public EbBill(string name, long phoneNumber, string mailId, int unitUsed)
        {
            _meterId++;
            MeterID="EB"+ _meterId;
            UserName = name;
            PhoneNumber = phoneNumber;
            MailId = mailId;
            UnitUsed=unitUsed;
        }
    }
}

