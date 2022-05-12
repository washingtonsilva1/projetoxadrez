using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao()
        {
        }

        public Peao(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
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
                if(!ExistePeca(pos))
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
            }
            return possiveis;
        }
    }
}
