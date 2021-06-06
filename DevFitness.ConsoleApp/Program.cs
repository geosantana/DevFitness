using System;
using System.Collections.Generic;

namespace DevFitness.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ExibirOpcoes();
            var opcao = Console.ReadLine();
            //switch (opcao)
            //{
            //    case "1":
            //        console.writeline();
            //    default:
            //        break;
            //}
            Console.WriteLine("Fechando o app.");
        }

        public static void ExibirOpcoes()
        {
            Console.WriteLine("-------Seja bem-vindo(a) ao DevFitness----");
            Console.WriteLine("1 - Exibir detalhes de usuário.");
            Console.WriteLine("2 - Cadastrar uma nova refeição.");
            Console.WriteLine("3 - Listar todas as refeições.");
        }

        public static void Cadastrar(List<Refeicao> refeicoes)
        {

        }
    }
}
