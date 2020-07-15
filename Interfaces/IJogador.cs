using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces
{
    public interface IJogador
    {
        /// <summary>
        /// Cria uma linha na Database(csv)
        /// </summary>
        /// <param name="j"></param>
        void Create(Jogador j);
        /// <summary>
        /// Lê os dados da Database(csv)
        /// </summary>
        /// <returns>Retorna lista de jogadores</returns>
        List<Jogador> ReadAll();
        /// <summary>
        /// Atualiza uma linha na Database(csv)
        /// </summary>
        /// <param name="j"></param>
        void Update(Jogador j);
        /// <summary>
        /// Deletar uma linha da Database
        /// </summary>
        /// <param name="IdJogador"></param>
        void Delete(int IdJogador);
    }
}