using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class KeyWord
    {
        public int KeyWordID { get; set; }
        public string KeyWordText { get; set; }
        public ICollection<ProductKeyWord>ProductKeyWords { get; set; }
        public KeyWord()
        {
            this.ProductKeyWords = new List<ProductKeyWord>();
        }
    }
}
