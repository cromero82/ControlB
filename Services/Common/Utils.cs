namespace Services.Common
{
    public static class Utils
    {
        /// <summary>
        /// Funcion que obtiene la primer letra de una palabra
        /// </summary>
        /// <param name="palabras"> Palabras que se analizará</param>
        /// <returns>La primer letra (hasta encontrar el primer espacio en blanco)</returns>
        public static string PrimerLetra(string palabras)
        {
            var pos = palabras.IndexOf(" ");
            if (pos > 0)
            {
                return palabras.Substring(1, palabras.IndexOf(" "));
            }
            else
            {
                return palabras;
            }            
        }       
    }
}
