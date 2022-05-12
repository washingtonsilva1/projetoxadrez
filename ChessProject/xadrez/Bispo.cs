using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo()
        {
        }

        public Bispo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] possiveis = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);
            //Superior esquerdo
            pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                possiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                    break;
                pos.Linha--;
                pos.Coluna--;
            }
            //Superior direito
            pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                possiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                    break;
                pos.Linha--;
                pos.Coluna++;
            }
            //Inferior Esquerdo
            pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                possiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                    break;
                pos.Linha++;
                pos.Coluna--;
            }
            //Inferior Direito
            pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                possiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                    break;
                pos.Linha++;
                pos.Coluna++;
            }
            return possiveis;
        }
    }
}
