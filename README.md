# Data-Communication-Project
This is the final Project for my Data Communication class

Server:
Server can be ran from the standalone Executable file included. If you desire to change the server, open the included 
Visual Basic Solution baned Server in Visual basic, then build it once you change what you want to change.
Make sure that there is a file directory with the name "Database" in the same 
directory as the server, or else it will break. 

Update the database, open the Existing Database file directory included with the server executable and rename the file directory "admin"
to the username desired by that admin. Next, open the newly renamed directory and open the "password" file and change the password within.
Please avoid using spaces or enters in the file, as it will not read properly in the client. The "tier" file should stay unedited, but it 
contains the value "2". When creating a new admin account, create the file directory named with the desired username, and in the new directory
add a two text documents, "password" which contains the desired password, and "tier" which should only contain a "2" and no other characters.
The 2 value sets that user to an admin.

Adding a student can be done automatically through the client.

Do not run more than one server at a time.

The server initally is set to the localhost IP address and port 1888 for the connecting port, this can be changed to the desired IP address.

The server uses comma separated values for commands.

Design Deficiencies:
Server WILL crash if the connection is improperly ended. This is due to the Socket Server programming causing the server to crash when a socket suddenly
disconnects.

ListTuitionHistory was planned to be implemented, but lack of time led to it not being completed.

There is a bug that where if a user without a password tries to log in it will fail, this bug was discovered last minute
and cannot be fixed in time

Test Coverage Results:
Most tests that test server are in the ServerTest project, but the ListStudentTuition and ListStudents are tested in the Client's test solution.

First run an instance of the server in a separate Visual Basic Client. 
AddStudent must be the first test done, RemoveStudent must be the last test done, any other tests can be done in any order.

Client:
The client can be ran from the standalone executable included, but a server instance must be running for it to operate. 
The executable is included in the src directory, but can be edited by using the Client folder's Tuition solution. Simpily open the
solution in Visual Studio, edit the code, and then build the project once tested.


Currently, the IP is set to localhost with the port 1888 being used. To change this a new executable must be created. Open the tuition
solution found in the Client folder in Visual Studio 2017 and open the LoginForm file. Right click on the form and click "View code".
In the code view of LoginForm, scroll to private void btnLogin_Click, inside that method, there will be the following values
IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);
Set the value of IPAddress.Parse to the desired IP Address, and change the 1888 in IPEndPoint remoteEP to the desired port.
Then build the client, the executable will be in the \Tuition Client\Client\WindowsFormsApp1\bin\Debug directory.

Design Deficencies:
When in admin view do NOT create a new student with a tuition that has characters other than numbers, as it will not parse

The student form cannot view tuition history yet due to time constraints.

PaymentForm is not actually connected to any payment processing system.

StudentForm will not update tuition imediately, this is a timing bug that can't be repaired due to time restraints.

The Payment Form has a bug that the waiting cursor is shown. The form can be used but the cursor is bugged. This bug's source couldn't be found in time

The AdminForm's addstudent method does not properly implement the password, this was discovered last minute and cannot be repaired in time
Test Coverage Results: 
Before Running Tests, make sure that an instance of the Server program is running. Any test can be ran in any order, and the tests will clean
their tracks.

InvokerTest tests the Invoker class, along with the updating methods for Admin 

StudentTest tests the Student class's getters.

AdminTest tests the remaining admin methods not tested in InvokerTest

The StudentTest and AdminTest won't show up on the test window due to reasons unkown, so run them manually.

If a test fails, you will need to go to the corresponding class and look into it to find the issue. Each test class is named after a 
class it tests.
