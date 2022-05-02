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
                tab.colocarPeca(new Torre(Cor.BRANCO, tab), new Posicao(0, 0));
                tab.colocarPeca(new Torre(Cor.BRANCO, tab), new Posicao(1, 3));
                tab.colocarPeca(new Rei(Cor.BRANCO, tab), new Posicao(0, 0));
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
