using System;

namespace ecommerceproject.Models
{
    public class MalzemeImage
    {
        public int Id { get; set; }
        public int MalzemeId { get; set; }
        public string FileName { get; set; }
        public bool IsDefaultImage { get; set; }
        public virtual Malzeme Malzeme { get; set; }

        internal dynamic findAll()
        {
            throw new NotImplementedException();
        }
    }
}
