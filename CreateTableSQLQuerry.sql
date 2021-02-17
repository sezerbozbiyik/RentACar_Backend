Create TABLE Cars
(
	Id INT NOT NULL PRIMARY KEY,
	BrandId int not null foreign key references Brands(BrandId),
	ColorId int not null foreign key references Colors(ColorId),
	ModelYear int,
	DailyPrice decimal,
	CarDescription text,
)
Create table Brands
(
	BrandId int not null primary key,
	BrandName text
)
create table Colors
(
	ColorId int not null primary key,
	ColorName text 
)