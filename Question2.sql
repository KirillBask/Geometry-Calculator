CREATE TABLE Products (
    Id INT PRIMARY KEY,
    "Name" TEXT
);

CREATE TABLE Categories (
    Id INT PRIMARY KEY,
    "Name" TEXT
);

CREATE TABLE ProductCategories (
    ProductId INT FOREIGN KEY REFERENCES Products(Id),
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
    PRIMARY KEY (ProductId, CategoryId)
);

SELECT P."Name", C."Name"
FROM Products P
LEFT JOIN ProductCategories PC
    ON P.Id = PC.ProductId
LEFT JOIN Categories C
    ON PC.CategoryId = C.Id;
