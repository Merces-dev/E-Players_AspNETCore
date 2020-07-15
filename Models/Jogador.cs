using System;
using System.Collections.Generic;
using System.IO;
using E_Players.Interfaces;

namespace E_Players.Models
{
    public class Jogador : EplayersBase, IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }

        private const string PATH = "Database/jogador.csv";
        /// <summary>
        /// Cria pasta e/ou arquivo
        /// </summary>
        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Cria uma linha na Database(csv)
        /// </summary>
        /// <param name="j"></param>
        public void Create(Jogador j)
        {
            string[] linha = { PrepararLinha(j) };
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// Preparar linha na Database(csv)
        /// </summary>
        /// <param name="j"></param>
        /// <returns>retorna a forma padrão para a linha na Database(csv)</returns>
        private string PrepararLinha(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe}";
        }
        /// <summary>
        /// Deletar uma linha da Database
        /// </summary>
        /// <param name="IdJogador"></param>
        public void Delete(int IdJogador)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdJogador.ToString());
            RewriteCSV(PATH,linhas);
        }
        /// <summary>
        /// Lê os dados da Database(csv)
        /// </summary>
        /// <returns>Retorna lista de jogadores</returns>
        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jogador = new Jogador();
                jogador.IdJogador = Int32.Parse(linha[0]);
                jogador.Nome = linha[1];
                jogador.IdEquipe = Int32.Parse(linha[2]);
                jogadores.Add(jogador);
                
            }
            return jogadores;
        }
        /// <summary>
        /// Atualiza uma linha na Database(csv)
        /// </summary>
        /// <param name="j"></param>
        public void Update(Jogador j)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdJogador.ToString());
            linhas.Add(PrepararLinha(j));
            RewriteCSV(PATH,linhas);

        }
    }
}