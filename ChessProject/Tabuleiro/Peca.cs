namespace tabuleiro
{
    class Peca
    {
        public Cor Cor { get; protected set; }
        public int QtdMovimento { get; protected set; } = 0;
        public Posicao Posicao { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca()
        {
        }

        public Peca(Cor cor, Posicao posicao, Tabuleiro tab)
        {
            Cor = cor;
            Posicao = posicao;
            Tab = tab;
        }
    }
}
