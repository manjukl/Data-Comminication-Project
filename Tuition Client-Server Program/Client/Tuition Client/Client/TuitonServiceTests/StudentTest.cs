using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
namespace TuitonServiceTests
{
    [TestClass]
    class StudentTest
    {
        [TestMethod ]
        public void TestGetters()
        {
            Student stu = new Student("text", "text", "text", "text", "11111");
            try
            {
                string temp;
                temp = stu.getFirstName();
                temp = stu.getLastName();
                temp = stu.getPassword();
                temp = stu.getStudentInfo();
                temp = stu.GetUsername();
            }
            catch(Exception e)
            {
                Assert.Fail();
            }
        }
    }
}
