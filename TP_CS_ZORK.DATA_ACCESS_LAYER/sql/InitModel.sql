DROP TABLE IF EXISTS [Players]
DROP TABLE IF EXISTS [Cells]
DROP TABLE IF EXISTS [WeaponsType]
DROP TABLE IF EXISTS [Weapons]
DROP TABLE IF EXISTS [Objects]
DROP TABLE IF EXISTS [ObjectsType]
DROP TABLE IF EXISTS [Monsters]

CREATE TABLE [Players] (
  [Id] int NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Exp] int NOT NULL,
  [Hp] int NOT NULL,
  [MaxHp] int NOT NULL,
  [CurrentCellId] int NOT NULL,
  [WeaponsId] int NOT NULL,
  [ObjectsId] int NOT NULL,
  CONSTRAINT PkPlayers PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Cells] (
  [Id] int NOT NULL,
  [PosX] int NOT NULL,
  [PosY] int NOT NULL,
  [CanMoveTo] bit NOT NULL,
  [MonsterRate] int NOT NULL,
  [ItemRate] int NOT NULL,
  [Description] nvarchar(255) NOT NULL,
  CONSTRAINT PkCells PRIMARY KEY ([Id])
)
GO

CREATE TABLE [WeaponsType] (
  [Id] int NOT NULL,
  [Dammage] int NOT NULL,
  [MissRate] int NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  CONSTRAINT PkWeaponsType PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Weapons] (
  [Id] int NOT NULL,
  [PlayerId] int NOT NULL,
  CONSTRAINT PkWeapons PRIMARY KEY ([Id])
)
GO

CREATE TABLE [ObjectsType] (
  [Id] int NOT NULL,
  [Dammage] int NOT NULL,
  [Heal] int NOT NULL,
  [MissRate] int NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  CONSTRAINT PkObjectsType PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Objects] (
  [Id] int NOT NULL,
  [PlayerId] int NOT NULL,
  CONSTRAINT PkObjects PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Monsters] (
  [Id] int NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Dammage] int NOT NULL,
  [MissRate] int NOT NULL,
  [Hp] int NOT NULL,
  CONSTRAINT PkMonsters PRIMARY KEY ([Id])
)
GO

ALTER TABLE [Players] ADD FOREIGN KEY ([CurrentCellId]) REFERENCES [Cells] ([Id])
GO

ALTER TABLE [Players] ADD FOREIGN KEY ([WeaponsId]) REFERENCES [Weapons] ([Id])
GO

ALTER TABLE [Players] ADD FOREIGN KEY ([ObjectsId]) REFERENCES [Objects] ([Id])
GO

ALTER TABLE [WeaponsType] ADD FOREIGN KEY ([Id]) REFERENCES [Weapons] ([Id])
GO

ALTER TABLE [Objects] ADD FOREIGN KEY ([Id]) REFERENCES [ObjectsType] ([Id])
GO