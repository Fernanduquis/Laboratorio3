using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio3
{
    public partial class Form1 : Form
    {
        List<Propiedades> propiedades = new List<Propiedades>();
        List<Propietarios> propietarios = new List<Propietarios>();
        List<Reporte> reportes = new List<Reporte>();




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            if (File.Exists(@"..\..\propietarios.txt"))
            {
                FileStream stream = new FileStream(@"..\..\propietarios.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Propietarios persona = new Propietarios();
                    persona.DPI = reader.ReadLine();
                    persona.NombrePropietario = reader.ReadLine();
                    persona.Apellido = reader.ReadLine();
                    
                    propietarios.Add(persona);
                }
                reader.Close();
            }

            if (File.Exists(@"..\..\propiedades.txt"))
            {
                FileStream stream = new FileStream(@"..\..\propiedades.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Propiedades Casas = new Propiedades();
                    Casas.NumeroCasa1 = Convert.ToInt32(reader.ReadLine());
                    Casas.DPIDueño1 = Convert.ToInt32(reader.ReadLine());
                    Casas.CuotaMantenimiento1 = Convert.ToInt32(reader.ReadLine());

                    propiedades.Add(Casas);
                }
                reader.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            
            foreach (var propiedad in propiedades)
            {
                reporte.NumeroCasa1 = propiedad.NumeroCasa1;
                reporte.CuotaMantenimiento1 = propiedad.CuotaMantenimiento1;

                reportes.Add(reporte);
            }

            foreach(var propietario in propietarios)
            {
               reporte.Nombre = propietario.NombrePropietario;
                reporte.Apellido = propietario.Apellido;
                reportes.Add(reporte);
            }

           
            dataGridViewReporte.DataSource = null;
            dataGridViewReporte.DataSource = reportes;
            dataGridViewReporte.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // int mayor = propietarios.Max(x => x.NombrePropietario);
            int mayor = propiedades.Max(k => k.CuotaMantenimiento1);
            int menor = propiedades.Min(X => X.CuotaMantenimiento1);
            textBoxbaja.Text = menor.ToString();
            textBoxNombre.Text =  mayor.ToString();



        }
    }
}
