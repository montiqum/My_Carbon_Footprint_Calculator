# Requirements
User Stories, Use Cases, Use-Case Diagram, and Requirements

## User Stories
[User Stories](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/Requirements/User_Stories.md)

1.	As an environmentalist, I need a website that will bring awareness to  the general public about carbon emissions and its effect on the environment.

2.	As a friend of the earth, I need a calculator for calculating my carbon footprint.

3.	As an environmental researcher, I need data about the average person’s carbon emissions so I can promote going green with reliable statistics.

## Use Cases
[Use Cases](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/Requirements/Use_Cases.md)

1.	Given a new user, when the user does not have a user ID, then generate and assign a new user ID and password.

2.	Given the current user, when the user selects ‘Use system as guest’, then allow the user access to the calculator.

3.	Given the current user when the user selects ‘Calculate my Footprint’, then calculate and display the users Carbon Footprint.

4.	Given the current user, when the user is on the Household page, then display methods of reducing household carbon emissions in the ‘Did you Know’ display.

5.	Given the current user, when the user is on the Vehicle page, then display methods of reducing vehicle carbon emissions in the ‘Did you Know’ display.

6.	Given the current user, when the user is on the Food page, then display methods of reducing carbon emissions through different food choices in the ‘Did you Know’ display.

7.	Given the current user, when the user selects the ‘Did You Know’ get more information link, then open a new webpage  with the link requested.

8.	Given any data provided by the user, when the user selects the next page, then store the information provide in the calculator’s database.

## Use-Cases Diagram (UML)
[Use Case Diagram](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/Requirements/Use_Case_Diagram.md)

![UML](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/Requirements/Melanie_Montique_Use_Case_Diagram.png)


## Requirements
[Requirements](https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/Requirements/Requirements.md)
1. The system shall ask the current user if he/she is a new user, existing user, or guest.
   1. (1.1) The system shall provide means for an existing user to enter his/her user ID and password.
      1. (1.1.1) Given a user ID, the system shall verify the validity of the user ID and password.
      2. (1.1.2) Given authorization, the system shall allow the user access to the calculator.
      3. (1.1.3) The system shall provide the new user with a new user ID and allow the new user to select a password.
      4. (1.1.4) The system shall give access to the calculator when the user selects ‘Use system as guest’.
   2. (1.2) The system shall provide calculate every user’s carbon footprint.
      1. (1.2.1) The system shall display the user’s result, along with a graphical comparison to other users.
      2. (1.2.2) The system shall allow the user means to save his/her results as a pdf or image.
   3. (1.3) The system shall display information and links about reducing Carbon emission in the 
      ‘Did You Know’ display box.
      
2. The system shall save the data provided by the user in the Calculator database.
   1. (2.1) Given data from a guest user the system shall store the data in the database marking the 
      user Id value with an asterisk. 
   2. (2.2) The system shall provide easy access to pages by means of page tabs.
   3. (2.3) The system shall provide drop down selections for user input vs. the user typing answers.
  
3. The system shall be developed with C# language, SQL and ASP.NET .
   1. (3.1) The system shall be hosted in Azure and GitHub.


## Requirements Table
| Requirement ID | 2nd Level ID | 3rd Level ID | Requirement Description | Test Method | Test ID |
| ---------------| ------------ | ------------ | ----------------------- | ----------- | --------|
| 1 |     |       | The system shall ask the current user if he/she is a new user, existing user, or guest.                                  |    |    |
|   | 1.1 |       | The system shall provide means for an existing user to enter his/her user ID and password.                               |    |    |
|   |     | 1.1.1 | Given a user ID, the system shall verify the validity of the user ID and password.                                       |    |    |
|   |     | 1.1.2 | Given authorization, the system shall allow the user access to the calculator.                                           |    |    |
|   |     | 1.1.3 | The system shall provide the new user with a new user ID and allow the new user to select a password.                    |    |    |
|   |     | 1.1.4 | The system shall give access to the calculator when the user selects ‘Use system as guest’.                              |    |    |
|   | 1.2 |       | The system shall provide calculate every user’s carbon footprint.                                                        |    |    |
|   |     | 1.2.1 | The system shall display the user’s result, along with a graphical comparison to other users                             |    |    |
|   |     | 1.2.2 | The system shall allow the user means to save his/her results as a pdf or image.                                         |    |    |
|   | 1.3 |       | The system shall display information and links about reducing Carbon emission in the ‘Did You Know’ display box.         |    |    |
| 2 |     |       | The system shall save the data provided by the user in the Calculator database.                                          |    |    |
|   | 2.1 |       | Given data from a guest user the system shall store the data in the database marking the user Id value with an asterisk. |    |    |
|   | 2.2 |       | The system shall provide easy access to pages by means of page tabs.                                                     |    |    |
|   | 2.3 |       | The system shall provide drop down selections for user input vs. the user typing answers.                                |    |    |                       | 3 |     |       | The system shall be developed with C# language, SQL and ASP.NET.                                                         |    |    |
|   | 3.1 |       | The system shall be hosted in Azure and GitHub.                                                                          |    |    |                       

[Back to Main](https://github.com/montiqum/My_Carbon_Footprint_Calculator)
