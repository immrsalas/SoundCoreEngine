// ============================================================================
// Instituto Tecnológico Superior de Monclova (TecNM)
// Materia: Estructura de Datos
// Proyecto: SoundCore Engine v2.0 - DJ Set Controller
// 
// Integrantes:
// - Martín Alejandro Salas Bernal (Número de Control: I25050383])
// 
// Fecha: 29 de Septiembre de 2026
// 
// ============================================================================



using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SoundCoreEngine.EstructurasPropias
{
    public class ListaSimpleEnlazada<T> : IEnumerable<T>
    {
        // Referencia al primer nodo
        public Nodo<T>? Cabeza { get; private set; }

        // NUEVO: Referencia directa al último nodo para lograr inserción O(1)
        public Nodo<T>? Cola { get; private set; }

        public int Conteo { get; private set; }

        public bool EstaVacia => Cabeza == null;

        // =========================================================================
        // 1. Inserción al final optimizada a O(1) utilizando el puntero 'Cola'
        // =========================================================================
        public void AgregarAlFinal(T valor)
        {
            var nuevoNodo = new Nodo<T>(valor);

            if (EstaVacia)
            {
                Cabeza = nuevoNodo;
                Cola = nuevoNodo; // La cabeza y la cola son el mismo nodo al inicio
            }
            else
            {
                Cola!.Siguiente = nuevoNodo; // Conecta directo sin bucles O(1)
                Cola = nuevoNodo;            // Actualiza la cola al nuevo nodo
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
                Cola = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = Cabeza!.Siguiente;
                Cabeza.Siguiente = nuevoNodo;

                // Si se insertó después de la cabeza y la cabeza era el único elemento,
                // el nuevo nodo ahora es la cola.
                if (Cabeza == Cola)
                {
                    Cola = nuevoNodo;
                }
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
            Cabeza = Cabeza.Siguiente;
            Conteo--;

            if (EstaVacia)
            {
                Cola = null; // Si se vació la lista, limpiamos la cola
            }

            return valor;
        }

        // =========================================================================
        // 4. Inversión In-Place O(n) tiempo, O(1) memoria
        // =========================================================================
        public void Invertir()
        {
            Nodo<T>? previo = null;
            Nodo<T>? actual = Cabeza;
            Nodo<T>? siguiente = null;

            // Al invertir, la antigua Cabeza pasa a ser la nueva Cola
            Cola = Cabeza;

            while (actual != null)
            {
                siguiente = actual.Siguiente;
                actual.Siguiente = previo;
                previo = actual;
                actual = siguiente;
            }

            Cabeza = previo;
        }

        // =========================================================================
        // 5. Inserción ordenada por un criterio O(n)
        // =========================================================================
        public void InsertarOrdenado(T valor, Comparison<T> comparador)
        {
            var nuevo = new Nodo<T>(valor);

            if (EstaVacia || comparador(valor, Cabeza!.Valor) < 0)
            {
                nuevo.Siguiente = Cabeza;
                Cabeza = nuevo;

                if (Cola == null) Cola = nuevo; // Si era el primer nodo

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

            // Si se insertó al final de todo, actualizamos la Cola
            if (nuevo.Siguiente == null)
            {
                Cola = nuevo;
            }

            Conteo++;
        }

        // =========================================================================
        // 6. Depurar duplicados
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
                        // Si se elimina el nodo apuntado por Cola, actualizamos la Cola al corredor
                        if (corredor.Siguiente == Cola)
                        {
                            Cola = corredor;
                        }

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
            Cola = null;
            Conteo = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var actual = Cabeza;
            while (actual != null)
            {
                yield return actual.Valor;
                actual = actual.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
