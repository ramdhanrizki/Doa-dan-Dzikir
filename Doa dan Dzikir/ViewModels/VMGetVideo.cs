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
    class VMGetVideo : ViewModelBase 
    {
        private ObservableCollection<ModelVideo> collectionvideo = new ObservableCollection<ModelVideo>();
        public ObservableCollection<ModelVideo> CollectionVideo
        {
            get
            {
                return collectionvideo;
            }
            set
            {
                if (this.collectionvideo != value)
                {
                    collectionvideo = value;
                    RaisePropertyChanged("");
                }
            }
        }

        public VMGetVideo()
        {
            LoadURL();
        }

        public async void LoadURL()
        {
            HttpClient clientlistdoa = new HttpClient();
            try
            {
                String RespondResult = await clientlistdoa.GetStringAsync(new Uri(Navigation.BASE_URL+"/api/video/"));
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
                ModelVideo mVideo= new ModelVideo();
                mVideo.idVideo = item.SelectToken("idVideo").ToString();
                mVideo.judulVideo = item.SelectToken("judulVideo").ToString();
                mVideo.video = Navigation.BASE_URL+"/api/public/video/" + item.SelectToken("video").ToString();
                mVideo.keterangan = item.SelectToken("keterangan").ToString();
                mVideo.sumber = item.SelectToken("sumber").ToString();
                collectionvideo.Add(mVideo);
            }
        }
    }
}

