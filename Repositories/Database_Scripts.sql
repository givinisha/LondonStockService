--Script to create stock table
CREATE TABLE Stock
(
    ID int IDENTITY(1,1) PRIMARY KEY,
    StockName varchar(7) UNIQUE,
	StockDescription VARCHAR(100) null,
	CurrentValue DECIMAL(13, 2)  NOT NULL,
	ModifiedDateTime DateTIME DEFAULT (getdate())
);
--Script to ALTER the column size
ALTER TABLE Stock
ALTER COLUMN StockName  varchar(9);

-- INSERT scripts to insert data into STOCK Table
INSERT INTO Stock(StockName,StockDescription,CurrentValue) VALUES ('LONSE:AMZ','Amazon',2142.89);
GO
INSERT INTO Stock(StockName,StockDescription,CurrentValue) VALUES ('LONSE:ACC','Accenture',214.50);
GO
INSERT INTO Stock(StockName,StockDescription,CurrentValue) VALUES ('LONSE:TAT','TATA',1500.50);
GO
INSERT INTO Stock(StockName,StockDescription,CurrentValue) VALUES ('LONSE:INF','Infosys Limited',1800.50);
GO


--Script to create Broker table
CREATE TABLE Broker
(
    ID int IDENTITY(1,1) PRIMARY KEY,
    BrokerName varchar(50) NOT NULL,
	Address VARCHAR(100)  null,
	ContactNumber varchar(10)
        constraint CK_MyTable_PhoneNumber check (ContactNumber like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	 CreatedDate DateTIME DEFAULT  (getdate())

);


-- INSERT scripts to insert data into Broker Table
INSERT INTO Broker(BrokerName,Address,ContactNumber) VALUES ('John','LONDON','8547585855');
GO
INSERT INTO Broker(BrokerName,Address,ContactNumber) VALUES ('Roy','PARIS','8547585855');
GO
INSERT INTO Broker(BrokerName,Address,ContactNumber) VALUES ('Paul','QueensLand','8547585855');
GO



--Script to create Broker table
CREATE TABLE BROKERS_STOCK
(
	BROKERID INT  FOREIGN KEY REFERENCES Broker(ID) ,
	STOCKID INT FOREIGN KEY REFERENCES STOCK(ID),
	SharesQuantity INT  NOT NULL,
	ModifiedTime DateTIME  DEFAULT getDate()

);


-- INSERT scripts to insert data into Broker Table
INSERT INTO BROKERS_STOCK(BROKERID,STOCKID,SharesQuantity) VALUES (2,2,400);
GO
INSERT INTO BROKERS_STOCK(BROKERID,STOCKID,SharesQuantity) VALUES (1,2,100);
GO
INSERT INTO BROKERS_STOCK(BROKERID,STOCKID,SharesQuantity) VALUES (2,3,200);
GO

SELECT * FROM STOCK;

SELECT * FROM BROKER;
SELECT * FROM BROKERS_STOCK;
