using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSearchAndReplace
{
    public static class SearchAndReplaceContent
    {
        // NOTE: Make sure you update SearchAndReplaceUtil.ExistingSets to match the entries here

        /// <summary>
        /// <para>Search items: all except last</para>
        /// <para>Replace with: last item</para>
        /// </summary>
        public static string[][] RemoveDiacritics = new string[][]
        {
            new string[] {"à", "á", "ã", "ä", "â", "a"},
            new string[] {"è", "é", "ê", "ë", "e"},
            new string[] {"ì", "í", "ï", "î", "i"},
            new string[] {"ò", "ó", "ö", "õ", "ô", "o"},
            new string[] {"ù", "ú", "ü", "û", "u"},
            new string[] {"ç", "c"},
            new string[] {"ñ", "n"}
        };
    }
}
