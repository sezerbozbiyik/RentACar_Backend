create table Users(
UserId int not null primary key,
FirstName text,
LastName text,
Email text,
Password text,
);

--employee tablosu da olabilir.--

create table Customers(
CustomerId int not null primary key,
UserId int not null foreign key references Users(UserId),
CompanyName text,
);

create table Rentals(
RentId int not null primary key,
Id int not null foreign key references Cars(Id),
CustomerId int not null foreign key references Customers(CustomerId),
RentDate datetime,
ReturnDate datetime,
);