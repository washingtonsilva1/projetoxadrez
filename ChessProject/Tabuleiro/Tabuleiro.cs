using System;

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

        public Peca getPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca getPeca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
                throw new TabuleiroException("Já existe uma peça nesta posição.");
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (!existePeca(pos))
                return null;
            Peca peca = getPeca(pos);
            peca.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return peca;
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return getPeca(pos) != null;
        }

        public bool posicaoValidar(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
                return false;
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValidar(pos))
                throw new TabuleiroException("Posição inválida.");
        }
    }
}
