using System;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; } = new Tabuleiro(8, 8);
        public int Turno { get; private set; } = 1;
        public Cor JogadorAtual { get; private set; } = Cor.BRANCO;
        public bool PartidaTerminada { get; private set; } = false;

        public PartidaXadrez()
        {
            IniciarPecas();
        }

        public void MovimentarPeca(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.ExistePeca(origem))
                throw new TabuleiroException("Não existe uma peça nesta posição!");
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarMovimento();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
        }

        public void IniciarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.PRETO, Tabuleiro), new PosicaoXadrez('d', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('e', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('e', 2).ToPosicao());
        }
    }
}
