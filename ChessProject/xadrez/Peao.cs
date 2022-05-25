using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaXadrez _partidaXadrez;
        public Peao()
        {
        }

        public Peao(Cor cor, Tabuleiro tab, PartidaXadrez partidaXadrez) : base(cor, tab)
        {
            _partidaXadrez = partidaXadrez;
        }

        private bool ExistePeca(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p != null;
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.GetPeca(pos);
            return p != null && p.Cor != Cor;
        }

        public override string ToString()
        {
            return "P";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] possiveis = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);
            if (Cor == Cor.BRANCO)
            {
                pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValidar(pos) && !ExistePeca(pos))
                    possiveis[pos.Linha, pos.Coluna] = true;
                if (!ExistePeca(pos))
                {
                    pos.MudarValores(Posicao.Linha - 2, Posicao.Coluna);
                    if (Tab.PosicaoValidar(pos) && !ExistePeca(pos) && QtdMovimento == 0)
                        possiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValidar(pos) && ExisteInimigo(pos))
                    possiveis[pos.Linha, pos.Coluna] = true;
                pos.MudarValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValidar(pos) && ExisteInimigo(pos))
                    possiveis[pos.Linha, pos.Coluna] = true;

                // Jogada especial En passant
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValidar(esquerda) && ExisteInimigo(esquerda) &&
                        Tab.GetPeca(esquerda) == _partidaXadrez.VulneravelEnPassant)
                    {
                        possiveis[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    if (Tab.PosicaoValidar(direita) && ExisteInimigo(direita) &&
                        Tab.GetPeca(direita) == _partidaXadrez.VulneravelEnPassant)
                    {
                        possiveis[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            if (Cor == Cor.PRETO)
            {
                pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValidar(pos) && !ExistePeca(pos))
                    possiveis[pos.Linha, pos.Coluna] = true;
                if (!ExistePeca(pos))
                {
                    pos.MudarValores(Posicao.Linha + 2, Posicao.Coluna);
                    if (Tab.PosicaoValidar(pos) && !ExistePeca(pos) && QtdMovimento == 0)
                        possiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValidar(pos) && ExisteInimigo(pos))
                    possiveis[pos.Linha, pos.Coluna] = true;
                pos.MudarValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValidar(pos) && ExisteInimigo(pos))
                    possiveis[pos.Linha, pos.Coluna] = true;

                // Jogada especial En passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValidar(esquerda) && ExisteInimigo(esquerda) &&
                        Tab.GetPeca(esquerda) == _partidaXadrez.VulneravelEnPassant)
                    {
                        possiveis[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    if (Tab.PosicaoValidar(direita) && ExisteInimigo(direita) &&
                        Tab.GetPeca(direita) == _partidaXadrez.VulneravelEnPassant)
                    {
                        possiveis[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }
            return possiveis;
        }
    }
}
