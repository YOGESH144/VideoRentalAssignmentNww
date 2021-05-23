using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRentalAssignmentNww;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRentalAssignmentNww.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            ControllerTask task = new ControllerTask();
            task.registerCustomer("Aman","Aman@gmail.com","2345","NZ");
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void Form2Test()
        {
            ControllerTask task = new ControllerTask();
            task.DelCustomer(1);
            Assert.IsTrue(true);
        }

    }
}