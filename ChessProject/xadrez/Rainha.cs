using tabuleiro;

namespace xadrez
{
    class Rainha : Peca
    {
        public Rainha()
        {
        }

        public Rainha(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] possiveis = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);
            // Cima
            pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                possiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                    break;
                pos.Linha--;
            }
            // Baixo
            pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                possiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                    break;
                pos.Linha++;
            }
            // Esquerda
            pos.MudarValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                possiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                    break;
                pos.Coluna--;
            }
            // Direita
            pos.MudarValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                possiveis[pos.Linha, pos.Coluna] = true;
                if (Tab.GetPeca(pos) != null && Tab.GetPeca(pos).Cor != Cor)
                    break;
                pos.Coluna++;
            }
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
