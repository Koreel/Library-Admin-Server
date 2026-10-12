SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE Users (
                       UserID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                       Username VARCHAR(50) UNIQUE NOT NULL,
                       PasswordHash VARCHAR(255) NOT NULL,
                       Email VARCHAR(100) UNIQUE NOT NULL,
                       Role VARCHAR(50) DEFAULT 'User',
                       IsActiveFg BIT DEFAULT 0,

                       CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
                       UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),

    -- Temporal table columns
                       ValidFrom DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL,
                       ValidTo DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL,

                       PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
)
    WITH (
        SYSTEM_VERSIONING = ON,
        HISTORY_TABLE = dbo.UsersHistory
        );
GO