using Compilador_sensor.AnalisisLexico;
using Compilador_sensor.ManejadorErrores;
using Compilador_sensor.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

namespace Compilador_sensor.AnalizadorSintactico
{
    public class AnalizadorSintactico 
    {
        private AnalizadorLexico analizadorLexico = new AnalizadorLexico();
        private ComponenteLexico Componente;
        private StringBuilder Traza;

        private void Expresion(int Nivel)
        {
            FormarEntrada(Nivel, "<Expresion>");
            if (Categoria.ENTRADA.Equals(Componente.ObtenerCategoria()))
            { 
                InstruccionEntrada(Nivel + 1);
            }
            else if (Categoria.SALIDA.Equals(Componente.ObtenerCategoria()))
            {
                InstruccionSalida(Nivel + 1);
            }
            FormarSalida(Nivel, "<Expresion>");
        }

        private void InstruccionEntrada(int Nivel)
        {
            FormarEntrada(Nivel, "<InstrucciónEntrada>");
            if (Categoria.ENTRADA.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
                if (Categoria.OBTENER_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
                {
                    FormarEntrada(Nivel, "<ObtenerTemperatura>");
                    Avanzar();
                    if (Categoria.UNIDAD_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
                    {
                        UnidadTemperatura(Nivel + 1);
                    }
                    FormarSalida(Nivel, "<ObtenerTemperatura>");
                }
                else if (Categoria.VALOR_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
                {
                    ValorTemperatura(Nivel + 1);
                }
                else if (Categoria.VALOR_ESTADO_SENSOR.Equals(Componente.ObtenerCategoria()))
                {
                    OrdenEstadoSensor(Nivel + 1);
                }
            }
            FormarSalida(Nivel, "<InstrucciónEntrada>");
            Expresion(1);
        }

        private void OrdenEstadoSensor(int Nivel)
        {
            FormarEntrada(Nivel, "<OrdenEstadoSensor>");
            if ("-00-".Equals(Componente.ObtenerLexema()))
            {
                Avanzar();
                if (Categoria.ENCENDER_SENSOR.Equals(Componente.ObtenerCategoria()))
                {
                    FormarEntrada(Nivel, "<EncenderSensor>");
                    Avanzar();
                    FormarSalida(Nivel, "<EncenderSensor>");
                }
            }
            if ("-11-".Equals(Componente.ObtenerLexema()))
            {
                Avanzar();
                if (Categoria.APAGAR_SENSOR.Equals(Componente.ObtenerCategoria()))
                {
                    FormarEntrada(Nivel, "<ApagarSensor>");
                    Avanzar();
                    FormarSalida(Nivel, "<ApagarSensor>");
                }
            }
            FormarSalida(Nivel, "<OrdenEstadoSensor>");
        }

        private void UnidadTemperatura(int Nivel)
        {
            FormarEntrada(Nivel, "UnidadTemperatura>");
            Avanzar();
            if(Categoria.DECREMENTAR.Equals(Componente.ObtenerCategoria()) || Categoria.INCREMENTAR.Equals(Componente.ObtenerCategoria()))
            {
                Orden(Nivel + 1);
            }
            FormarSalida(Nivel, "<Unidademperatura>");
        }

        private void ValorTemperatura(int Nivel)
        {
            FormarEntrada(Nivel, "<ValorTemperatura>");
            Avanzar();
            if (Categoria.UNIDAD_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
            {
                UnidadTemperatura(Nivel + 1);
            }
            FormarSalida(Nivel, "<ValorTemperatura>");
        }

        private void InstruccionSalida(int Nivel)
        {
            FormarEntrada(Nivel, "<InstrucciónSalida>");
            Avanzar();
            if (Categoria.VALOR_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
            {
                ValorTemperatura(Nivel + 1);
            }
            else if (Categoria.VALOR_ESTADO_SENSOR.Equals(Componente.ObtenerCategoria()))
            {
                EstadoSensor(Nivel + 1);
            }
            FormarSalida(Nivel, "<InstrucciónSalida>");
            Expresion(1);
        }

        private void EstadoSensor(int Nivel)
        {
            FormarEntrada(Nivel, "<EstadoSensor>");
            if ("-00-".Equals(Componente.ObtenerLexema()))
            {
                Avanzar();
                if ("OFF".Equals(Componente.ObtenerLexema()))
                {
                    FormarEntrada(Nivel, "<SensorApagado>");
                    Avanzar();
                    FormarSalida(Nivel, "<SensorApagado>");
                }
            }
            if ("-11-".Equals(Componente.ObtenerLexema()))
            {
                Avanzar();
                if ("ON".Equals(Componente.ObtenerLexema()))
                {
                    FormarEntrada(Nivel, "<SensorEncendido>");
                    Avanzar();
                    FormarSalida(Nivel, "<SensorEncendido>");
                    
                }
            }
            FormarSalida(Nivel, "<EstadoSensor>");
        }
        private void Orden (int Nivel)
        {
            FormarEntrada(Nivel, "<Orden>");
            Avanzar();
            FormarSalida(Nivel, "<Orden>");
        }

        public void Analizar(bool Depurar)
        {
            Avanzar();
            Traza = new StringBuilder();
            Expresion(1);

            if (Depurar)
            {
                //MessageBox.Show(Traza.ToString());
                Console.WriteLine(Traza.ToString());
            }

            if (GestorErrores.ObtenerInstancia().HayErrores())
            {
                MessageBox.Show("La compilación ha finalizado, pero hay errores en el programa de Entrada, por favor verifique la consola de errores");
            }
            else if (Categoria.FIN_ARCHIVO.Equals(Componente.ObtenerCategoria()))
            {
                MessageBox.Show("Compilación finalizada correctamente");
            }
            else
            {
                MessageBox.Show("Aunque la compilación ha finalizado, faltaron componentes por analizar");
            }
        }


        private void Avanzar()
        {
            Componente = analizadorLexico.DevolverComponenteLexico();
            Global.Form.LlenarTablas(Componente);
        }

        private void FormarEntrada(int Nivel, string regla)
        {
            for (int contador = 1; contador <= Nivel * 5; contador++)
            {
                Traza.Append("-");
            }
            Traza.Append("> ");
            Traza.Append("INICIO" + regla);
            Traza.Append("\n");
            if(Nivel != 1)
            {
                FormarComponente(Nivel);
            }
        }
        private void FormarSalida(int Nivel, string regla)
        {
            Traza.Append("<");
            for (int contador = 1; contador <= Nivel * 5; contador++)
            {
                Traza.Append("-");
            }
            Traza.Append("FIN " + regla);
            Traza.Append("\n");
        }

        private void FormarComponente(int Nivel)
        {
            Traza.Append("-");
            for (int contador = 1; contador <= (Nivel + 1) * 5; contador++)
            {
                Traza.Append("-");
            }
            Traza.Append("Componente actual ").Append(this.Componente.ObtenerLexema()).Append("/").Append(this.Componente.ObtenerCategoria());
            Traza.Append("\n");
        }    
    }
}
