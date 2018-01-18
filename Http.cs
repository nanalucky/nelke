using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Threading;
using System.IO.Compression;


namespace nelke
{
    public class RequestState
    {
        // This class stores the State of the request.
        const int BUFFER_SIZE = 1024;
        public StringBuilder requestData;
        public byte[] BufferRead;
        public HttpWebRequest request;
        public HttpWebResponse response;
        public WebHeaderCollection headers;
        public Stream streamResponse;
        public CookieContainer cookieContainer;
        public Encoding requestEncoding;
        public string body;

        
        public RequestState()
        {
            BufferRead = new byte[BUFFER_SIZE];
            requestData = new StringBuilder("");
            request = null;
            streamResponse = null;
            headers = null;
            cookieContainer = new CookieContainer();
            requestEncoding = Encoding.GetEncoding("utf-8");
            body = @"";
        }
    }
    
    class Player
    {
        public string strAccount = @"";
        public string strPassword = @"";
        public Thread thread;
        bool bLoginSuccess = false;

        RequestState requestState;
        ManualResetEvent allDone;

        private string GetBody(HttpWebResponse response)
        {
            string body = @"";
            System.IO.StreamReader reader = null;
            Encoding requestEncoding = Encoding.GetEncoding("utf-8");

            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                reader = new System.IO.StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), requestEncoding);
            }
            else
            {
                reader = new System.IO.StreamReader(response.GetResponseStream(), requestEncoding);
            }
            body = reader.ReadToEnd();
            return body; 
        }

        private string GetBody(RequestState _requestState)
        {
            System.IO.StreamReader reader = null;
            if (_requestState.response.ContentEncoding.ToLower().Contains("gzip"))
            {
                reader = new System.IO.StreamReader(new GZipStream(_requestState.response.GetResponseStream(), CompressionMode.Decompress), _requestState.requestEncoding);
            }
            else
            {
                reader = new System.IO.StreamReader(_requestState.response.GetResponseStream(), _requestState.requestEncoding);
            }
            _requestState.body = reader.ReadToEnd();
            return _requestState.body;
        }

        private void RespFirstCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                // State of request is asynchronous.
                RequestState myRequestState = (RequestState)asynchronousResult.AsyncState;
                HttpWebRequest myHttpWebRequest = myRequestState.request;
                myRequestState.response = (HttpWebResponse)myHttpWebRequest.EndGetResponse(asynchronousResult);

                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(Http.CheckValidationResult);
                myRequestState.request = WebRequest.Create(@"http://ticket.nelke.cn/nelke/member/login") as HttpWebRequest;
                myRequestState.request.ProtocolVersion = HttpVersion.Version11;
                myRequestState.request.Method = "POST";
                myRequestState.headers = myRequestState.request.Headers;
                myRequestState.headers.Add("Origin", "http://ticket.nelke.cn");
                myRequestState.request.Referer = @"http://ticket.nelke.cn/nelke/ticket/pc/login.jsp";
                myRequestState.headers.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.5");
                myRequestState.request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36 Edge/16.16299";
                myRequestState.request.ContentType = @"application/x-www-form-urlencoded; charset=UTF-8";
                myRequestState.request.Accept = "application/json, text/javascript, */*; q=0.01";
                myRequestState.request.CookieContainer = myRequestState.cookieContainer;

                StringBuilder buffer = new StringBuilder();
                buffer.AppendFormat("{0}={1}", "loginName", strAccount);
                buffer.AppendFormat("&{0}={1}", "password", strPassword);
                buffer.AppendFormat("&{0}={1}", "identifyingCode", "");
                buffer.AppendFormat("&{0}={1}", "remember", "false");
                Byte[] data = myRequestState.requestEncoding.GetBytes(buffer.ToString());
                using (Stream stream = myRequestState.request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                } 
                IAsyncResult result = (IAsyncResult)myRequestState.request.BeginGetResponse(new AsyncCallback(RespLoginCallback), myRequestState);
                return;
            }
            catch (WebException e)
            {
                Console.WriteLine("\nRespCallback Exception raised!");
                Console.WriteLine("\nMessage:{0}", e.Message);
                Console.WriteLine("\nStatus:{0}", e.Status);
                allDone.Set();
            }
        }


        private void RespLoginCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                // State of request is asynchronous.
                RequestState myRequestState = (RequestState)asynchronousResult.AsyncState;
                HttpWebRequest myHttpWebRequest = myRequestState.request;
                myRequestState.response = (HttpWebResponse)myHttpWebRequest.EndGetResponse(asynchronousResult);

                GetBody(myRequestState);
                if (myRequestState.body.IndexOf("code") >= 0)
                {
                    JObject joBody = (JObject)JsonConvert.DeserializeObject(myRequestState.body);
                    if (string.Compare((string)joBody["code"], "1", true) == 0)
                    {
                        Program.form1.UpdateDataGridView(strAccount, Column.Login, "成功");
                        bLoginSuccess = true;
                    }
                }

                allDone.Set();
                return;
            }
            catch (WebException e)
            {
                Console.WriteLine("\nRespCallback Exception raised!");
                Console.WriteLine("\nMessage:{0}", e.Message);
                Console.WriteLine("\nStatus:{0}", e.Status);
                allDone.Set();
            }
        }
        

        public void Run()
        {
            allDone = new ManualResetEvent(false);
            bLoginSuccess = false;
            requestState = new RequestState();

            int nLoginTimes = 1;
            while(true)
            {
                Program.form1.UpdateDataGridView(strAccount, Column.Login, string.Format("开始登录:{0}", nLoginTimes));
                try
                {
                    allDone.Reset();

                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(Http.CheckValidationResult);
                    requestState.request = WebRequest.Create(@"http://ticket.nelke.cn/nelke/ticket/pc/login.jsp ") as HttpWebRequest;
                    requestState.request.ProtocolVersion = HttpVersion.Version11;
                    requestState.request.Method = "GET";
                    requestState.headers = requestState.request.Headers;
                    requestState.request.Accept = "text/html, application/xhtml+xml, image/jxr, */*";
                    requestState.headers.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.5");
                    requestState.request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36 Edge/16.16299";
                    requestState.headers.Add("Accept-Encoding", "gzip, deflate"); 
                    requestState.request.CookieContainer = requestState.cookieContainer;
                    IAsyncResult result = (IAsyncResult)requestState.request.BeginGetResponse(new AsyncCallback(RespFirstCallback), requestState);
                    allDone.WaitOne();
                }
                catch (WebException e)
                {
                    Console.WriteLine("\nRespCallback Exception raised!");
                    Console.WriteLine("\nMessage:{0}", e.Message);
                    Console.WriteLine("\nStatus:{0}", e.Status);
                }
                
                if (bLoginSuccess)
                {
                    break;
                }
                nLoginTimes++;
                if (nLoginTimes > 3)
                {
                    Program.form1.UpdateDataGridView(strAccount, Column.Login, string.Format("放弃"));
                    return;
                }
                Thread.Sleep(500);
           }


            while ((DateTime.Now < AllPlayers.dtStartTime))
            {
                if ((AllPlayers.dtStartTime - DateTime.Now).TotalMilliseconds > 60000)
                    Thread.Sleep(60000);
                else if ((AllPlayers.dtStartTime - DateTime.Now).TotalMilliseconds > 1000)
                    Thread.Sleep(1000);
                else if ((AllPlayers.dtStartTime - DateTime.Now).TotalMilliseconds > 50)
                    Thread.Sleep(50);
                else
                    Thread.Sleep(1);
            }

        }
    };

    class AllPlayers
    {
        public static bool bSetProxy = false;
        public static string strURL = @"";
        public static string strSkuid = @"";
        public static string strSkuid2 = @"";
        public static string strActTime = @"";
        public static int nInterval = 1000;
        public static DateTime dtStartTime;
        public static DateTime dtEndTime;
        public static List<Player> listPlayer = new List<Player>();

        public static void Init()
        {
            string szConfigFileName = System.Environment.CurrentDirectory + @"\" + @"config.txt";
            string szAccountFileName = System.Environment.CurrentDirectory + @"\" + @"account.csv";

            string[] arrayConfig = File.ReadAllLines(szConfigFileName);
            JObject joInfo = (JObject)JsonConvert.DeserializeObject(arrayConfig[0]);
            dtStartTime = DateTime.Parse((string)joInfo["StartTime"]);
            dtEndTime = DateTime.Parse((string)joInfo["EndTime"]);
            strSkuid = (string)joInfo["skuid"];
            strSkuid2 = (string)joInfo["skuid2"];
            strActTime = (string)joInfo["actTime"];
            nInterval = (int)joInfo["interval"];
            strURL = (string)joInfo["URL"];
            if ((string)joInfo["SetProxy"] == @"0")
                bSetProxy = false;
            else
                bSetProxy = true;
            Program.form1.Form1_Init();

            listPlayer = new List<Player>();
            string[] arrayText = File.ReadAllLines(szAccountFileName);
            for (int i = 0; i < arrayText.Length; ++i)
            {
                string[] arrayParam = arrayText[i].Split(new char[] { ',' });
                if (arrayParam.Length >= 3)
                {
                    Player player = new Player();
                    player.strAccount = arrayParam[1];
                    player.strPassword = arrayParam[2];
                    player.thread = new Thread(new ThreadStart(player.Run));
                    listPlayer.Add(player);
                    Program.form1.dataGridViewInfo_AddRow(arrayParam[1]);
                }
            }
        }


        public static void Run()
        {
            foreach (Player player in listPlayer)
            {
                player.thread.Start();
                Thread.Sleep(500);
            }

            foreach (Player player in listPlayer)
            {
                player.thread.Join();
            }

            Program.form1.richTextBoxStatus_AddString("任务完成!\n");
            Program.form1.button1_Enabled();
        }
    };
    
    
    
    class Http
    {
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
                
        public static string Timestamp()
        {
            TimeSpan span = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return ((ulong)span.TotalMilliseconds).ToString();
        }

        public static string UserMd5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                pwd = pwd + s[i].ToString("x2");
            }
            return pwd;
        }

    }
}
