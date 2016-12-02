using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doa_dan_Dzikir.Model
{
    class ModelDoa
    {
        public String idDoa { get; set; }
        public String judulDoa { get; set; }
        public String idKategori { get; set; }
        public String tumbnail { get; set; }
        public String doaArab { get; set; }
        public String doaLatin { get; set; }
        public String doaArti { get; set; }
        public String keterangan { get; set; }
        public String totalBaca { get; set; }
        public String namaKategori { get; set; }
    }
}
