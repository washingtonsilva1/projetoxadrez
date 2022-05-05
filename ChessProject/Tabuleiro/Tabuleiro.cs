﻿using System;

namespace tabuleiro
{
    class Tabuleiro
    {
        public Peca[,] Pecas { get; private set; }
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        public Tabuleiro()
        {
        }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca GetPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca GetPeca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
                throw new TabuleiroException("Já existe uma peça nesta posição.");
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (!ExistePeca(pos))
                return null;
            Peca peca = GetPeca(pos);
            peca.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return peca;
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return GetPeca(pos) != null;
        }

        public bool PosicaoValidar(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
                return false;
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValidar(pos))
                throw new TabuleiroException("Posição inválida.");
        }
    }
}
