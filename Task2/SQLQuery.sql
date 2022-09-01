USE ProductsCategoriesDB;
GO

CREATE TABLE Products
	(
		ProductID int PRIMARY KEY NOT NULL,
		ProductName nvarchar(25) NOT NULL,
	)  
GO

CREATE TABLE Categories
	(
		CategoryID int PRIMARY KEY NOT NULL,
		CategoryName nvarchar(25) NOT NULL,
	)  
GO

CREATE TABLE ProductsCategories
	(
		ProductID int FOREIGN KEY REFERENCES Products(ProductID),
		CategoryID int FOREIGN KEY REFERENCES Categories(CategoryID),
		PRIMARY KEY (ProductID, CategoryID)
	)  
GO

INSERT Products
(ProductID, ProductName)
VALUES
(1,'������'),
(2,'�����'),
(3,'��������'),
(4,'����'),
(5,'������'),
(6,'������������ �����'),
(7,'�����'),
(8,'�������');

GO

INSERT Categories
(CategoryID, CategoryName)
VALUES
(1,'������'),
(2,'����'),
(3,'����'),
(4,'�����'),
(5,'����');

GO

SELECT ProductName, CategoryName FROM Products 

LEFT JOIN ProductsCategories
ON Products.ProductID = ProductsCategories.ProductID

LEFT JOIN Categories
ON ProductsCategories.CategoryID = Categories.CategoryID

SELECT * FROM Products

SELECT * FROM Categories

SELECT * FROM ProductsCategories