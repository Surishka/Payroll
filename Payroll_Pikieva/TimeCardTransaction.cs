using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_Pikieva
{
    public class TimeCardTransaction : Transaction
    {
        private readonly DateTime date;
        private readonly double hours;
        private readonly int empId;
        
        public TimeCardTransaction(DateTime date, double hours, int empId)
        {
            // TODO: Complete member initialization
            this.date = date;
            this.hours = hours;
            this.empId = empId;
        }
           public void Execute()
        {
            //throw new NotImplementedException();
            Employee e = PayrollDatabase.GetEmployee(empId);
            if ( e !=null )
            {
                HourlyClassification hc = e.Classification as HourlyClassification;
                if ( hc != null )
                    hc.AddTimeCard(new TimeCard(date,hours));
             
                 else 
                    throw new InvalidOperationException("an attempt to add a card timecard " + "for an employee is not on an hourly payment");
            }
                else 
                    throw new InvalidOperationException("Worker not found");
            

        }
    }
}
