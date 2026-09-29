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


namespace SoundCoreEngine
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}