using System;
using JogoDaVelha;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace JogoDaVelha
{
    partial class Form1 : Form
    {
           public void FormLayout()
        {
            this.Name = "Form1";
            this.Text = "Form1";
            this.Size = new System.Drawing.Size(500, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        IAjogoDaVelha Jogo;
        public Form1(){
            InitializeComponent();
            Jogo = new IAjogoDaVelha();
        }

        private void cell1_Click(object sender, EventArgs e){
            var myButton = (Button)sender;
            myButton.Enabled = false;
            bool xWin = false;
            txtTurn.Text= Jogo.pegarAtacante().ToString() + " Jogou!";
            myButton.Text = (Jogo.pegarAtacante() == IAjogoDaVelha.Jogador.X) ? "X" : "O";
            Jogo.colocarValornoTabuleiro(int.Parse(myButton.Name.Replace("cell",""))-1);
            if(Jogo.Vencedor(Jogo.pegarTabuleiro())){
                getIndexes(Jogo.pegarIndices());
                if(MessageBox.Show(this, Jogo.pegarAtacante() + " Venceu O Jogo!", "Jogo Da Velha",MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK){
                    xWin = (Jogo.pegarAtacante() == IAjogoDaVelha.Jogador.X) ? true : false;
                    if(xWin){
                        txtX.Text = (int.Parse(txtX.Text) + 1).ToString();
                    }
                    else{
                        txtO.Text = (int.Parse(txtO.Text) + 1).ToString();
                    }
                    Jogo.iniciarTabuleiro();
                    ResetButton();
                    HabilitaBotao(true);
                }
                Jogo.limparIndices();
            }
            else if (Jogo.Empate(Jogo.pegarTabuleiro())){
                MessageBox.Show("Reiniciar Jogo!");
                Jogo.iniciarTabuleiro();
                ResetButton();
                HabilitaBotao(true);
            }
            Jogo.proximoJogador();
        }

        private void Form1_Load(object sender, EventArgs e){
            if(MessageBox.Show(this, "Jogador O , deseja iniciar o jogo?", "Iniciar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes){
                Jogo.jogadorDaVez(IAjogoDaVelha.Jogador.O);
            }
            else{
                Jogo.jogadorDaVez(IAjogoDaVelha.Jogador.X);
            }
            txtTurn.Text = Jogo.pegarAtacante().ToString() + " Jogou!";
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"Deseja resetar o jogo ?","Jogo Da Velha",MessageBoxButtons.YesNo) == DialogResult.Yes) { 
                txtX.Text = "0";
                txtO.Text = "0";
                Form1_Load(sender, e);
                ResetButton();
                Jogo.iniciarTabuleiro();
                HabilitaBotao(true);
            }
        }

         private void ResetButton() {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (btn.Text != "&Resetar")
                {
                    btn.Text = "";
                }
            }
        }

        private void HabilitaBotao(bool wen) {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (btn.Enabled == false)
                {
                    btn.Enabled = wen;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetButton();
        }

        private void getIndexes(List<int> indexes) {
            int ctr = 8;
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (btn.Name != "btnResetar")
                {
                    ctr--;
                    foreach (int index in indexes)
                    {
                        if (index == ctr)
                        {
                            btn.Enabled = (btn.Enabled == false) ? true : true;
                            btn.ForeColor = Color.Green;
                        }
                    }
                }
                else {
                    ctr++;
                }
                
            }
        }

        
        
         
    }
}