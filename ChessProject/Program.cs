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
                PosicaoXadrez pos = new PosicaoXadrez('a', 1);
                Console.WriteLine(pos);
                Console.WriteLine(pos.toPosicao());
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