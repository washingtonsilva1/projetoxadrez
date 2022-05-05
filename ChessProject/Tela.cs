using System;
using tabuleiro;
using xadrez;

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

        public static Posicao lerPosicaoXadrez(string s)
        {
            char col = s[0];
            int lin = int.Parse(s[1].ToString());
            return new PosicaoXadrez(col, lin).toPosicao();
        }

        private static void imprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.PRETO)
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
