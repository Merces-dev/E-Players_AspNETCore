using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces
{
    public interface INoticias
    {
        void Create(Noticias e);
        List<Noticias> ReadAll();
        void Update(Noticias e);
        void Delete(int IdNoticia);   
    }
}