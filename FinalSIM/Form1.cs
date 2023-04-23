namespace FinalSIM
{
    public partial class Form1 : Form
    {
        static Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        
        private void txt_cant_sim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;

            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((txt_cant_sim.Text == "" || txt_desde.Text == "" || txt_hasta.Text =="" || txt_llegada_cliente.Text == "" || txt_demoraAtencionA.Text == "" ||
                txt_demoraAtencionB.Text == "" || txt_demoraPedidoA.Text=="" || txt_demoraPedidoB.Text == "" ) || (Int64.Parse(txt_desde.Text) > Int64.Parse(txt_hasta.Text))
                || (Double.Parse(txt_demoraAtencionA.Text) > Double.Parse(txt_demoraAtencionB.Text)) || (Double.Parse(txt_demoraPedidoA.Text) > Double.Parse(txt_demoraPedidoB.Text))
                || (Int64.Parse(txt_hasta.Text) > Int64.Parse(txt_cant_sim.Text)) || ((Double.Parse(txt_llegada_cliente.Text) == 0)))
            {
                MessageBox.Show("Algun dato es no valido!");
            }
            else
            {
                Form sim = new Form2(txt_cant_sim.Text,
                                     txt_desde.Text,
                                     txt_hasta.Text,
                                     txt_llegada_cliente.Text,
                                     txt_demoraAtencionA.Text,
                                     txt_demoraAtencionB.Text,
                                     txt_demoraPedidoA.Text,
                                     txt_demoraPedidoB.Text,
                                     this);
                this.Hide();
                sim.ShowDialog();
            }
                      
        }

        
        
    }    
}