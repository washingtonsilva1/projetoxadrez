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
            iniciarPecas();
        }

        public void movimentarPeca(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.retirarPeca(origem);
            p.incrementarMovimento();
            Peca pecaCapturada = Tabuleiro.retirarPeca(destino);
            Tabuleiro.colocarPeca(p, destino);
        }

        public void iniciarPecas()
        {
            Tabuleiro.colocarPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('c', 8).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('c', 7).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('d', 7).toPosicao());
            Tabuleiro.colocarPeca(new Rei(Cor.PRETO, Tabuleiro), new PosicaoXadrez('d', 8).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('e', 7).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('e', 8).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('c', 2).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('c', 1).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('d', 2).toPosicao());
            Tabuleiro.colocarPeca(new Rei(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('d', 1).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('e', 1).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('e', 2).toPosicao());
        }
    }
}
