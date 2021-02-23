insert into Users(UserId,FirstName,LastName,Email,Password)
values (1,'Sezer','Bozbıyık','sezer.bzbyk@gmail.com','123456'),
(2,'Samet','Karapençe','sametk@gmail.com','asd1234'),
(3,'Mehmet','Bozkurt','mehmetb@gmail.com','1234asd'),
(4,'Hatice','Güven','haticeg@gmail.com','10203040'),
(5,'Hayriye','Bozbıyık','hayriyeb@gmail.com','010203'),
(6,'İsmet','Mutlu','ismetm@gmail.com','112233')

insert into Customers(CustomerId,UserId,CompanyName)
values (1,2,'karapençe a.ş'),
(2,4,'güven a.ş'),
(3,1,'bozbıyık a.ş'),
(4,3,'bozkurt a.ş'),
(5,6,'mutlu a.ş')

insert into Rentals(RentId,Id,CustomerId,RentDate,ReturnDate)
values (1,2,2,'2015-11-05 14:29:36','2015-11-07 17:19:26'),
(2,4,3,'2010-11-05 13:29:36','2010-11-10 14:19:26'),
(3,1,2,'2020-11-15 14:29:36','2020-11-19 20:19:26'),
(4,3,1,'2019-11-02 13:29:36','2019-11-07 16:19:26'),
(5,6,4,'2018-11-12 16:29:36','2018-11-15 22:19:26')