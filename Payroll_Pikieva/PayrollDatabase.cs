﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_Pikieva
{
    public class PayrollDatabase
    {
        private static Hashtable employees = new Hashtable();
       
        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        }
        public static Employee GetEmployee(int id)
        {
            return employees[id] as Employee;
        }



        public static void DeleteEmployee(int id)
        { employees.Remove(id); }
    }
}
