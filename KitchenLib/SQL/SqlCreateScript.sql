DROP TABLE IF EXISTS Grocery;
DROP TABLE IF EXISTS Ingredient;

CREATE TABLE Grocery (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Barcode NVARCHAR(20),
	[Name] NVARCHAR(100) NOT NULL,
	Quantity INT,
	Ingredient NVARCHAR(50),
	Category NVARCHAR(50)
);

CREATE TABLE Ingredient (
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
	[Description] NVARCHAR(1000),
	ThumbUrl NVARCHAR(200),
	[Type] NVARCHAR(50)
);

CREATE TABLE Recipe (
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	MealAlternate NVARCHAR(100),
	Category NVARCHAR(100),
	Area NVARCHAR(100),
	Country NVARCHAR(50),
	Instructions NVARCHAR(2000),
	ThumbUrl NVARCHAR(200),
	Tags NVARCHAR(100),
	YoutubeUrl NVARCHAR(200),
	strIngredient1 NVARCHAR(30),
	strIngredient2 NVARCHAR(30),
	strIngredient3 NVARCHAR(30),
	strIngredient4 NVARCHAR(30),
	strIngredient5 NVARCHAR(30),
	strIngredient6 NVARCHAR(30),
	strIngredient7 NVARCHAR(30),
	strIngredient8 NVARCHAR(30),
	strIngredient9 NVARCHAR(30),
	strIngredient10 NVARCHAR(30),
	strIngredient11 NVARCHAR(30),
	strIngredient12 NVARCHAR(30),
	strIngredient13 NVARCHAR(30),
	strIngredient14 NVARCHAR(30),
	strIngredient15 NVARCHAR(30),
	strIngredient16 NVARCHAR(30),
	strIngredient17 NVARCHAR(30),
	strIngredient18 NVARCHAR(30),
	strIngredient19 NVARCHAR(30),
	strIngredient20 NVARCHAR(30),
	strMeasure1 NVARCHAR(20),
	strMeasure2 NVARCHAR(20),
	strMeasure3 NVARCHAR(20),
	strMeasure4 NVARCHAR(20),
	strMeasure5 NVARCHAR(20),
	strMeasure6 NVARCHAR(20),
	strMeasure7 NVARCHAR(20),
	strMeasure8 NVARCHAR(20),
	strMeasure9 NVARCHAR(20),
	strMeasure10 NVARCHAR(20),
	strMeasure11 NVARCHAR(20),
	strMeasure12 NVARCHAR(20),
	strMeasure13 NVARCHAR(20),
	strMeasure14 NVARCHAR(20),
	strMeasure15 NVARCHAR(20),
	strMeasure16 NVARCHAR(20),
	strMeasure17 NVARCHAR(20),
	strMeasure18 NVARCHAR(20),
	strMeasure19 NVARCHAR(20),
	strMeasure20 NVARCHAR(20)
);