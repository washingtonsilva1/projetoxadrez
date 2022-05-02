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
                Tabuleiro tab = new Tabuleiro(8, 8);
                Peca torre = new Torre(Cor.BRANCO, tab);
                tab.colocarPeca(torre, new Posicao(0, 0));
                Tela.imprimirTabuleiro(tab);
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