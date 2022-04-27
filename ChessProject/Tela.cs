using System;
using tabuleiro;

namespace ChessProject
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.getPeca(i, j) != null)
                        Console.Write("P ");
                    else
                        Console.Write("- ");
                }
                Console.WriteLine();
            }
        }
    }
}
