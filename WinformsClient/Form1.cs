using System.Net.Http.Json;

namespace WinformsClient
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7007")
        };

        public Form1()
        {
            InitializeComponent();
        }

        private async Task CargarProductosAsync()
        {
            var productos = await client.GetFromJsonAsync<List<Producto>>("api/Productos");
            dgvProductos.DataSource = productos;
        }

        private async void Refrescar_Click(object sender, EventArgs e)
        {
            Refrescar.Enabled = false;
            try
            {
                await CargarProductosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Refrescar.Enabled = true;
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            Guardar.Enabled = false;
            try
            {
                if (!decimal.TryParse(txtPrecio.Text, out var precio) ||
                    !int.TryParse(txtStock.Text, out var stock))
                {
                    MessageBox.Show("Precio o stock inválido");
                    return;
                }

                var nuevo = new Producto { Nombre = txtNombre.Text, Precio = precio, Stock = stock };
                var respuesta = await client.PostAsJsonAsync("api/Productos", nuevo);
                respuesta.EnsureSuccessStatusCode();

                txtNombre.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
                await CargarProductosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Guardar.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textStock_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}

