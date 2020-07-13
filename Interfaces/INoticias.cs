using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces
{
    public interface INoticias
    {
        /// <summary>
        /// Cria uma linha na Database(csv)
        /// </summary>
        /// <param name="n"></param>
        void Create(Noticias e);
        /// <summary>
        /// Lê os dados da Database(csv)
        /// </summary>
        /// <returns>Retorna lista de notícias</returns>
        List<Noticias> ReadAll();
        /// <summary>
        /// Atualiza uma linha na Database(csv)
        /// </summary>
        /// <param name="n"></param>
        void Update(Noticias e);
        /// <summary>
        /// Deletar uma linha da Database
        /// </summary>
        /// <param name="IdNoticia"></param>
        void Delete(int IdNoticia);   
    }
}