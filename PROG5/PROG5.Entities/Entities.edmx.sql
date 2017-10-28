
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/28/2017 16:22:07
-- Generated from EDMX file: C:\Users\jjvij\git\PROG5\PROG5\PROG5.Entities\Entities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [prog5];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_NinjaNinjaEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NinjaEquipmentSet] DROP CONSTRAINT [FK_NinjaNinjaEquipment];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentNinjaEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NinjaEquipmentSet] DROP CONSTRAINT [FK_EquipmentNinjaEquipment];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentTypeEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentSet] DROP CONSTRAINT [FK_EquipmentTypeEquipment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[NinjaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NinjaSet];
GO
IF OBJECT_ID(N'[dbo].[EquipmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipmentSet];
GO
IF OBJECT_ID(N'[dbo].[NinjaEquipmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NinjaEquipmentSet];
GO
IF OBJECT_ID(N'[dbo].[EquipmentTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipmentTypeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'NinjaSet'
CREATE TABLE [dbo].[NinjaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Gold] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EquipmentSet'
CREATE TABLE [dbo].[EquipmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Int] int  NOT NULL,
    [Str] int  NOT NULL,
    [Agi] int  NOT NULL,
    [Gold] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [EquipmentType_Id] int  NOT NULL
);
GO

-- Creating table 'NinjaEquipmentSet'
CREATE TABLE [dbo].[NinjaEquipmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ninja_Id] int  NULL,
    [Equipment_Id] int  NULL
);
GO

-- Creating table 'EquipmentTypeSet'
CREATE TABLE [dbo].[EquipmentTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'NinjaSet'
ALTER TABLE [dbo].[NinjaSet]
ADD CONSTRAINT [PK_NinjaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EquipmentSet'
ALTER TABLE [dbo].[EquipmentSet]
ADD CONSTRAINT [PK_EquipmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NinjaEquipmentSet'
ALTER TABLE [dbo].[NinjaEquipmentSet]
ADD CONSTRAINT [PK_NinjaEquipmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EquipmentTypeSet'
ALTER TABLE [dbo].[EquipmentTypeSet]
ADD CONSTRAINT [PK_EquipmentTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Ninja_Id] in table 'NinjaEquipmentSet'
ALTER TABLE [dbo].[NinjaEquipmentSet]
ADD CONSTRAINT [FK_NinjaNinjaEquipment]
    FOREIGN KEY ([Ninja_Id])
    REFERENCES [dbo].[NinjaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NinjaNinjaEquipment'
CREATE INDEX [IX_FK_NinjaNinjaEquipment]
ON [dbo].[NinjaEquipmentSet]
    ([Ninja_Id]);
GO

-- Creating foreign key on [Equipment_Id] in table 'NinjaEquipmentSet'
ALTER TABLE [dbo].[NinjaEquipmentSet]
ADD CONSTRAINT [FK_EquipmentNinjaEquipment]
    FOREIGN KEY ([Equipment_Id])
    REFERENCES [dbo].[EquipmentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentNinjaEquipment'
CREATE INDEX [IX_FK_EquipmentNinjaEquipment]
ON [dbo].[NinjaEquipmentSet]
    ([Equipment_Id]);
GO

-- Creating foreign key on [EquipmentType_Id] in table 'EquipmentSet'
ALTER TABLE [dbo].[EquipmentSet]
ADD CONSTRAINT [FK_EquipmentTypeEquipment]
    FOREIGN KEY ([EquipmentType_Id])
    REFERENCES [dbo].[EquipmentTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentTypeEquipment'
CREATE INDEX [IX_FK_EquipmentTypeEquipment]
ON [dbo].[EquipmentSet]
    ([EquipmentType_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------