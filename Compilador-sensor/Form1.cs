using Compilador_sensor.AnalisisLexico;
using Compilador_sensor.Transversal;
using Compilador_sensor.AnalizadorSintactico;
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

namespace Compilador_sensor
{
    public partial class Form1 : Form
    {
        OpenFileDialog OpenFile = new OpenFileDialog();
        string ArchivoReference, ActualLinea;

        public Form1()
        {
            InitializeComponent();
        }

        private void RbtnArchivo_CheckedChanged_1(object sender, EventArgs e)
        {
            dataGridViewDummy.Rows.Clear();
            dataGridViewLiterale.Rows.Clear();
            dataGridViewPalRe.Rows.Clear();
            if (RbtnArchivo.Checked) // SI EL USUARIO ELIGE ESA OPCIÓN, ENTONCES CAMBIAMOS LA GRAFICA
            {
                
                BtnCarga.Show();
                
                TxtArchivo.Show();
                txtConsola.Hide();
                BtnCarga.Location = new Point(512, 44);
                this.CenterToScreen();
            }
        }

        private void RbtnConsola_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Hide();
            dataGridViewDummy.Rows.Clear();
            dataGridViewLiterale.Rows.Clear();
            dataGridViewPalRe.Rows.Clear();
            if (RbtnConsola.Checked)// SI EL USUARIO ELIGE ESA OPCIÓN, ENTONCES SE MUEVE EL BOTON DE CARGA
            {
                BtnCarga.Show();
                txtConsola.Show();
                TxtArchivo.Hide();
                TxtArchivo.ResetText();
                BtnCarga.Location = new Point(210, 187);

            }
        }

        private void BtnCarga_Click(object sender, EventArgs e)
        {
           
            Cache.INSTANCIA.ReiniciarCache();
            if (RbtnArchivo.Checked)
            {
                AbrirArchivo();
                TxtArchivo.Text = ArchivoReference;
                if (TxtArchivo.Text.Length > 0)
                {
                    ArchivoReference = "";
                }
                BtnCarga.Hide();
            }
            else if (RbtnConsola.Checked)
            {
                readconsole();
                BtnCarga.Hide();
                this.CenterToScreen();
                
            }
            else
            {
                MessageBox.Show("Por favor selecciona una opción", "Programa Entrada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

    

        private void AbrirArchivo()
        {
            listBox1.Show();
            try
            {
                OpenFile.Filter = "Text Files(.txt)| *.txt"; // mostrarme solo los archivos .txt
                listBox1.Items.Clear();
                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    ArchivoReference = OpenFile.FileName; // obtener la referencia del archivo
                    StreamReader streamReader = new StreamReader(ArchivoReference);  // leer el archivo
                    int contador = 1;
                    while (true)
                    {
                        ActualLinea = streamReader.ReadLine(); // retorna la linea actual
                        Cache.INSTANCIA.AgregarLinea(ActualLinea);
                        listBox1.Items.Add(contador + ". " + ActualLinea);
                        if (streamReader.EndOfStream) // si termina de leer el archivo completamente, parame el Stream y dale un break al Bucle While
                        {
                            streamReader.Close();
                            break;
                        }
                        contador++;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Se ocurre un error...\nIntente de nuevo!", "DEV COP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                AnalizadorSintactico.AnalizadorSintactico AnalizadorSintactico = new AnalizadorSintactico.AnalizadorSintactico();
                AnalizadorSintactico.Analizar(enableDebug.Checked);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Global.Form = this;
            listBox1.Hide();
        }

 

        private void readconsole()
        {
            string[] lineas = txtConsola.Text.Split('\n');
            for(int i=0;i<lineas.Length; i++)
            {
                Cache.INSTANCIA.AgregarLinea(lineas[i]);
            }
            
        }

        public void LlenarTablas(ComponenteLexico Componente)
        {
            if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
            {
                LlenarTablaLiterales(Componente);
            }
            else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
            {
                LlenarTablaPalabrasReservadas(Componente);
            }
            else if (Tipo.DUMMY.Equals(Componente.ObtenerTipo()))
            {
                LlenarTablaDummies(Componente);
            }

        }

        public void LlenarTablaLiterales(ComponenteLexico Componente)
        {
            dataGridViewLiterale.Rows.Add(Componente.ObtenerLexema(),
               Componente.ObtenerCategoria(), Componente.ObtenerNumeroLinea(),
               Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal());
        }

        public void LlenarTablaPalabrasReservadas(ComponenteLexico Componente)
        {
            dataGridViewPalRe.Rows.Add(Componente.ObtenerLexema(),
                Componente.ObtenerCategoria(), Componente.ObtenerNumeroLinea(),
                Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal());
        }

        public void LlenarTablaDummies(ComponenteLexico Componente)
        {
            dataGridViewDummy.Rows.Add(Componente.ObtenerLexema(),
                Componente.ObtenerCategoria(), Componente.ObtenerNumeroLinea(),
                Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal());
        }
    }
}
