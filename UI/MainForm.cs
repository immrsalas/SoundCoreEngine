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
            int cantidadDatos = 25000;

            var confirm = MessageBox.Show(
                $"Se van a generar e ingresar {cantidadDatos:N0} datos reales directamente dentro de las 3 listas.\n\n¿Deseas iniciar la prueba?",
                "Prueba de Carga Real",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            // Usamos los nombres correctos de tus variables miembro y métodos de limpieza
            _colaPropia.Limpiar();
            _colaLinkedList.Clear();
            _colaList.Clear();

            // -------------------------------------------------------------
            // 1. INSERCIÓN REAL: Lista Simple Propia (Nodos)
            // -------------------------------------------------------------
            Stopwatch swPropia = Stopwatch.StartNew();
            for (int i = 1; i <= cantidadDatos; i++)
            {
                _colaPropia.AgregarAlFinal(new Pista(i, $"Pista {i}", "Artista Benchmark", 120 + (i % 40), 180));
            }
            swPropia.Stop();
            double msPropia = swPropia.Elapsed.TotalMilliseconds;

            // -------------------------------------------------------------
            // 2. INSERCIÓN REAL: .NET LinkedList<T> (Lista Doblemente Enlazada)
            // -------------------------------------------------------------
            Stopwatch swLinkedList = Stopwatch.StartNew();
            for (int i = 1; i <= cantidadDatos; i++)
            {
                _colaLinkedList.AddLast(new Pista(i, $"Pista {i}", "Artista Benchmark", 120 + (i % 40), 180));
            }
            swLinkedList.Stop();
            double msLinkedList = swLinkedList.Elapsed.TotalMilliseconds;

            // -------------------------------------------------------------
            // 3. INSERCIÓN REAL: .NET List<T> (Array Dinámico)
            // -------------------------------------------------------------
            Stopwatch swList = Stopwatch.StartNew();
            for (int i = 1; i <= cantidadDatos; i++)
            {
                _colaList.Add(new Pista(i, $"Pista {i}", "Artista Benchmark", 120 + (i % 40), 180));
            }
            swList.Stop();
            double msList = swList.Elapsed.TotalMilliseconds;

            // Refrescar la vista del DataGridView en pantalla
            ActualizarVista();

            // Despliegue de Resultados
            string resultado = $"📊 TIEMPOS DE INSERCIÓN REAL ({cantidadDatos:N0} REGISTROS)\n\n" +
                               $"• Lista Simple Propia: {msPropia:F2} ms\n" +
                               $"• .NET LinkedList<T>: {msLinkedList:F2} ms\n" +
                               $"• .NET List<T>: {msList:F2} ms\n\n" +
                               $"Los 25,000 datos ya se encuentran cargados en las listas del sistema.";

            MessageBox.Show(resultado, "Benchmark Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCargarAudio_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de audio (*.mp3;*.wav)|*.mp3;*.wav|Todos los archivos (*.*)|*.*";
                openFileDialog.Title = "Seleccionar canción para analizar BPM";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = openFileDialog.FileName;
                    string nombreCancion = System.IO.Path.GetFileNameWithoutExtension(rutaArchivo);

                    // 1. Calculamos el BPM y la duración real usando la clase que creamos
                    int bpmCalculado = AudioBpmAnalyzer.CalcularBpmDesdeArchivo(rutaArchivo);
                    int duracionSegundos = AudioBpmAnalyzer.ObtenerDuracionSegundos(rutaArchivo);

                    // 2. Formateamos la duración a minutos:segundos (ej. 03:45)
                    TimeSpan tiempo = TimeSpan.FromSeconds(duracionSegundos);
                    string duracionFormateada = tiempo.ToString(@"mm\:ss");

                    // 3. Mostramos un mensaje con los resultados obtenidos
                    MessageBox.Show(
                        $"Canción: {nombreCancion}\n" +
                        $"BPM Estimado: {bpmCalculado}\n" +
                        $"Duración: {duracionFormateada}",
                        "Análisis de Audio Completado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Opcional: Aquí puedes agregar el objeto a tu DataGridView, ListBox o Lista de canciones.
                }
            }
        }

        
    }
}
