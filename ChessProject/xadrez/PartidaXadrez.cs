using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        private List<Peca> _pecasEmJogo = new List<Peca>();
        private List<Peca> _pecasCapturadas = new List<Peca>();
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
            if (pecaCapturada != null)
            {
                _pecasEmJogo.Remove(_pecasEmJogo.Find(p => p == pecaCapturada));
                _pecasCapturadas.Add(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(p, destino);
        }

        private void MudarJogador()
        {
            if (JogadorAtual == Cor.BRANCO)
                JogadorAtual = Cor.PRETO;
            else
                JogadorAtual = Cor.BRANCO;
        }

        private void NovaPeca(Peca p, PosicaoXadrez pos)
        {
            Tabuleiro.ColocarPeca(p, pos.ToPosicao());
            _pecasEmJogo.Add(p);
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

        public List<Peca> PecasCapturadas(Cor cor)
        {
            return _pecasCapturadas.FindAll(p => p.Cor == cor);
        }

        public List<Peca> PecasEmJogo(Cor cor)
        {
            return _pecasEmJogo.FindAll(p => p.Cor == cor);
        }

        public void IniciarPecas()
        {
            NovaPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('c', 8));
            NovaPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('c', 7));
            NovaPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('d', 7));
            NovaPeca(new Rei(Cor.PRETO, Tabuleiro), new PosicaoXadrez('d', 8));
            NovaPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('e', 7));
            NovaPeca(new Torre(Cor.PRETO, Tabuleiro), new PosicaoXadrez('e', 8));
            NovaPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('c', 2));
            NovaPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('c', 1));
            NovaPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('d', 2));
            NovaPeca(new Rei(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('d', 1));
            NovaPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('e', 1));
            NovaPeca(new Torre(Cor.BRANCO, Tabuleiro), new PosicaoXadrez('e', 2));
        }
    }
}
