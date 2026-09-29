using SoundCoreEngine.EstructurasPropias;
using SoundCoreEngine.Modelos;

namespace SoundCoreEngine
{
    public partial class MainForm : Form
    {
        // Instanciamos tu estructura propia indicando que guardará 'Pista'
        private ListaSimpleEnlazada<Pista> _colaPropia = new ListaSimpleEnlazada<Pista>();
        private int _contadorId = 1; // Para autogenerar los IDs

        public MainForm()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        // Método para que la tabla se prepare para recibir los datos de Pista
        private void ConfigurarDataGridView()
        {
            dgvCola.AutoGenerateColumns = true; // Se crean las columnas solas en base al Record
            dgvCola.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCola.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCola.ReadOnly = true;
        }

        // Actualiza visualmente el DataGridView después de cada cambio
        private void ActualizarVista()
        {
            dgvCola.DataSource = null; // Limpiamos

            // Usamos .ToList() solo para la visualización, pero en memoria tu lista trabaja por punteros
            var listaVisual = new System.Collections.Generic.List<Pista>();

            // ¡Esto funciona gracias al IEnumerable<T> que implementaste!
            foreach (var pista in _colaPropia)
            {
                listaVisual.Add(pista);
            }

            dgvCola.DataSource = listaVisual;
        }

        // --- EVENTOS DE LOS BOTONES ---

        private void btnAgregarFinal_Click(object sender, EventArgs e)
        {
            var pista = CrearPistaDesdeInterfaz();
            _colaPropia.AgregarAlFinal(pista);
            ActualizarVista();
        }

        private void btnUpNext_Click(object sender, EventArgs e)
        {
            var pista = CrearPistaDesdeInterfaz();
            _colaPropia.ReproducirSiguiente(pista);
            ActualizarVista();
        }

        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            if (_colaPropia.EstaVacia)
            {
                MessageBox.Show("No hay pistas en la cola.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var pistaAvanzada = _colaPropia.AvanzarPista();
            MessageBox.Show($"Pista desencolada:\n{pistaAvanzada}", "Avanzar Pista");
            ActualizarVista();
        }

        private void btnInvertir_Click(object sender, EventArgs e)
        {
            _colaPropia.Invertir();
            ActualizarVista();
        }

        private void btnOrdenarBpm_Click(object sender, EventArgs e)
        {
            // Creamos una nueva lista temporal para no perder la original durante el reordenamiento in-place (si quisieras)
            // Pero aquí aplicaremos la inserción ordenada a una nueva cola para que quede limpio:

            var nuevaCola = new ListaSimpleEnlazada<Pista>();
            foreach (var p in _colaPropia)
            {
                // Ordenar por BPM usando un comparador (lambda)
                nuevaCola.InsertarOrdenado(p, (p1, p2) => p1.Bpm.CompareTo(p2.Bpm));
            }
            _colaPropia = nuevaCola;
            ActualizarVista();
        }

        private void btnDepurar_Click(object sender, EventArgs e)
        {
            // Pide depurar si tienen exactamente el mismo Titulo y Artista
            _colaPropia.DepurarDuplicados((p1, p2) => p1.Titulo == p2.Titulo && p1.Artista == p2.Artista);
            ActualizarVista();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _colaPropia.Limpiar();
            ActualizarVista();
        }

        // Método auxiliar para leer las cajas de texto y crear la pista
        private Pista CrearPistaDesdeInterfaz()
        {
            var titulo = string.IsNullOrWhiteSpace(txtTitulo.Text) ? "Desconocido" : txtTitulo.Text;
            var artista = string.IsNullOrWhiteSpace(txtArtista.Text) ? "Desconocido" : txtArtista.Text;
            var bpm = (int)numBpm.Value;
            var duracion = (int)numDuracion.Value;

            return new Pista(_contadorId++, titulo, artista, bpm, duracion);
        }
    }
}
