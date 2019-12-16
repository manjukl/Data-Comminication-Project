using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace Tuition
{
   class RemoveStudent : Command
   {
      Student student;
      Admin admin;
        /**
        This is the remove student constructor that initializes student and admin
        @param surrent student and current admin
        */
        public RemoveStudent(Student stu, Admin ad)
        {
         admin = ad;
         student = stu;
        }

        /**
        This method lets the admin remove student by calling the get username and removes 
        the student .
        */
        public override void Execute()
        {
         admin.RemoveStudent(student.GetUsername());
        }

        /**
        This method lets the admin add student by calling the get username, get password
        which returns a one for student, get first and last name methods.This is where we 
        implement the undo methods for remove students.
        */
        public override void Unexecute()
        {
         admin.AddStudent(student.GetUsername(), student.getPassword(), "1", student.getFirstName(), student.getLastName(), student.getTuition());
         }
   }
}
