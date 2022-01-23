using System;
using System.Collections.Generic;
using playlist.Interfaces;




namespace playlist
{
    public class playlistRepositorio : IRepositorio<playlist>
    {
        private List<playlist> listaplaylist = new List<playlist>(); 
        public void Atualiza(int id, playlist objeto)
        {
           listaplaylist[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaplaylist[id].Excluir();
        }

        public void Insere(playlist objeto)
        {
            listaplaylist.Add(objeto);
        }

        public List<playlist> Lista()
        {
           return listaplaylist;
        }

        public int ProximoId()
        {
            return listaplaylist.Count;
        }
        public playlist RetornaPorId(int id)
        {
            return listaplaylist[id];
        }
    }
}