namespace VMES.Database.Vmes.Models
{

	public enum ProductoEnvaseEtiquetaType : byte
	{
		Ean13 = 0,
		Itf14 = 1,
		Code39 = 2,
		Code128 = 3,
		Ean128 = 4,
		Sscc14 = 5,
		DataMatrix = 6,
		QrCode = 7,
	}

}
