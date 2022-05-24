using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez _partidaXadrez;
        public Rei()
        {
        }

        public Rei(Cor cor, Tabuleiro tab, PartidaXadrez px) : base(cor, tab)
        {
            _partidaXadrez = px;
        }

        private bool TesteRoque(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p != null && p is Torre && p.QtdMovimento == 0 & p.Cor == Cor;
        }

        private bool ExistePeca(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p != null;
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

            // Jogada especial Roque
            if (QtdMovimento == 0 && !_partidaXadrez.Xeque)
            {
                // Roque Menor
                Posicao pos_roque = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteRoque(pos_roque))
                {
                    Posicao pos_r1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao pos_r2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (!ExistePeca(pos_r1) && !ExistePeca(pos_r2))
                        possiveis[pos_r2.Linha, pos_r2.Coluna] = true;
                }

                // Roque Maior
                pos_roque.MudarValores(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteRoque(pos_roque))
                {
                    Posicao pos_r1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao pos_r2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao pos_r3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (!ExistePeca(pos_r1) && !ExistePeca(pos_r2) && !ExistePeca(pos_r3))
                        possiveis[pos_r2.Linha, pos_r2.Coluna] = true;
                }

            }
            return possiveis;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
