using Common.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Klase
{
    public class Block : IBlock
    {
        public Guid Id { get; set; }

        public double broj { get; set; }
        public Guid? PrethodniId { get; set; }

        public Podatak Vrednost { get; set; }

        public DateTime Datum { get; set; }

        public Block(Podatak vrednost)
        {
            Id = Guid.NewGuid();
            Vrednost = vrednost;
            broj = 0.00001;
            PrethodniId = null;
        }

        public string KreirajSHA256()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                
                string podaci = this.Id.ToString() + this.Vrednost.vrednost + this.Datum.ToString();

                byte[] value = sha256.ComputeHash(Encoding.UTF8.GetBytes(podaci));
                return Encoding.UTF8.GetString(value);
            }
        }
    }
}
