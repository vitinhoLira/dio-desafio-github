// See https://aka.ms/new-console-template for more information
using System;

namespace playlist
{
    class Program
    {
        static playlistRepositorio repositorio = new playlistRepositorio();
        static void Main(string[] args)
        {   
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
						ListarPlayList();
						break;
					case "2":
						InserirPlayList();
						break;
					case "3":
						AtualizarPlayList();
						break;
					case "4":
						ExcluirPlayList();
						break;
					case "5":
						VisualizarPlayList();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços. ");
            Console.ReadLine(); 
        }  

        private static void ExcluirPlayList()
        {
            Console.Write("Digite o id da playlist: ");
            int indicePLaylist = Convert.ToInt32(Console.ReadLine());
            
            repositorio.Exclui(indicePLaylist);
        }

        private static void VisualizarPlayList()
        {
            Console.Write("Digite o id da Playlist: ");
            int indicePlaylist = Convert.ToInt32(Console.ReadLine());

            var playlist = repositorio.RetornaPorId(indicePlaylist);

            Console.WriteLine(playlist);
        }   

        private static void AtualizarPlayList()
        {   
            Console.Write("Digite o id da Playlist: ");
            int indicePLaylist = Convert.ToInt32(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-1", i,Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o Título da Música: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da Música: ");
            int entradaAno = Convert.ToInt32(Console.ReadLine()); 

            Console.Write("Digite o Compositor da Música: ");
			string entradaCompositor = Console.ReadLine();

			playlist atualizaPlaylist = new playlist(id: indicePLaylist, genero: (Genero)entradaGenero, titulo: entradaTitulo, anoLancamento: entradaAno, compositor: entradaCompositor);
										

			repositorio.Atualiza(indicePLaylist, atualizaPlaylist);
		}

        private static void ListarPlayList()
		{
			Console.WriteLine("Listar Playlist: ");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Playlist cadastrada.");
				return;
            }

            foreach (var playlist in lista)
            {
                var excluido = playlist.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", playlist.retornaId(), playlist.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirPlayList()
        {
            Console.WriteLine("Inserir nova Playlist: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o Título da Playlist: ");
			string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Banda: ");
			int entradaAno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a Descrição da Banda: ");
			string entradaCompositor = Console.ReadLine();

            playlist novaPlaylist = new playlist(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, anoLancamento: entradaAno, compositor: entradaCompositor);

            repositorio.Insere(novaPlaylist);    
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
			Console.WriteLine("DIO Playlist a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Playlist");
			Console.WriteLine("2- Inserir nova Playlist");
			Console.WriteLine("3- Atualizar Playlist");
			Console.WriteLine("4- Excluir Playlist");
			Console.WriteLine("5- Visualizar Playlist");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
        }
    }
}
