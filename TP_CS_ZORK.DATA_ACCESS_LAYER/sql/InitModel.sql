DROP TABLE IF EXISTS [Players]
DROP TABLE IF EXISTS [Cells]
DROP TABLE IF EXISTS [WeaponsType]
DROP TABLE IF EXISTS [Weapons]
DROP TABLE IF EXISTS [ObjectsType]
DROP TABLE IF EXISTS [Objects]
DROP TABLE IF EXISTS [Monster]

CREATE TABLE [Players] (
  [Id] int,
  [Name] nvarchar(255),
  [Exp] int,
  [Hp] int,
  [MaxHp] int,
  [CurrentCellId] int,
  [WeaponsId] int,
  [ObjectsId] int,
  CONSTRAINT PkPlayers PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Cells] (
  [Id] int,
  [PosX] int,
  [PosY] int,
  [CanMoveTo] bit,
  [MonsterRate] int,
  [ItemRate] int,
  [Description] nvarchar(255),
  CONSTRAINT PkCells PRIMARY KEY ([Id])
)
GO

CREATE TABLE [WeaponsType] (
  [Id] int,
  [Dammage] int,
  [MissRate] int,
  [Name] nvarchar(255),
  CONSTRAINT PkWeaponsType PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Weapons] (
  [Id] int,
  [PlayerId] int,
  CONSTRAINT PkWeapons PRIMARY KEY ([Id])
)
GO

CREATE TABLE [ObjectsType] (
  [Id] int,
  [Dammage] int,
  [Heal] int,
  [MissRate] int,
  [Name] nvarchar(255),
  CONSTRAINT PkObjectsType PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Objects] (
  [Id] int,
  [PlayerId] int,
  CONSTRAINT PkObjects PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Monsters] (
  [Id] int,
  [Name] nvarchar(255),
  [Dammage] int,
  [MissRate] int,
  [Hp] int,
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