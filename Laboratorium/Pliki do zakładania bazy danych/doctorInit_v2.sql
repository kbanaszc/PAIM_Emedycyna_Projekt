
BEGIN TRANSACTION;
GO

CREATE TABLE [Specjalization] (
    [id] int NOT NULL IDENTITY,
    [specName] VARCHAR(20) NOT NULL,
	[Type] int NOT NULL,
    CONSTRAINT [PK_Specjalization] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Doctor] (
    [id] int NOT NULL IDENTITY,
    [Name] VARCHAR(20) NOT NULL,
    CONSTRAINT [PK_Doctor] PRIMARY KEY ([id])
);
GO

CREATE TABLE [DoctorSpecjalization] (
    [SpecjalizationId] int NOT NULL,
    [DoctorId] int NOT NULL,
    CONSTRAINT [PK_DoctorSpecjalization] PRIMARY KEY ([SpecjalizationId], [DoctorId]),
    CONSTRAINT [FK_DoctorSpecjalization_Specjalization_SpecjalizationId] FOREIGN KEY ([SpecjalizationId]) REFERENCES [Specjalization] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_DoctorSpecjalization_Doctor_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctor] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_DoctorSpecjalization_DoctorId] ON [DoctorSpecjalization] ([DoctorId]);
GO


COMMIT;
GO

