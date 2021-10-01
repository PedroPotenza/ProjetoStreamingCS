using System;
using System.Collections.Generic;

namespace ProjetoStreamingCS
{
    internal class Menu
    {
        private int opcao;
        //List<Item> items = new List<Item>();

        //items.Add(new Item("Cadastrar Cliente"));

        public void ShowMenu()
        {

            Console.WriteLine("---- Sistema Streaming ----\n");
            Console.WriteLine("  1 - Cadastrar Cliente");
            Console.WriteLine("  2 - Cadastrar Filme");
            Console.WriteLine("  3 - Cadastrar Plano Basico");
            Console.WriteLine("  4 - Cadastrar Plano Premium");
            Console.WriteLine("  5 - Cadastrar Contrato");
            Console.WriteLine("  6 - Carregar Filme");
            Console.WriteLine("  7 - Cancelar Contrato");
            Console.WriteLine("  8 - Gerar Fatura");
            Console.WriteLine("  9 - Lista os Dados de um dado Cliente");
            Console.WriteLine(" 10 - Listar o histórico de uma dado cliente");
            Console.WriteLine(" 11 - Listar clientes que excederam a cota mensal");
            Console.WriteLine(" 12 - Frequência de um dado filme");   

            ReadOption();

        }

        private void ReadOption()
        {

            Console.Write("\nOpção: ");
            opcao = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch(opcao)
            {
                case 1:
                    Console.WriteLine("---- Cadastrar Cliente ----");
                    Console.WriteLine("Opção 1 selecionada\n");
                    
                break;

                case 2:
                    Console.WriteLine("---- Cadastrar Filme ----");
                    Console.WriteLine("Opção 2 selecionada\n");
                break;

                case 3:
                    Console.WriteLine("---- Cadastrar Plano Básico ----");
                    Console.WriteLine("Opção 3 selecionada\n");
                break;

                case 4:
                    Console.WriteLine("---- Cadastrar Plano Premium ----");
                    Console.WriteLine("Opção 4 selecionada\n");
                break;

                case 5:
                    Console.WriteLine("---- Cadastrar Contrato ----");
                    Console.WriteLine("Opção 5 selecionada\n");
                break;

                case 6:
                    Console.WriteLine("---- Carregar Filme ----");
                    Console.WriteLine("Opção 6 selecionada\n");
                break;

                case 7:
                    Console.WriteLine("---- Cancelar Contrato ----");
                    Console.WriteLine("Opção 7 selecionada\n");
                break;

                case 8:
                    Console.WriteLine("---- Gerar Fatura ----");
                    Console.WriteLine("Opção 8 selecionada\n");
                break;

                case 9:
                    Console.WriteLine("---- Informação do Cliente ----");
                    Console.WriteLine("Opção 9 selecionada\n");
                break;

                case 10:
                    Console.WriteLine("---- Historico do Cliente ----");
                    Console.WriteLine("Opção 10 selecionada\n");
                break;

                case 11:
                    Console.WriteLine("---- Clientes Excedentes ----");
                    Console.WriteLine("Opção 11 selecionada\n");
                break;

                case 12:
                    Console.WriteLine("---- Frequencia de um Filme ----");
                    Console.WriteLine("Opção 12 selecionada\n");
                break;

                case 0:
                    Console.WriteLine("Finalizando Sistema...\n");
                    Console.WriteLine("Pressione qualquer tecla para encerrar.");
                    Console.ReadKey(false);
                    Console.Clear();
                    Environment.Exit(1);
                break;

                default: 
                    Console.WriteLine("Opção inválida!\n");
                break;
            }
        }
    }
}