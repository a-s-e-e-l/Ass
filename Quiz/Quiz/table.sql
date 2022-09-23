CREATE TABLE restaurant (
  [Id] INT CHECK ([Id] > 0) NOT NULL IDENTITY,
  [Name] VARCHAR(255) NOT NULL DEFAULT '',
  [PhoneNumber] VARCHAR(255) NOT NULL DEFAULT '',
  [CraetedDate] DATETIME NOT NULL DEFAULT GETDATE(),
  [UpdatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
  [Archived] SMALLINT NOT NULL DEFAULT 0,
  PRIMARY KEY ([Id]),
  );

  CREATE TABLE restaurantMenu (
  [Id] INT CHECK ([Id] > 0) NOT NULL IDENTITY,
  [RId] INT NOT NULL,
  [MealName] VARCHAR(255) NOT NULL DEFAULT '',
  [PriceInNis] float NOT NULL DEFAULT 0,
  [PriceInUsd] float NOT NULL DEFAULT 0,
  [Quantity] INT NOT NULL DEFAULT 0,
  FOREIGN KEY (RId) REFERENCES restaurant(Id),
  [CraetedDate] DATETIME NOT NULL DEFAULT GETDATE(),
  [UpdatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
  [Archived] SMALLINT NOT NULL DEFAULT 0,
  PRIMARY KEY ([Id]),
  );

  CREATE TABLE customer (
  [Id] INT CHECK ([Id] > 0) NOT NULL IDENTITY,
  [FirstName] VARCHAR(255) NOT NULL DEFAULT '',
  [LastName] VARCHAR(255) NOT NULL DEFAULT '',
  [CraetedDate] DATETIME NOT NULL DEFAULT GETDATE(),
  [UpdatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
  [Archived] SMALLINT NOT NULL DEFAULT 0,
  PRIMARY KEY ([Id]),
  );

  CREATE TABLE resCustomer(  [Id] INT CHECK ([Id] > 0) NOT NULL IDENTITY,  [MId] INT NOT NULL,  [CId] INT NOT NULL,  [CraetedDate] DATETIME NOT NULL DEFAULT GETDATE(),
  [UpdatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
  [Archived] SMALLINT NOT NULL DEFAULT 0,  FOREIGN KEY (MId) REFERENCES restaurantMenu(Id),  FOREIGN KEY (CId) REFERENCES customer(Id),  PRIMARY KEY ([Id]),);drop table resCustomer--Scaffold-DbContext "Server=DESKTOP-EG5VIK2;Database=restaurantdb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models 