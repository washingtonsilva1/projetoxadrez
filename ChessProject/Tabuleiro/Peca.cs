namespace tabuleiro
{
    class Peca
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

        public void incrementarMovimento()
        {
            QtdMovimento++;
        }
    }
}
