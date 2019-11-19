namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitializeDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libraries",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    libraryName = c.String(nullable: false, maxLength: 100),
                    libraryAddress = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            Sql(@"SET IDENTITY_INSERT [dbo].[Libraries] ON
            INSERT INTO [dbo].[Libraries] ([ID], [libraryName], [libraryAddress]) VALUES (1, N'Library Rishon Lezion', N'31.9742542,34.7994532')
            SET IDENTITY_INSERT [dbo].[Libraries] OFF
            ");

            CreateTable(
                "dbo.Genres",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    genreName = c.String(),
                })
                .PrimaryKey(t => t.ID);
            Sql(@"SET IDENTITY_INSERT [dbo].[Genres] ON
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (1, N'Comedy')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (2, N'Romance')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (3, N'Drama')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (4, N'Action')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (5, N'Horror')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (6, N'SciFi')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (7, N'Thriller')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (8, N'Children')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (9, N'Fantasy')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (10, N'Crime')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (11, N'Thriller')
            INSERT INTO [dbo].[Genres] ([ID], [genreName]) VALUES (12, N'Adventure')
            SET IDENTITY_INSERT [dbo].[Genres] OFF
            ");

            CreateTable(
                "dbo.MembershipTypes",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    membershipType = c.String(nullable: false, maxLength: 100),
                    duration = c.Int(nullable: false),
                    payment = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);
            Sql(@"SET IDENTITY_INSERT [dbo].[MembershipTypes] ON
            INSERT INTO [dbo].[MembershipTypes] ([ID], [membershipType], [duration], [payment]) VALUES (1, N'Free', 99999, 0)
            INSERT INTO [dbo].[MembershipTypes] ([ID], [membershipType], [duration], [payment]) VALUES (2, N'Premium', 12, 10)
            SET IDENTITY_INSERT [dbo].[MembershipTypes] OFF");

            CreateTable(
                "dbo.Books",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    bookName = c.String(nullable: false, maxLength: 100),
                    genreID = c.Int(nullable: false),
                    dateAdded = c.DateTime(nullable: false),
                    releaseDate = c.DateTime(nullable: false),
                    author = c.String(maxLength: 150),
                    membershipType = c.Int(nullable: false),
                    summary = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genres", t => t.genreID, cascadeDelete: true)
                .Index(t => t.genreID);
            Sql(@"SET IDENTITY_INSERT [dbo].[Books] ON
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (1, N'The Catcher in the Rye', 1, N'2017-11-04 00:00:00', N'1951-12-11 00:00:00', N'  J. D. Salinger ', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (2, N'Angels & Demons', 12, N'2017-11-04 00:00:00', N'2000-05-09 00:00:00', N'Dan Brown ', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (3, N'Pride and Prejudicer', 4, N'2017-11-04 00:00:00', N'1813-01-28 00:00:00', N' Jane Austen', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (4, N'The Kite Runner', 4, N'2017-11-12 00:00:00', N'2003-09-12 00:00:00', N' Khaled Hosseini', 1, N' Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (5, N'Divergent', 3, N'2017-11-12 00:00:00', N'2016-02-04 00:00:00', N'Veronica Roth ', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (6, N'Nineteen Eighty-Four', 5, N'2017-11-12 00:00:00', N'1949-06-08 00:00:00', N'George Orwell', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (7, N'Animal Farm: A Fairy Story', 8, N'2017-11-12 00:00:00', N'1945-08-17 00:00:00', N' George Orwell', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (8, N'Catching Fire', 10, N'2017-11-12 00:00:00', N'2009-09-01 00:00:00', N' Suzanne Collins', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (9, N'Harry Potter and the Prisoner of Azkaban ', 3, N'2017-11-12 00:00:00', N'1999-07-08 00:00:00', N'  J. K. Rowling', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (10, N'The Fellowship of the Ring', 1, N'2017-11-12 00:00:00', N'1954-07-29 00:00:00', N' J. R. R. Tolkien', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (11, N'Mockingjay', 1, N'2017-11-12 00:00:00', N'2010-07-24 00:00:00', N' Suzanne Collins', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (12, N'The Lovely Bones', 10, N'2017-11-12 00:00:00', N'2002-06-03 00:00:00', N' Alice Sebold', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (13, N'Lord of the Flies', 8, N'2017-11-12 00:00:00', N'1954-09-17 00:00:00', N'William Golding', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (14, N'Gone Girl', 9, N'2017-11-12 00:00:00', N'2012-05-24 00:00:00', N'Gillian Flynn', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (15, N'The Help', 3, N'2017-11-12 00:00:00', N'2009-02-10 00:00:00', N' Kathryn Stockett', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (16, N'Memoirs of a Geisha', 11, N'2017-11-12 00:00:00', N'1997-09-27 00:00:00', N' Arthur Golden', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (17, N'Fifty Shades of Grey', 3, N'2017-11-12 00:00:00', N'2011-12-08 00:00:00', N' E. L. James', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (18, N'The Alchemist', 2, N'2017-11-12 00:00:00', N'1998-06-03 00:00:00', N'Paulo Coelho', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (19, N'The Notebook', 4, N'2017-11-12 00:00:00', N'1996-10-01 00:00:00', N'Nicholas Sparks', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (20, N'Water for Elephants', 2, N'2017-11-12 00:00:00', N'2006-05-26 00:00:00', N'Sara Gruen', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (21, N'The Book Thief', 11, N'2017-11-12 00:00:00', N'2005-11-02 00:00:00', N'Markus Zusak', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (22, N'The Adventures of Huckleberry Finn', 12, N'2017-11-12 00:00:00', N'1884-12-10 00:00:00', N'Mark Twain', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (23, N'The Perks of Being a Wallflower', 4, N'2017-11-12 00:00:00', N'1999-02-01 00:00:00', N' Stephen Chbosky', 2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (24, N'Insurgent', 1, N'2017-11-12 00:00:00', N'2012-05-01 00:00:00', N'Veronica Roth', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (25, N'The Princess Bride', 4, N'2017-11-12 00:00:00', N'1973-12-08 00:00:00', N'William Goldman', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            INSERT INTO [dbo].[Books] ([ID], [bookName], [genreID], [dateAdded], [releaseDate], [author], [membershipType], [summary]) VALUES (26, N'The Road', 12, N'2017-11-12 00:00:00', N'2006-09-26 00:00:00', N'Cormac McCarthyv', 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.')
            SET IDENTITY_INSERT [dbo].[Books] OFF

            ");


            CreateTable(
                "dbo.Rentals",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    rentalUser = c.String(),
                    rentalBook = c.String(),
                    rentalExpiration = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);
            Sql(@"SET IDENTITY_INSERT [dbo].[Rentals] ON
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (1, N'MicaArrowsmith@library.com', N'Gladiator', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (2, N'LoraineMcmaster@library.com', N'The Hangover', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (3, N'VelvaCollett@library.com', N'Scream', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (4, N'genishbat', N'the', N'2017-11-13 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (5, N'EthylMerryman@library.com', N'Inception', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (6, N'LoraineMcmaster@library.com', N'Frozen', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (7, N'VelvaCollett@library.com', N'Inception', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (8, N'MarciaAble@library.com', N'Gladiator', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (9, N'KevinLeedy@library.com', N'The Hangover', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (14, N'AldoIacovelli@library.com', N'Frozen', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (15, N'HwaJosephson@library.com', N'Inception', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (19, N'DavidMace@library.com', N'Harry Potter and the Sorcerer''s Stone', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (20, N'LinneaVidaurri@library.com', N'Fifty Shades Darker', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (24, N'EthylMerryman@library.com', N'Inception', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (25, N'AldoIacovelli@library.com', N'Frozen', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (26, N'HwaJosephson@library.com', N'Inception', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (27, N'DavidMace@library.com', N'Harry Potter and the Sorcerer''s Stone', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (28, N'LinneaVidaurri@library.com', N'Fifty Shades Darker', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (29, N'KashaGallimore@library.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (30, N'JulietteBosh@library.com', N'Fifty Shades Darker', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (31, N'MarciaAble@library.com', N'Forrest Gump', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (32, N'MarciaAble@library.com', N'Forrest Gump', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (33, N'GemmaLinz@library.com', N'Scream', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (34, N'JosefinaRiebel@library.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (38, N'GemmaLinz@library.com', N'Scream', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (39, N'JosefinaRiebel@library.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (48, N'MicaArrowsmith@library.com', N'Fifty Shades Darker', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (49, N'DinorahDhillon@library.com', N'The Hangover', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (50, N'MicaArrowsmith@library.com', N'Fifty Shades Darker', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (51, N'DinorahDhillon@library.com', N'The Hangover', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (52, N'MicaArrowsmith@library.com', N'The Wolf of Wall Street', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (53, N'MicaArrowsmith@library.com', N'The Wolf of Wall Street', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (54, N'CorrieDau@library.com', N'The Notebook', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (55, N'CorrieDau@library.com', N'The Notebook', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (56, N'DavidMace@library.com', N'Scream', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (57, N'LinneaVidaurri@library.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (58, N'LoraineMcmaster@library.com', N'The Wolf of Wall Street', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (59, N'DinorahDhillon@library.com', N'The Hangover', N'2017-03-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (60, N'GemmaLinz@library.com', N'Inception', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (61, N'MicaArrowsmith@library.com', N'Gladiator', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (63, N'DavidMace@library.com', N'Scream', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (64, N'LinneaVidaurri@library.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (65, N'LoraineMcmaster@library.com', N'The Wolf of Wall Street', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (70, N'DinorahDhillon@library.com', N'The Hangover', N'2017-03-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (76, N'GemmaLinz@library.com', N'Inception', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (77, N'MicaArrowsmith@library.com', N'Gladiator', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (78, N'LoraineMcmaster@library.com', N'The Hangover', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (79, N'VelvaCollett@library.com', N'Scream', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (80, N'LoraineMcmaster@library.com', N'Frozen', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (86, N'LoraineMcmaster@library.com', N'The Hangover', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (87, N'VelvaCollett@library.com', N'Scream', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (91, N'LoraineMcmaster@library.com', N'Frozen', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (92, N'VelvaCollett@library.com', N'Inception', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (93, N'VelvaCollett@library.com', N'Inception', N'2017-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (94, N'MarciaAble@library.com', N'Gladiator', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (95, N'KevinLeedy@library.com', N'The Hangover', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (96, N'MonserrateFabela@library.com', N'Scream', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (101, N'MarciaAble@library.com', N'Gladiator', N'2017-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (102, N'KevinLeedy@library.com', N'The Hangover', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (103, N'MonserrateFabela@library.com', N'Scream', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (108, N'MonserrateFabela@library.com', N'Scream', N'2017-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (109, N'GemmaLinz@library.com', N'Inception', N'2016-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (110, N'MicaArrowsmith@library.com', N'Gladiator', N'2016-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (111, N'DavidMace@library.com', N'Scream', N'2016-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (112, N'LinneaVidaurri@library.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (113, N'LoraineMcmaster@library.com', N'The Wolf of Wall Street', N'2015-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (114, N'DinorahDhillon@library.com', N'The Hangover', N'2015-03-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (115, N'GemmaLinz@library.com', N'Inception', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (116, N'MicaArrowsmith@library.com', N'Gladiator', N'2015-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (117, N'LoraineMcmaster@library.com', N'The Hangover', N'2015-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (118, N'VelvaCollett@library.com', N'Scream', N'2015-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (119, N'LoraineMcmaster@library.com', N'Frozen', N'2015-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (120, N'LoraineMcmaster@library.com', N'The Hangover', N'2015-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (121, N'VelvaCollett@library.com', N'Scream', N'2018-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (122, N'LoraineMcmaster@library.com', N'Frozen', N'2018-12-01 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (123, N'VelvaCollett@library.com', N'Inception', N'2016-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (124, N'VelvaCollett@library.com', N'Inception', N'2016-01-11 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (125, N'MarciaAble@library.com', N'Gladiator', N'2015-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (126, N'KevinLeedy@library.com', N'The Hangover', N'2016-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (127, N'MonserrateFabela@library.com', N'Scream', N'2016-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (128, N'MarciaAble@library.com', N'Gladiator', N'2016-02-12 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (129, N'KevinLeedy@library.com', N'The Hangover', N'2015-01-08 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (130, N'MonserrateFabela@library.com', N'Scream', N'2015-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (131, N'MonserrateFabela@library.com', N'Scream', N'2015-10-10 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (133, N'guest@library.com', N'Forrest Gump', N'2017-11-14 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (134, N'guest@library.com', N'The Notebook', N'2016-11-14 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (135, N'guest@library.com', N'Frozen', N'2016-11-14 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (136, N'guest@library.com', N'The Hangover', N'2017-11-20 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (137, N'guest@library.com', N'The Wolf of Wall Street', N'2017-11-28 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (138, N'guest@library.com', N'Harry Potter and the Sorcerer''s Stone', N'2017-11-14 00:00:00')
            INSERT INTO [dbo].[Rentals] ([ID], [rentalUser], [rentalBook], [rentalExpiration]) VALUES (139, N'guest@library.com', N'Inception', N'2017-11-10 00:00:00')
            SET IDENTITY_INSERT [dbo].[Rentals] OFF
            ");
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cb3fc2b9-663f-4bb7-849e-cf086e5ae840', N'Manager')
            ");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'90de9e1c-8eae-4642-8918-a52c6fcff28d', N'cb3fc2b9-663f-4bb7-849e-cf086e5ae840')
            ");


            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    fName = c.String(nullable: false, maxLength: 50),
                    lName = c.String(nullable: false, maxLength: 50),
                    gender = c.String(nullable: false),
                    birth = c.DateTime(nullable: false),
                    membershipTypeID = c.Int(nullable: false),
                    genreID = c.Int(nullable: false),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'002e0b7c-9b1f-4030-83d8-226bdccbcdc0', N'Loraine', N'Mcmaster', N'male', N'1993-07-06 00:00:00', 1, 1, N'LoraineMcmaster@library.com', 0, N'ADY9H1/ZgmtaYaq3EBQm3656pkhxBuJmZi0eEW5jz2xuQM8Gt/ycksVZQmGTP2rxkA==', N'280c037e-59d4-4365-92d3-58b411f55f08', NULL, 0, 0, NULL, 1, 0, N'LoraineMcmaster@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0944aae4-927e-4f46-b271-bc23eb8b986f', N'Lettie', N'Levitt', N'female', N'1991-07-01 00:00:00', 1, 2, N'LettieLevitt@library.com', 0, N'AE0a52DCfvECf89l9ubEBmnKLy8JhCiuB4f5alNn9l4la3avo5Qeck0fARb02Oz4fQ==', N'fe2419ea-6706-49f3-b646-66bc50fd866c', NULL, 0, 0, NULL, 1, 0, N'LettieLevitt@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c636a49-3991-4caf-b6c9-9cd378361891', N'Modesto', N'Tanksley', N'Female', N'1980-01-01 00:00:00', 1, 3, N'ModestoTanksley@library.com', 0, N'AGbL1XuXCA9KLdhDG9yk6boLdBlM1PgxElLinGh3SdEcnQhrMS8rgJx7C6rLYcIRdQ==', N'672c3f76-8493-40e7-8679-2ee936e7c955', NULL, 0, 0, NULL, 1, 0, N'ModestoTanksley@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'12f417ab-1e86-4642-8512-7650c40bada6', N'Brook', N'Middlebrooks', N'male', N'1991-03-01 00:00:00', 1, 4, N'BrookMiddlebrooks@library.com', 0, N'AOEFiDxBirXsvj1o8KQSN7MYhcIqDwSHaDndMc21rM7ETwQpwXqJpq3K0S4bogcmhw==', N'd984d5b6-cd69-498a-ad14-7b0a02a40f7e', NULL, 0, 0, NULL, 1, 0, N'BrookMiddlebrooks@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1b84aed6-d11e-4e13-9713-cc400a09407e', N'Merryman', N'Ethyl', N'Male', N'1991-11-05 00:00:00', 1, 5, N'EthylMerryman@library.com', 0, N'AF7UinowtRZTcpcJHyYZnMkse7KtLfpe5sFfTxo8hiAHYXIu9oNwXdagccjTwane6A==', N'9a7d209a-1c1b-4ab9-af46-c6815b2f7a5a', NULL, 0, 0, NULL, 1, 0, N'EthylMerryman@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2c80d8cf-9e46-4874-9f85-efafdad0bb39', N'Mica', N'Arrowsmith', N'female', N'1972-08-12 00:00:00', 2, 6, N'MicaArrowsmith@library.com', 0, N'ABdTPC/ig954qFL9gNTqrT9zSB8RNpUnmPZVAZ+eiFDR2LwCjn7HeWafU2bwHElqlw==', N'dc92b4ad-76bc-4128-ba47-e93b8e84f3c3', NULL, 0, 0, NULL, 1, 0, N'MicaArrowsmith@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'32ea37c3-c454-41e8-b657-0856ea908995', N'Hwa', N'Josephson', N'male', N'1980-07-05 00:00:00', 2, 7, N'HwaJosephson@library.com', 0, N'AIV46cTn0athyN3xdX6Nq/2OOmlIBE2pw+suZ+YsTXvdZJXEtWCBhZn/NyBhOlfU1A==', N'c734ba36-3066-4e67-82c7-3a49fa9eb12a', NULL, 0, 0, NULL, 1, 0, N'HwaJosephson@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3679ea23-fe40-4b28-8613-2d1db2aed345', N'Arlena', N'Admire', N'male', N'1966-08-07 00:00:00', 2, 8, N'ArlenaAdmire@library.com', 0, N'AN2SbiurQhEaVBoRs7pohrTm343eFhQnq+x9RLj85QdcjG9Zs36Mig3iNg0PAgtczA==', N'e61a750a-b3a0-4341-98c4-059976893880', NULL, 0, 0, NULL, 1, 0, N'ArlenaAdmire@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3a660a27-c70b-40c3-a2a6-e340695680ab', N'Marcia', N'Able', N'Female', N'1969-07-02 00:00:00', 1, 9, N'MarciaAble@library.com', 0, N'ALpg/RXHLWKLRR5MmPOvNglPZfj0FAOz4D18yhQrLZ/VrfPBlbgfhPJV99XAGYMLDw==', N'a35aca51-a5c3-4714-9835-eb7caf3e86ba', NULL, 0, 0, NULL, 1, 0, N'MarciaAble@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'45715a90-af82-45b9-9ba9-6c6a1cd797c8', N'Fabela', N'Monserrate', N'female', N'1970-07-12 00:00:00', 1, 10, N'MonserrateFabela@library.com', 0, N'APZY7Dhit58b+cUg6mNDPn2m/o2vT86mUcO+OKOE9mmlhzotmAp3YvoEZPyIDDhtqA==', N'8c99b07a-ed2f-4cb1-835e-b17699cc9e55', NULL, 0, 0, NULL, 1, 0, N'MonserrateFabela@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4deb911c-5f3f-4534-9103-c43f0f802a6c', N'Melanie', N'Gates', N'Female', N'1991-02-02 00:00:00', 1, 11, N'MelanieGates@library.com', 0, N'AGQLZXIpAB3/urxyDSmV+CJk4LdJTEcTRue2dKBdP5/ihqhQea6D0RSksp+Hbvx6DQ==', N'b8254c50-4b9f-45bd-b03d-21cfec4ef436', NULL, 0, 0, NULL, 1, 0, N'MelanieGates@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54174d90-0650-47ba-a0c8-b8881a48063f', N'Corrie', N'Dau', N'male', N'1990-01-01 00:00:00', 2, 12, N'CorrieDau@library.com', 0, N'AFJbrXBGwcX48+jRgbA5w0p1DbYjVpb0UGmVi/2TjTsSalx4BNDV2lVsjxclBwjMMg==', N'2935066a-8912-419d-89e6-70fac8e5c856', NULL, 0, 0, NULL, 1, 0, N'CorrieDau@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5d8757d4-fe5a-4ca1-a010-6e0da2397c0d', N'Linnea', N'Vidaurri', N'male', N'1991-07-11 00:00:00', 2, 1, N'LinneaVidaurri@library.com', 0, N'AIRocUDKWpYwvbk2zCMgLKkoJb2Xs/d6y9gMxl47oYjmN/xOzE3UB7bDT5cO2uff/g==', N'21454798-fb10-4a3f-bc8c-4b47af43d419', NULL, 0, 0, NULL, 1, 0, N'LinneaVidaurri@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'637d7611-ca44-4e51-ae6c-8e85cc8c947b', N'David', N'Mace', N'male', N'1988-07-05 00:00:00', 2, 2, N'DavidMace@library.com', 0, N'AGbuTP2OEb1d8B2mkaUr1DwnuaJw6l/LKGgKUA00jnBrMD267cKhELDKFujZLAtymQ==', N'fbd26175-4bc6-4ff6-a6af-aff961179dcc', NULL, 0, 0, NULL, 1, 0, N'DavidMace@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'658a1fd0-7527-4bc1-80ac-047be66a4593', N'Dhillon', N'Dinorah', N'male', N'1991-01-08 00:00:00', 1, 3, N'DinorahDhillon@library.com', 0, N'AJqWWCF+2LI4Fo+LNNVzkhC/hw9JHGhTs1zQpfDXqBijoYMEm06+YiuU74ywUhzSNg==', N'f51fc8cd-0a2e-4f16-8ad5-86b33de8c73d', NULL, 0, 0, NULL, 1, 0, N'DinorahDhillon@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6dc30dce-0a15-4596-99e0-f0b58ff06490', N'Linz', N'Gemma', N'Female', N'1964-03-11 00:00:00', 1, 4, N'GemmaLinz@library.com', 0, N'AMcu/IvAVBjP8u3OAXsUgziDdI/eflH/Q97ULEs1r+q3OGPqWOqcdtAIL4SuMibJEQ==', N'deaa5899-9abc-485c-8aa4-e58c931f0b85', NULL, 0, 0, NULL, 1, 0, N'GemmaLinz@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'90de9e1c-8eae-4642-8918-a52c6fcff28d', N'Admin', N'Admin', N'Female', N'1990-01-01 00:00:00', 1, 5, N'admin@library.com', 0, N'APgc8All1us+lIB0rYpQj1dsvfmmjPL/NY/o823wNfTq57VlhFQEbilFZd7h1B0HcQ==', N'611e7412-723e-437b-889a-d9456af8a9a6', NULL, 0, 0, NULL, 1, 0, N'admin@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'927d2c14-c082-454a-8e93-ced88d93cba5', N'Louie', N'Fulmer', N'male', N'1982-11-10 00:00:00', 1, 1, N'LouieFulmer@library.com', 0, N'ACqthdy5mgkiC04HerXs7MntGoiB2/esDU76oDy7TX4QROuG44oNzKUQv3aO2lv6Pw==', N'0e8e2a04-7db7-4815-b9f3-778afd222c7a', NULL, 0, 0, NULL, 1, 0, N'LouieFulmer@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b39e5ae4-6ad3-401d-a607-c908cd76e099', N'Kevin', N'Leedy', N'male', N'1982-10-12 00:00:00', 1, 2, N'KevinLeedy@library.com', 0, N'APgnN1iKwjU4VmWD3nakkhXT/XkQAzI9n4Jss4n4pZw7Ntp6oSa7r8lNE0Z8i7mw2A==', N'080fb082-3155-4285-8840-6ef912cd8631', NULL, 0, 0, NULL, 1, 0, N'KevinLeedy@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b7df5533-177d-4cf0-a898-225207ccebe2', N'Kasha', N'Gallimore', N'male', N'1995-06-06 00:00:00', 1, 3, N'KashaGallimore@library.com', 0, N'AH6MHNDP58Uy7KN4Tzhl7GfIXtX3oITfAAlYNt4AN9RWo1fJQom+sY3u1SZxFVPHrA==', N'd9611769-ab63-4e0b-b971-be1e7f3665e0', NULL, 0, 0, NULL, 1, 0, N'KashaGallimore@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c06e2d4c-f7b9-4c5c-84c5-f73fd97f513d', N'Kris', N'Swarthout', N'male', N'1983-03-12 00:00:00', 2, 1, N'KrisSwarthout@library.com', 0, N'AAkfrVYbMCEKvvUKvggzIs+cicXUQ84l1NPQDqgDmClWYNNJhYlbLHmqfhYgskAaWw==', N'0a942ecb-1bac-40a2-9db8-d7736c755f52', NULL, 0, 0, NULL, 1, 0, N'KrisSwarthout@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c34f18fc-6b9c-41f5-9d00-e1abb46931ad', N'guest', N'guest', N'female', N'1990-01-01 00:00:00', 2, 2, N'guest@library.com', 0, N'AHUFfH4vQX75vmLlumICDSGkeYlytv932CqS7/8DcCkv22SqhJd7X039CbNe2FCKUg==', N'291ebe6d-2771-4631-9e9d-d20e4ed0addf', NULL, 0, 0, NULL, 1, 0, N'guest@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c3dba52c-7937-4df3-9a07-93215dca3e9c', N'Josefina', N'Riebel', N'Female', N'1980-06-04 00:00:00', 1, 3, N'JosefinaRiebel@library.com', 0, N'AHfPXQa/TylmS/XS8d4TGsZhvjXe1MueMQMJDN4Z6gAhikL1Sf163FELTDfUhBamkA==', N'ed48e42b-2ede-4d77-84de-0bc31e7d8faf', NULL, 0, 0, NULL, 1, 0, N'JosefinaRiebel@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd2f68248-e93c-43d0-ab6b-aa43ad0a6fd2', N'Aldo', N'Iacovelli', N'female', N'1979-02-05 00:00:00', 2, 1, N'AldoIacovelli@library.com', 0, N'AAvBDW04zc21d6hUN4k1rNrS7CsOPyNpM51SjnBPTaxY7fWaCoifCQWKh1eneDD2BA==', N'8b5bb30b-d2e7-4412-9edd-79a45785567f', NULL, 0, 0, NULL, 1, 0, N'AldoIacovelli@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd63db566-c9e1-4e88-859c-2569ae652564', N'Chantay', N'Blackwater', N'male', N'1984-07-07 00:00:00', 1, 1, N'ChantayBlackwater@library.com', 0, N'ALaKBaANNO4Q+YuSn5uYqhkPpeshmwwmT2DlvQMr8DmWilqXlF93WdjKmckPrRYadw==', N'bcb4bca7-576d-4bd8-8e0c-99f275e36b81', NULL, 0, 0, NULL, 1, 0, N'ChantayBlackwater@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dafa9647-2ab1-49d4-8438-21e50a3b717b', N'Clint', N'Nero', N'male', N'1980-12-02 00:00:00', 2, 8, N'ClintNero@library.com', 0, N'ALVqTDboGYI4gJs5eqZXY1gv1Q2C0NDpk2JIVlSeZS8k7zNFgEKb3T6a5vpZ6DLQVQ==', N'1138dfed-5b93-4361-a527-e2a4cb4fb1ef', NULL, 0, 0, NULL, 1, 0, N'ClintNero@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc8072de-4f6b-41f0-bfb3-6a9d6e899cb8', N'Chrystal', N'Kari', N'male', N'1996-03-05 00:00:00', 1, 9, N'ChrystalKari@library.com', 0, N'AP/OPnuc4DZ9bYqEm43hF+TxYtXb85+GEtKT65Q3otG+yRkmMguDixskMsTEK9Q/BQ==', N'62214218-f8f2-406e-a4a0-be327ea5a8d6', NULL, 0, 0, NULL, 1, 0, N'ChrystalKari@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dd005e61-674c-41af-8b18-f87bf3d6fe06', N'Yolanda', N'Rylander', N'female', N'1996-06-04 00:00:00', 2, 10, N'YolandaRylander@library.com', 0, N'AFaEYdnWGquVTJ2/l5Pmm/EaN2umvZteipOoFNyLrgCk8y7fjmcqn4enmcl3kO54RQ==', N'a65dc6da-6798-4d16-b028-2c7fdd658824', NULL, 0, 0, NULL, 1, 0, N'YolandaRylander@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ea32605b-0005-4d72-911f-a7362670f205', N'Louetta', N'Lachapelle', N'male', N'1969-04-12 00:00:00', 2, 12, N'LouettaLachapelle@library.com', 0, N'AKpFB71buRivWB009sc+/Bq+rG124Fw21g0E34GYYQTHppZV1JstJVhuOOWBBLug7g==', N'4c765c0f-a885-4c97-a4d9-e4fc56bd0ae9', NULL, 0, 0, NULL, 1, 0, N'LouettaLachapelle@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'eaf4776d-f0a9-4abd-bf12-013a235d8a97', N'Jaleesa', N'Polite', N'female', N'1987-01-04 00:00:00', 2, 11, N'JaleesaPolite@library.com', 0, N'AOre78uSQ44jhnsPoLvbGlkn8LhgLLiaO3dBrbyUCncEK5DEgffc4kJFNDbjffBoQQ==', N'15be2794-2545-4cfe-b195-2126966a022c', NULL, 0, 0, NULL, 1, 0, N'JaleesaPolite@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f3e8f596-67b2-45d6-8efd-2d3f3824642b', N'Juliette', N'Bosh', N'female', N'1993-05-09 00:00:00', 2, 1, N'JulietteBosh@library.com', 0, N'ACg7qOeq0vnxrpOslBPwFSLWhwIE/LJzupEpKhAUnS1DLiygCO1kctVAnn+kuIQvLQ==', N'2d250bb9-46e5-4053-8dc3-ece599f21fc5', NULL, 0, 0, NULL, 1, 0, N'JulietteBosh@library.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [fName], [lName], [gender], [birth], [membershipTypeID], [genreID], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ff774146-cf5c-453a-b17d-48965e43b28c', N'Velva', N'Collett', N'female', N'1996-02-12 00:00:00', 2, 3, N'VelvaCollett@library.com', 0, N'AJaD5JhFyS+m1xtA5ArIg59jyJ7NDP9D2nCmTqFfqMmpb1XkmGfk1LfRFH0LdJQBQA==', N'86c11ffb-2e9a-440c-adb2-cc50c5d64820', NULL, 0, 0, NULL, 1, 0, N'VelvaCollett@library.com')
            ");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Books", "genreID", "dbo.Genres");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Books", new[] { "genreID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rentals");
            DropTable("dbo.Books");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Genres");
            DropTable("dbo.Libraries");
        }
    }
}