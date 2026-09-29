using SoundCoreEngine.EstructurasPropias;
using SoundCoreEngine.Modelos;
using System.Diagnostics;

namespace SoundCoreEngine
{
    public partial class MainForm : Form
    {
        // Instancias de las 3 estructuras de datos para compararlas
        private ListaSimpleEnlazada<Pista> _colaPropia = new ListaSimpleEnlazada<Pista>();
        private LinkedList<Pista> _colaLinkedList = new LinkedList<Pista>();
        private List<Pista> _colaList = new List<Pista>();

        private int _contadorId = 1; // Auto-incremento para los IDs

        public MainForm()
        {
            InitializeComponent();
            ConfigurarDataGridView();

            // Suscribir eventos de cambio en los RadioButtons si existen
            if (rbPropia != null) rbPropia.CheckedChanged += rbEstructura_CheckedChanged;
            if (rbLinkedList != null) rbLinkedList.CheckedChanged += rbEstructura_CheckedChanged;
            if (rbList != null) rbList.CheckedChanged += rbEstructura_CheckedChanged;
        }

        private void ConfigurarDataGridView()
        {
            dgvCola.AutoGenerateColumns = true;
            dgvCola.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCola.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCola.ReadOnly = true;
        }

        // Actualiza la tabla y el resumen dinámico de duraciones
        private void ActualizarVista()
        {
            dgvCola.DataSource = null;

            var listaVisual = new List<Pista>();
            int duracionTotalSegundos = 0;

            // Determinar qué estructura leer según el RadioButton seleccionado
            if (rbPropia != null && rbPropia.Checked)
            {
                foreach (var pista in _colaPropia)
                {
                    listaVisual.Add(pista);
                    duracionTotalSegundos += pista.DuracionSegundos;
                }
            }
            else if (rbLinkedList != null && rbLinkedList.Checked)
            {
                foreach (var pista in _colaLinkedList)
                {
                    listaVisual.Add(pista);
                    duracionTotalSegundos += pista.DuracionSegundos;
                }
            }
            else
            {
                foreach (var pista in _colaList)
                {
                    listaVisual.Add(pista);
                    duracionTotalSegundos += pista.DuracionSegundos;
                }
            }

            dgvCola.DataSource = listaVisual;

            // Actualizar etiqueta de resumen inferior de la playlist
            if (lblResumen != null)
            {
                int minutos = duracionTotalSegundos / 60;
                int segundos = duracionTotalSegundos % 60;
                lblResumen.Text = $"Total en cola: {listaVisual.Count} pistas | Duración acumulada: {minutos}m {segundos}s";
            }
        }

        private Pista CrearPistaDesdeInterfaz()
        {
            var titulo = string.IsNullOrWhiteSpace(txtTitulo.Text) ? "Sin Título" : txtTitulo.Text;
            var artista = string.IsNullOrWhiteSpace(txtArtista.Text) ? "Sin Artista" : txtArtista.Text;
            var bpm = (int)numBpm.Value;
            var duracion = (int)numDuracion.Value;

            return new Pista(_contadorId++, titulo, artista, bpm, duracion);
        }

        // --- ACCIONES DE COLA ---

        private void btnAgregarFinal_Click(object sender, EventArgs e)
        {
            var pista = CrearPistaDesdeInterfaz();

            if (rbPropia != null && rbPropia.Checked) _colaPropia.AgregarAlFinal(pista);
            else if (rbLinkedList != null && rbLinkedList.Checked) _colaLinkedList.AddLast(pista);
            else _colaList.Add(pista);

            ActualizarVista();
        }

        private void btnUpNext_Click(object sender, EventArgs e)
        {
            var pista = CrearPistaDesdeInterfaz();

            if (rbPropia != null && rbPropia.Checked)
            {
                _colaPropia.ReproducirSiguiente(pista);
            }
            else if (rbLinkedList != null && rbLinkedList.Checked)
            {
                if (_colaLinkedList.First != null) _colaLinkedList.AddAfter(_colaLinkedList.First, pista);
                else _colaLinkedList.AddFirst(pista);
            }
            else
            {
                if (_colaList.Count > 0) _colaList.Insert(1, pista);
                else _colaList.Add(pista);
            }

            ActualizarVista();
        }

        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            Pista? pistaAvanzada = null;

            if (rbPropia != null && rbPropia.Checked)
            {
                if (_colaPropia.EstaVacia) return;
                pistaAvanzada = _colaPropia.AvanzarPista();
            }
            else if (rbLinkedList != null && rbLinkedList.Checked)
            {
                if (_colaLinkedList.Count == 0) return;
                pistaAvanzada = _colaLinkedList.First!.Value;
                _colaLinkedList.RemoveFirst();
            }
            else
            {
                if (_colaList.Count == 0) return;
                pistaAvanzada = _colaList[0];
                _colaList.RemoveAt(0);
            }

            if (pistaAvanzada != null && lblReproduciendo != null)
            {
                lblReproduciendo.Text = $"Estado Actual: ► Reproduciendo: \"{pistaAvanzada.Titulo} - {pistaAvanzada.Artista} ({pistaAvanzada.Bpm} BPM)\"";
            }

            ActualizarVista();
        }

        private void btnInvertir_Click(object sender, EventArgs e)
        {
            if (rbPropia != null && rbPropia.Checked)
            {
                _colaPropia.Invertir();
            }
            else if (rbLinkedList != null && rbLinkedList.Checked)
            {
                var invertida = new LinkedList<Pista>(_colaLinkedList.Reverse());
                _colaLinkedList = invertida;
            }
            else
            {
                _colaList.Reverse();
            }

            ActualizarVista();
        }

        private void btnOrdenarBpm_Click(object sender, EventArgs e)
        {
            if (rbPropia != null && rbPropia.Checked)
            {
                var nuevaCola = new ListaSimpleEnlazada<Pista>();
                foreach (var p in _colaPropia)
                {
                    nuevaCola.InsertarOrdenado(p, (p1, p2) => p1.Bpm.CompareTo(p2.Bpm));
                }
                _colaPropia = nuevaCola;
            }
            else if (rbLinkedList != null && rbLinkedList.Checked)
            {
                var ordenados = _colaLinkedList.OrderBy(p => p.Bpm).ToList();
                _colaLinkedList = new LinkedList<Pista>(ordenados);
            }
            else
            {
                _colaList.Sort((p1, p2) => p1.Bpm.CompareTo(p2.Bpm));
            }

            ActualizarVista();
        }

        private void btnDepurar_Click(object sender, EventArgs e)
        {
            if (rbPropia != null && rbPropia.Checked)
            {
                _colaPropia.DepurarDuplicados((p1, p2) => p1.Titulo == p2.Titulo && p1.Artista == p2.Artista);
            }
            else
            {
                MessageBox.Show("La depuración in-place O(1) está optimizada para la Lista Propia de Nodos.", "Aviso");
            }

            ActualizarVista();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _colaPropia.Limpiar();
            _colaLinkedList.Clear();
            _colaList.Clear();

            if (lblReproduciendo != null)
                lblReproduciendo.Text = "Estado Actual: ► Reproduciendo: Ninguna";

            ActualizarVista();
        }

        private void rbEstructura_CheckedChanged(object? sender, EventArgs e)
        {
            ActualizarVista();
        }

        // --- BENCHMARK Y TELEMETRÍA ---

        private void btnBenchmark_Click(object sender, EventArgs e)
        {
            int cantidad = numCantidadTest != null ? (int)numCantidadTest.Value : 25000;

            // 1. Prueba Lista Propia (Inserción intermedia Up Next)
            var listaP = new ListaSimpleEnlazada<Pista>();
            var sw1 = Stopwatch.StartNew();
            for (int i = 0; i < cantidad; i++)
            {
                listaP.ReproducirSiguiente(new Pista(i, $"Pista {i}", "Artista Test", 120, 180));
            }
            sw1.Stop();

            // 2. Prueba .NET LinkedList<T>
            var listaLL = new LinkedList<Pista>();
            var sw2 = Stopwatch.StartNew();
            for (int i = 0; i < cantidad; i++)
            {
                if (listaLL.First == null) listaLL.AddFirst(new Pista(i, $"Pista {i}", "Artista Test", 120, 180));
                else listaLL.AddAfter(listaLL.First, new Pista(i, $"Pista {i}", "Artista Test", 120, 180));
            }
            sw2.Stop();

            // 3. Prueba .NET List<T> (Array Dinámico)
            var listaL = new List<Pista>();
            var sw3 = Stopwatch.StartNew();
            for (int i = 0; i < cantidad; i++)
            {
                if (listaL.Count == 0) listaL.Add(new Pista(i, $"Pista {i}", "Artista Test", 120, 180));
                else listaL.Insert(1, new Pista(i, $"Pista {i}", "Artista Test", 120, 180));
            }
            sw3.Stop();

            // Actualizar etiquetas del panel inferior
            if (lblResultPropia != null)
                lblResultPropia.Text = $"- Lista Propia (Nodos): {sw1.Elapsed.TotalMilliseconds:F1} ms | Operaciones: Inserción intermedia O(1)";

            if (lblResultLinkedList != null)
                lblResultLinkedList.Text = $"- .NET LinkedList<T>: {sw2.Elapsed.TotalMilliseconds:F1} ms | Operaciones: Inserción con LinkedListNode O(1)";

            if (lblResultList != null)
                lblResultList.Text = $"- .NET List<T> (Array Din.): {sw3.Elapsed.TotalMilliseconds:F1} ms | Operaciones: Insert(idx) sufre degradación por Array.Copy";
        }
    }
}
