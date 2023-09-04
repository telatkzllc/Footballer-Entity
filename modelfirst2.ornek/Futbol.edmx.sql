
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2023 10:48:50
-- Generated from EDMX file: C:\Users\girnet\Desktop\Yazılım Ders Notlarım\modelfirst2.ornek\modelfirst2.ornek\Futbol.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Spor];
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

-- Creating table 'FutbolcuSet'
CREATE TABLE [dbo].[FutbolcuSet] (
    [FutbolcuId] int IDENTITY(1,1) NOT NULL,
    [Fname] nvarchar(max)  NOT NULL,
    [Fulke] nvarchar(max)  NOT NULL,
    [Fmaas] decimal(18,0)  NOT NULL,
    [Fkulup] nvarchar(max)  NOT NULL,
    [AntrenorId] int  NOT NULL
);
GO

-- Creating table 'AntrenorSet'
CREATE TABLE [dbo].[AntrenorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amaas] decimal(18,0)  NOT NULL,
    [Aname] nvarchar(max)  NOT NULL,
    [Aulke] nvarchar(max)  NOT NULL,
    [Akulup] nvarchar(max)  NOT NULL,
    [BaskanId] int  NOT NULL
);
GO

-- Creating table 'SKSet'
CREATE TABLE [dbo].[SKSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Kname] nvarchar(max)  NOT NULL,
    [Kdeger] decimal(18,0)  NOT NULL,
    [Kcalısans] int  NOT NULL
);
GO

-- Creating table 'BaskanSet'
CREATE TABLE [dbo].[BaskanSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bname] nvarchar(max)  NOT NULL,
    [Bage] int  NOT NULL,
    [Bunvan] nvarchar(max)  NOT NULL,
    [SKId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FutbolcuId] in table 'FutbolcuSet'
ALTER TABLE [dbo].[FutbolcuSet]
ADD CONSTRAINT [PK_FutbolcuSet]
    PRIMARY KEY CLUSTERED ([FutbolcuId] ASC);
GO

-- Creating primary key on [Id] in table 'AntrenorSet'
ALTER TABLE [dbo].[AntrenorSet]
ADD CONSTRAINT [PK_AntrenorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SKSet'
ALTER TABLE [dbo].[SKSet]
ADD CONSTRAINT [PK_SKSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BaskanSet'
ALTER TABLE [dbo].[BaskanSet]
ADD CONSTRAINT [PK_BaskanSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AntrenorId] in table 'FutbolcuSet'
ALTER TABLE [dbo].[FutbolcuSet]
ADD CONSTRAINT [FK_AntrenorFutbolcu]
    FOREIGN KEY ([AntrenorId])
    REFERENCES [dbo].[AntrenorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AntrenorFutbolcu'
CREATE INDEX [IX_FK_AntrenorFutbolcu]
ON [dbo].[FutbolcuSet]
    ([AntrenorId]);
GO

-- Creating foreign key on [BaskanId] in table 'AntrenorSet'
ALTER TABLE [dbo].[AntrenorSet]
ADD CONSTRAINT [FK_BaskanAntrenor]
    FOREIGN KEY ([BaskanId])
    REFERENCES [dbo].[BaskanSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BaskanAntrenor'
CREATE INDEX [IX_FK_BaskanAntrenor]
ON [dbo].[AntrenorSet]
    ([BaskanId]);
GO

-- Creating foreign key on [SKId] in table 'BaskanSet'
ALTER TABLE [dbo].[BaskanSet]
ADD CONSTRAINT [FK_SKBaskan]
    FOREIGN KEY ([SKId])
    REFERENCES [dbo].[SKSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SKBaskan'
CREATE INDEX [IX_FK_SKBaskan]
ON [dbo].[BaskanSet]
    ([SKId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------