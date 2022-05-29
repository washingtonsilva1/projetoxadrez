namespace tabuleiro
{
    abstract class Peca
    {
        public Cor Cor { get; protected set; }
        public int QtdMovimento { get; protected set; } = 0;
        public Posicao Posicao { get; set; } = null;
        public Tabuleiro Tab { get; protected set; }

        public Peca()
        {
        }

        public Peca(Cor cor, Tabuleiro tab)
        {
            Cor = cor;
            Tab = tab;
        }

        private protected bool PodeMover(Posicao pos)
        {
            return Tab.ExistePeca(pos) == false || Tab.GetPeca(pos).Cor != Cor;
        }

        public void IncrementarMovimento()
        {
            QtdMovimento++;
        }

        public void DecrementarMovimento()
        {
            QtdMovimento--;
        }

        public bool ExisteMovimentoPossivel()
        {
            bool[,] mat = MovimentosPossiveis();
            foreach(bool a in mat)
            {
                if (a)
                    return true;
            }
            return false;
        }

        public bool PossivelMover(Posicao pos)
        {
            bool[,] movPos = MovimentosPossiveis();
            if (movPos[pos.Linha, pos.Coluna])
                return true;
            return false;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
