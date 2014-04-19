using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
#if Mono
using System.Threading.Tasks;
#endif
#if Mono
using System.Windows.Input;
#endif
using AlexanderKa.QuantaRouter.PCL.Interfaces;
using AlexanderKa.QuantaRouter.PCL.StatusUpdate;

namespace AlexanderKa.QuantaRouter.PCL
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class Router : BaseViewModel
    {
        protected const string Disable3gCommand = "&xmlPId=1&action=0";
        protected const string Enable3gCommand = "&xmlPId=1&action=1";
        private bool _Connected { get; set; }

        public bool Connected
        {
            get { return _Connected; }
            set
            {
                UIContext.Post(delegate(object state)
                    {
                        if (_Connected != (bool)state)
                        {
                            _Connected = (bool)state;
                            OnPropertyChanged(() => Connected);
                        }
                    }, value);

            }
        }

        /// <summary>
        ///  Нужно ли обновлять
        /// </summary>
        public bool NeedToRefresh = true;

        /// <summary>
        ///     Время обновления статуса
        /// </summary>
        public int RefreshDelay = 1;

        public int RefreshTimeOut = 5;

        private Exception _LastException = new Exception();







        public Router()
        {

            Initialize();

        }

        private IHttpClient client { get; set; }

        public Router(IHttpClient _client)
        {
            client = _client;
            Initialize();

        }

        /// <summary>
        ///     Статус устройства
        /// </summary>
        public Status Status { get; private set; }

        public Exception LastException
        {
            get { return _LastException; }
            set
            {
                if (!_LastException.Equals(value))
                {
                    _LastException = value;
                    OnPropertyChanged(() => LastException);
                }
            }
        }

        //public ICommand Disable
        //{
        //    get { return new BaseCommand(DisableCommand); }
        //}

        public void Initialize()
        {
            UIContext = SynchronizationContext.Current;
            Status = new Status();
            Connected = true;
            LTESwitch = new BaseCommand(this.DisableCommand);
            Updaters.Add(new MainStatusUpdate() { router = this, UIContext = UIContext });
            Updaters.Add(new WlanStatusUpdate() { router = this, UIContext = UIContext });
            Updaters.Add(new MacAddrTableUpdate() { router = this, UIContext = UIContext });
            Updaters.Add(new SingnalBatteryRoamUpdate() { router = this, UIContext = UIContext });
            RefreshStatusAsync();

        }
        List<IStatusUpdate> Updaters = new List<IStatusUpdate>();

        public async void RefreshStatusAsync()
        {

            await Task.Delay(TimeSpan.FromSeconds(RefreshDelay));

#if DEBUG
            DateTime dold = DateTime.Now;
#endif
            await Task.Factory.StartNew(new Action(() =>
                {

                    Updaters.All(update =>
                        {

                            Debug.WriteLine("Start MakeAsyncRequest" + update.ToString());

                            Task<string> htmlRequest;
                            if (update is IHavePostData)
                            {
                                htmlRequest = MakeAsyncRequestPost(update.url, (update as IHavePostData).PostData);

                            }
                            else
                            {
                                htmlRequest = MakeAsyncRequest(update.url);
                            }
                            if (htmlRequest.Result != null)
                            {

                                return update.ParseStatus(htmlRequest.Result).Result;
                            }


                            if (htmlRequest.Result != null)
                            {

                                return update.ParseStatus(htmlRequest.Result).Result;
                            }


                            return false;
                        });
#if DEBUG
                    TimeSpan sp = DateTime.Now - dold;
                    Debug.WriteLine("All Update runnings" + sp.TotalSeconds.ToString());
#endif

                    //foreach (var statusUpdate in Updaters)
                    //{
                    //    Debug.WriteLine("Start MakeAsyncRequest" + statusUpdate.ToString());
                    //    var htmlRequest = MakeAsyncRequest(statusUpdate.url);
                    //    if (htmlRequest.Result != null)
                    //    {

                    //        statusUpdate.ParseStatus(htmlRequest.Result);
                    //    }
                    //}








                    //Повторим

                    RefreshStatusAsync();






                }));
        }


        public async Task<string> MakeAsyncRequest(string url)
        {


            try
            {
                var responce = client.GetStringAsync(url);
                //с таймаутом
                if (await Task.WhenAny(responce, Task.Delay(TimeSpan.FromSeconds(RefreshTimeOut))) == responce)
                {
                    //Без таймаута
                    if (responce.Exception != null)
                    {
                        return MakeRequestAsyncFailed();
                    }
                    if (responce.Result == null)
                    {
                        return MakeRequestAsyncFailed();
                    }
                    //Если все хорошо
                    return responce.Result;
                }
                //  else
                {
                    //Taимаут
                    Debug.WriteLine("MakeAsyncRequest TimeOut");
                    return MakeRequestAsyncFailed();
                }
            }
            catch (Exception)
            {
                return MakeRequestAsyncFailed();
            }


            #region Старая версия
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.ContentType = contentType;
            //request.Method = method;






            //try
            //{
            //    var responce = request.GetResponseAsync();
            //    if (await Task.WhenAny(responce, Task.Delay(TimeSpan.FromSeconds(RefreshTimeOut))) == responce)
            //    {
            //        //Без таймаута
            //        if (responce.Exception != null)
            //        {
            //            return MakeRequestAsyncFailed();
            //        }
            //        if (responce.Result == null)
            //        {
            //            return MakeRequestAsyncFailed();
            //        }
            //        //Если все хорошо
            //        return ReadStreamFromResponse(responce.Result);
            //    }
            //    else
            //    {
            //        //Taимаут
            //        Debug.WriteLine("MakeAsyncRequest TimeOut");
            //        return MakeRequestAsyncFailed();
            //    }

            //}
            //catch (Exception exception)
            //{
            //    SetException(exception);
            //}

            //return MakeRequestAsyncFailed();

            #endregion





        }

        public async Task<string> MakeAsyncRequestPost(string url, string PostData)
        {


            try
            {
                var responce = client.GetStringAsyncPost(url, PostData);
                //с таймаутом
                if (await Task.WhenAny(responce, Task.Delay(TimeSpan.FromSeconds(RefreshTimeOut))) == responce)
                {
                    //Без таймаута
                    if (responce.Exception != null)
                    {
                        return MakeRequestAsyncFailed();
                    }
                    if (responce.Result == null)
                    {
                        return MakeRequestAsyncFailed();
                    }
                    //Если все хорошо
                    return responce.Result;
                }
                //  else
                {
                    //Taимаут
                    Debug.WriteLine("MakeAsyncRequest TimeOut");
                    return MakeRequestAsyncFailed();
                }
            }
            catch (Exception)
            {
                return MakeRequestAsyncFailed();
            }


            #region Старая версия
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.ContentType = contentType;
            //request.Method = method;






            //try
            //{
            //    var responce = request.GetResponseAsync();
            //    if (await Task.WhenAny(responce, Task.Delay(TimeSpan.FromSeconds(RefreshTimeOut))) == responce)
            //    {
            //        //Без таймаута
            //        if (responce.Exception != null)
            //        {
            //            return MakeRequestAsyncFailed();
            //        }
            //        if (responce.Result == null)
            //        {
            //            return MakeRequestAsyncFailed();
            //        }
            //        //Если все хорошо
            //        return ReadStreamFromResponse(responce.Result);
            //    }
            //    else
            //    {
            //        //Taимаут
            //        Debug.WriteLine("MakeAsyncRequest TimeOut");
            //        return MakeRequestAsyncFailed();
            //    }

            //}
            //catch (Exception exception)
            //{
            //    SetException(exception);
            //}

            //return MakeRequestAsyncFailed();

            #endregion





        }
        private string MakeRequestAsyncFailed()
        {
            UIContext.Post(delegate(object state)
            {
                Status.CleanValues();
            }, "");
            return null;
        }
        //UI Контекст синхронизации
        private SynchronizationContext UIContext;

        private void SetException(Exception ex)
        {
            UIContext.Post(delegate(object state)
                {
                    LastException = (Exception)state;
                }, ex);

        }

        private ICommand _LTESwitch { get; set; }

        public ICommand LTESwitch
        {
            get
            {
                return _LTESwitch;
            }
            set
            {
                if (_LTESwitch != value)
                {
                    _LTESwitch = value;
                    this.OnPropertyChanged(() => LTESwitch);
                }
            }
        }

        private async void DisableCommand()
        {
            if (Status.State == "NoNetwork" || Status.State == null)
            {
                Debug.WriteLine("MakeAsyncRequestPost Enable");
                int i =1;
                while (i < 3)
                {
                    string z =
                   await
                   MakeAsyncRequestPost("http://status.yota.ru/xmlpost.cgi", Enable3gCommand);
                    await Task.Delay(100);
                    i++;
                }

            }
            else
            {
                int i=1;
                while (i < 3)
                {
                    
               
                    Debug.WriteLine("MakeAsyncRequestPost Disable");

                    string z =
                        await
                        MakeAsyncRequestPost("http://status.yota.ru/xmlpost.cgi", Disable3gCommand);
                    await Task.Delay(100);
                    i++;
                }

            }
        }



        public ICommand LoginCommand {get{return  new BaseCommand(Login);}}

        private void Login()
        {
            
            //<form method="post" action="https://login.yota.ru/UI/Login" id="customerLoginForm">
            //    <input type="hidden" name="goto" value="https://my.yota.ru:443/selfcare/loginSuccess"/>
            //    <input type="hidden" name="gotoOnFail" value="https://my.yota.ru:443/selfcare/loginError"/>
            //    <input type="hidden" name="org" value="customer"/>
            this.MakeAsyncRequestPost("https://login.yota.ru/UI/Login", "goto=https://my.yota.ru/selfcare/mydevices&gotoOnFail=https://my.yota.ru:443/selfcare/loginError&org=customer&login=anykeysas@yandex.ru&password=a7brbrhd");
        }
    }


}