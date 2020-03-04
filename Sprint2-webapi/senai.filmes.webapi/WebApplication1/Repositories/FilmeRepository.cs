using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace senai.Filmes.WebApi.Repositories
{
    /// <summary>
    /// Repositório dos genero
    /// </summary>
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source - Nome do Servidor
        /// initial catalog - Nome do Banco de Dados
        /// integrated security=true - Faz a autenticação com o usuário do sistema
        /// user Id=sa; pwd=sa@132 - Faz a autenticação com um usuário específico, passando o logon e a senha
        /// </summary>
        //private string StringConexao = "Data Source=DESKTOP-NJ6LHN1\\SQLDEVELOPER; initial catalog=filme; integrated security=true;";
        private string stringConexao = "Data Source=DEV201\\SQLEXPRESS; initial catalog=Filmes_tardes; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Atualiza um filme passando o ID pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto filme que será atualizado</param>
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Filmes SET Titulo = @Titulo WHERE IdFilme = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", filme.IdFilme);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);


                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um filme passando o id pelo recurso
        /// </summary>
        /// <param name="id">ID do filme que será atualizado</param>
        /// <param name="filme">Objeto filme que será atualizado</param>
        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE genero SET Nome = @Nome WHERE Idgenero = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", filme.Titulo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um filme pelo ID
        /// </summary>
        /// <param name="id">ID do filme que será buscado</param>
        /// <returns>Retorna um filme buscado ou null caso não seja encontrado</returns>
        public FilmeDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdFilme, Titulo FROM Filmes WHERE IdFilme = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Caso a o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Cria um objeto genero
                        FilmeDomain filmeBuscado = new FilmeDomain
                        {
                            // Atribui à propriedade Idfilme o valor da coluna "Idfilme" da tabela do banco
                            IdFilme = Convert.ToInt32(rdr["IdFilme"])

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            ,
                            Titulo = rdr["Titulo"].ToString()
                        };

                        // Retorna o filme com os dados obtidos
                        return filmeBuscado;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="filme">Objeto genero que será cadastrado</param>
        public void Cadastrar(FilmeDomain filme)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                // string queryInsert = "INSERT INTO filme(Nome) VALUES ('" + filme.Nome + "')";
                // Não usar dessa forma pois pode causar o efeito Joana D'arc
                // Além de permitir SQL Injection
                // Por exemplo
                // "nome" : "')DROP TABLE filme--'"
                // Ao tentar cadastrar o comando acima, irá deletar a tabela generos do banco de dados
                // https://www.devmedia.com.br/sql-injection/6102

                // Declara a query que será executada passando o valor como parâmetro, evitando assim os problemas acima
                string queryInsert = "INSERT INTO Filmes(Titulo) VALUES (@Titulo)";

                // Declara o comando passando a query e a conexão
                SqlCommand cmd = new SqlCommand(queryInsert, con);

                // Passa o valor do parâmetro
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                // Abre a conexão com o banco de dados
                con.Open();

                // Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deleta um filme através do seu ID
        /// </summary>
        /// <param name="id">ID do filme que será deletado</param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM generos WHERE Idgenero = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os filme
        /// </summary>
        /// <returns>Retorna uma lista de filme</returns>
        public List<FilmeDomain> Listar()
        {
            // Cria uma lista filme onde serão armazenados os dados
            List<FilmeDomain> filme = new List<FilmeDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFilme, Titulo from Filmes";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {
                        // Cria um objeto genero do tipo GeneroDomain
                        FilmeDomain Filme = new FilmeDomain
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            IdFilme = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Titulo = rdr["Titulo"].ToString()
                        };

                        // Adiciona o genero criado à tabela filme
                        filme.Add(Filme);
                    }
                }
            }

            // Retorna a lista de generos
            return filme;
        }
    }
}