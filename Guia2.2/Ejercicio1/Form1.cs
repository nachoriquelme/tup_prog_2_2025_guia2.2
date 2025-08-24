using Ejercicio1.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProcesoEncuestas proceso = new ProcesoEncuestas();
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            RegistroDeEncuesta fEncuesta = new RegistroDeEncuesta();

            if (fEncuesta.ShowDialog() == DialogResult.OK) 
            {
                Encuesta encuesta = new Encuesta();

                encuesta.UsaBicicleta = fEncuesta.chkUsaBici.Checked;
                encuesta.UsaAuto = fEncuesta.chkUsaAuto.Checked;
                encuesta.UsaTransPub = fEncuesta.chkUsaTransPub.Checked;
                encuesta.DistanciaASuDestino = Convert.ToDouble(fEncuesta.tbDistancia.Text);

                encuesta.Email = fEncuesta.tbEmail.Text;

                bool puedeSerContactado = fEncuesta.chkPuedeContactado.Checked;

                proceso.RegistrarEncuesta(encuesta, puedeSerContactado);
            }
            fEncuesta.Dispose();
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            Informe FInforme = new Informe();

            FInforme.Text = "Informe.";

            FInforme.listBox1.Items.Add("Informe");
            FInforme.listBox1.Items.Add("Porcentaijes de transportes habituales");
            FInforme.listBox1.Items.Add($"Bicicleta:  {proceso.PorcBicicleta}%");
            FInforme.listBox1.Items.Add($"Automóvil:  {proceso.PorcAuto}%");
            FInforme.listBox1.Items.Add($"Transporte público:  {proceso.PorcTransPub}%");

            FInforme.ShowDialog();
            FInforme.Dispose();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            Informe fInforme = new Informe();

            fInforme.Text = "Informe.";

            fInforme.listBox1.Items.Add("Informe de encuestados contactables");

            proceso.OrdenarEncuestables();
            for (int n = 0; n < proceso.CantContactables; n++)
            {
                fInforme.listBox1.Items.Add($"Email: {proceso.VerContactable(n).Email} - Distancia: {proceso.VerContactable(n).DistanciaASuDestino}");
            }

            fInforme.ShowDialog();
            fInforme.Dispose();
        }
    }
}
