using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_Pikieva
{
    public class DeleteEmployeeTransaction : Transaction
    {
       private readonly int empid;

       public DeleteEmployeeTransaction(int id)
       {
           this.empid = id;
       }

       public void Execute()
       {
           PayrollDatabase.DeleteEmployee(empid);
       }

    }
}
