using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace APILejour
{
    public partial class Form1 : Form
    {
            string URI = "";
            int codigoProduto = 1;

        public Form1()
        {
            InitializeComponent();

        }

        private async void GetAllProdutos()
        {
            URI = txtURI.Text;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        gdvDados.DataSource = JsonConvert.DeserializeObject<User[]>(ProdutoJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                    }
                }
            }
        }

        private void btnObterProdutos_Click(object sender, EventArgs e)
        {
            GetAllProdutos();
        }
    }
}
