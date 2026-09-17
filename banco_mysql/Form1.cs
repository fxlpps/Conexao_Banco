using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Baixado do "pacotes NuGet -> MySql"

namespace banco_mysql
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Dados da conexão
            conexao = new MySqlConnection("server=localhost; user=root; password=");

            //Abre a conexão
            conexao.Open();

            //Vai criar o banco e usá-lo, e depois chamamos a variável da conexão
            comando = new MySqlCommand("create database if not exists cadastro; use cadastro", conexao);

            //Executa a criação do banco de dados
            comando.ExecuteNonQuery();

            //Criação da tabela
            comando = new MySqlCommand("create table if not exists funcionario" +
                "(codigo int(11) not null auto_increment, " +
                "nome varchar(50) not null, " +
                "rua varchar(50) not null, " +
                "numero varchar(10) not null, " +
                "bairro varchar(30) not null," +
                "cep varchar(10) not null," +
                "telefone varchar(15) not null," +
                "email varchar(55) not null," +
                "primary key (codigo))", conexao, null);

            //Comando para executar a tabela
            comando.ExecuteNonQuery();

            //fexha a conexão
            conexao.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Botão salvar
            sql = "insert into funcionario(nome, rua, numero, bairro, cep, telefone, email) " +
                "values('"+txtNome.Text+"','"+txtRua.Text+"','"+txtNum.Text+"','"+txtBairro.Text+"','"+txtCep.Text+"','"+txtTel.Text+"','"+txtEmail.Text+"')";

            try
            {
                conexao.Open();
                try
                {
                    comando = new MySqlCommand(sql, conexao);
                    comando.ExecuteNonQuery();
                    //Vê se vai os dadoss foram salvos
                    MessageBox.Show("Dados salvos com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception erro)
                {
                    //Mostra a mensagem de erro ao salvar os dados
                    MessageBox.Show("Erro as salvar os dados!!", erro.Message);
                }

            }catch(Exception erro)
            {
                //Vê se o banco de dados foi conectado
                MessageBox.Show("Erro ao conectar ao banco!!", erro.Message);
            }
            finally
            {
                //Fecha a conexão
                conexao.Close();
            }
            txtNome.Clear();
            txtEmail.Clear();
            txtCep.Clear();
            txtBairro.Clear();
            txtNum.Clear();
            txtRua.Clear();
            txtTel.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Botão de sair
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var exer = new Consultar();
            exer.Show();
        }
    }
}
