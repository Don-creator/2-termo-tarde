USE Filmes_tardes;
GO

INSERT INTO Generos	(Nome)
VALUES				('Ação')
					,('Drama');
GO

INSERT INTO Filmes	(Titulo, IdGenero)
VALUES				('A vida é bela', 2)
					,('Rambo', 1);
GO