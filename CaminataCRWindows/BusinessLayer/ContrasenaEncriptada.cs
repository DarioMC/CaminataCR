using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ContrasenaEncriptada
    {
        private string contrasenaEncriptadaTira;
        public ContrasenaEncriptada(string contrasenaNoEncriptada)
        {
            using (SHA512 sham = new SHA512Managed())
            {
                var data = Encoding.UTF8.GetBytes(contrasenaNoEncriptada);
                var contrasenaEncriptada = sham.ComputeHash(data);
                //contrasenaEncriptadaTira = contrasenaEncriptada.ToString();
                // convierte el array de bits a una tira hexadecimal
                string hex = BitConverter.ToString(contrasenaEncriptada);
                contrasenaEncriptadaTira = hex.Replace("-", "");
            }
        }

        public string getContrasenaEncriptadaTira()
        {
            return contrasenaEncriptadaTira;
        }
    }
}
