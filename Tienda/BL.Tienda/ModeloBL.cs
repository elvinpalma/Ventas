using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Tienda
{
    public class ModeloBL
    {
        public BindingList<Modelo> ListaModelos { get; set; } 

        public ModeloBL()
        {
            ListaModelos = new BindingList<Modelo>();

            var modelo1 = new Modelo();
            modelo1.Id = 1;
            modelo1.Descipcion = "Vinyl Records Album: My Way";
            modelo1.Artista = "Frank Sinatra";
            modelo1.Precio = 2000;
            modelo1.Existencia = 15;
            modelo1.Activo = true;

            ListaModelos.Add(modelo1);

            var modelo2 = new Modelo();
            modelo2.Id = 2;
            modelo2.Descipcion = "Vinyl Records Album: Let it be";
            modelo2.Artista = "The Beatles";
            modelo2.Precio = 3000;
            modelo2.Existencia = 16;
            modelo2.Activo = true;

            ListaModelos.Add(modelo2);

            var modelo3 = new Modelo();
            modelo3.Id = 3;
            modelo3.Descipcion = "Vinyl Records Album: The Wall";
            modelo3.Artista = "Pink Floy";
            modelo3.Precio = 3500;
            modelo3.Existencia = 25;
            modelo3.Activo = true;

            ListaModelos.Add(modelo3);
        }

        public BindingList<Modelo> ObtenerModelos()
        {
            return ListaModelos;
        }

        public Resultado GuardarModelo(Modelo modelo)
        {
            var resultado = Validar(modelo);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            if (modelo.Id == 0)
            {
                modelo.Id = ListaModelos.Max(item => item.Id) + 1;
            }

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarModelo()
        {
            var nuevoModelo = new Modelo();
            ListaModelos.Add(nuevoModelo);
        }

        public bool EliminarModelo(int id)
        {
            foreach (var modelo in ListaModelos)
            {
                if (modelo.Id == id)
                {
                    ListaModelos.Remove(modelo);
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Modelo modelo)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(modelo.Descipcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripción";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(modelo.Artista) == true)
            {
                resultado.Mensaje = "Ingrese un artista";
                resultado.Exitoso = false;
            }

            if (modelo.Existencia < 0)
            {
                resultado.Mensaje = "La existencia debe ser mayor que cero";
                resultado.Exitoso = false;
            }

            if (modelo.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor que cero";
                resultado.Exitoso = false;
            }

            return resultado;
        }
    }

    public class Modelo
    {
        public int Id { get; set; }
        public string Descipcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
        public string Artista { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
