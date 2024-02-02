using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable

namespace BlazorCrud.Shared
{
    public class APIResponse<TEntity>
    {
        // propiedades exitosas
        public HttpStatusCode CodigoEstado { get; set; }

        public bool EsExitoso { get; set; }

        public TEntity Resultado { get; set; }

        public int TotalRegistros { get; set; }

        //_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

        //propiedades fallidas
        public string MensajeError { get; set; }

        public List<string> MensajesError { get; set; }
    }
}
