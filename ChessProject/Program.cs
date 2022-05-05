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
                while (!px.PartidaTerminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(px.Tabuleiro);
                    Console.WriteLine("===================");
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez(Console.ReadLine());
                    Console.Clear();
                    Tela.ImprimirTabuleiro(px.Tabuleiro, px.Tabuleiro.GetPeca(origem));
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez(Console.ReadLine());
                    px.MovimentarPeca(origem, destino);
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine("Erro de tabuleiro: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro inesperado: " + e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}