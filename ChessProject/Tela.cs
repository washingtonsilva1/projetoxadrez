using System;
using tabuleiro;
using xadrez;

namespace ChessProject
{
    class Tela
    {
        public static void ImprimirPartida(PartidaXadrez px)
        {
            Console.Clear();
            ImprimirTabuleiro(px.Tabuleiro);
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirPecasCapturadas(px, Cor.BRANCO);
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirPecasCapturadas(px, Cor.PRETO);
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.WriteLine("Turno: " + px.Turno);
            Console.WriteLine("Jogador da vez: " + px.JogadorAtual);
            Console.WriteLine();
        }

        private static void ImprimirPecasCapturadas(PartidaXadrez px, Cor cor)
        {
            Console.Write("[ ");
            foreach(Peca p in px.PecasCapturadas(cor))
            {
                Console.Write(p + " ");
            }
            Console.WriteLine("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.GetPeca(i, j));
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h\n");
            Console.WriteLine();
            Console.WriteLine("===================");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, Peca p)
        {
            ConsoleColor original = Console.BackgroundColor;
            bool[,] possiveis = p.MovimentosPossiveis();
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (possiveis[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        ImprimirPeca(tab.GetPeca(i, j));
                        Console.BackgroundColor = original;
                    }
                    else
                        ImprimirPeca(tab.GetPeca(i, j));
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h\n");
            Console.WriteLine();
            Console.WriteLine("===================");
        }

        public static Posicao LerPosicaoXadrez(string s)
        {
            char col = s[0];
            int lin = int.Parse(s[1].ToString());
            return new PosicaoXadrez(col, lin).ToPosicao();
        }

        private static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
                Console.Write("- ");
            else
            {
                if (peca.Cor == Cor.PRETO)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                else
                    Console.Write(peca);
                Console.Write(" ");
            }
        }
    }
}
