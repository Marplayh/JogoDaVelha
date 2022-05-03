using System;
using JogoDaVelha;

using System.Collections.Generic;

namespace JogoDaVelha
{
    class IAjogoDaVelha
    {
        public IAjogoDaVelha(){
            iniciarTabuleiro();
        }

        List<int> indexWin = new List<int>(new int []{0,0,0});
        List<Jogador> Tabuleiro = new List<Jogador>();
        List<Jogador> tabuleiroTemporario = new List<Jogador>();
        public enum Jogador{
            X,
            O,
            S
        }

        private Jogador turno;

        public List<Jogador> pegarTabuleiro(){
            return Tabuleiro;
        }

        public List<int> pegarIndices(){
            return indexWin;
        }

        public void limparIndices(){
            indexWin[0] = 0;
            indexWin[1] = 0;
            indexWin[2] = 0;
        }

        public void iniciarTabuleiro(){
            Tabuleiro.Clear();
            for(int i = 0; i<9;i++){
                Tabuleiro.Add(Jogador.S);
            }
        }

        public void colocarValornoTabuleiro(int valor){
            Tabuleiro[valor]=this.pegarAtacante();
        }

        public void proximoJogador(){
            turno = (turno == Jogador.X) ? Jogador.O : Jogador.X;
        }

        public Jogador pegarAtacante(){
            return turno;
        }

        public void jogadorDaVez(Jogador jogador){
            this.turno = jogador;
        }

        public Boolean Vencedor(List<Jogador> tabuleiroTemporario){
              if(this.checarDiagonal(tabuleiroTemporario) || this.checarHorizontal(tabuleiroTemporario) || this.checarVertical(tabuleiroTemporario)){
                  return true;
              }
              return false;
        }

        public Boolean Empate(List<Jogador> tabuleiroTemporario){
            int ctr = 0;
            foreach (Jogador jogador in tabuleiroTemporario){
                if(jogador == Jogador.S){
                    ctr++;
                }
            }
            return (ctr == 0) ? true: false;
        }

        private Boolean checarDiagonal(List<Jogador> tabuleiroTemp){
            if(tabuleiroTemp[0] == tabuleiroTemp[4] && tabuleiroTemp[0] == tabuleiroTemp[8]){
                if(tabuleiroTemp[0] != Jogador.S){
                    indexWin[0] = 0;
                    indexWin[1] = 4;
                    indexWin[2] = 8;
                    return true;
                }
            }
            if(tabuleiroTemp[2] == tabuleiroTemp[4] && tabuleiroTemp[2] == tabuleiroTemp[6]){
                if(tabuleiroTemp[2] != Jogador.S){
                    indexWin[0] = 2;
                    indexWin[1] = 4;
                    indexWin[2] = 6;
                    return true;
                }
            }
            return false;
        }

        private Boolean checarHorizontal(List<Jogador> tabuleiroTemp){
            if(tabuleiroTemp[0] == tabuleiroTemp[1] && tabuleiroTemp[0] == tabuleiroTemp[2]){
                if(tabuleiroTemp[0] != Jogador.S){
                    indexWin[0] = 0;
                    indexWin[1] = 1;
                    indexWin[2] = 2;
                    return true;
                }
            }
             if(tabuleiroTemp[3] == tabuleiroTemp[4] && tabuleiroTemp[3] == tabuleiroTemp[5]){
                if(tabuleiroTemp[3] != Jogador.S){
                    indexWin[0] = 3;
                    indexWin[1] = 4;
                    indexWin[2] = 5;
                    return true;
                }
            }
            if(tabuleiroTemp[6] == tabuleiroTemp[7] && tabuleiroTemp[6] == tabuleiroTemp[8]){
                if(tabuleiroTemp[6] != Jogador.S){
                    indexWin[0] = 6;
                    indexWin[1] = 7;
                    indexWin[2] = 8;
                    return true;
                }
            }
            return false;
        }

        private Boolean checarVertical(List<Jogador> tabuleiroTemp){
            if(tabuleiroTemp[0] == tabuleiroTemp[3] && tabuleiroTemp[0] == tabuleiroTemp[6]){
                if(tabuleiroTemp[0] != Jogador.S){
                    indexWin[0] = 0;
                    indexWin[1] = 3;
                    indexWin[2] = 6;
                    return true;
                }
            }
            if(tabuleiroTemp[1] == tabuleiroTemp[4] && tabuleiroTemp[1] == tabuleiroTemp[7]){
                if(tabuleiroTemp[1] != Jogador.S){
                    indexWin[0] = 1;
                    indexWin[1] = 4;
                    indexWin[2] = 7;
                    return true;
                }
            }
            if(tabuleiroTemp[2] == tabuleiroTemp[5] && tabuleiroTemp[2] == tabuleiroTemp[8]){
                if(tabuleiroTemp[2] != Jogador.S){
                    indexWin[0] = 2;
                    indexWin[1] = 5;
                    indexWin[2] = 8;
                    return true;
                }
            }
            return false;
        }

        public List<int> pegarCelulasDisponiveis(List<Jogador> tabuleiroTemp){
            List<int> pegarCelulas = new List<int>();
            int ctr = 0;
            foreach (Jogador jogador in tabuleiroTemp){
                if(jogador == Jogador.S){
                    pegarCelulas.Add(ctr);
                }
                ctr++;
            }
            return pegarCelulas;
        }



    }
}