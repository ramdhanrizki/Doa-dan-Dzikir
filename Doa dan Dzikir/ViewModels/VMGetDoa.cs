using Doa_dan_Dzikir.Common;
using Doa_dan_Dzikir.Helpers;
using Doa_dan_Dzikir.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Doa_dan_Dzikir.ViewModels
{
    class VMGetDoa : ViewModelBase
    {
        private ModelDoa mDoa = new ModelDoa();
       

        public ModelDoa _mDoa
        {
            get { return mDoa; }
            set { mDoa = value; }
        }

        public String judulDoa
        {
            get { return _mDoa.judulDoa; }
            set
            {
                _mDoa.judulDoa = value;
                RaisePropertyChanged("");
            }
        }

        public String tumbnail
        {
            get { return _mDoa.tumbnail; }
            set
            {
                _mDoa.tumbnail = value;
                RaisePropertyChanged("");
            }
        }

        public String doaArab
        {
            get { return _mDoa.doaArab; }
            set
            {
                _mDoa.doaArab = value;
                RaisePropertyChanged("");
            }
        }

        public String doaArti
        {
            get { return _mDoa.doaArti; }
            set
            {
                _mDoa.doaArti = value;
                RaisePropertyChanged("");
            }
        }

        public String doaLatin
        {
            get { return _mDoa.doaLatin; }
            set
            {
                _mDoa.doaLatin = value;
                RaisePropertyChanged("");
            }
        }

        public String keterangan
        {
            get { return _mDoa.keterangan; }
            set
            {
                _mDoa.keterangan = value;
                RaisePropertyChanged("");
            }
        }
        public VMGetDoa()
        {
            this.LoadURL();
        }

        private async void LoadURL()
        {
            HttpClient client = new HttpClient();
            try
            {
                String responResult = await client.
                    GetStringAsync(new Uri(Navigation.BASE_URL + "/api/doa/" + Navigation.idDoa));

                DownloadListDoa(responResult);
                client.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void DownloadListDoa(string responResult)
        {
            try
            {
                JObject JResult = JObject.Parse(responResult);
                JArray JItem = JArray.Parse(JResult.SelectToken("result").ToString());
                foreach (JObject item in JItem)
                {
                    judulDoa = item.SelectToken("judulDoa").ToString();
                    tumbnail = Navigation.BASE_URL+"/"+item.SelectToken("tumbnail").ToString();
                    doaLatin = item.SelectToken("doaLatin").ToString();
                    doaArti = item.SelectToken("doaArti").ToString();
                    doaArab = item.SelectToken("doaArab").ToString();
                    keterangan = item.SelectToken("keterangan").ToString();
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
