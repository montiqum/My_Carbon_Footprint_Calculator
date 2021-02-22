DROP DATABASE IF EXISTS CarbonFootprintCalculator;

CREATE DATABASE CarbonFootprintCalculator;

USE CarbonFootprintCalculator;


DROP TABLE IF EXISTS CarbonFootprint;
CREATE TABLE CarbonFootprint
(
	cfpID							INT				NOT NULL	PRIMARY KEY
	,travel_emmisions_Mg_Yr			DECIMAL(10, 2)
	,household_emmisions_Mg_Yr		DECIMAL(10, 2)
	,waste_emmisions_Mg_Yr			DECIMAL(10, 2)
	,total_CO2_emmissions_Mg_Yr		DECIMAL(10, 2)	NOT NULL
);

INSERT INTO CarbonFootprint
VALUES
(
	1, 4.6, 7.5, 16.0, 28.1
),
(
	2, 4.2, 6.3, 18.2, 28.7
),
(
	3, 3.6, 4.8, 13.4, 21.8
),
(
	4, 5.1, 5.7, 17.1, 25.6
),
(
	5, 3.2, 7.8, 15.4, 27.3
);

SELECT *
FROM CarbonFootprint;

DROP TABLE IF EXISTS Users;
CREATE TABLE Users
(
	UserID			INT		NOT NULL	PRIMARY KEY
	,City			NVARCHAR (40)
	,[State]		NVARCHAR (40)
	,Zip			INT
	,annual_income	MONEY
	,cfpID			INT		NOT NULL	FOREIGN KEY REFERENCES CarbonFootprint(cfpID)
);

INSERT INTO Users
VALUES
(
	1, 'San Diego', 'CA', 92102, 90000, 1
),
(
	2, 'Austin', 'TX', 73344, 85000, 2
),
(
	3, 'Redmond', 'WA', 98052, 95000, 3
),
(
	4, 'Hyattsville', 'MD', 20781, 83000, 4
),
(
	5, 'San Antonio', 'TX', 78216, 86000, 5
);

SELECT *
FROM Users;

DROP TABLE IF EXISTS House;
CREATE TABLE House
(
	HouseID						INT		NOT NULL	PRIMARY KEY
	,household_size				INT		NOT NULL
	,sqft						INT		NOT NULL
	,energy_usage_KWh_Mth		INT		NOT NULL
	,energy_type				NVARCHAR (40)		
	,water_usage_HCF_Yr			INT		NOT NULL	
	,City						NVARCHAR (40)
	,[State]					NVARCHAR (40)
	,Zip						INT
	,UserID						INT		NOT NULL	FOREIGN KEY REFERENCES Users(UserID)
);

INSERT INTO House
VALUES
(
	1, 5, 1450, 1050, 'Electric', 168, 'San Diego', 'CA', 92102, 1
),
(
	2, 6, 2250, 918, 'Electric', 194,  'Austin', 'TX', 73344, 2
),
(
	3, 4, 1850, 945, 'Electric', 172,  'Redmond', 'WA', 98052, 3
),
(
	4, 2, 1950, 880, 'Electric', 152,  'Hyattsville', 'MD', 20781, 4
),
(
	5, 3, 2450, 790, 'Solar', 134,  'San Antonio', 'TX', 78216, 5
);

SELECT *
FROM House;

DROP TABLE IF EXISTS Vehicle;
CREATE TABLE Vehicle
(
	VehicleID		INT				NOT NULL	PRIMARY KEY
	,[year]			INT	
	,Make			NVARCHAR (40)
	,Model			NVARCHAR (40)
	,Fuel_Type		NVARCHAR (40)
	,Mileage		INT
	,UserID			INT				NOT NULL	FOREIGN KEY REFERENCES Users(UserID)
);

INSERT INTO Vehicle
VALUES
(
	1, 2016, 'Subaru', 'Forrester', 'Gas', 10853, 1
),
(
	2, 2019, 'Dodge', 'Charger', 'Gas', 12570, 2
),
(
	3, 2017, 'Mazda', 'CX5', 'Gas', 11486, 3
),
(
	4, 2012, 'Toyota', 'Highlander', 'Hybrid', 12468, 4
),
(
	5, 2021, 'Tesla', 'Model 3', 'Electric', 14389, 5
);

SELECT *
FROM Vehicle;

DROP TABLE IF EXISTS Food;
CREATE TABLE Food
(
	FoodID		INT		NOT NULL	PRIMARY KEY
	,FoodType	NVARCHAR (40)
	,UserID		INT		NOT NULL	FOREIGN KEY REFERENCES Users(UserID)
);

INSERT INTO Food(FoodID, UserID, FoodType)
VALUES
(
	1, 1, 'Pork'
),
(
	2, 3, 'Carbohydrates'
),
(
	3, 5, 'Dairy'
),
(
	4, 4, 'Seafood'
),
(
	5, 2, 'Fruits'
);


SELECT *
FROM Food
ORDER by UserID;
