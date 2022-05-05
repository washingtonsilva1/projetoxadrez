using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei()
        {
        }

        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] possiveis = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);
            // Cima
            pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            // Esquerda
            pos.MudarValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            // Direita
            pos.MudarValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            // Baixo
            pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            return possiveis;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
