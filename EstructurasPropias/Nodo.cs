using System;
using System.Collections.Generic;
using System.Text;

namespace SoundCoreEngine.EstructurasPropias
{
    /// <summary>
    /// Representa un nodo genérico dentro de una Lista Enlazada Simple.
    /// Al ser genérico <T>, puede guardar cualquier tipo de dato (por ejemplo, Pista).
    /// </summary>
    public class Nodo<T>
    {
        // El dato o valor que almacena el nodo
        public T Valor { get; set; }

        // La referencia/puntero hacia el siguiente nodo en la lista (o null si es el último)
        public Nodo<T>? Siguiente { get; set; }

        // Constructor para inicializar el nodo con un valor
        public Nodo(T valor)
        {
            Valor = valor;
            Siguiente = null; // Al crearse, aún no apunta a ningún otro nodo
        }
    }
}
