using System;
using System.Collections.Generic;

namespace Test
{
    public class Jogo
    {
        public int IdJogo { get; set; }
        public int Placar { get; set; }
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
        public int MinRec { get; set; }
        public int MaxRec { get; set; }
    }


    public class Menu
    {
        public void renderizarMenu()
        {
            List<string> opcoesMenu = new List<string>();
            opcoesMenu.Add("Adicionar partida.");
            opcoesMenu.Add("Consultar partida.");
            opcoesMenu.Add("Consultar pontuacao máxima e mínima da temporada.");
            opcoesMenu.Add("Consultar recorde máximo e mínimo.");
            opcoesMenu.Add("Sair.");

            foreach (string opcao in opcoesMenu)
            {
                Console.WriteLine((opcoesMenu.IndexOf(opcao) + 1) + ". " + opcao);
            }
        }

        public void adicionarPartida()
        {
            Jogo novapartida = new Jogo();
            Console.WriteLine("\nDigite o numero da partida:");
            novapartida.IdJogo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nDigite o placar da partida:");
            novapartida.Placar = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nDigite o mínimo de pontos da temporada:");
            novapartida.MinTemp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nDigite o máximo de pontos da Temporada:");
            novapartida.MaxTemp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nDigite o recorde mínimo:");
            novapartida.MinRec = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nDigite o recorde máximo:");
            novapartida.MaxRec = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(novapartida);
            Console.WriteLine("\nConfirmar entrada de dado (S/N):");
            string confirmacao = Console.ReadLine();

            if (confirmacao.ToUpper() == "S")
            {
                Console.WriteLine("\nNovo jogo adicionado a Tabela\n");


            }
        }

        public void consultarPastida()
        {
            Jogo consulta = new Jogo();
            Console.ReadLine();
            Console.WriteLine(consulta.IdJogo);
        }

        public void mostrarTabela()
        {
            string linha;
            int contador = 0;

            List<Jogo> registro = new List<Jogo>();
            System.IO.StreamReader arqJogos = new System.IO.StreamReader(@"C:\Users\Felipe\Desktop\Test\Tabela.txt");

            while ((linha = arqJogos.ReadLine()) != null)
            {
                string[] dados = linha.Split(',');
                registro.Add(new Jogo
                {
                    IdJogo = Convert.ToInt32(dados[0]),
                    Placar = Convert.ToInt32(dados[1]),
                    MinTemp = Convert.ToInt32(dados[2]),
                    MaxTemp = Convert.ToInt32(dados[3]),
                    MinRec = Convert.ToInt32(dados[4]),
                    MaxRec = Convert.ToInt32(dados[5])
                });
                contador++;
            }

            arqJogos.Close();

            foreach (Jogo value in registro)
            {
                Console.WriteLine(value.IdJogo + " | " + value.Placar + " | " + value.MinTemp + " | " + value.MaxTemp + " | " + value.MinRec + " | " + value.MaxRec);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.renderizarMenu();

            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            if (cki.KeyChar == '1')
            {
                menu.adicionarPartida();
            }

            if (cki.KeyChar == '2')
            {
                menu.consultarPastida();
            }

            Console.ReadKey();
        }
    }
}
