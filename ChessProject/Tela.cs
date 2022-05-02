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
                Console.Write((8 - i) + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.getPeca(i, j) != null)
                    {
                        imprimirPeca(tab.getPeca(i, j));
                        Console.Write(" ");
                    }
                    else
                        Console.Write("- ");
                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H");
            Console.WriteLine();
        }

        private static void imprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.BRANCO)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else
            {
                Console.Write(peca);
            }
        }
    }
}
