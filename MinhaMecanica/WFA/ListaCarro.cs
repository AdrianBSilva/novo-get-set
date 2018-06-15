using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class ListaCarro : Form
    {
        string nomeAntigo = string.Empty;
        List<Carro> carros = new List<Carro>();
        public ListaCarro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void ListaCarro_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/AdrianBSilva?tab=repositories";
            System.Diagnostics.Process.Start(link);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Carro carro = new Carro();
                carro.Nome = txtNome.Text;
                carro.Marca = txtValor.Text;
                carro.Ano = Convert.ToInt16(txtAno.Text);
                carro.Valor = Convert.ToDecimal(txtValor.Text);
                tabControl1.SelectedIndex = 0;
                if (nomeAntigo == "")
                {
                    carros.Add(carro);
                    AdicionarCarroTabela(carro);


                }
                else
                {
                    int linha = carros.FindIndex(x => x.Nome == nomeAntigo);
                    carros[linha] = carro;
                    EditarCarroNaTabela(carro, linha);
                    MessageBox.Show("Alterado com seucesso");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void EditarCarroNaTabela(Carro carro, int linha)
        {
            dataGridView1.Rows[linha].Cells[0].Value = carro.Nome;
            dataGridView1.Rows[linha].Cells[0].Value = carro.Marca;
            dataGridView1.Rows[linha].Cells[0].Value = carro.Ano;
            dataGridView1.Rows[linha].Cells[0].Value = carro.Valor;
        }

        private void AdicionarCarroTabela(Carro carro)
        {
            dataGridView1.Rows.Add(new object[]{
                carro.Nome, carro.Marca, carro.Ano, carro.Valor
            });
        }

        private void Limparcampos()
        {
            txtNome.Text = "";
            txtMarca.Text = "";
            txtAno.Text = "";
            txtValor.Text = "";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            string link = "http://www.friv.com/";

            System.Diagnostics.Process.Start(link);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            string link = "https://globoesporte.globo.com/futebol/copa-do-mundo/jogo/15-06-2018/portugal-espanha.ghtml";

            System.Diagnostics.Process.Start(link);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleciona uma linha desgraça");
                return;
            }

            int linha = dataGridView1.CurrentRow.Index;
            string nome = dataGridView1.Rows[linha].Cells[0].Value.ToString();
            for(int i = 0 i < carros.Count; i++)
            {
                Carro carro = carros[i];
                if(carro.Nome == nome)
                {
                    carros.RemoveAt(i);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int linha = dataGridView1.CurrentRow.Index;
            string nome = dataGridView1.Rows[linha].Cells[0].Value.ToString();
            foreach (Carro carro in carros)
            {
                if(carro.Nome == nome)
                {
                    txtNome.Text = carro.Nome;
                    txtMarca.Text = carro.Marca;
                    txtAno.Text = Convert.ToString(carro.Ano);
                    txtValor.Text = Convert.ToString(carro.Valor);
                    nomeAntigo = carro.Nome;
                    tabControl1.SelectedIndex = 1;
                    break;
                }
            }
        }
    }
}
