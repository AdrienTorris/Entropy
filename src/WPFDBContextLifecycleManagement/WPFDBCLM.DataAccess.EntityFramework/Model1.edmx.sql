
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/21/2016 13:56:38
-- Generated from EDMX file: C:\Users\a.torris\Documents\Workspace\Entropy\src\WPFDBContextLifecycleManagement\WPFDBCLM.DataAccess.EntityFramework\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [POCValoris];
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

-- Creating table 'BlogPostSet'
CREATE TABLE [dbo].[BlogPostSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [CreationDate] nvarchar(max)  NOT NULL,
    [Category_Id] int  NOT NULL
);
GO

-- Creating table 'BlogPostCategorySet'
CREATE TABLE [dbo].[BlogPostCategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BlogPostSet'
ALTER TABLE [dbo].[BlogPostSet]
ADD CONSTRAINT [PK_BlogPostSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogPostCategorySet'
ALTER TABLE [dbo].[BlogPostCategorySet]
ADD CONSTRAINT [PK_BlogPostCategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Category_Id] in table 'BlogPostSet'
ALTER TABLE [dbo].[BlogPostSet]
ADD CONSTRAINT [FK_CategoryId]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[BlogPostCategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryId'
CREATE INDEX [IX_FK_CategoryId]
ON [dbo].[BlogPostSet]
    ([Category_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------