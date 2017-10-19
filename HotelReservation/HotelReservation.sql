USE master
GO

if exists (select * from sysdatabases where name = 'HotelReservation')
	drop database HotelReservation
go

Create database HotelReservation
go

Use HotelReservation

CREATE TABLE Customer(
CustomerID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Phone VARCHAR(30) NOT NULL,
Email VARCHAR(30) NOT NULL,
CreditCard VARCHAR(16) NOT NULL
)


CREATE TABLE Guest(
GuestID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
GuestAge INT NOT NULL
)

CREATE TABLE RoomType(
RoomTypeID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
RoomTypeDesc VARCHAR(MAX) NOT NULL,
RoomCapacity INT NOT NULL
)

CREATE TABLE Promotions(
PromotionID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
PromoRate DECIMAL NOT NULL,
PromoCode VARCHAR(30) NOT NULL,
PromoDesc VARCHAR(MAX) NOT NULL
)

CREATE TABLE AddOn(
AddOnID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
AddOnName VARCHAR(30) NOT NULL,
AddOnDescription VARCHAR(MAX) NOT NULL
)

CREATE TABLE Amenities(
AmenityID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
AmenityName VARCHAR(30) NOT NULL,
AmenityDesc VARCHAR(MAX) NOT NULL
)

CREATE TABLE Room(
RoomID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
RoomTypeID INT NOT NULL,
RoomNumber VARCHAR(6) NOT NULL,
FloorNumber INT NOT NULL
CONSTRAINT FK_Room_RoomType
	FOREIGN KEY(RoomTypeID)
	REFERENCES RoomType(RoomTypeID)
)

CREATE TABLE RoomRate(
RateID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
RoomTypeID INT NOT NULL,
RoomRate DECIMAL NOT NULL,
CONSTRAINT FK_RoomRate_RoomType
	FOREIGN KEY(RoomTypeID)
	REFERENCES RoomType(RoomTypeID)
)

CREATE TABLE Reservation(
ReservationID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
PromotionID INT NULL,
CustomerID INT NOT NULL,
CONSTRAINT FK_Reservation_Promotions
	FOREIGN KEY(PromotionID)
	REFERENCES Promotions(PromotionID),
CONSTRAINT FK_Reservation_Customer
	FOREIGN KEY(CustomerID)
	REFERENCES Customer(CustomerID)
)

CREATE TABLE RoomReservation(
RoomReservationID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
RoomID INT NOT NULL,
ReservationID INT NOT NULL,
CONSTRAINT FK_RoomReservation_Room
	FOREIGN KEY(RoomID)
	REFERENCES Room(RoomID),
CONSTRAINT FK_RoomReservation_Reservation
	FOREIGN KEY (ReservationID)
	REFERENCES Reservation(ReservationID)
)

CREATE TABLE GuestReservation(
GuestReservationID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
GuestID INT NOT NULL,
ReservationID INT NOT NULL,
CONSTRAINT FK_GuestReservation_Guest
	FOREIGN KEY(GuestID)
	REFERENCES Guest(GuestID),
CONSTRAINT FK_GuestReservation_Reservation
	FOREIGN KEY(ReservationID)
	REFERENCES Reservation(ReservationID)
)

CREATE TABLE AddOnRate(
AddOnRateID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
AddOnRate DECIMAL NOT NULL,
AddOnID INT NOT NULL,
CONSTRAINT FK_AddOnRate_AddOn
	FOREIGN KEY(AddOnID)
	REFERENCES AddOn(AddOnID)
)

CREATE TABLE ReservationAddOn(
ReservationAddOnID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
ReservationID INT NOT NULL,
RoomID INT NOT NULL,
AddOnID INT NOT NULL,
CONSTRAINT FK_ReservationAddOn_Reservation
	FOREIGN KEY(ReservationID)
	REFERENCES Reservation(ReservationID),
CONSTRAINT FK_ReservationAddOn_Room
	FOREIGN KEY (RoomID)
	REFERENCES Room(RoomID),
CONSTRAINT FK_ReservationAddOn_AddOn
	FOREIGN KEY(AddOnID)
	REFERENCES AddOn(AddOnID)
)

CREATE TABLE RoomAmenities(
RoomAmenitiesID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
AmenityID INT NOT NULL,
ROOMID INT NOT NULL,
CONSTRAINT FK_RoomAmenities_Room
	FOREIGN KEY(RoomID)
	REFERENCES Room(RoomID),
CONSTRAINT FK_RoomAmenities_Amenities
	FOREIGN KEY (AmenityID)
	REFERENCES Amenities(AmenityID)
)

CREATE TABLE Billing(
BillingID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Taxes DECIMAL NOT NULL,
Fees DECIMAL NOT NULL,
Total DECIMAL NOT NULL,
ReservationID INT NOT NULL,
CustomerID INT NOT NULL,
CONSTRAINT FK_Billing_Reservation
	FOREIGN KEY(ReservationID)
	REFERENCES Reservation(ReservationID),
CONSTRAINT FK_Billing_Customer
	FOREIGN KEY(CustomerID)
	REFERENCES Customer(CustomerID)
)

CREATE TABLE BillingDetail(
BillingDetailID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
SubTotal DECIMAL NOT NULL,
BillingID INT NOT NULL,
RateID INT NOT NULL,
AddOnRateID INT NOT NULL,
CONSTRAINT FK_BillingDetail_Billing
	FOREIGN KEY(BillingID)
	REFERENCES Billing(BillingID),
CONSTRAINT FK_BillingDetail_RoomRate
	FOREIGN KEY(RateID)
	REFERENCES RoomRate(RateID),
CONSTRAINT FK_BillingDetail_AddOnRate
	FOREIGN KEY(AddOnRateID)
	REFERENCES AddOnRate(AddOnRateID)
)