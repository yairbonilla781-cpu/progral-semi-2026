using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Conversor2
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Dictionary<string, double>> conversiones;

        public Form1()
        {
            InitializeComponent();
            InicializarDatos();

           
            this.Load += Form1_Load;
            button1.Click += button1_Click;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void InicializarDatos()
        {
            conversiones = new Dictionary<string, Dictionary<string, double>>
            {
                { "Monedas", new Dictionary<string, double>
                    {
                        { "Dólar (USD)", 1.0 }, { "Euro (EUR)", 0.92 }, { "Yen (JPY)", 155.0 },
                        { "Libra (GBP)", 0.79 }, { "Peso Mexicano (MXN)", 17.1 }, { "Quetzal (GTQ)", 7.8 },
                        { "Lempira (HNL)", 24.6 }, { "Córdoba (NIO)", 36.7 }, { "Colón CR (CRC)", 515.0 },
                        { "Dólar Canadiense (CAD)", 1.35 }
                    }
                },
                { "Masa", new Dictionary<string, double>
                    {
                        { "Gramo (g)", 1.0 }, { "Kilogramo (kg)", 0.001 }, { "Miligramo (mg)", 1000.0 },
                        { "Libra (lb)", 0.00220462 }, { "Onza (oz)", 0.035274 }, { "Tonelada (t)", 0.000001 },
                        { "Quintal (q)", 0.0000220462 }, { "Arroba (@)", 0.0000881849 }, { "Stone (st)", 0.000157473 },
                        { "Microgramo (µg)", 1000000.0 }
                    }
                },
                { "Volumen", new Dictionary<string, double>
                    {
                        { "Litro (L)", 1.0 }, { "Mililitro (mL)", 1000.0 }, { "Metro cúbico (m³)", 0.001 },
                        { "Galón (US)", 0.264172 }, { "Onza fluida (fl oz)", 33.814 }, { "Taza (cup)", 4.22675 },
                        { "Pinta (pt)", 2.11338 }, { "Cucharada (tbsp)", 67.628 }, { "Cucharadita (tsp)", 202.884 },
                        { "Barril (bbl)", 0.00628981 }
                    }
                },
                { "Longitud", new Dictionary<string, double>
                    {
                        { "Metro (m)", 1.0 }, { "Kilómetro (km)", 0.001 }, { "Centímetro (cm)", 100.0 },
                        { "Milímetro (mm)", 1000.0 }, { "Milla (mi)", 0.000621371 }, { "Yarda (yd)", 1.09361 },
                        { "Pie (ft)", 3.28084 }, { "Pulgada (in)", 39.3701 }, { "Milla náutica (nmi)", 0.000539957 },
                        { "Micrómetro (µm)", 1000000.0 }
                    }
                },
                { "Almacenamiento", new Dictionary<string, double>
                    {
                        { "Byte (B)", 1.0 }, { "Kilobyte (KB)", 1.0 / 1024.0 }, { "Megabyte (MB)", 1.0 / Math.Pow(1024, 2) },
                        { "Gigabyte (GB)", 1.0 / Math.Pow(1024, 3) }, { "Terabyte (TB)", 1.0 / Math.Pow(1024, 4) },
                        { "Petabyte (PB)", 1.0 / Math.Pow(1024, 5) }, { "Bit (b)", 8.0 }, { "Kibibyte (KiB)", 1.0 / 1024.0 },
                        { "Mebibyte (MiB)", 1.0 / Math.Pow(1024, 2) }, { "Gibibyte (GiB)", 1.0 / Math.Pow(1024, 3) }
                    }
                },
                { "Tiempo", new Dictionary<string, double>
                    {
                        { "Segundo (s)", 1.0 }, { "Milisegundo (ms)", 1000.0 }, { "Minuto (min)", 1.0 / 60.0 },
                        { "Hora (h)", 1.0 / 3600.0 }, { "Día (d)", 1.0 / 86400.0 }, { "Semana", 1.0 / 604800.0 },
                        { "Mes (30 días)", 1.0 / 2592000.0 }, { "Año (365 días)", 1.0 / 31536000.0 },
                        { "Lustro (5 años)", 1.0 / (31536000.0 * 5) }, { "Década (10 años)", 1.0 / (31536000.0 * 10) }
                    }
                }
            };
        }

        private void CargarCategorias()
        {
            comboBox1.Items.Clear();
            foreach (var cat in conversiones.Keys)
            {
                comboBox1.Items.Add(cat);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                ActualizarUnidades();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarUnidades();
        }

        private void ActualizarUnidades()
        {
            if (comboBox1.SelectedItem == null) return;

            string categoriaSeleccionada = comboBox1.SelectedItem.ToString();

            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            foreach (var unidad in conversiones[categoriaSeleccionada].Keys)
            {
                comboBox2.Items.Add(unidad);
                comboBox3.Items.Add(unidad);
            }

            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = comboBox3.Items.Count > 1 ? 1 : 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double cantidad))
            {
                MessageBox.Show("Ingrese un número válido en la cantidad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría y sus unidades.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string categoria = comboBox1.SelectedItem.ToString();
            string unidadDe = comboBox2.SelectedItem.ToString();
            string unidadA = comboBox3.SelectedItem.ToString();

            double factorDe = conversiones[categoria][unidadDe];
            double factorA = conversiones[categoria][unidadA];

            double valorEnBase = cantidad / factorDe;
            double resultado = valorEnBase * factorA;

            string textoResultado = $"Resultado: {cantidad} {unidadDe} = {resultado:G8} {unidadA}";

            
            try { label5.Text = textoResultado; } catch { }
           
        }
    }
}