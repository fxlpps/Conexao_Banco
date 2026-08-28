using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Conexao_Banco
{
    public partial class Form1 : Form
    {

        public string sql;
        MySqlConnection conexao;
        MySqlCommand comando;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexao = new MySqlConnection("server=localhost; user=root; password="); //<-- servidor, usuário e senha
            conexao.Open();

            comando = new MySqlCommand("create database if not exists cadastro; use cadastro", conexao);
            comando.ExecuteNonQuery();
            comando = new MySqlCommand("create table if not exists " + "funcionario(codigo int(11) not null auto_increment, nome varchar(50) not null, rua varchar(50) not null, numero varchar(10) not null, bairro varchar(30) not null, cep varchar(10) not null, tel varchar(15) not null, email varchar(55) not null, primary key (codigo))", conexao, null);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtRua_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "insert into funcionario(nome, rua, numero, bairro, cep, tel, email) values('"
                + txtNome.Text + "','"
                + txtRua.Text + "','"
                + txtNumero.Text + "','"
                + txtBairro.Text + "','"
                + txtCEP.Text + "','"
                + txtTelefone.Text + "','"
                + txtEmail.Text + "')";


            try
            {
                conexao.Open();
                try
                {
                    comando = new MySqlCommand(sql, conexao);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados salvos com sucesso", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao salvar dados", erro.Message);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao conectar ao banco", erro.Message);
            } 
            finally { conexao.Close(); }
            txtNome.Clear();
            txtBairro.Clear();
            txtCEP.Clear();
            txtEmail.Clear();
            txtNumero.Clear();
            txtRua.Clear();
            txtTelefone.Clear();
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
