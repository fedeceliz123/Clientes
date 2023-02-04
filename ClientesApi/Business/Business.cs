using Business.Models;
using Business.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business
{
    public class Business
    {
        public static List<Validaciones> validaciones(InsertClienteDTO cliente)
        {
            List<Validaciones> list = new List<Validaciones>();

            if (string.IsNullOrEmpty(cliente.Nombres))
            {
                list.Add(new Validaciones {
                    validado = false,
                    campo = "Nombre",
                    mensaje = "El campo nombre es obligatorio"
                });
            }
            if (string.IsNullOrEmpty(cliente.Apellidos))
            {
                list.Add(new Validaciones
                {
                    validado = false,
                    campo = "Apellido",
                    mensaje = "El campo apellido es obligatorio"
                });
            }
            if (string.IsNullOrEmpty(cliente.CUIT))
            {
                list.Add(new Validaciones
                {
                    validado = false,
                    campo = "CUIT",
                    mensaje = "El campo CUIT es obligatorio"
                });
            }
            Int64 cuitN;
            if (!Int64.TryParse(cliente.CUIT, out cuitN) || cliente.CUIT.Length != 11)
            {
                list.Add(new Validaciones
                {
                    validado = false,
                    campo = "CUIT",
                    mensaje = "El campo CUIT no tiene el formato correcto"
                });
            }
            if (string.IsNullOrEmpty(cliente.telefonoCelular))
            {
                list.Add(new Validaciones
                {
                    validado = false,
                    campo = "Telefono Celular",
                    mensaje = "El campo Telefono es obligatorio"
                });
            }
            if (string.IsNullOrEmpty(cliente.email))
            {
                list.Add(new Validaciones
                {
                    validado = false,
                    campo = "Email",
                    mensaje = "El campo Email es obligatorio"
                });
            }

            if (!validarEmail(cliente.email))
            {
                list.Add(new Validaciones
                {
                    validado = false,
                    campo = "Email",
                    mensaje = "El campo Email no tiene el formato correcto"
                });
            }
            DateTime fecha;

            if (!DateTime.TryParse(cliente.FechaNacimiento.ToShortDateString(), out fecha))
            {
                list.Add(new Validaciones
                {
                    validado = false,
                    campo = "Fecha de nacimiento",
                    mensaje = "El campo Fecha de nacimiento no tiene el formato correcto"
                });
            }
        
            return list;

        }
        private static bool validarEmail(string email)
        {            
            return Regex.IsMatch(email, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }
    }
}
