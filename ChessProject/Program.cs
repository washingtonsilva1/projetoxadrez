using System;
using tabuleiro;
using xadrez;

namespace ChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaXadrez px = new PartidaXadrez();
                while(!px.PartidaTerminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(px.Tabuleiro);
                    Console.WriteLine("================================\n");
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez(Console.ReadLine());
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez(Console.ReadLine());
                    px.movimentarPeca(origem, destino);
                }
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine("Error de tabuleiro: " + e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}