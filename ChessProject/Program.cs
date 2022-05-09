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
                    try
                    {
                        Tela.ImprimirPartida(px);
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez(Console.ReadLine());
                        px.ValidarOrigem(origem);
                        Console.Clear();
                        Tela.ImprimirTabuleiro(px.Tabuleiro, px.Tabuleiro.GetPeca(origem));
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez(Console.ReadLine());
                        px.ValidarDestino(origem, destino);
                        px.RealizarMovimento(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
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