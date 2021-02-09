using System;
using System.Linq;
using DIO.Series.Classes;
using DIO.Series.Enum;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("\n\nObrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("\nVisuakizar séries\n\n");

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("\nExcluir séries\n\n");

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("\nAtualizar séries\n\n");

            Console.Write("Digite id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(EGenero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(EGenero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizacaoSerie = new Serie(
                indiceSerie,
                (EGenero)entradaGenero, 
                entradaTitulo, 
                entradaDescricao, 
                entradaAno
            );

            repositorio.Atualizar(indiceSerie, atualizacaoSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("\nInserir nova séries\n\n");
            
            foreach (int i in System.Enum.GetValues(typeof(EGenero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(EGenero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                repositorio.ProximoId(), 
                (EGenero)entradaGenero, 
                entradaTitulo, 
                entradaDescricao, 
                entradaAno
            );

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("\nListar séries\n\n");

            var lista = repositorio.Lista();

            if(lista.Count() == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var item in lista)
            {
                if(!item.RetornarExcluido())
                    Console.WriteLine("#ID {0}: {1}", item.RetornarId(), item.RetornarTitulo());
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\nDIO Séries a seu dispor!!!\n\n");
            Console.WriteLine("Informe a opção desejada: \n");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar séries");
            Console.WriteLine("4 - Excluir séries");
            Console.WriteLine("5 - Visualizar séries");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair\n");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
