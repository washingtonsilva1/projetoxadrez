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

        private void MovimentarPeca(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarMovimento();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
        }

        private void MudarJogador()
        {
            if (JogadorAtual == Cor.BRANCO)
                JogadorAtual = Cor.PRETO;
            else
                JogadorAtual = Cor.BRANCO;
        }

        public void ValidarOrigem(Posicao origem)
        {
            if (Tabuleiro.GetPeca(origem) == null)
                throw new TabuleiroException("Não existe uma peça na posição de origem!");
            if (Tabuleiro.GetPeca(origem).Cor != JogadorAtual)
                throw new TabuleiroException("Somente podem se mover as peças: " + JogadorAtual + ".");
            if (!Tabuleiro.GetPeca(origem).ExisteMovimentoPossivel())
                throw new TabuleiroException("Esta peça não pode se mover!");
        }

        public void ValidarDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.GetPeca(origem).PodeMoverPara(destino))
                throw new TabuleiroException("Essa peça não pode se mover para esta posição!");
        }

        public void RealizarMovimento(Posicao origem, Posicao destino)
        {
            MovimentarPeca(origem, destino);
            MudarJogador();
            Turno++;
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
