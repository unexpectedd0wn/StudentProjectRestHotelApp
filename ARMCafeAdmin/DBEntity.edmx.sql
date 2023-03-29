
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/29/2023 18:21:38
-- Generated from EDMX file: C:\Users\AIS\Documents\RestHotelApp - Copy\ARMCafeAdmin\DBEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HMS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

--IF OBJECT_ID(N'[dbo].[FK_BanquetDishes_Banquets]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[BanquetDishes] DROP CONSTRAINT [FK_BanquetDishes_Banquets];
--GO
--IF OBJECT_ID(N'[dbo].[FK_BanquetDishes_Dishes]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[BanquetDishes] DROP CONSTRAINT [FK_BanquetDishes_Dishes];
--GO
--IF OBJECT_ID(N'[dbo].[FK_BanquetDishes_ToUsers]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[BanquetDishes] DROP CONSTRAINT [FK_BanquetDishes_ToUsers];
--GO
--IF OBJECT_ID(N'[dbo].[FK_Banquets_BanquetStatus]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[Banquets] DROP CONSTRAINT [FK_Banquets_BanquetStatus];
--GO
--IF OBJECT_ID(N'[dbo].[FK_Banquets_PrepaymentStatuses]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[Banquets] DROP CONSTRAINT [FK_Banquets_PrepaymentStatuses];
--GO
--IF OBJECT_ID(N'[dbo].[FK_Banquets_ToUsers]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[Banquets] DROP CONSTRAINT [FK_Banquets_ToUsers];
--GO
--IF OBJECT_ID(N'[dbo].[FK_BookingTables_BookingTableStatus]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[BookingTables] DROP CONSTRAINT [FK_BookingTables_BookingTableStatus];
--GO
--IF OBJECT_ID(N'[dbo].[FK_BookingTables_RestTables]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[BookingTables] DROP CONSTRAINT [FK_BookingTables_RestTables];
--GO
--IF OBJECT_ID(N'[dbo].[FK_BookingTables_ToUsers]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[BookingTables] DROP CONSTRAINT [FK_BookingTables_ToUsers];
--GO
--IF OBJECT_ID(N'[dbo].[FK_Dishes_DishType]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [FK_Dishes_DishType];
--GO
--IF OBJECT_ID(N'[dbo].[FK_DishType_ToUsers]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[DishType] DROP CONSTRAINT [FK_DishType_ToUsers];
--GO
--IF OBJECT_ID(N'[dbo].[FK_PrepaymentStatuses_ToUsers]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[PrepaymentStatuses] DROP CONSTRAINT [FK_PrepaymentStatuses_ToUsers];
--GO
--IF OBJECT_ID(N'[dbo].[FK_Reports_ToUsers]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_Reports_ToUsers];
--GO
--IF OBJECT_ID(N'[dbo].[FK_RestTables_ToTablePosition]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[RestTables] DROP CONSTRAINT [FK_RestTables_ToTablePosition];
--GO
--IF OBJECT_ID(N'[dbo].[FK_RestTables_ToUsers]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[RestTables] DROP CONSTRAINT [FK_RestTables_ToUsers];
--GO
--IF OBJECT_ID(N'[dbo].[FK_TablePosition_ToUsers]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[TablePosition] DROP CONSTRAINT [FK_TablePosition_ToUsers];
--GO
--IF OBJECT_ID(N'[dbo].[FK_Waiters_ToUsers]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[Waiters] DROP CONSTRAINT [FK_Waiters_ToUsers];
--GO
--IF OBJECT_ID(N'[dbo].[FK_WatersSchedule_ToUsers]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[WatersSchedule] DROP CONSTRAINT [FK_WatersSchedule_ToUsers];
--GO

---- --------------------------------------------------
---- Dropping existing tables
---- --------------------------------------------------

--IF OBJECT_ID(N'[dbo].[BanquetDishes]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[BanquetDishes];
--GO
--IF OBJECT_ID(N'[dbo].[Banquets]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[Banquets];
--GO
--IF OBJECT_ID(N'[dbo].[BanquetStatus]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[BanquetStatus];
--GO
--IF OBJECT_ID(N'[dbo].[BookingTables]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[BookingTables];
--GO
--IF OBJECT_ID(N'[dbo].[BookingTableStatus]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[BookingTableStatus];
--GO
--IF OBJECT_ID(N'[dbo].[Dishes]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[Dishes];
--GO
--IF OBJECT_ID(N'[dbo].[DishType]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[DishType];
--GO
--IF OBJECT_ID(N'[dbo].[PrepaymentStatuses]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[PrepaymentStatuses];
--GO
--IF OBJECT_ID(N'[dbo].[Reports]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[Reports];
--GO
--IF OBJECT_ID(N'[dbo].[RestTables]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[RestTables];
--GO
--IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[sysdiagrams];
--GO
--IF OBJECT_ID(N'[dbo].[TablePosition]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[TablePosition];
--GO
--IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[Users];
--GO
--IF OBJECT_ID(N'[dbo].[Waiters]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[Waiters];
--GO
--IF OBJECT_ID(N'[dbo].[WatersSchedule]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[WatersSchedule];
--GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BanquetDishes'
CREATE TABLE [dbo].[BanquetDishes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BanquetId] int  NOT NULL,
    [DishId] int  NOT NULL,
    [Qty] int  NULL,
    [ChangedBy] int  NULL,
    [ChangedDate] datetime  NULL
);
GO

-- Creating table 'BanquetStatus'
CREATE TABLE [dbo].[BanquetStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(10)  NOT NULL
);
GO

-- Creating table 'BookingTableStatus'
CREATE TABLE [dbo].[BookingTableStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'BookingTables'
CREATE TABLE [dbo].[BookingTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [PhoneNumber] nvarchar(50)  NOT NULL,
    [Table] int  NOT NULL,
    [NumberOfQuests] nvarchar(50)  NOT NULL,
    [StatusId] int  NOT NULL,
    [BookingTime] varchar(50)  NOT NULL,
    [ChangedBy] int  NOT NULL,
    [ChangedDate] datetime  NOT NULL
);
GO

-- Creating table 'Dishes'
CREATE TABLE [dbo].[Dishes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Price] decimal(10,0)  NOT NULL,
    [Discount] decimal(10,0)  NULL,
    [Type] int  NULL,
    [Weight] decimal(10,0)  NOT NULL,
    [IsAvalible] bit  NOT NULL,
    [Сomposition] nvarchar(max)  NULL,
    [ChangedBy] int  NULL,
    [ChangedDate] datetime  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [isAdmininistrator] bit  NOT NULL
);
GO

-- Creating table 'Waiters'
CREATE TABLE [dbo].[Waiters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [PhoneNumber] nvarchar(50)  NULL,
    [ChangedBy] int  NOT NULL,
    [ChangedDate] datetime  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'WatersSchedules'
CREATE TABLE [dbo].[WatersSchedules] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WaterId] int  NOT NULL,
    [WorkDate] datetime  NOT NULL,
    [ChangedBy] int  NOT NULL,
    [ChangedDate] datetime  NOT NULL
);
GO

-- Creating table 'Banquets'
CREATE TABLE [dbo].[Banquets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Time] varchar(50)  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [NumberOfQuests] nvarchar(50)  NOT NULL,
    [CustomerFirstName] nvarchar(50)  NOT NULL,
    [CustomerLastName] nvarchar(50)  NOT NULL,
    [CustomerPhoneNumber] nvarchar(50)  NOT NULL,
    [PrepaymentId] int  NOT NULL,
    [StatusId] int  NOT NULL,
    [Service] decimal(10,0)  NOT NULL,
    [Discount] decimal(5,2)  NOT NULL,
    [ChangedBy] int  NOT NULL,
    [ChangeDate] datetime  NOT NULL
);
GO

-- Creating table 'DishTypes'
CREATE TABLE [dbo].[DishTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [ChangedBy] int  NOT NULL,
    [ChangedDate] datetime  NOT NULL
);
GO

-- Creating table 'PrepaymentStatuses'
CREATE TABLE [dbo].[PrepaymentStatuses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [ChangedBy] int  NOT NULL,
    [ChangedDate] datetime  NOT NULL
);
GO

-- Creating table 'Reports'
CREATE TABLE [dbo].[Reports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [ChangedBy] int  NOT NULL,
    [ChangedDate] datetime  NOT NULL
);
GO

-- Creating table 'TablePositions'
CREATE TABLE [dbo].[TablePositions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [ChangedBy] int  NOT NULL,
    [ChangedDate] datetime  NOT NULL
);
GO

-- Creating table 'RestTables'
CREATE TABLE [dbo].[RestTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TableNumber] int  NOT NULL,
    [PositionId] int  NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [ChangedBy] int  NOT NULL,
    [ChangedDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BanquetDishes'
ALTER TABLE [dbo].[BanquetDishes]
ADD CONSTRAINT [PK_BanquetDishes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BanquetStatus'
ALTER TABLE [dbo].[BanquetStatus]
ADD CONSTRAINT [PK_BanquetStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BookingTableStatus'
ALTER TABLE [dbo].[BookingTableStatus]
ADD CONSTRAINT [PK_BookingTableStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'BookingTables'
ALTER TABLE [dbo].[BookingTables]
ADD CONSTRAINT [PK_BookingTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Dishes'
ALTER TABLE [dbo].[Dishes]
ADD CONSTRAINT [PK_Dishes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Waiters'
ALTER TABLE [dbo].[Waiters]
ADD CONSTRAINT [PK_Waiters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WatersSchedules'
ALTER TABLE [dbo].[WatersSchedules]
ADD CONSTRAINT [PK_WatersSchedules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Banquets'
ALTER TABLE [dbo].[Banquets]
ADD CONSTRAINT [PK_Banquets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DishTypes'
ALTER TABLE [dbo].[DishTypes]
ADD CONSTRAINT [PK_DishTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PrepaymentStatuses'
ALTER TABLE [dbo].[PrepaymentStatuses]
ADD CONSTRAINT [PK_PrepaymentStatuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [PK_Reports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TablePositions'
ALTER TABLE [dbo].[TablePositions]
ADD CONSTRAINT [PK_TablePositions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RestTables'
ALTER TABLE [dbo].[RestTables]
ADD CONSTRAINT [PK_RestTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StatusId] in table 'BookingTables'
ALTER TABLE [dbo].[BookingTables]
ADD CONSTRAINT [FK_BookingTables_BookingTableStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[BookingTableStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingTables_BookingTableStatus'
CREATE INDEX [IX_FK_BookingTables_BookingTableStatus]
ON [dbo].[BookingTables]
    ([StatusId]);
GO

-- Creating foreign key on [DishId] in table 'BanquetDishes'
ALTER TABLE [dbo].[BanquetDishes]
ADD CONSTRAINT [FK_BanquetDishes_Dishes]
    FOREIGN KEY ([DishId])
    REFERENCES [dbo].[Dishes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BanquetDishes_Dishes'
CREATE INDEX [IX_FK_BanquetDishes_Dishes]
ON [dbo].[BanquetDishes]
    ([DishId]);
GO

-- Creating foreign key on [ChangedBy] in table 'BanquetDishes'
ALTER TABLE [dbo].[BanquetDishes]
ADD CONSTRAINT [FK_BanquetDishes_ToUsers]
    FOREIGN KEY ([ChangedBy])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BanquetDishes_ToUsers'
CREATE INDEX [IX_FK_BanquetDishes_ToUsers]
ON [dbo].[BanquetDishes]
    ([ChangedBy]);
GO

-- Creating foreign key on [ChangedBy] in table 'BookingTables'
ALTER TABLE [dbo].[BookingTables]
ADD CONSTRAINT [FK_BookingTables_ToUsers]
    FOREIGN KEY ([ChangedBy])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingTables_ToUsers'
CREATE INDEX [IX_FK_BookingTables_ToUsers]
ON [dbo].[BookingTables]
    ([ChangedBy]);
GO

-- Creating foreign key on [ChangedBy] in table 'Waiters'
ALTER TABLE [dbo].[Waiters]
ADD CONSTRAINT [FK_Waiters_ToUsers]
    FOREIGN KEY ([ChangedBy])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Waiters_ToUsers'
CREATE INDEX [IX_FK_Waiters_ToUsers]
ON [dbo].[Waiters]
    ([ChangedBy]);
GO

-- Creating foreign key on [ChangedBy] in table 'WatersSchedules'
ALTER TABLE [dbo].[WatersSchedules]
ADD CONSTRAINT [FK_WatersSchedule_ToUsers]
    FOREIGN KEY ([ChangedBy])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WatersSchedule_ToUsers'
CREATE INDEX [IX_FK_WatersSchedule_ToUsers]
ON [dbo].[WatersSchedules]
    ([ChangedBy]);
GO

-- Creating foreign key on [BanquetId] in table 'BanquetDishes'
ALTER TABLE [dbo].[BanquetDishes]
ADD CONSTRAINT [FK_BanquetDishes_Banquets]
    FOREIGN KEY ([BanquetId])
    REFERENCES [dbo].[Banquets]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BanquetDishes_Banquets'
CREATE INDEX [IX_FK_BanquetDishes_Banquets]
ON [dbo].[BanquetDishes]
    ([BanquetId]);
GO

-- Creating foreign key on [StatusId] in table 'Banquets'
ALTER TABLE [dbo].[Banquets]
ADD CONSTRAINT [FK_Banquets_BanquetStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[BanquetStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Banquets_BanquetStatus'
CREATE INDEX [IX_FK_Banquets_BanquetStatus]
ON [dbo].[Banquets]
    ([StatusId]);
GO

-- Creating foreign key on [ChangedBy] in table 'Banquets'
ALTER TABLE [dbo].[Banquets]
ADD CONSTRAINT [FK_Banquets_ToUsers]
    FOREIGN KEY ([ChangedBy])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Banquets_ToUsers'
CREATE INDEX [IX_FK_Banquets_ToUsers]
ON [dbo].[Banquets]
    ([ChangedBy]);
GO

-- Creating foreign key on [PrepaymentId] in table 'Banquets'
ALTER TABLE [dbo].[Banquets]
ADD CONSTRAINT [FK_Banquets_PrepaymentStatuses]
    FOREIGN KEY ([PrepaymentId])
    REFERENCES [dbo].[PrepaymentStatuses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Banquets_PrepaymentStatuses'
CREATE INDEX [IX_FK_Banquets_PrepaymentStatuses]
ON [dbo].[Banquets]
    ([PrepaymentId]);
GO

-- Creating foreign key on [Type] in table 'Dishes'
ALTER TABLE [dbo].[Dishes]
ADD CONSTRAINT [FK_Dishes_DishType]
    FOREIGN KEY ([Type])
    REFERENCES [dbo].[DishTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Dishes_DishType'
CREATE INDEX [IX_FK_Dishes_DishType]
ON [dbo].[Dishes]
    ([Type]);
GO

-- Creating foreign key on [ChangedBy] in table 'DishTypes'
ALTER TABLE [dbo].[DishTypes]
ADD CONSTRAINT [FK_DishType_ToUsers]
    FOREIGN KEY ([ChangedBy])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DishType_ToUsers'
CREATE INDEX [IX_FK_DishType_ToUsers]
ON [dbo].[DishTypes]
    ([ChangedBy]);
GO

-- Creating foreign key on [ChangedBy] in table 'PrepaymentStatuses'
ALTER TABLE [dbo].[PrepaymentStatuses]
ADD CONSTRAINT [FK_PrepaymentStatuses_ToUsers]
    FOREIGN KEY ([ChangedBy])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrepaymentStatuses_ToUsers'
CREATE INDEX [IX_FK_PrepaymentStatuses_ToUsers]
ON [dbo].[PrepaymentStatuses]
    ([ChangedBy]);
GO

-- Creating foreign key on [ChangedBy] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [FK_Reports_ToUsers]
    FOREIGN KEY ([ChangedBy])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reports_ToUsers'
CREATE INDEX [IX_FK_Reports_ToUsers]
ON [dbo].[Reports]
    ([ChangedBy]);
GO

-- Creating foreign key on [ChangedBy] in table 'TablePositions'
ALTER TABLE [dbo].[TablePositions]
ADD CONSTRAINT [FK_TablePosition_ToUsers]
    FOREIGN KEY ([ChangedBy])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TablePosition_ToUsers'
CREATE INDEX [IX_FK_TablePosition_ToUsers]
ON [dbo].[TablePositions]
    ([ChangedBy]);
GO

-- Creating foreign key on [Table] in table 'BookingTables'
ALTER TABLE [dbo].[BookingTables]
ADD CONSTRAINT [FK_BookingTables_RestTables]
    FOREIGN KEY ([Table])
    REFERENCES [dbo].[RestTables]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingTables_RestTables'
CREATE INDEX [IX_FK_BookingTables_RestTables]
ON [dbo].[BookingTables]
    ([Table]);
GO

-- Creating foreign key on [PositionId] in table 'RestTables'
ALTER TABLE [dbo].[RestTables]
ADD CONSTRAINT [FK_RestTables_ToTablePosition]
    FOREIGN KEY ([PositionId])
    REFERENCES [dbo].[TablePositions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestTables_ToTablePosition'
CREATE INDEX [IX_FK_RestTables_ToTablePosition]
ON [dbo].[RestTables]
    ([PositionId]);
GO

-- Creating foreign key on [ChangedBy] in table 'RestTables'
ALTER TABLE [dbo].[RestTables]
ADD CONSTRAINT [FK_RestTables_ToUsers]
    FOREIGN KEY ([ChangedBy])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestTables_ToUsers'
CREATE INDEX [IX_FK_RestTables_ToUsers]
ON [dbo].[RestTables]
    ([ChangedBy]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------