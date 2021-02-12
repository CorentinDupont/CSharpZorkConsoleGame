DECLARE @dropAllConstraints NVARCHAR(MAX) = N'';

SELECT @dropAllConstraints  += N'
ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id))
    + '.' + QUOTENAME(OBJECT_NAME(parent_object_id)) + 
    ' DROP CONSTRAINT ' + QUOTENAME(name) + ';'
FROM sys.foreign_keys;
EXEC sp_executesql @dropAllConstraints 

DROP TABLE IF EXISTS [Objects]
DROP TABLE IF EXISTS [Weapons]
DROP TABLE IF EXISTS [Players]
DROP TABLE IF EXISTS [Cells]
DROP TABLE IF EXISTS [WeaponsType]
DROP TABLE IF EXISTS [ObjectsType]
DROP TABLE IF EXISTS [Monsters]

CREATE TABLE [Players] (
  [Id] int PRIMARY KEY NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Exp] int NOT NULL,
  [Hp] int NOT NULL,
  [MaxHp] int NOT NULL,
  [CurrentCellId] int NOT NULL
)
GO

CREATE TABLE [Cells] (
  [Id] int PRIMARY KEY NOT NULL,
  [PosX] int NOT NULL,
  [PosY] int NOT NULL,
  [CanMoveTo] bit NOT NULL,
  [MonsterRate] int NOT NULL,
  [ItemRate] int NOT NULL,
  [Description] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [WeaponsType] (
  [Id] int PRIMARY KEY NOT NULL,
  [Damage] int NOT NULL,
  [MissRate] int NOT NULL,
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Weapons] (
  [Id] int PRIMARY KEY NOT NULL,
  [PlayerId] int NOT NULL,
  [WeaponTypeId] int NOT NULL
)
GO

CREATE TABLE [ObjectsType] (
  [Id] int PRIMARY KEY NOT NULL,
  [Damage] int NOT NULL,
  [Heal] int NOT NULL,
  [MissRate] int NOT NULL,
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Objects] (
  [Id] int PRIMARY KEY NOT NULL,
  [PlayerId] int NOT NULL,
  [ObjectTypeId] int NOT NULL
)
GO

CREATE TABLE [Monsters] (
  [Id] int PRIMARY KEY NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Damage] int NOT NULL,
  [MissRate] int NOT NULL,
  [Hp] int NOT NULL
)
GO

ALTER TABLE [Players] ADD FOREIGN KEY ([CurrentCellId]) REFERENCES [Cells] ([Id])
GO

ALTER TABLE [Weapons] ADD FOREIGN KEY ([WeaponTypeId]) REFERENCES [WeaponsType] ([Id])
GO

ALTER TABLE [Weapons] ADD FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([Id])
GO

ALTER TABLE [Objects] ADD FOREIGN KEY ([ObjectTypeId]) REFERENCES [ObjectsType] ([Id])
GO

ALTER TABLE [Objects] ADD FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([Id])
GO