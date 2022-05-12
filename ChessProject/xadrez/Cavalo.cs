using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo()
        {
        }

        public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] possiveis = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);
            //Frente
            pos.MudarValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            //Baixo
            pos.MudarValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValidar(pos) && PodeMover(pos))
                possiveis[pos.Linha, pos.Coluna] = true;
            return possiveis;
        }
    }
}
