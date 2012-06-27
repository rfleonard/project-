
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/06/2012 23:09:56
-- Generated from EDMX file: C:\Users\AnthonyOToole\Desktop\Semester 3\EntityFrameworkResearch\4.Project Versions\EFMotorist\PenaltyPointsMVC3\PenaltyPointsMVC3\PenaltyPointsModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_ListedOffencesOffencesHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OffencesHistory] DROP CONSTRAINT [FK_ListedOffencesOffencesHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_OffencesHistorySummonsDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SummonsDetails] DROP CONSTRAINT [FK_OffencesHistorySummonsDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_DriverDetailsOffencesHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OffencesHistory] DROP CONSTRAINT [FK_DriverDetailsOffencesHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleDetailsOffencesHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OffencesHistory] DROP CONSTRAINT [FK_VehicleDetailsOffencesHistory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ListedOffences]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListedOffences];
GO
IF OBJECT_ID(N'[dbo].[OffencesHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OffencesHistory];
GO
IF OBJECT_ID(N'[dbo].[VehicleDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleDetails];
GO
IF OBJECT_ID(N'[dbo].[DriverDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DriverDetails];
GO
IF OBJECT_ID(N'[dbo].[SummonsDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SummonsDetails];
GO
IF OBJECT_ID(N'[dbo].[NotificationsIssued]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NotificationsIssued];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ListedOffences'
CREATE TABLE [dbo].[ListedOffences] (
    [LoId] int IDENTITY(1,1) NOT NULL,
    [LoName] nvarchar(max)  NOT NULL,
    [LoDesc] nvarchar(max)  NOT NULL,
    [Lo28Days] int  NOT NULL,
    [Lo56days] int  NOT NULL,
    [LoCourtPoints] int  NOT NULL,
    [LoFine28] decimal(18,0)  NOT NULL,
    [LoFine56] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'OffencesHistory'
CREATE TABLE [dbo].[OffencesHistory] (
    [OhId] int IDENTITY(1,1) NOT NULL,
    [OhLoid] int  NOT NULL,
    [OhRegistration] nvarchar(max)  NOT NULL,
    [OhLicenceNo] nvarchar(10)  NOT NULL,
    [OhLocation] nvarchar(max)  NOT NULL,
    [OhOffenceDate] datetime  NOT NULL,
    [OhStatus] nvarchar(max)  NOT NULL,
    [OhPointsApplied] int  NOT NULL,
    [OhPointsDate] datetime  NOT NULL,
    [VehicleDetailsVdRegistration] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'VehicleDetails'
CREATE TABLE [dbo].[VehicleDetails] (
    [VdRegistration] nvarchar(10)  NOT NULL,
    [VdType] nvarchar(max)  NOT NULL,
    [VdMake] nvarchar(max)  NOT NULL,
    [VdCubicCapacity] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'DriverDetails'
CREATE TABLE [dbo].[DriverDetails] (
    [DdLicenceNo] nvarchar(10)  NOT NULL,
    [DdName] nvarchar(max)  NOT NULL,
    [DdAddress] nvarchar(max)  NOT NULL,
    [DdAccumulatedPoints] int  NOT NULL,
    [DdLicenceStatus] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SummonsDetails'
CREATE TABLE [dbo].[SummonsDetails] (
    [SdId] int IDENTITY(1,1) NOT NULL,
    [SdDate] datetime  NOT NULL,
    [SdJudgement] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NotificationsIssued'
CREATE TABLE [dbo].[NotificationsIssued] (
    [NiLicenceNo] nvarchar(10)  NOT NULL,
    [NiName] nvarchar(max)  NOT NULL,
    [NiPoints] int  NOT NULL,
    [NiDesc] nvarchar(max)  NOT NULL,
    [NiDate] datetime  NOT NULL
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

-- Creating primary key on [OhId] in table 'OffencesHistory'
ALTER TABLE [dbo].[OffencesHistory]
ADD CONSTRAINT [PK_OffencesHistory]
    PRIMARY KEY CLUSTERED ([OhId] ASC);
GO

-- Creating primary key on [VdRegistration] in table 'VehicleDetails'
ALTER TABLE [dbo].[VehicleDetails]
ADD CONSTRAINT [PK_VehicleDetails]
    PRIMARY KEY CLUSTERED ([VdRegistration] ASC);
GO

-- Creating primary key on [DdLicenceNo] in table 'DriverDetails'
ALTER TABLE [dbo].[DriverDetails]
ADD CONSTRAINT [PK_DriverDetails]
    PRIMARY KEY CLUSTERED ([DdLicenceNo] ASC);
GO

-- Creating primary key on [SdId] in table 'SummonsDetails'
ALTER TABLE [dbo].[SummonsDetails]
ADD CONSTRAINT [PK_SummonsDetails]
    PRIMARY KEY CLUSTERED ([SdId] ASC);
GO

-- Creating primary key on [NiLicenceNo] in table 'NotificationsIssued'
ALTER TABLE [dbo].[NotificationsIssued]
ADD CONSTRAINT [PK_NotificationsIssued]
    PRIMARY KEY CLUSTERED ([NiLicenceNo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OhLoid] in table 'OffencesHistory'
ALTER TABLE [dbo].[OffencesHistory]
ADD CONSTRAINT [FK_ListedOffencesOffencesHistory]
    FOREIGN KEY ([OhLoid])
    REFERENCES [dbo].[ListedOffences]
        ([LoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ListedOffencesOffencesHistory'
CREATE INDEX [IX_FK_ListedOffencesOffencesHistory]
ON [dbo].[OffencesHistory]
    ([OhLoid]);
GO

-- Creating foreign key on [SdId] in table 'SummonsDetails'
ALTER TABLE [dbo].[SummonsDetails]
ADD CONSTRAINT [FK_OffencesHistorySummonsDetails]
    FOREIGN KEY ([SdId])
    REFERENCES [dbo].[OffencesHistory]
        ([OhId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OhLicenceNo] in table 'OffencesHistory'
ALTER TABLE [dbo].[OffencesHistory]
ADD CONSTRAINT [FK_DriverDetailsOffencesHistory]
    FOREIGN KEY ([OhLicenceNo])
    REFERENCES [dbo].[DriverDetails]
        ([DdLicenceNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DriverDetailsOffencesHistory'
CREATE INDEX [IX_FK_DriverDetailsOffencesHistory]
ON [dbo].[OffencesHistory]
    ([OhLicenceNo]);
GO

-- Creating foreign key on [VehicleDetailsVdRegistration] in table 'OffencesHistory'
ALTER TABLE [dbo].[OffencesHistory]
ADD CONSTRAINT [FK_VehicleDetailsOffencesHistory]
    FOREIGN KEY ([VehicleDetailsVdRegistration])
    REFERENCES [dbo].[VehicleDetails]
        ([VdRegistration])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleDetailsOffencesHistory'
CREATE INDEX [IX_FK_VehicleDetailsOffencesHistory]
ON [dbo].[OffencesHistory]
    ([VehicleDetailsVdRegistration]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------