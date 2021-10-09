using Compilador_sensor.ManejadorErrores;
using Compilador_sensor.TablaSimbolos;
using Compilador_sensor.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador_sensor.AnalisisLexico
{
    class AnalizadorLexico
    {
        private int Puntero;
        private int NumeroLineaActual;
        private Linea LineaActual;
        private String CaracterActual;
        private String Lexema;
        private int EstadoActual;
        private bool ContinuarAnalisis;
        private ComponenteLexico Componente;


        public AnalizadorLexico()
        {
            CargarNuevaLinea();
        }

        private void CargarNuevaLinea()
        {
            NumeroLineaActual = NumeroLineaActual + 1;
            LineaActual = Cache.ObtenerCache().ObtenerLinea(NumeroLineaActual);
            NumeroLineaActual = LineaActual.ObtenerNumero(); //Asegura que se quede en el fin de archivo
            Puntero = 0;

        }

        private void DevolverPuntero()
        {
            if (Puntero > 1)
            {
                Puntero = Puntero - 1;
            }
        }

        private void AvanzarPuntero()
        {
            Puntero = Puntero + 1;
        }

        private void LeerSiguienteCaracter()
        {
            if (LineaActual.esFinArchivo())
            {
                CaracterActual = LineaActual.ObtenerContenido();
            }
            else if (Puntero >= LineaActual.ObtenerLongitud())
            {
                Puntero = LineaActual.ObtenerLongitud() + 1;
                CaracterActual = "@FL@";
            }
            else
            {
                CaracterActual = LineaActual.ObtenerContenido().Substring(Puntero, 1); //oBTIENE LA PARTE DE LA CADENA DEL PUNTERO Y OBTIENE UN CARACTER
                /*if (!EsSlashR())
                {
                    AvanzarPuntero();
                }*/
                AvanzarPuntero();
            }
        }

        public void Reiniciar()
        {
            Lexema = "";
            CaracterActual = "";
            EstadoActual = 0;
            ContinuarAnalisis = true;
        }

        public void ReiniciarPuntero()
        {
            Puntero = 0;
            EstadoActual = 34;
            ContinuarAnalisis = true;
        }

        private void DevorarEspacioBlanco()
        {
            String BLANCO = " ";

            while (BLANCO.Equals(CaracterActual))
            {
                LeerSiguienteCaracter();
            }
        }

        private void FormarComponente(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionInicial, int PosicionFinal, Tipo Tipo)
        {
            Componente = ComponenteLexico.Crear(Lexema, Categoria, NumeroLinea, PosicionInicial, PosicionFinal, Tipo);
            Tabla.ObtenerInstancia().Agregar(Componente);
        }

        public ComponenteLexico DevolverComponenteLexico()
        {
            Reiniciar();
            while (ContinuarAnalisis)
            {
                switch (EstadoActual)
                {
                    case 0:
                        ProcesarEstado0();
                        break;
                    case 1:
                        ProcesarEstado1();
                        break;
                    case 2:
                        ProcesarEstado2();
                        break;
                    case 3:
                        ProcesarEstado3();
                        break;
                    case 4:
                        ProcesarEstado4();
                        break;
                    case 5:
                        ProcesarEstado5();
                        break;
                    case 6:
                        ProcesarEstado6();
                        break;
                    case 7:
                        ProcesarEstado7();
                        break;
                    case 8:
                        ProcesarEstado8();
                        break;
                    case 9:
                        ProcesarEstado9();
                        break;
                    case 10:
                        ProcesarEstado10();
                        break;
                    case 11:
                        ProcesarEstado11();
                        break;
                    case 12:
                        ProcesarEstado12();
                        break;
                    case 13:
                        ProcesarEstado13();
                        break;
                    case 14:
                        ProcesarEstado14();
                        break;
                    case 15:
                        ProcesarEstado15();
                        break;
                    case 16:
                        ProcesarEstado16();
                        break;
                    case 17:
                        ProcesarEstado17();
                        break;
                    case 18:
                        ProcesarEstado18();
                        break;
                    case 19:
                        ProcesarEstado19();
                        break;
                    case 20:
                        ProcesarEstado20();
                        break;
                    case 21:
                        ProcesarEstado21();
                        break;
                    case 22:
                        ProcesarEstado22();
                        break;
                    case 23:
                        ProcesarEstado23();
                        break;
                    case 24:
                        ProcesarEstado24();
                        break;
                    case 25:
                        ProcesarEstado25();
                        break;
                    case 26:
                        ProcesarEstado26();
                        break;
                    case 27:
                        ProcesarEstado27();
                        break;
                    case 28:
                        ProcesarEstado28();
                        break;
                    case 29:
                        ProcesarEstado29();
                        break;
                    case 30:
                        ProcesarEstado30();
                        break;
                    case 31:
                        ProcesarEstado31();
                        break;
                    case 32:
                        ProcesarEstado32();
                        break;
                    case 33:
                        ProcesarEstado33();
                        break;
                    case 34:
                        ProcesarEstado34();
                        break;
                    case 35:
                        ProcesarEstado35();
                        break;
                    case 36:
                        ProcesarEstado36();
                        break;
                    case 37:
                        ProcesarEstado37();
                        break;
                    case 38:
                        ProcesarEstado38();
                        break;
                    case 39:
                        ProcesarEstado39();
                        break;
                    case 40:
                        ProcesarEstado40();
                        break;
                    case 41:
                        ProcesarEstado41();
                        break;
                    case 42:
                        ProcesarEstado42();
                        break;
                    case 43:
                        ProcesarEstado43();
                        break;
                    case 44:
                        ProcesarEstado44();
                        break;
                    case 45:
                        ProcesarEstado45();
                        break;
                    case 46:
                        ProcesarEstado46();
                        break;
                    case 47:
                        ProcesarEstado47();
                        break;
                    case 48:
                        ProcesarEstado48();
                        break;
                    case 49:
                        ProcesarEstado49();
                        break;
                    case 50:
                        ProcesarEstado50();
                        break;
                    case 51:
                        ProcesarEstado51();
                        break;
                    case 52:
                        ProcesarEstado52();
                        break;
                    case 53:
                        ProcesarEstado53();
                        break;
                    case 54:
                        ProcesarEstado54();
                        break;
                    case 55:
                        ProcesarEstado55();
                        break;
                    case 56:
                        ProcesarEstado56();
                        break;
                    case 57:
                        ProcesarEstado57();
                        break;
                    case 58:
                        ProcesarEstado58();
                        break;
                    case 59:
                        ProcesarEstado59();
                        break;
                    case 60:
                        ProcesarEstado60();
                        break;
                    case 61:
                        ProcesarEstado61();
                        break;
                    case 62:
                        ProcesarEstado62();
                        break;
                    case 63:
                        ProcesarEstado63();
                        break;
                    case 64:
                        ProcesarEstado64();
                        break;
                    case 65:
                        ProcesarEstado65();
                        break;
                    case 66:
                        ProcesarEstado66();
                        break;
                    case 67:
                        ProcesarEstado67();
                        break;
                    case 68:
                        ProcesarEstado68();
                        break;
                    case 69:
                        ProcesarEstado69();
                        break;
                    case 70:
                        ProcesarEstado70();
                        break;
                    case 71:
                        ProcesarEstado71();
                        break;
                    case 72:
                        ProcesarEstado72();
                        break;
                    case 73:
                        ProcesarEstado73();
                        break;
                    case 74:
                        ProcesarEstado74();
                        break;
                    case 75:
                        ProcesarEstado75();
                        break;
                    case 76:
                        ProcesarEstado76();
                        break;
                    case 77:
                        ProcesarEstado77();
                        break;
                    case 78:
                        ProcesarEstado78();
                        break;
                    case 79:
                        ProcesarEstado79();
                        break;
                    case 80:
                        ProcesarEstado80();
                        break;
                    case 81:
                        ProcesarEstado81();
                        break;
                    case 82:
                        ProcesarEstado82();
                        break;
                    case 83:
                        ProcesarEstado83();
                        break;
                    case 84:
                        ProcesarEstado84();
                        break;
                    case 85:
                        ProcesarEstado85();
                        break;
                    case 86:
                        ProcesarEstado86();
                        break;
                    case 87:
                        ProcesarEstado87();
                        break;
                    case 88:
                        ProcesarEstado88();
                        break;
                    case 89:
                        ProcesarEstado89();
                        break;
                    case 90:
                        ProcesarEstado90();
                        break;
                    case 91:
                        ProcesarEstado91();
                        break;
                }

            }
            return Componente;
        }

        private void ProcesarEstado0()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();

            if (EsCaracterO())
            {
                EstadoActual = 1;
                FormarLexema();
            }
            else if (EsCaracterI())
            {
                EstadoActual = 7;
                FormarLexema();
            }
            else if (EsCaracterD())
            {
                EstadoActual = 21;
                FormarLexema();
            }
            else if (EsCaracterG())
            {
                EstadoActual = 40;
                FormarLexema();
            }
            else if (EsCaracterC() || EsCaracterF() || EsCaracterK() || EsCaracterR())
            {
                EstadoActual = 59;
                FormarLexema();
            }
            else if (EsGuionMedio())
            {
                EstadoActual = 60;
                FormarLexema();
            }
            else if (EsCaracterS())
            {
                EstadoActual = 32;
                FormarLexema();
            }
            else if (EsDigitoBinario())
            {
                EstadoActual = 55;
                FormarLexema();
            }
            else if (EsFinLinea())
            {
                EstadoActual = 67;
            }
            else if (LineaActual.esFinArchivo())
            {
                EstadoActual = 66;
                FormarLexema();
            }else if (EsSlashR())
            {
                EstadoActual = 67;
            }
            else
            {
                EstadoActual = 68;
            }
        }

        private void ProcesarEstado1()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterU())
            {
                EstadoActual = 2;
                FormarLexema();
            }
            else if (EsCaracterN())
            {
                EstadoActual = 3;
                FormarLexema();
            }
            else if (EsCaracterF())
            {
                EstadoActual = 5;
                FormarLexema();
            }
            else
            {
                EstadoActual = 70;
            }
        }

        private void ProcesarEstado2()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterT())
            {
                EstadoActual = 4;
                FormarLexema();
            }
            else
            {
                EstadoActual = 71;
            }
        }

        private void ProcesarEstado3()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.ESTADO_SENSOR, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.LITERAL);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado4()
        {

            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.SALIDA, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.PALABRA_RESERVADA);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado5()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterF())
            {
                EstadoActual = 6;
                FormarLexema();
            }
            else
            {
                EstadoActual = 72;
            }
        }

        private void ProcesarEstado6()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.ESTADO_SENSOR, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.LITERAL);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado7()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterN())
            {
                EstadoActual = 8;
                FormarLexema();
            }
            else
            {
                EstadoActual = 73;
            }
        }

        private void ProcesarEstado8()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterC())
            {
                EstadoActual = 10;
                FormarLexema();
            }
            else if (EsCaracterI())
            {
                EstadoActual = 19;
                FormarLexema();
            }
            else if (EsCaracterValido())
            {
                EstadoActual = 9;
            }
            else
            {
                EstadoActual = 68;
            }
        }

        private void ProcesarEstado9()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.ENTRADA, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.PALABRA_RESERVADA);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado10()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterR())
            {
                EstadoActual = 11;
                FormarLexema();
            }
            else
            {
                EstadoActual = 76;
            }
        }

        private void ProcesarEstado11()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterE())
            {
                EstadoActual = 12;
                FormarLexema();
            }
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado12()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterM())
            {
                EstadoActual = 13;
                FormarLexema();
            }
            else
            {
                EstadoActual = 78;
            }
        }

        private void ProcesarEstado13()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterE())
            {
                EstadoActual = 14;
                FormarLexema();
            } 
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado14()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterN())
            {
                EstadoActual = 15;
                FormarLexema();
            }
            else
            {
                EstadoActual = 73;
            }
        }

        private void ProcesarEstado15()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterT())
            {
                EstadoActual = 16;
                FormarLexema();
            }
            else
            {
                EstadoActual = 73;
            }
        }

        private void ProcesarEstado16()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterA())
            {
                EstadoActual = 17;
                FormarLexema();
            }
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado17()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterR())
            {
                EstadoActual = 18;
                FormarLexema();
            }
            else
            {
                EstadoActual = 76;
            }
        }

        private void ProcesarEstado18()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.INCREMENTAR, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.PALABRA_RESERVADA);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado19()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterT())
            {
                EstadoActual = 20;
                FormarLexema();
            }
            else
            {
                EstadoActual = 71;
            }
        }

        private void ProcesarEstado20()
        {
            LeerSiguienteCaracter();
            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.ENCENDER_SENSOR, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.PALABRA_RESERVADA);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado21()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterE())
            {
                EstadoActual = 22;
                FormarLexema();
            }
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado22()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterC())
            {
                EstadoActual = 23;
                FormarLexema();
            }
            else
            {
                EstadoActual = 82;
            }
        }

        private void ProcesarEstado23()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterR())
            {
                EstadoActual = 24;
                FormarLexema();
            }
            else
            {
                EstadoActual = 76;
            }
        }

        private void ProcesarEstado24()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterE())
            {
                EstadoActual = 25;
                FormarLexema();
            }
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado25()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterM())
            {
                EstadoActual = 26;
                FormarLexema();
            }
            else
            {
                EstadoActual = 78;
            }
        }

        private void ProcesarEstado26()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterE())
            {
                EstadoActual = 27;
                FormarLexema();
            }
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado27()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterN())
            {
                EstadoActual = 28;
                FormarLexema();
            }
            else
            {
                EstadoActual = 73;
            }
        }

        private void ProcesarEstado28()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterT())
            {
                EstadoActual = 29;
                FormarLexema();
            }
            else
            {
                EstadoActual = 74;
            }
        }

        private void ProcesarEstado29()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterA())
            {
                EstadoActual = 30;
                FormarLexema();
            }
            else
            {
                EstadoActual = 79;
            }
        }

        private void ProcesarEstado30()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterR())
            {
                EstadoActual = 31;
                FormarLexema();
            }
            else
            {
                EstadoActual = 76;
            }
        }

        private void ProcesarEstado31()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.DECREMENTAR, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.PALABRA_RESERVADA);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado32()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterH())
            {
                EstadoActual = 33;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado33()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterU())
            {
                EstadoActual = 34;
                FormarLexema();
            }
            else
            {
                EstadoActual = 80;
            }
        }

        private void ProcesarEstado34()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterT())
            {
                EstadoActual = 35;
                FormarLexema();
            }
            else
            {
                EstadoActual = 71;
            }
        }

        private void ProcesarEstado35()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterD())
            {
                EstadoActual = 36;
                FormarLexema();
            }
            else
            {
                EstadoActual = 88;
            }
        }

        private void ProcesarEstado36()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterO())
            {
                EstadoActual = 37;
                FormarLexema();
            }
            else
            {
                EstadoActual = 86;
            }
        }

        private void ProcesarEstado37()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterW())
            {
                EstadoActual = 38;
                FormarLexema();
            }
            else
            {
                EstadoActual = 89;
            }
        }

        private void ProcesarEstado38()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterN())
            {
                EstadoActual = 39;
                FormarLexema();
            }
            else
            {
                EstadoActual = 73;
            }
        }

        private void ProcesarEstado39()
        {

            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.APAGAR_SENSOR, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.PALABRA_RESERVADA);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado40()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterE())
            {
                EstadoActual = 41;
                FormarLexema();
            }
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado41()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterT())
            {
                EstadoActual = 42;
                FormarLexema();
            }
            else
            {
                EstadoActual = 71;
            }
        }

        private void ProcesarEstado42()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsGuionBajo())
            {
                EstadoActual = 43;
                FormarLexema();
            }
            else
            {
                EstadoActual = 90;
            }
        }

        private void ProcesarEstado43()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterT())
            {
                EstadoActual = 44;
                FormarLexema();
            }
            else
            {
                EstadoActual = 71;
            }
        }

        private void ProcesarEstado44()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterE())
            {
                EstadoActual = 45;
                FormarLexema();
            }
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado45()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterM())
            {
                EstadoActual = 46;
                FormarLexema();
            }
            else
            {
                EstadoActual = 78;
            }
        }

        private void ProcesarEstado46()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterP())
            {
                EstadoActual = 47;
                FormarLexema();
            }
            else
            {
                EstadoActual = 77;
            }
        }

        private void ProcesarEstado47()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterE())
            {
                EstadoActual = 48;
                FormarLexema();
            }
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado48()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterR())
            {
                EstadoActual = 49;
                FormarLexema();
            }
            else
            {
                EstadoActual = 76;
            }
        }

        private void ProcesarEstado49()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterA())
            {
                EstadoActual = 50;
                FormarLexema();
            }
            else
            {
                EstadoActual = 79;
            }
        }

        private void ProcesarEstado50()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterT())
            {
                EstadoActual = 51;
                FormarLexema();
            }
            else
            {
                EstadoActual = 71;
            }
        }

        private void ProcesarEstado51()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterU())
            {
                EstadoActual = 52;
                FormarLexema();
            }
            else
            {
                EstadoActual = 80;
            }
        }

        private void ProcesarEstado52()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterR())
            {
                EstadoActual = 53;
                FormarLexema();
            }
            else
            {
                EstadoActual = 76;
            }
        }

        private void ProcesarEstado53()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCaracterE())
            {
                EstadoActual = 54;
                FormarLexema();
            }
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado54()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.OBTENER_TEMPERATURA, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.PALABRA_RESERVADA);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado55()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsDigitoBinario())
            {
                EstadoActual = 56;
                FormarLexema();
            }
            else
            {
                EstadoActual = 91;
            }
        }

        private void ProcesarEstado56()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsDigitoBinario())
            {
                EstadoActual = 57;
                FormarLexema();
            }
            else
            {
                EstadoActual = 91;
            }
        }

        private void ProcesarEstado57()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsDigitoBinario())
            {
                EstadoActual = 58;
                FormarLexema();
            }
            else
            {
                EstadoActual = 91;
            }
        }

        private void ProcesarEstado58()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.VALOR_TEMPERATURA, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.LITERAL);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado59()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.UNIDAD_TEMPERATURA, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.LITERAL);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado60()
        {
            LeerSiguienteCaracter();
            //DevorarEspacioBlanco();
            if (EsCero())
            {
                EstadoActual = 61;
                FormarLexema();
            }
            else if (EsUno())
            {
                EstadoActual = 63;
                FormarLexema();
            }
            else
            {
                EstadoActual = 91;
            }
        }

        private void ProcesarEstado61()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsCero())
            {
                EstadoActual = 62;
                FormarLexema();
            }
            else
            {
                EstadoActual = 84;
            }
        }

        private void ProcesarEstado62()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsGuionMedio())
            {
                EstadoActual = 65;
                FormarLexema();
            }
            else
            {
                EstadoActual = 85;
            }
        }

        private void ProcesarEstado63()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsUno())
            {
                EstadoActual = 64;
                FormarLexema();
            }
            else
            {
                EstadoActual = 83;
            }
        }

        private void ProcesarEstado64()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();
            if (EsGuionMedio())
            {
                EstadoActual = 65;
                FormarLexema();
            }
            else
            {
                EstadoActual = 85;
            }
        }

        private void ProcesarEstado65()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.VALOR_ESTADO_SENSOR, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.LITERAL);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado66()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int posicionaFinal = Puntero - 1;

            FormarComponente(Lexema, Categoria.FIN_ARCHIVO, NumeroLineaActual, PosicionInicial, posicionaFinal, Tipo.SIMBOLO);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado67()
        {
            EstadoActual = 0;
            CargarNuevaLinea();
        }

        private void ProcesarEstado68()
        {
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema.");
            this.ContinuarAnalisis = false;
        }

        private void ProcesarEstado69()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema.");
        }

        private void ProcesarEstado70()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una U, N o F");
        }

        private void ProcesarEstado71()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una T");
        }

        private void ProcesarEstado72()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una F");
        }

        private void ProcesarEstado73()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una N");
        }

        private void ProcesarEstado74()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una T");
        }

        private void ProcesarEstado75()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una E");
        }

        private void ProcesarEstado76()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una R");
        }

        private void ProcesarEstado77()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una P");
        }

        private void ProcesarEstado78()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una M");
        }

        private void ProcesarEstado79()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una A");
        }

        private void ProcesarEstado80()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una U");
        }

        private void ProcesarEstado81()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una I");
        }

        private void ProcesarEstado82()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una C");
        }

        private void ProcesarEstado83()
        {
            DevolverPuntero();
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            FormarComponente(Lexema + ObtenerValorAutcompletado(Lexema), Categoria.VALOR_TEMPERATURA, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            Tabla.ObtenerInstancia().Agregar(Componente);

            string Falla = "Símbolo no válido: " + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y se esperaba un 1.";
            string Solucion = "Asegúrese de haber escrito un 1";

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);

            GestorErrores.ObtenerInstancia().Agregar(Error);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado84()
        {
            DevolverPuntero();
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            FormarComponente(Lexema + ObtenerValorAutcompletado(Lexema) , Categoria.VALOR_TEMPERATURA, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            Tabla.ObtenerInstancia().Agregar(Componente);

            string Falla = "Símbolo no válido: " + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y se esperaba un 0.";
            string Solucion = "Asegúrese de haber escrito un 0";

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);

            GestorErrores.ObtenerInstancia().Agregar(Error);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado85()
        {
            DevolverPuntero();
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            
            FormarComponente(Lexema + ObtenerValorAutcompletado(Lexema), Categoria.VALOR_TEMPERATURA, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            Tabla.ObtenerInstancia().Agregar(Componente);

            string Falla = "Símbolo no válido: " + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y se esperaba un -";
            string Solucion = "Asegúrese de haber escrito un -";

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);

            GestorErrores.ObtenerInstancia().Agregar(Error);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado86()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una O");
        }

        private void ProcesarEstado87()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una H");
        }

        private void ProcesarEstado88()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una D");
        }

        private void ProcesarEstado89()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba una W");
        }

        private void ProcesarEstado90()
        {
            DevolverPuntero();
            throw new Exception("El caracter: " + CaracterActual + " no es válido para la formación del lexema." +
                "Se esperaba un _");
        }

        private void ProcesarEstado91()
        {
            DevolverPuntero();
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            if (!Lexema.Contains("-"))
            {
                FormarComponente(ObtenerValorAutcompletado(Lexema) + Lexema, Categoria.VALOR_TEMPERATURA, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);
            }
            else
            {
                FormarComponente(Lexema + ObtenerValorAutcompletado(Lexema), Categoria.VALOR_TEMPERATURA, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);
            }

            Tabla.ObtenerInstancia().Agregar(Componente);

            string Falla = "Símbolo no válido: " + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y se esperaba un 1 o un 0.";
            string Solucion = "Asegúrese de haber escrito un 1 o un 0";

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);

            GestorErrores.ObtenerInstancia().Agregar(Error);

            ContinuarAnalisis = false;
        }

        public string ObtenerValorAutcompletado(string Lexema)
        {
            string valorDefecto = "";

            if (Lexema.Length == 1 && !Lexema.Contains("-"))
            {
                valorDefecto = "000";
            }
            else if (Lexema.Length == 2 && !Lexema.Contains("-"))
            {
                valorDefecto = "00";
            }
            else if (Lexema.Length == 3 && !Lexema.Contains("-"))
            {
                valorDefecto = "0";
            } else if(Lexema.Length == 1 && Lexema.Contains("-"))
            {
                valorDefecto = "00-";
            }
            else if (Lexema.Length == 2 && Lexema.Contains("-"))
            {
                if (Lexema.Contains("1"))
                {
                    valorDefecto = "1-";
                }
                else if (Lexema.Contains("0"))
                {
                    valorDefecto = "0-";
                }
            }
            else if (Lexema.Length == 3 && Lexema.Contains("-"))
            {
                valorDefecto = "-";
            }
            return valorDefecto;
        }

        private bool EsGuionBajo()
        {
            return "_".Equals(CaracterActual);
        }

        private bool EsDigitoBinario()
        {
            return "0".Equals(CaracterActual) || "1".Equals(CaracterActual); ;
        }

        private bool EsCaracterO()
        {
            return "O".Equals(CaracterActual);
        }

        private bool EsCaracterU()
        {
            return "U".Equals(CaracterActual);
        }

        private bool EsCaracterT()
        {
            return "T".Equals(CaracterActual);
        }

        private bool EsCaracterI()
        {
            return "I".Equals(CaracterActual);
        }

        private bool EsCaracterN()
        {
            return "N".Equals(CaracterActual);
        }

        private bool EsCaracterF()
        {
            return "F".Equals(CaracterActual);
        }

        private bool EsCaracterC()
        {
            return "C".Equals(CaracterActual);
        }

        private bool EsCaracterK()
        {
            return "K".Equals(CaracterActual);
        }

        private bool EsCaracterR()
        {
            return "R".Equals(CaracterActual);
        }

        private bool EsGuionMedio()
        {
            return "-".Equals(CaracterActual);
        }

        private bool EsCero()
        {
            return "0".Equals(CaracterActual);
        }

        private bool EsUno()
        {
            return "1".Equals(CaracterActual);
        }

        private bool EsCaracterM()
        {
            return "M".Equals(CaracterActual);
        }

        private bool EsCaracterE()
        {
            return "E".Equals(CaracterActual);
        }

        private bool EsCaracterA()
        {
            return "A".Equals(CaracterActual);
        }

        private bool EsCaracterD()
        {
            return "D".Equals(CaracterActual);
        }

        private bool EsCaracterG()
        {
            return "G".Equals(CaracterActual);
        }

        private bool EsCaracterP()
        {
            return "P".Equals(CaracterActual);
        }

        private bool EsCaracterS()
        {
            return "S".Equals(CaracterActual);
        }

        private bool EsCaracterH()
        {
            return "H".Equals(CaracterActual);
        }

        private bool EsCaracterW()
        {
            return "W".Equals(CaracterActual);
        }

        private bool EsFinLinea()
        {
            return "@FL@".Equals(CaracterActual) || EsSlashR();
        }

        private void FormarLexema()
        {
            Lexema = Lexema + CaracterActual;
        }

        private bool EsCaracterValido()
        {
            return EsCaracterA() || EsCaracterC() || EsCaracterD() || EsCaracterE()
                || EsCaracterF() || EsCaracterG() || EsCaracterH() || EsCaracterI()
                || EsCaracterK() || EsCaracterM() || EsCaracterN() || EsCaracterO()
                || EsCaracterP() || EsCaracterR() || EsCaracterS() || EsCaracterT()
                || EsCaracterU() || EsCaracterW() || EsDigitoBinario() || EsFinLinea()
                || EsGuionBajo() || EsGuionMedio() || LineaActual.esFinArchivo();
                //|| EsSlashR();
        }

        private bool EsSlashR()
        {
            return "\r".Equals(CaracterActual);
        }
    }
}
