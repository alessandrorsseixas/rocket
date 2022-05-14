CREATE TABLE [dbo].[ClientePetrobras] (
    [Id]    INT              IDENTITY (1, 1) NOT NULL,
    [Code]  UNIQUEIDENTIFIER NOT NULL,
    [Nome]  VARCHAR (100)    NOT NULL,
    [Porte] VARCHAR (10)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

