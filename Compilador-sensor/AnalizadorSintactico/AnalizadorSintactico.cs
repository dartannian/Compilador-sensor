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
                if (!Categoria.FIN_ARCHIVO.Equals(Componente.ObtenerCategoria()))
                {
                    Expresion(1);
                }
            }
            else if (Categoria.SALIDA.Equals(Componente.ObtenerCategoria()))
            {
                InstruccionSalida(Nivel + 1);
                if (!Categoria.FIN_ARCHIVO.Equals(Componente.ObtenerCategoria()))
                {
                    Expresion(1);
                }
            }
            FormarSalida(Nivel, "<Expresion>");
        }

        private void InstruccionEntrada(int Nivel)
        {
            FormarEntrada(Nivel, "<InstrucciónEntrada>");

            Avanzar();
            if (Categoria.OBTENER_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
            {
                FormarEntrada(Nivel, "<ObtenerTemperatura>");
                Avanzar();
                if (Categoria.UNIDAD_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
                {
                    UnidadTemperatura(Nivel + 1);
                }
                else
                {
                    if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewLiterale.Rows.RemoveAt(Global.Form.dataGridViewLiterale.Rows.Count - 2);
                    }
                    else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewPalRe.Rows.RemoveAt(Global.Form.dataGridViewPalRe.Rows.Count - 2);
                    }
                    String Falla = "Componente no válido" + Componente.ObtenerLexema();
                    String Causa = "El componente no es valido para formar la expresión";
                    String Solucion = "agregar componente valido";

                    Error Error = Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error);
                    throw new Exception("Error tipo stopper durante el análisis sintactico, observe la terminal para la mas información sobre el error");
                }
                FormarSalida(Nivel, "<ObtenerTemperatura>");
            }
            else if (Categoria.VALOR_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
            {
                ValorTemperatura(Nivel + 1);
                if (Categoria.UNIDAD_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
                {
                    UnidadTemperatura(Nivel + 1);
                    if (Categoria.DECREMENTAR.Equals(Componente.ObtenerCategoria()) || Categoria.INCREMENTAR.Equals(Componente.ObtenerCategoria()))
                    {
                        Orden(Nivel + 1);
                    }
                    else
                    {
                        if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
                        {
                            Global.Form.dataGridViewLiterale.Rows.RemoveAt(Global.Form.dataGridViewLiterale.Rows.Count - 2);
                        }
                        else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
                        {
                            Global.Form.dataGridViewPalRe.Rows.RemoveAt(Global.Form.dataGridViewPalRe.Rows.Count - 2);
                        }
                        String Falla = "Componente no válido" + Componente.ObtenerLexema();
                        String Causa = "El componente no es valido para formar la expresión";
                        String Solucion = "agregar componente valido";

                        Error Error = Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                        GestorErrores.ObtenerInstancia().Agregar(Error); throw new Exception("Error tipo stopper durante el análisis sintactico, observe la terminal para la mas información sobre el error");
                    }
                }
                else
                {
                    if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewLiterale.Rows.RemoveAt(Global.Form.dataGridViewLiterale.Rows.Count - 2);
                    }
                    else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewPalRe.Rows.RemoveAt(Global.Form.dataGridViewPalRe.Rows.Count - 2);
                    }
                    String Falla = "Componente no válido" + Componente.ObtenerLexema();
                    String Causa = "El componente no es valido para formar la expresión";
                    String Solucion = "agregar componente valido";

                    Error Error = Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error); throw new Exception("Error tipo stopper durante el análisis sintactico, observe la terminal para la mas información sobre el error");
                }

            }
            else if (Categoria.VALOR_ESTADO_SENSOR.Equals(Componente.ObtenerCategoria()))
            {
                OrdenEstadoSensor(Nivel + 1);
            }
            else
            {
                if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
                {
                    Global.Form.dataGridViewLiterale.Rows.RemoveAt(Global.Form.dataGridViewLiterale.Rows.Count - 2);
                }
                else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
                {
                    Global.Form.dataGridViewPalRe.Rows.RemoveAt(Global.Form.dataGridViewPalRe.Rows.Count - 2);
                }
                String Falla = "Componente no válido" + Componente.ObtenerLexema();
                String Causa = "El componente no es valido para formar la expresión";
                String Solucion = "agregar componente valido";

                Error Error = Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                GestorErrores.ObtenerInstancia().Agregar(Error);
                throw new Exception("Error tipo stopper durante el análisis sintactico, observe la terminal para la mas información sobre el error");
            }

            FormarSalida(Nivel, "<InstrucciónEntrada>");
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
                else
                {
                    if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewLiterale.Rows.RemoveAt(Global.Form.dataGridViewLiterale.Rows.Count - 2);
                    }
                    else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewPalRe.Rows.RemoveAt(Global.Form.dataGridViewPalRe.Rows.Count - 2);
                    }
                    String Falla = "Componente no válido" + Componente.ObtenerLexema();
                    String Causa = "El componente no es valido para formar la expresión";
                    String Solucion = "agregar componente valido";

                    Error Error = Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error);
                    throw new Exception("Error tipo stopper durante el análisis sintactico, observe la terminal para la mas información sobre el error");
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
                else
                {
                    if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewLiterale.Rows.RemoveAt(Global.Form.dataGridViewLiterale.Rows.Count - 2);
                    }
                    else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewPalRe.Rows.RemoveAt(Global.Form.dataGridViewPalRe.Rows.Count - 2);
                    }
                    String Falla = "Componente no válido" + Componente.ObtenerLexema();
                    String Causa = "El componente no es valido para formar la expresión";
                    String Solucion = "agregar componente valido";

                    Error Error = Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error);
                    throw new Exception("Error tipo stopper durante el análisis sintactico, observe la terminal para la mas información sobre el error");
                }
            }
            FormarSalida(Nivel, "<OrdenEstadoSensor>");
        }

        private void UnidadTemperatura(int Nivel)
        {
            FormarEntrada(Nivel, "UnidadTemperatura>");
            Avanzar();
            FormarSalida(Nivel, "<Unidademperatura>");
        }

        private void ValorTemperatura(int Nivel)
        {
            FormarEntrada(Nivel, "<ValorTemperatura>");
            Avanzar();
            FormarSalida(Nivel, "<ValorTemperatura>");
        }

        private void InstruccionSalida(int Nivel)
        {
            FormarEntrada(Nivel, "<InstrucciónSalida>");
            Avanzar();
            if (Categoria.VALOR_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
            {
                ValorTemperatura(Nivel + 1);
                if (Categoria.UNIDAD_TEMPERATURA.Equals(Componente.ObtenerCategoria()))
                {
                    UnidadTemperatura(Nivel + 1);
                }
                else
                {
                    if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewLiterale.Rows.RemoveAt(Global.Form.dataGridViewLiterale.Rows.Count - 2);
                    }
                    else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewPalRe.Rows.RemoveAt(Global.Form.dataGridViewPalRe.Rows.Count - 2);
                    }
                    String Falla = "Componente no válido" + Componente.ObtenerLexema();
                    String Causa = "El componente no es valido para formar la expresión";
                    String Solucion = "agregar componente valido";

                    Error Error = Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error);
                    throw new Exception("Error tipo stopper durante el análisis sintactico, observe la terminal para la mas información sobre el error");
                }
            }
            else if (Categoria.VALOR_ESTADO_SENSOR.Equals(Componente.ObtenerCategoria()))
            {
                EstadoSensor(Nivel + 1);
            }
            else
            {
                if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
                {
                    Global.Form.dataGridViewLiterale.Rows.RemoveAt(Global.Form.dataGridViewLiterale.Rows.Count - 2);
                }
                else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
                {
                    Global.Form.dataGridViewPalRe.Rows.RemoveAt(Global.Form.dataGridViewPalRe.Rows.Count - 2);
                }
                String Falla = "Componente no válido" + Componente.ObtenerLexema();
                String Causa = "El componente no es valido para formar la expresión";
                String Solucion = "agregar componente valido";

                Error Error = Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                GestorErrores.ObtenerInstancia().Agregar(Error);
                throw new Exception("Error tipo stopper durante el análisis sintactico, observe la terminal para la mas información sobre el error");
            }
            FormarSalida(Nivel, "<InstrucciónSalida>");
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
                else
                {
                    if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewLiterale.Rows.RemoveAt(Global.Form.dataGridViewLiterale.Rows.Count - 2);
                    }
                    else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewPalRe.Rows.RemoveAt(Global.Form.dataGridViewPalRe.Rows.Count - 2);
                    }
                    String Falla = "Componente no válido" + Componente.ObtenerLexema();
                    String Causa = "El componente no es valido para formar la expresión";
                    String Solucion = "agregar componente valido";

                    Error Error = Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error);
                    throw new Exception("Error tipo stopper durante el análisis sintactico, observe la terminal para la mas información sobre el error");
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
                else
                {
                    if (Tipo.LITERAL.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewLiterale.Rows.RemoveAt(Global.Form.dataGridViewLiterale.Rows.Count - 2);
                    }
                    else if (Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
                    {
                        Global.Form.dataGridViewPalRe.Rows.RemoveAt(Global.Form.dataGridViewPalRe.Rows.Count - 2);
                    }
                    String Falla = "Componente no válido" + Componente.ObtenerLexema();
                    String Causa = "El componente no es valido para formar la expresión";
                    String Solucion = "agregar componente valido";

                    Error Error = Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error);
                    throw new Exception("Error tipo stopper durante el análisis sintactico, observe la terminal para la mas información sobre el error");
                }
            }
            FormarSalida(Nivel, "<EstadoSensor>");
        }
        private void Orden(int Nivel)
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
                MessageBox.Show(Traza.ToString());
                //Console.WriteLine(Traza.ToString());
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
            if (Nivel != 1)
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
