using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Extensions
{
    public static class StringExtension
    {
        public static string ReplaceAcentos(this String str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                string normalized = str.Normalize(NormalizationForm.FormKD);
                Encoding removal = Encoding.GetEncoding(Encoding.ASCII.CodePage,
                                                        new EncoderReplacementFallback(""),
                                                        new DecoderReplacementFallback(""));
                byte[] bytes = removal.GetBytes(normalized);
                return Encoding.ASCII.GetString(bytes);
            }

            return "";
        }
    }
}
