using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Validations
{
    public class CheckValidFecha : ValidationAttribute
    {
        public CheckValidFecha()
        {
            ErrorMessage = "La fecha debe ser mayor a la actual.";
        }
        public override bool IsValid(Object value)
        {
            DateTime hoy = DateTime.Now;
            if (hoy <= (DateTime)value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}