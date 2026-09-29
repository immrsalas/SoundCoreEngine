using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SoundCoreEngine.EstructurasPropias
{
    /// <summary>
    /// Lista Enlazada Simple construida desde cero con punteros/referencias directas.
    /// Implementa IEnumerable<T> para permitir el uso de foreach y enlace a controles como DataGridView.
    /// </summary>
    public class ListaSimpleEnlazada<T> : IEnumerable<T>
    {
        // Puntero/Referencia al primer elemento de la lista
        public Nodo<T>? Cabeza { get; private set; }

        // Contador de elementos en la lista
        public int Conteo { get; private set; }

        // Propiedad que indica si la lista está vacía
        public bool EstaVacia => Cabeza == null;

        // =========================================================================
        // 1. Inserción al final: Recorre la lista hasta encontrar el último nodo O(n)
        // =========================================================================
        public void AgregarAlFinal(T valor)
        {
            var nuevoNodo = new Nodo<T>(valor);

            if (EstaVacia)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                var actual = Cabeza!;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente; // Avanza hasta el último nodo
                }
                actual.Siguiente = nuevoNodo; // Conecta el nuevo nodo al final
            }

            Conteo++;
        }

        // =========================================================================
        // 2. Up Next: Inserción inmediata tras la cabeza O(1)
        // =========================================================================
        public void ReproducirSiguiente(T valor)
        {
            var nuevoNodo = new Nodo<T>(valor);

            if (EstaVacia)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = Cabeza!.Siguiente;
                Cabeza.Siguiente = nuevoNodo;
            }

            Conteo++;
        }

        // =========================================================================
        // 3. Desencolar pista actual (Eliminar Cabeza) O(1)
        // =========================================================================
        public T AvanzarPista()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La cola de reproducción está vacía.");

            T valor = Cabeza!.Valor;
            Cabeza = Cabeza.Siguiente; // La cabeza ahora pasa a ser el siguiente nodo
            Conteo--;
            return valor;
        }

        // =========================================================================
        // 4. Inversión In-Place: Reorienta punteros O(n) tiempo, O(1) memoria
        // =========================================================================
        public void Invertir()
        {
            Nodo<T>? previo = null;
            Nodo<T>? actual = Cabeza;
            Nodo<T>? siguiente = null;

            while (actual != null)
            {
                siguiente = actual.Siguiente; // 1. Guarda la referencia del resto de la lista
                actual.Siguiente = previo;    // 2. Invierte la dirección del puntero
                previo = actual;              // 3. Avanza 'previo' un paso
                actual = siguiente;           // 4. Avanza 'actual' un paso
            }

            Cabeza = previo; // La nueva cabeza es el que era el último nodo
        }

        // =========================================================================
        // 5. Inserción ordenada por un criterio (ej. BPM) O(n)
        // =========================================================================
        public void InsertarOrdenado(T valor, Comparison<T> comparador)
        {
            var nuevo = new Nodo<T>(valor);

            // Si está vacía o el nuevo valor debe ir antes que la cabeza
            if (EstaVacia || comparador(valor, Cabeza!.Valor) < 0)
            {
                nuevo.Siguiente = Cabeza;
                Cabeza = nuevo;
                Conteo++;
                return;
            }

            var actual = Cabeza;
            while (actual.Siguiente != null && comparador(valor, actual.Siguiente.Valor) >= 0)
            {
                actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
            Conteo++;
        }

        // =========================================================================
        // 6. Depurar duplicados sin estructuras auxiliares O(n^2) tiempo, O(1) espacio
        // =========================================================================
        public void DepurarDuplicados(Func<T, T, bool> sonIguales)
        {
            var actual = Cabeza;

            while (actual != null)
            {
                var corredor = actual;
                while (corredor.Siguiente != null)
                {
                    if (sonIguales(actual.Valor, corredor.Siguiente.Valor))
                    {
                        // Salta el nodo duplicado para desconectarlo de la memoria
                        corredor.Siguiente = corredor.Siguiente.Siguiente;
                        Conteo--;
                    }
                    else
                    {
                        corredor = corredor.Siguiente;
                    }
                }
                actual = actual.Siguiente;
            }
        }

        // Limpia toda la lista
        public void Limpiar()
        {
            Cabeza = null;
            Conteo = 0;
        }

        // =========================================================================
        // Implementación de IEnumerable<T> con yield return para poder usar foreach
        // =========================================================================
        public IEnumerator<T> GetEnumerator()
        {
            var actual = Cabeza;
            while (actual != null)
            {
                yield return actual.Valor; // Retorna el valor actual
                actual = actual.Siguiente;  // Avanza al siguiente nodo
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
