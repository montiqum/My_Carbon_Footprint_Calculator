# Requirements Table
| Requirement ID | 2nd Level ID | 3rd Level ID | Requirement Description | Test Method | Test ID |
| :-------------:| :----------: | :----------: | ----------------------- | ----------- | :------:|
| 1 |     |       | The system shall ask the current user if he/she is a new user, existing user, or guest.                                  | Inspection    | <a href=https://github.com/montiqum/My_Carbon_Footprint_Calculator/blob/main/README.md#t1> 1.1.1 </a> |
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


[Back To Requirements](https://github.com/montiqum/My_Carbon_Footprint_Calculator/tree/main/Requirements)
