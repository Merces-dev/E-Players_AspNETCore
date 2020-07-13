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

        public Noticias(){
            CreateFolderAndFile(PATH);
        }
        public void Create(Noticias n)
        {
            string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }
        private string PrepararLinha(Noticias n)
        {
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        public List<Noticias> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            linhas.Add(PrepararLinha(n));
            RewriteCSV(PATH, linhas);  
        }

        public void Delete(int IdNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);        }
    }
}