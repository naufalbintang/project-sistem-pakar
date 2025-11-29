-- ========================================================
-- SCHEMA DATABASE SISTEM PAKAR TOPIK SKRIPSI
-- ========================================================

-- =======================
-- 1. TABLE: Topik
-- =======================
CREATE TABLE [dbo].[Topik] (
    [Id_topik]   INT            IDENTITY (1, 1) NOT NULL,
    [nama_topik] NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_topik] ASC)
);


-- =======================
-- 2. TABLE: Mahasiswa
-- =======================
CREATE TABLE [dbo].[Mahasiswa] (
    [nim]   NVARCHAR (10)  NOT NULL,
    [nama]  NVARCHAR (100) NOT NULL,
    [prodi] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([nim] ASC)
);


-- =======================
-- 3. TABLE: Konsultasi
-- =======================
CREATE TABLE [dbo].[Konsultasi] (
    [Id_konsultasi] INT            IDENTITY (1, 1) NOT NULL,
    [Id_topik]      INT            NULL,
    [nim]           NVARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_konsultasi] ASC),

    FOREIGN KEY ([Id_topik]) REFERENCES [dbo].[Topik] ([Id_topik]),
    FOREIGN KEY ([nim])      REFERENCES [dbo].[Mahasiswa] ([nim])
);


-- =======================
-- 4. TABLE: Pertanyaan
-- =======================
CREATE TABLE [dbo].[Pertanyaan] (
    [Id_pertanyaan]    INT          IDENTITY (1, 1) NOT NULL,
    [teks_pertanyaan]  TEXT         NOT NULL,
    [bobot_pertanyaan] FLOAT (53)   NOT NULL,
    [Id_topik]         INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_pertanyaan] ASC),

    FOREIGN KEY ([Id_topik]) REFERENCES [dbo].[Topik] ([Id_topik])
);


-- =======================
-- 5. TABLE: Jawaban_Mhs
-- =======================
CREATE TABLE [dbo].[Jawaban_Mhs] (
    [Id_konsultasi] INT          NOT NULL,
    [Id_pertanyaan] INT          NOT NULL,
    [jawaban]       NVARCHAR(5)  NOT NULL,

    CONSTRAINT [PK_SesiJawaban]
        PRIMARY KEY CLUSTERED ([Id_pertanyaan] ASC, [Id_konsultasi] ASC),

    FOREIGN KEY ([Id_pertanyaan]) REFERENCES [dbo].[Pertanyaan] ([Id_pertanyaan]),
    FOREIGN KEY ([Id_konsultasi]) REFERENCES [dbo].[Konsultasi] ([Id_konsultasi])
);
