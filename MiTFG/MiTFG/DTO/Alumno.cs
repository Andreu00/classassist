using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class Alumno
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string NumeroTelefono { get; set; }
        public int? Curso { get; set; }
        public int? FaltasDeAsistencia { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public int TutoresID { get; set; }

        // Constructor vacío
        public Alumno() { }

        // Constructor con parámetros
        public Alumno(int id, string nombre, string apellidos, string dni, string email, string numeroTelefono, int? curso, int? faltasDeAsistencia, DateTime? fechaDeNacimiento, int tutoresID)
        {
            ID = id;
            Nombre = nombre;
            Apellidos = apellidos;
            DNI = dni;
            Email = email;
            NumeroTelefono = numeroTelefono;
            Curso = curso;
            FaltasDeAsistencia = faltasDeAsistencia;
            FechaDeNacimiento = fechaDeNacimiento;
            TutoresID = tutoresID;
        }
    }
}
