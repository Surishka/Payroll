using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll_Pikieva;
using System.Text;

namespace Tests_Pikieva
{
    [TestClass]
    public class Tests_Pikieva
    {
        [TestMethod]
        public void TestEmployee()
        {
            int empId = 1;
            Employee e = new Employee(empId, "Bob", "Home");
            Assert.AreEqual("Bob", e.Name);
            Assert.AreEqual("Home", e.Address);
            Assert.AreEqual(empId, e.EmpId);
        }
        [TestMethod]
        public void TestEmployeeToString()
        {
            int empId = 1;
            string address = "Makha4kala";
            string name = "Suriya";
            string classification = "SYSadmin";
            string schedule = "flexible";
            string method = "cash";
            StringBuilder e = new StringBuilder();
            e.Append("Emp#: ").Append(empId).Append("   ");
            e.Append(name).Append("   ");
            e.Append(address).Append("   ");
            e.Append("Paid ").Append(classification).Append("  ");
            e.Append(schedule);
            e.Append(" by ").Append(method);
        }
        [TestMethod]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);


        }
    }
}
