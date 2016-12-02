using Doa_dan_Dzikir.Common;
using Doa_dan_Dzikir.Helpers;
using Doa_dan_Dzikir.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Doa_dan_Dzikir.ViewModels
{
    class VMGetListDoa:ViewModelBase
    {
        private ObservableCollection<ModelDoa> collectiondoa = new ObservableCollection<ModelDoa>();
        public ObservableCollection<ModelDoa> CollectionDoa
        {
            get
            {
                return collectiondoa;
            }
            set
            {
                if (this.collectiondoa != value)
                {
                    collectiondoa = value;
                    RaisePropertyChanged("");
                }
            }


        }

        public VMGetListDoa()
        {
            LoadURL();
        }

        public async void LoadURL()
        {
            HttpClient clientlistdoa = new HttpClient();
            try
            {

                String RespondResult = await clientlistdoa.GetStringAsync(new Uri(Navigation.BASE_URL+"/api/doa/"));
                DownloadListDoa(RespondResult);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

       

        private void DownloadListDoa(String respondResult)
        {

            JObject jresult = JObject.Parse(respondResult);
            JArray jdata = JArray.Parse(jresult.SelectToken("result").ToString());
            foreach (JObject item in jdata)
            {
                ModelDoa mdoa = new ModelDoa();
                mdoa.idDoa = item.SelectToken("idDoa").ToString();
                mdoa.judulDoa = item.SelectToken("judulDoa").ToString();
                mdoa.tumbnail = Navigation.BASE_URL +"/"+ item.SelectToken("tumbnail").ToString();
                mdoa.keterangan = item.SelectToken("keterangan").ToString();
                mdoa.doaArab = item.SelectToken("doaArab").ToString();
                mdoa.namaKategori = item.SelectToken("kategori").ToString();
                collectiondoa.Add(mdoa);

            }
        }
    }
}
