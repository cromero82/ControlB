using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.General
{
    public class Jresult
    {
        public dynamic Data { get; set; }
        public bool Success { get; set; }
        public string HtmlSuccess { get; set; }
        public String Message { get; set; }
        public Jresult() { Success = false; Message = "Transacción no pudo ser completada, se presento un error interno"; }

       
        public void SetError(string Titulo)
        {
            Success = false; //SuccessResult.Error;
            HtmlSuccess = "Error";
            Message = Titulo;
        }

        //public void SetWarning(string Titulo)
        //{
        //    Success = SuccessResult.Warning;
        //    SuccessString = "Warning";
        //    Message = Titulo;
        //}

        public void SetOk(string Titulo)
        {
            Success = true;  //SuccessResult.Ok;
            HtmlSuccess = "Ok";
            Message = Titulo;
        }

        private void MensajeError(Exception ex)
        {
            if (ex.Message.Equals("Error al actualizar las entradas. Vea la excepción interna para obtener detalles."))
            {
                Message = ex.InnerException.InnerException.Message;
            }
            else
            {
                Message = ex.Message;
            }

        }
        
    }
       
}
