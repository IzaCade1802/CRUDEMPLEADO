using EjemploConexioBDMySQL.Context;
using EjemploConexioBDMySQL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploConexioBDMySQL.Services
{
    public class EmpleadoService
    {
        public void Add(Empleado request)
        {
            try
            {
                using(var _context = new ApplicationDbContext())
                {
                    Empleado empleado = new Empleado() 
                { 
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaRegistro = DateTime.Now,
                    Correo = request.Correo,
                };
                    _context.Empleados.Add(empleado);
                    _context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }

        public Empleado View(int PKEmpleado)
        {
            try
            {
                var _context = new ApplicationDbContext();
                var per = _context.Empleados
                    .Where(s => s.PKEmpleado == PKEmpleado).FirstOrDefault();
                return per;
            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
        }

        public void Modific(Empleado request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var empl = _context.Empleados.Where(s => s.PKEmpleado == request.PKEmpleado).First<Empleado>();
                    empl.Nombre = request.Nombre;
                    empl.Apellido = request.Apellido;
                    empl.Correo = request.Correo;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }

        public void Delete(Empleado request)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var std = context.Empleados.Where(s => s.PKEmpleado == request.PKEmpleado).First<Empleado>();
                    context.Empleados.Remove(std);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
    }
}
