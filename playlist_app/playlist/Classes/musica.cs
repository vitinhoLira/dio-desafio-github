using System;

namespace playlist
{
    public class playlist : EntidadeBase
    {
        //Atributos
        private Genero Genero {get; set; }
        private string Titulo {get; set; }
        private string Compositor {get; set; }
        private int anoLancamento {get; set; }
         private bool Excluido {get; set;}

        //Metodos
        public playlist(int id, Genero genero, string titulo, string compositor, int anoLancamento) 
        {  
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Compositor = compositor;
            this.anoLancamento = anoLancamento; 
            this.Excluido = false;
                  
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição da banda: " + this.Compositor + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.anoLancamento + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno; 
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
         public int retornaId()
        {
             return this.Id;
        }
         public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir()
        {
            this.Excluido = true;
        }
    }

}          
          
