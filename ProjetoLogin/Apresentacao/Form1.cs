﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoLogin;
using ProjetoLogin.Apresentacao;
using ProjetoLogin.Modelo;

namespace ProjetoLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrese_Click(object sender, EventArgs e)
        {
            Cadastrese cad = new Cadastrese();
            cad.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.acessar(txbLogin.Text, txbSenha.Text);
            if (controle.mensagem.Equals(""))
            {
                if (controle.tem)
                {
                    MessageBox.Show("Logado com sucesso", "Entradado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BemVindo bv = new BemVindo();
                    bv.Show();
                }
                else
                {
                    MessageBox.Show("login não encontrado, verifique login e senha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else
            {
                MessageBox.Show(controle.mensagem);
            }
        }
    }
}
