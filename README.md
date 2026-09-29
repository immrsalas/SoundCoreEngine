# 🎧 SoundCore Engine v2.0 - DJ Set Controller

Un controlador de playlist e ingenio de mezcla simular en tiempo real para DJs, desarrollado en **C# (.NET 8)** y **Windows Forms**. 

Este proyecto fue diseñado para la materia de **Estructuras de Datos** (Ingeniería en Informática - TecNM) con el objetivo de demostrar la implementación, eficiencia y manipulación en memoria de una **Lista Simple Enlazada Genérica (`ListaSimpleEnlazada<T>`)** basada en punteros, comparando su rendimiento frente a las colecciones nativas de .NET.

---

## 🚀 Características Principales

* **Estructura Propia Base (`ListaSimpleEnlazada<T>`):** Implementación desde cero basada en nodos (`Nodo<T>`) con administración dinámica de punteros.
* **Manejo de Playlist en Vivo:**
  * **Encolar al final:** Inserción $O(1)$ al final de la cola.
  * **Up Next (Siguiente):** Inserción intermedia $O(1)$ justo después de la pista actual.
  * **Avanzar Pista:** Desencolado $O(1)$ del primer nodo actualizando la telemetría de reproducción.
  * **Inversión In-Place:** Algoritmo de 3 punteros (`previo`, `actual`, `siguiente`) para dar vuelta a la lista en $O(n)$ sin memoria adicional.
  * **Inserción Ordenada por BPM:** Ordenamiento dinamizado por Criterio/Lambda.
  * **Depuración de Duplicados:** Eliminación de nodos repetidos (mismo Título y Artista).
* **Conmutación de Estructuras:** Permite cambiar dinámicamente el motor de la lista en ejecución entre la **Lista Propia**, **`LinkedList<T>`** (.NET) y **`List<T>`** (Array Dinámico de .NET).
* **Módulo de Benchmark y Telemetría:** Prueba de estrés masiva (ej. 25,000 inserciones intermedias) midiendo tiempos exactos en milisegundos con `Stopwatch`.

---

## 🛠️ Arquitectura y Diseño (Patrón MVC)

El proyecto está organizado en tres capas principales:

```text
SoundCoreEngine/
├── EstructurasPropias/
│   ├── Nodo.cs                    # Nodo genérico con referencia 'Siguiente'
│   └── ListaSimpleEnlazada.cs    # Lógica de punteros e IEnumerable<T>
├── Modelos/
│   └── Pista.cs                   # Record/Modelo con datos de la canción (Id, Titulo, Artista, Bpm, Duracion)
└── UI/
    ├── MainForm.cs                # Controlador de eventos e interfaz gráfica (WinForms)
    └── MainForm.Designer.cs       # Layout visual organizado en GroupBoxes
