# My Carbon Footprint Calculator


My Carbon Footprint Calculator is a resource available to the average everyday person to help them calculate their estimated carbon footprint, 
and keep them informed on ways to help reduce carbon emissions. 
It is intended to bring awareness to household members on the effects of carbon emissions on the atmosphere, and climate. 
By changing our diet, recycling habits, and energy usage, everyone can effectively make a difference.

## Table of Contents

[1. Description](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/README.md#my-carbon-footprint-calculator)

[2. Wireframe Diagram](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/README.md#wireframe-diagram)

[3. Entity Relationship Diagram](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/README.md#entity-relationship-diagram)

[4. Database Diagram](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/README.md#database-diagram)

[5. SQL Database](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/README.md#initial-sql-database)

[6. Requirements](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/README.md#requirements)

[7. Testing](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/README.md#testing)


## Wireframe Diagram
![Wireframe Diagram](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/Wireframe%20Draft.JPG)


## Entity Relationship Diagram 
![ERD](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/Melanie%20Montique%20ERD1%20final%20cut.jpg)

## Database Diagram
![Database Diagram](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/Database%20Diagram.JPG)

## Initial SQL Database

https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/Carbon_Footprint_Calculator.sql

## Requirements
[Requirements](https://github.com/montiqum/My_Carbon_Footprint_Calculator/tree/main/Requirements)

# Requirements Table
| Requirement ID | 2nd Level ID | 3rd Level ID | Requirement Description | Test Method | Test ID |
| :-------------:| :----------: | :----------: | ----------------------- | ----------- | :------:|
| 1 |     |       | The system shall ask the current user if he/she is a new user, existing user, or guest.                                  | Inspection    | 1.1.1 |
|   | 1.1 |       | The system shall provide means for an existing user to enter his/her user ID and password.                               | Demonstration | 2.1.1 |
|   |     | 1.1.1 | Given a user ID, the system shall verify the validity of the user ID and password.                                       | Test          | 3.1.1 |
|   |     | 1.1.2 | Given authorization, the system shall allow the user access to the calculator.                                           | Demonstration | 2.1.2 |
|   |     | 1.1.3 | The system shall provide the new user with a new user ID and allow the new user to select a password.                    | Test          | 3.1.2 |
|   |     | 1.1.4 | The system shall give access to the calculator when the user selects ‘Use system as guest’.                              | Demonstration | 2.1.3 |
|   | 1.2 |       | The system shall calculate every user’s carbon footprint.                                                                | Demonstration | 2.1.4 |
|   |     | 1.2.1 | The system shall accurately calculate every user’s carbon footprint.                                                     | Test          | 3.1.3 |
|   |     | 1.2.2 | The system shall display the user’s result, along with a graphical comparison to other users                             | Demonstration | 2.1.5 |
|   |     | 1.2.3 | The system shall allow the user means to save his/her results as a pdf or image.                                         | Analysis      | 4.1.1 |
|   | 1.3 |       | The system shall display information and links about reducing Carbon emission in the ‘Did You Know’ display box.         | Demonstration | 2.1.6 |
| 2 |     |       | The system shall save the data provided by the user in the Calculator database.                                          | Analysis      | 4.2.1 |
|   | 2.1 |       | Given data from a guest user the system shall store the data in the database marking the user Id value with an asterisk. | Test          | 3.2.1 |
|   | 2.2 |       | The system shall provide easy access to pages by means of page tabs.                                                     | Inspection    | 1.2.1 |
|   | 2.3 |       | The system shall provide drop down selections for user input vs. the user typing answers.                                | Demonstration | 2.2.1 |  
| 3 |     |       | The system shall be developed with C# language, SQL and ASP.NET.                                                         | Inspection    | 1.3.1 |
|   | 3.1 |       | The system shall be hosted in Azure and GitHub.                                                                          | Inspection    | 1.3.2 |   

## Testing
[Test Table](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/TestTable.md)

# Test Table

| Test ID | Requirement ID | Test Procedure | Current Status | Time Stamp | Build/Version |
| :------:| :------------: | -------------- | -------------- | ---------- | --------------|
| [1.1.1](#t1) | 1     | Verify that the system ask the current if he/she is a new user, existing user, or guest.                                                                                                            | Not Tested | NULL | N/A |
| 1.2.1 | 2.2   | When the system is lauched, verify tabs are displayed at the top of the application.                                                                                                                | Not Tested | NULL | N/A |
| 1.3.1 | 3     | Inspect the system build and verify it contains files and programs that include SQL, Visual Studio, and ASP.Net file types                                                                          | Not Tested | NULL | N/A |
| 1.3.2 | 3.1   | Check Github or Azure to view the files of the program.                                                                                                                                             | Not Tested | NULL | N/A |
| 2.1.1 | 1.1   | When the system runs and the current user selects existing user, verify the system displays textboxes for user id and password.                                                                     | Not Tested | NULL | N/A |
| 2.1.2 | 1.1.2 | When the user verifies their credentials, ensure the system moves to the Calulator screen and displays the user tab and screen.                                                                     | Not Tested | NULL | N/A |
| 2.1.3 | 1.1.4 | When the user access the HomePage the current user selects 'Use system as guest', then verify the user gains access to the user tab and page.                                                       | Not Tested | NULL | N/A |
| 2.1.4 | 1.2   | Provide 3 seperate users to enter their information, and verify the system displays the current user's result.                                                                                      | Not Tested | NULL | N/A |
| 2.1.5 | 1.2.2 | When a user accesses the system, verify the system displays a graph along with the User's Carbon Footprint Calculation.                                                                             | Not Tested | NULL | N/A |
| 2.1.6 | 1.3   | Verify that the system follows the same execution path except for gaining access to the system . Then verify on each page the "Did you know' box contains a link to gain more info on the subject.  | Not Tested | NULL | N/A |
| 2.2.1 | 2.3   | When the system is lauched, verify drop down selections are available for the user to choose from throughout the application.                                                                       | Not Tested | NULL | N/A |
| 3.1.1 | 1.1.1 | Supply the correct user id and password, and verify system logs in. Then supply incorrect information and verify error message displayed.                                                           | Not Tested | NULL | N/A |
| 3.1.2 | 1.1.3 | When the current user selects new user the system should generate and display the user id and then provide a textbox for the user to enter the new password.                                        | Not Tested | NULL | N/A |
| 3.1.3 | 1.2.1 | Use test cases and unit tests to verify that the system's calculations are accurate.                                                                                                                | Not Tested | NULL | N/A |
| 3.2.1 | 2.1   | Select the guest user option on the Homepage. Follow the steps. When the user sees their carbon footprint online, verify an asterisk is added in the User id of the guest user.                     | Not Tested | NULL | N/A |  
| 4.1.1 | 1.2.3 | On the final page of execution, verify the system provides a means to save the result as pdf, or some other file.                                                                                   | Not Tested | NULL | N/A |
| 4.2.1 | 2     | Enter and store multiple values in the Carbon Footprint Application. Then retrieve the  data stored in the database and verify they match.                                                          | Not Tested | NULL | N/A |                       

[Back to Main](https://github.com/montiqum/My_Carbon_Footprint_Calculator)

