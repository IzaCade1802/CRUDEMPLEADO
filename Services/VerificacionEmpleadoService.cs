using EjemploConexioBDMySQL.Context;
using EjemploConexioBDMySQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploConexioBDMySQL.Services
{
    public class VerificacionEmpleadoService
    {
        public string VerifyEmpleado(Empleado request)
        {
			try
			{
                var _context = new ApplicationDbContext();
                var per = _context.Empleados
                    .Where(s => s.Apellido == request.Apellido && s.Correo == request.Correo)
                    .ToList();
                return per.Count.ToString();
            }
			catch (Exception ex)
			{

				throw new Exception("Error: ", ex);
			}
        }

        public string VerifyID(Empleado request)
        {
            try
            {
                var _context = new ApplicationDbContext();
                var per = _context.Empleados
                    .Where(s => s.PKEmpleado == request.PKEmpleado).ToList();
                return per.Count.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
        }
    }
}
