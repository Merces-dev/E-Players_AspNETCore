
using System;
using System.Collections.Generic;
using System.IO;
using E_Players.Interfaces;
namespace E_Players.Models
{
    public class Noticias: EplayersBase, INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";
        /// <summary>
        /// Cria a Pasta ou o arquivo
        /// </summary>
        public Noticias(){
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Cria uma linha na Database(csv)
        /// </summary>
        /// <param name="n"></param>
        public void Create(Noticias n)
        {
            string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// Preparar linha na Database(csv)
        /// </summary>
        /// <param name="n"></param>
        /// <returns>retorna a forma padrão para a linha na Database(csv)</returns>
        private string PrepararLinha(Noticias n)
        {
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }
        /// <summary>
        /// Lê os dados da Database(csv)
        /// </summary>
        /// <returns>Retorna lista de notícias</returns>
        public List<Noticias> ReadAll()
        {
           List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];
                

                noticias.Add(noticia);
            }
            return noticias;
        }
        /// <summary>
        /// Atualiza uma linha na Database(csv)
        /// </summary>
        /// <param name="n"></param>
        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            linhas.Add(PrepararLinha(n));
            RewriteCSV(PATH, linhas);  
        }
        /// <summary>
        /// Deletar uma linha da Database
        /// </summary>
        /// <param name="IdNoticia"></param>
        public void Delete(int IdNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);        }
    }
}