namespace tabuleiro
{
    abstract class Peca
    {
        public Cor Cor { get; protected set; }
        public int QtdMovimento { get; protected set; } = 0;
        public Posicao Posicao { get; set; } = null;
        public Tabuleiro Tab { get; set; }

        public Peca()
        {
        }

        public Peca(Cor cor, Tabuleiro tab)
        {
            Cor = cor;
            Tab = tab;
        }

        public abstract bool[,] MovimentosPossiveis();

        public void IncrementarMovimento()
        {
            QtdMovimento++;
        }

        private protected bool PodeMover(Posicao pos)
        {
            return Tab.ExistePeca(pos) == false || Tab.GetPeca(pos).Cor != Cor;
        }
    }
}
