using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banco_mysql
{
    public partial class Consultar : Form
    {
        //Variáveis
        public string sql;
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter adaptador;
        DataTable dados;

        public Consultar()
        {
            InitializeComponent();
        }

        public void listar()
        {
            //Função para receber os dados já cadatrados e colocá-los dentro do datagreed
            conexao = new MySqlConnection("server=localhost; user=root; password=; database=cadastro");//Informa qual banco é para abrir
            sql = "select * from funcionario";
            try
            {
                conexao.Open(); //abre a conexao
                comando = new MySqlCommand(sql, conexao); //Esse comando serve para preparar e executar uma instrução SQL em um banco de dados MySQL 
                adaptador = new MySqlDataAdapter(comando); //busca dados do banco
                dados = new DataTable();
                adaptador.Fill(dados); //o adaptador.Fill organiza as informações buscadas no banco e organizá-las dizendo qual é qual 
                dataGridView1.DataSource = dados; //pega as informações e coloca dentro do datagreed
                Formatar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro as conectar as banco de dados", erro.Message);
            }
            finally
            {
                conexao.Close(); //Fecha a conexão
            }
        }

        //Formatação do datagrid
        public void Formatar()
        {
            //formatação da legenda
            dataGridView1.Columns[0].HeaderText = "Código";
            dataGridView1.Columns[1].HeaderText = "Nome";
            dataGridView1.Columns[2].HeaderText = "Rua";
            dataGridView1.Columns[3].HeaderText = "Número";
            dataGridView1.Columns[4].HeaderText = "Bairro";
            dataGridView1.Columns[5].HeaderText = "CEP";
            dataGridView1.Columns[6].HeaderText = "Telefone";
            dataGridView1.Columns[7].HeaderText = "E-mail";

            dataGridView1.Columns[0].Visible = false; //Deixa invisível a coluna, nesse caso a coluna código

            //Alinhamento das colunas
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Largura das colunas
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 220;

            //Mudar tipo e tamanho, tamanho e deixar o texto em negrito
            dataGridView1.Columns[0].DefaultCellStyle.Font =
                new Font("arial", 8, FontStyle.Bold); //tipo,tamanho,estilo da fonte
            dataGridView1.Columns[1].DefaultCellStyle.Font =
                new Font("arial", 8, FontStyle.Bold);
            dataGridView1.Columns[2].DefaultCellStyle.Font =
                new Font("arial", 8, FontStyle.Bold);
            dataGridView1.Columns[3].DefaultCellStyle.Font =
                new Font("arial", 8, FontStyle.Bold);
            dataGridView1.Columns[4].DefaultCellStyle.Font =
                new Font("arial", 8, FontStyle.Bold);
            dataGridView1.Columns[5].DefaultCellStyle.Font =
                new Font("arial", 8, FontStyle.Bold);
            dataGridView1.Columns[6].DefaultCellStyle.Font =
                new Font("arial", 8, FontStyle.Bold);
            dataGridView1.Columns[7].DefaultCellStyle.Font =
                new Font("arial", 8, FontStyle.Bold);

            //Muda a cor das linhas alternando-as
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.MediumOrchid;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkOrchid;

        }

        private void Consultar_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var voltar = new Form1();
            voltar.Show();
        }

        //Textbox de pesquisa
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                sql = "select * from funcionario";
                radioButton1.Checked = false; //O rádio button não fica selecionado
                radioButton2.Checked = false;
            }
            if (radioButton1.Checked == true)
            {
                sql = "select * from funcionario where codigo =" + textBox1.Text + ""; //Se ele clicar nesse botão, será feito uma busca até encontrar um usuário que tenha o mesmo código
            } else if (radioButton2.Checked == true)
            {
                //O like é usado quando comparamos textos
                sql = "select * from funcionario where nome like '%" + textBox1.Text + "%'"; //Procura o usuário pelo nome
            }

            try
            {
                conexao.Open();
                comando = new MySqlCommand(sql, conexao);
                adaptador = new MySqlDataAdapter(comando);
                dados = new DataTable();
                adaptador.Fill(dados);
                dataGridView1.DataSource = dados;
                Formatar();
            } catch (Exception erro)
            {
                MessageBox.Show("Erro as conectar as banco de dados", erro.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        //Janela de propriedades -> Raio -> "CellClick"
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Comando para quando clicar na linha, acontece algo
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            //Muda o valor dentro do texbox com os valores que foram cadastrados
            txtCodigo.Text = row.Cells[0].Value.ToString();
            txtNome.Text = row.Cells[1].Value.ToString();
            txtRua.Text = row.Cells[2].Value.ToString();
            txtNum.Text = row.Cells[3].Value.ToString();
            txtBairro.Text = row.Cells[4].Value.ToString();
            txtCep.Text = row.Cells[5].Value.ToString();
            txtTel.Text = row.Cells[6].Value.ToString();
            txtEmail.Text = row.Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Botão excluir
            sql = "delete from funcionario where codigo='" + this.txtCodigo.Text + "'";

            try //abre e verifica se conectou ao banco de dados
            {
                conexao.Open(); //Abre o banco

                try //Vê se o comando delete foi executado com sucesso
                {
                    comando = new MySqlCommand(sql, conexao); //executa
                    adaptador = new MySqlDataAdapter(comando); //ponte entre o seu banco de dados MySQL e o código
                    dados = new DataTable(); //permite manipular dados
                    adaptador.Fill(dados);
                } catch (Exception erro)
                {
                    MessageBox.Show("Erro ao excluir dados do banco de dados", erro.Message);
                }

            }
            catch (Exception erro)
            {
                //Mensagem de erro
                MessageBox.Show("Erro ao conectar ao banco ", erro.Message);
            }
            finally
            {
                conexao.Close(); //Fecha a conexão
            }
            //Apaga os dados do cadastro na interface
            listar();
            txtCodigo.Clear();
            txtNome.Clear();
            txtRua.Clear();
            txtCep.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            txtNum.Clear();
            txtBairro.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Botão alterar
            sql = "update funcionario set nome='" + this.txtNome.Text + "', rua='" + this.txtRua.Text + "', numero='" + this.txtNum.Text + "', bairro='" + this.txtBairro.Text + "', cep='" + this.txtCep.Text + "', telefone='" + this.txtTel.Text + "', email='" + this.txtEmail.Text + "' where codigo='" + this.txtCodigo.Text + "'";
            try 
            {
                conexao.Open(); 

                try 
                {
                    comando = new MySqlCommand(sql, conexao); 
                    adaptador = new MySqlDataAdapter(comando); 
                    dados = new DataTable(); 
                    adaptador.Fill(dados);
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao alterar dados", erro.Message);
                }

            }
            catch (Exception erro)
            {
                
                MessageBox.Show("Erro ao conectar ao banco ", erro.Message);
            }
            finally
            {
                conexao.Close();
            }
            listar();
            txtCodigo.Clear();
            txtNome.Clear();
            txtRua.Clear();
            txtCep.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            txtNum.Clear();
            txtBairro.Clear();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

