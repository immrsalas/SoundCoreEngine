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
using System.Collections.Generic;
using System.Text;

namespace SoundCoreEngine.Modelos
{
    public record Pista(int Id, string Titulo, string Artista, int Bpm, int DuracionSegundos)
    {
        public override string ToString() =>
            $"[ID: {Id:D3}] {Titulo} - {Artista} | {Bpm} BPM ({DuracionSegundos}s)";
    }
}
