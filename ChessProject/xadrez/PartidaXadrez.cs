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
        public bool Xeque { get; private set; } = false;

        public PartidaXadrez()
        {
            IniciarPecas();
        }

        private Peca MovimentarPeca(Posicao origem, Posicao destino)
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
            return pecaCapturada;
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

        private Peca Rei(Cor cor)
        {
            return PecasEmJogo(cor).Find(p => p is Rei);
        }

        private Cor Adversario(Cor cor)
        {
            if (Cor.BRANCO == cor)
                return Cor.PRETO;
            else
                return Cor.BRANCO;
        }

        private void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.RetirarPeca(destino);
            p.DecrementarMovimento();
            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                _pecasCapturadas.Remove(_pecasCapturadas.Find(p => p == pecaCapturada));
                _pecasEmJogo.Add(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(p, origem);
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);
            foreach (Peca p in PecasEmJogo(Adversario(cor)))
            {
                bool[,] possiveis = p.MovimentosPossiveis();
                if (possiveis[rei.Posicao.Linha, rei.Posicao.Coluna])
                    return true;
            }
            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
                return false;
            foreach (Peca p in PecasEmJogo(cor))
            {
                bool[,] possiveis = p.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (possiveis[i, j])
                        {
                            Posicao origem = p.Posicao;
                            Peca pecaCapturada = MovimentarPeca(origem, new Posicao(i, j));
                            bool xeque = EstaEmXeque(cor);
                            DesfazerMovimento(origem, new Posicao(i, j), pecaCapturada);
                            if (!xeque)
                                return false;
                        }
                    }
                }
            }
            return true;
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
            if (!Tabuleiro.GetPeca(origem).PossivelMover(destino))
                throw new TabuleiroException("Essa peça não pode se mover para esta posição!");
        }

        public void RealizarMovimento(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = MovimentarPeca(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("O seu rei está em xeque!");
            }
            if (EstaEmXeque(Adversario(JogadorAtual)))
                Xeque = true;
            else
                Xeque = false;
            if (TesteXequeMate(Adversario(JogadorAtual)))
                PartidaTerminada = true;
            else
            {
                MudarJogador();
                Turno++;
            }
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
