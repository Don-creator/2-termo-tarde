USE Gufi_Tarde;

SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;
SELECT * FROM TipoEvento;
SELECT * FROM Evento;
SELECT * FROM Presenca;

-- DQL Linguagem de consu~ltas de dados

SELECT NomeUsuario, Email, IdTipoUsuario, DataNascimento, Genero 
FROM Usuario;

SELECT CNPJ, NomeFantasia, Endereco 
FROM Instituicao;

SELECT TituloTipoEvento 
FROM TipoEvento;


SELECT Usuario.NomeUsuario, Usuario.Email, Evento.NomeEvento, TipoEvento.TituloTipoEvento, Evento.DataEvento, Evento.AcessoLivre as PublicoPrivado, Evento.Descricao, Instituicao.NomeFantasia, Instituicao.Endereco, Instituicao.CNPJ
FROM Evento INNER JOIN Presenca ON Presenca.IdEvento = Evento.IdEvento 
INNER JOIN TipoEvento ON TipoEvento.IdTipoEvento = Evento.IdTipoEvento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
INNER JOIN Usuario ON Usuario.IdUsuario = Presenca.IdUsuario
WHERE Usuario.IdUsuario = 4 AND Evento.AcessoLivre = 1
























