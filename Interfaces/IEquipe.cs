using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces
{
    public interface IEquipe
    {
        /// <summary>
        /// Cria uma linha na Database(csv)
        /// </summary>
        /// <param name="e"></param>
        void Create(Equipe e);
        /// <summary>
        /// Lê os dados da Database(csv)
        /// </summary>
        /// <returns>Retorna lista de equipes</returns>
        List<Equipe> ReadAll();
        /// <summary>
        /// Atualiza uma linha na Database(csv)
        /// </summary>
        /// <param name="e"></param>
        void Update(Equipe e);
        /// <summary>
        /// Deletar uma linha da Database
        /// </summary>
        /// <param name="IdEquipe"></param>
        void Delete(int IdEquipe);
    }
}