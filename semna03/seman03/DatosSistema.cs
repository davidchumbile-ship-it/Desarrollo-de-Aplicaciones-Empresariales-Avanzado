using System;
using System.Collections.ObjectModel;

namespace seman03
{
    public class SalidaModel
    {
        public string TipoDocumento { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public string Peso { get; set; } = string.Empty;
        public string TipoAuto { get; set; } = string.Empty;
        public string NombreTransportista { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public string FechaYHora { get; set; } = string.Empty;
        public string PesoIngreso { get; set; } = string.Empty;
        public string PesoSalida { get; set; } = string.Empty;
    }

    public class CamionModel
    {
        public string Placa { get; set; } = string.Empty;
        public string PesoMaximo { get; set; } = string.Empty;
        public string PesoVacio { get; set; } = string.Empty;
    }

    public class ConductorModel
    {
        public string NombreConductor { get; set; } = string.Empty;
        public string Licencia { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string PesoMaximo { get; set; } = string.Empty;
        public string PesoVacio { get; set; } = string.Empty;
    }

    public static class DatosSistema
    {
        public static ObservableCollection<SalidaModel> Salidas { get; } = new ObservableCollection<SalidaModel>
        {
            new SalidaModel
            {
                TipoDocumento = "Factura",
                NumeroDocumento = "F001-000452",
                Peso = "18500 kg",
                TipoAuto = "Tráiler Volvo FH",
                NombreTransportista = "Transportes Los Andes S.A.C.",
                Fecha = "03/09/2026",
                FechaYHora = "03/09/2026 14:30",
                PesoIngreso = "35000 kg",
                PesoSalida = "16500 kg"
            },
            new SalidaModel
            {
                TipoDocumento = "Guía de Remisión",
                NumeroDocumento = "G002-001290",
                Peso = "8200 kg",
                TipoAuto = "Camión Isuzu Forward",
                NombreTransportista = "Logística Central E.I.R.L.",
                Fecha = "03/09/2026",
                FechaYHora = "03/09/2026 15:45",
                PesoIngreso = "15000 kg",
                PesoSalida = "6800 kg"
            },
            new SalidaModel
            {
                TipoDocumento = "Factura",
                NumeroDocumento = "F001-000453",
                Peso = "12400 kg",
                TipoAuto = "Camión Scania R500",
                NombreTransportista = "Cargas y Envíos Perú",
                Fecha = "02/09/2026",
                FechaYHora = "02/09/2026 11:15",
                PesoIngreso = "28000 kg",
                PesoSalida = "15600 kg"
            }
        };

        public static ObservableCollection<CamionModel> Camiones { get; } = new ObservableCollection<CamionModel>
        {
            new CamionModel { Placa = "ABC-123", PesoMaximo = "30000 kg", PesoVacio = "12000 kg" },
            new CamionModel { Placa = "XYZ-789", PesoMaximo = "25000 kg", PesoVacio = "10500 kg" },
            new CamionModel { Placa = "TRK-456", PesoMaximo = "40000 kg", PesoVacio = "16000 kg" }
        };

        public static ObservableCollection<ConductorModel> Conductores { get; } = new ObservableCollection<ConductorModel>
        {
            new ConductorModel { NombreConductor = "Carlos Mendoza Pérez", Licencia = "Q12345678", Placa = "ABC-123", PesoMaximo = "30000 kg", PesoVacio = "12000 kg" },
            new ConductorModel { NombreConductor = "Juan Ramos Quispe", Licencia = "Q87654321", Placa = "XYZ-789", PesoMaximo = "25000 kg", PesoVacio = "10500 kg" },
            new ConductorModel { NombreConductor = "Mario Torres Silva", Licencia = "Q45612378", Placa = "TRK-456", PesoMaximo = "40000 kg", PesoVacio = "16000 kg" }
        };
    }
}
