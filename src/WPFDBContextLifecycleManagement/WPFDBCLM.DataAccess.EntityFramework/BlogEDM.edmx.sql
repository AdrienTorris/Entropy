
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2016 15:00:54
-- Generated from EDMX file: C:\Users\a.torris\Documents\Workspace\Entropy\src\WPFDBContextLifecycleManagement\WPFDBCLM.DataAccess.EntityFramework\BlogEDM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [YourDB];
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

-- Creating table 'BlogPosts'
CREATE TABLE [dbo].[BlogPosts] (
    [Id] uniqueidentifier  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [LastUpdateDate] datetime  NOT NULL,
    [BlogCategoryId] int  NOT NULL
);
GO

-- Creating table 'BlogCategories'
CREATE TABLE [dbo].[BlogCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BlogPosts'
ALTER TABLE [dbo].[BlogPosts]
ADD CONSTRAINT [PK_BlogPosts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogCategories'
ALTER TABLE [dbo].[BlogCategories]
ADD CONSTRAINT [PK_BlogCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BlogCategoryId] in table 'BlogPosts'
ALTER TABLE [dbo].[BlogPosts]
ADD CONSTRAINT [FK_BlogCategoryBlogPost]
    FOREIGN KEY ([BlogCategoryId])
    REFERENCES [dbo].[BlogCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogCategoryBlogPost'
CREATE INDEX [IX_FK_BlogCategoryBlogPost]
ON [dbo].[BlogPosts]
    ([BlogCategoryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------