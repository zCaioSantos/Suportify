namespace Suportify.Common.Utils.Extensions
{
    public static class StringExtension
    {
        public static string Truncar(this string str, int tamanhoMaximo)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= tamanhoMaximo)
            {
                return str;
            }
            return str.Substring(0, tamanhoMaximo) + "...";
        }


        public static string RemoverCaracteresEspeciais(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            // Define os caracteres permitidos
            char[] caracteresPermitidos = "abcdefghijklmnopqrstuvwxyz0123456789-".ToCharArray();
            // Filtra os caracteres da string original
            return new string(str.Where(c => caracteresPermitidos.Contains(c)).ToArray());
        }

    }
}
