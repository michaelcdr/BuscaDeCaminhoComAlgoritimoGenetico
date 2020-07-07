using System;

namespace AG.Web.Extensions
{
    public static class StringExtensions
    {
        public static string SubstringDoJava(this String entrada, int inicio, int fim)
            => entrada.Substring(inicio, fim - inicio);
    }
}
