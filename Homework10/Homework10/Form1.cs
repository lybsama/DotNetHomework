using System;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Collections.Generic;


namespace homework10
{
    public partial class Form1 : Form
    {
        Crawler1 crawler = new Crawler1();
        Thread thread = null;


        public Form1()
        {
            InitializeComponent();
            crawler.PageDownloaded += Crawler_PageDownloaded;
            crawler.CrawlerStopped += Crawler_CrawlerStopped;
        }

        private void Crawler_CrawlerStopped(Crawler1 obj)
        {
            MessageBox.Show( "爬虫已停止");
        }

        private void Crawler_PageDownloaded(Crawler1 crawler, int index, string url, string info)
        {
            var pageInfo = new { Index = index, URL = url, Status = info };
        }
        public class Crawler1
        {
            public event Action<Crawler1> CrawlerStopped;
            public event Action<Crawler1, int, string, string> PageDownloaded;

            private ConcurrentDictionary<string, bool> urls = new ConcurrentDictionary<string, bool>();

            private ConcurrentQueue<string> pending = new ConcurrentQueue<string>();

            private readonly string urlDetectRegex = @"(href|HREF)\s*=\s*[""'](?<url>[^""'#>]+)[""']";

            public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w\d.]+)(:\d+)?($|/))([\w\d]+/)*(?<file>[^#?]*)";
            public string HostFilter { get; set; }
            public string FileFilter { get; set; } 
            public int MaxPage { get; set; } 
            public string StartURL { get; set; } 
            public Encoding HtmlEncoding { get; set; }

            public Crawler1()
            {
                MaxPage = 100;
                HtmlEncoding = Encoding.UTF8;
            }

            public void Start()
            {
                urls.Clear();
                pending = new ConcurrentQueue<string>();
                pending.Enqueue(StartURL);

                List<Task> tasks = new List<Task>();
                int complatedCount = 0;
                PageDownloaded += (crawler, index, url, info) => { complatedCount++; };

                while (tasks.Count < MaxPage)
                {
                    if (!pending.TryDequeue(out string url))
                    {
                        if (complatedCount < tasks.Count)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    int index = tasks.Count;
                    Task task = Task.Run(() => DownloadAndParse(url, index));
                    tasks.Add(task);
                }

                Task.WaitAll(tasks.ToArray()); 
                CrawlerStopped(this);
            }

            private void DownloadAndParse(string url, int index)
            {
                try
                {
                    string html = DownLoad(url, index);
                    urls[url] = true;
                    Parse(html, url);
                    PageDownloaded(this, index, url, "success");
                }
                catch (Exception ex)
                {
                    PageDownloaded(this, index, url, "Error:" + ex.Message);
                }
            }

            private string DownLoad(string url, int index)
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = HtmlEncoding;
                string html = webClient.DownloadString(url);
                File.WriteAllText(index + ".html", html, Encoding.UTF8);
                return html;
            }

            private void Parse(string html, string pageUrl)
            {
                var matches = new Regex(urlDetectRegex).Matches(html);
                foreach (Match match in matches)
                {
                    string linkUrl = match.Groups["url"].Value;
                    if (linkUrl == null || linkUrl == "") continue;
                    linkUrl = FixUrl(linkUrl, pageUrl);

                    Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                    string host = linkUrlMatch.Groups["host"].Value;
                    string file = linkUrlMatch.Groups["file"].Value;
                    if (file == "") file = "index.html";

                    if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter)
                      && !urls.ContainsKey(linkUrl))
                    {
                        pending.Enqueue(linkUrl);
                        urls.TryAdd(linkUrl, false);
                    }
                }
            }
            static private string FixUrl(string url, string baseUrl)
            {
                if (url.Contains("://"))
                {
                    return url;
                }
                if (url.StartsWith("//"))
                {
                    return "http:" + url;
                }
                if (url.StartsWith("/"))
                {
                    Match urlMatch = Regex.Match(baseUrl, urlParseRegex);
                    String site = urlMatch.Groups["site"].Value;
                    return site.EndsWith("/") ? site + url.Substring(1) : site + url;
                }

                if (url.StartsWith("../"))
                {
                    url = url.Substring(3);
                    int idx = baseUrl.LastIndexOf('/');
                    return FixUrl(url, baseUrl.Substring(0, idx));
                }

                if (url.StartsWith("./"))
                {
                    return FixUrl(url.Substring(2), baseUrl);
                }

                int end = baseUrl.LastIndexOf("/");
                return baseUrl.Substring(0, end) + "/" + url;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            crawler.StartURL = "https://www.cnblogs.com/";

            Match match = Regex.Match(crawler.StartURL, Crawler1.urlParseRegex);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            crawler.HostFilter = "^" + host + "$";
            crawler.FileFilter = ".html?$";

            if (thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(crawler.Start);
            thread.Start();
            MessageBox.Show("Start crawling...");
        }
    }
}
