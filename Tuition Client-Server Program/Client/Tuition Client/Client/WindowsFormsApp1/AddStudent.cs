using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace Tuition
{
   class AddStudent : Command
   {
      Admin admin;
      Student student;
      /**
       This is the add student constructor that initializes student and admin
       @param surrent student and current admin
      */
      public AddStudent(Student stu, Admin ad)
      {
         student = stu;
         admin = ad;
      }

       /**
       This method lets the admin add student by calling the get username, get password
       which returns a one for student, get first and last name methods.
       */
       public override void Execute()
       {
         admin.AddStudent(student.GetUsername(), student.getPassword(), "1", student.getFirstName(), student.getLastName(), student.getTuition());
       }

        /**
        This method simply removes a student by getiing the user name of the student 
        and removing it. This is where we implemented the undo method for add student.
        */
        public override void Unexecute()
      {
         admin.RemoveStudent(student.GetUsername());
      }
   }
}
