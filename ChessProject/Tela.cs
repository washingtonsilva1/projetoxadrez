﻿using System;
using tabuleiro;
using xadrez;

namespace ChessProject
{
    class Tela
    {
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

        public static void ImprimirPartida(PartidaXadrez px)
        {
            Console.Clear();
            ImprimirTabuleiro(px.Tabuleiro);
            ConsoleColor aux = Console.ForegroundColor;
            if (!px.PartidaTerminada)
            {
                if (px.Xeque)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("XEQUE!");
                    Console.ForegroundColor = aux;
                    Console.WriteLine();
                }
                Console.WriteLine("Peças capturadas:");
                Console.Write("Brancas: ");
                ImprimirPecasCapturadas(px, Cor.BRANCO);
                Console.Write("Pretas: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                ImprimirPecasCapturadas(px, Cor.PRETO);
                Console.ForegroundColor = aux;
                Console.WriteLine();
                Console.WriteLine("Turno: " + px.Turno);
                Console.WriteLine("Jogador da vez: " + px.JogadorAtual);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine();
                Console.ForegroundColor = aux;
                Console.WriteLine("Vencedor: " + px.JogadorAtual);
            }
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
            ConsoleColor aux = Console.ForegroundColor;
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write((8 - i) + " ");
                Console.ForegroundColor = aux;
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.GetPeca(i, j));
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  a b c d e f g h\n");
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.WriteLine("===================");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, Peca p)
        {
            ConsoleColor original = Console.BackgroundColor;
            ConsoleColor aux = Console.ForegroundColor;
            bool[,] possiveis = p.MovimentosPossiveis();
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write((8 - i) + " ");
                Console.ForegroundColor = aux;
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  a b c d e f g h\n");
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.WriteLine("===================");
        }

        public static Posicao LerPosicaoXadrez(string s)
        {
            char col = s[0];
            int lin = int.Parse(s[1].ToString());
            return new PosicaoXadrez(col, lin).ToPosicao();
        }
    }
}
