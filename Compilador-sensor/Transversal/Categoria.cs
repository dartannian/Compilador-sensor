using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_sensor.Transversal
{
    public enum Categoria
    {
        SALIDA, ENTRADA, VALOR_TEMPERATURA, UNIDAD_TEMPERATURA, ESTADO_SENSOR, VALOR_ESTADO_SENSOR, INCREMENTAR,
        DECREMENTAR, OBTENER_TEMPERATURA, APAGAR_SENSOR, ENCENDER_SENSOR, FIN_LINEA, FIN_ARCHIVO
    }
}
