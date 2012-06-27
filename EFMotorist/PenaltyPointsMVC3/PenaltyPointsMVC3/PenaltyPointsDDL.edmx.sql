
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2012 14:23:06
-- Generated from EDMX file: C:\Users\AnthonyOToole\Desktop\sqlserver penaltypoints\PenaltyPointsMVC3\PenaltyPointsMVC3\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PenaltyPointsDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ListedOffences'
CREATE TABLE [dbo].[ListedOffences] (
    [LoId] int IDENTITY(1,1) NOT NULL,
    [LoName] nvarchar(max)  NOT NULL,
    [LoDesc] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [LoId] in table 'ListedOffences'
ALTER TABLE [dbo].[ListedOffences]
ADD CONSTRAINT [PK_ListedOffences]
    PRIMARY KEY CLUSTERED ([LoId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------