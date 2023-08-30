Use AddressBook;
select * from AddressBookDetails;

--Create Stored Procedures
create Procedure AddContactDetails(
@firstName varchar(20),
@lastName varchar(20),
@address varchar(30),
@city varchar(20),
@state varchar(20),
@zip bigint,
@phonenumber varchar(10), 
@email varchar(30) 
)
As
begin insert Into AddressBookDetails values(@firstName,@lastName,@address,@city,@state,@zip,@phonenumber,@email)
End

Create Procedure EditContactDetails(
@firstName varchar(20),
@lastName varchar(20),
@address varchar(30),
@city varchar(20),
@state varchar(20),
@zip bigint,
@phonenumber varchar(10), 
@email varchar(30) 
)
As
begin
update AddressBookDetails set firstName=@firstName,lastName=@lastName,address=@address,city=@city,state=@state,zip=@zip,phonenumber=@phonenumber,email=@email where firstName=@firstName
End

Create Procedure DeleteContactDetails(
@firstName varchar(20)
)
As
Begin Delete from AddressBookDetails where firstName=@firstName
End


Alter Procedure DetailsinCity(
@city varchar(20)
)
As
Begin Select * from AddressBookDetails where city=@city order by firstname 
End

Alter Procedure DetailsinState(
@state varchar(20)
)
As
Begin Select * from AddressBookDetails where state=@state order by firstname 
End

Create Procedure CountinCity
As
Begin Select city, count(*)as count from AddressBookDetails group by city
End


Create Procedure CountinState
As
Begin Select state, count(*)as count from AddressBookDetails group by state
End

Create table Type(
id int primary key identity(1,1),
type varchar(20)
);

Insert into Type Values('Family');
Insert into Type Values('Friends');
Insert into Type Values('Profession');
Insert into Type Values('Others');

select * from Type;