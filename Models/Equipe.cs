using System;
using System.Collections.Generic;
using System.IO;
using E_Players.Interfaces;

namespace E_Players.Models
{
    public class Equipe : EplayersBase, IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/equipe.csv";
        /// <summary>
        /// Cria a Pasta ou o arquivo
        /// </summary>
        public Equipe(){
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Preparar linha na Database(csv)
        /// </summary>
        /// <param name="e"></param>
        /// <returns>retorna a forma padrão para a linha na Database(csv)</returns>
        private string PrepararLinha(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
        /// <summary>
        /// Cria uma linha na Database(csv)
        /// </summary>
        /// <param name="e"></param>
        public void Create(Equipe e)
        {
            string[] linhas = { PrepararLinha(e) };
            File.AppendAllLines(PATH, linhas);
        }

        /// <summary>
        /// Deletar uma linha da Database
        /// </summary>
        /// <param name="IdEquipe"></param>
        public void Delete(int IdEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }
        /// <summary>
        /// Lê os dados da Database(csv)
        /// </summary>
        /// <returns>Retorna lista de equipes</returns>
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
        /// <summary>
        /// Atualiza uma linha na Database(csv)
        /// </summary>
        /// <param name="e"></param>
        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(PrepararLinha(e));
            RewriteCSV(PATH, linhas);
        }
    }
}