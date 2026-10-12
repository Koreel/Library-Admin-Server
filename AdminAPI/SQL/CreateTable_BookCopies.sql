SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE BookCopies (
                            CopyID INT PRIMARY KEY IDENTITY(1,1),
                            BookID INT NOT NULL,
                            IsAvailable BIT NOT NULL DEFAULT 1,

                            CONSTRAINT FK_BookCopies_BookDetails
                                FOREIGN KEY (BookID)
                                    REFERENCES BookDetails(id)
);