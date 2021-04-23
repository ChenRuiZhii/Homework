using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;




namespace Crawler
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

        }
        
        public class WebCrawler
        {
            public Hashtable urls;
            private int count = 0;

            public WebCrawler(Hashtable url)
            {
                this.urls = url;
                CheckForIllegalCrossThreadCalls = false;
            }

            public Label label;
            public int maxCount { get; set; }
            
            public void Crawl()
            {
                while(true)
                {
                    string current = null;
                    foreach(string url in urls.Keys)
                    {
                        Console.WriteLine(url);
                            
                            current = url;

                        if (!(bool)urls[url]) break;
                    }
                    if (current==null || (bool)urls[current] || count > maxCount) break;
                    label.Text += "\n爬行" + current + "页面!";
                    string html = DownLoad(current);
                    urls[current] = true;
                    count++;
                    Parse(html,current);
                }
            }

            public string DownLoad(string url)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = Encoding.UTF8;
                    string html = webClient.DownloadString(url);

                    string fileName = count.ToString();
                    File.WriteAllText(fileName, html, Encoding.UTF8);
                    return html;
                }
                catch(Exception ex)
                {
                    label.Text += ex.Message;
                    Console.WriteLine(ex.Message);
                    return "";
                }
            }

            public void Parse(string html ,string current)
            {
                string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+(html|aspx|jsp)[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach(Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"','\"',  '#', '>');
                    
                    if (strRef.Length == 0) continue;

                    if (strRef.Substring(0, 2) == "//") strRef = "https:" + strRef;
                    else if (strRef.Substring(0, 1) == "/") strRef = current + strRef;
                    if (urls[strRef] == null) urls[strRef] = false;
                }
            }


        }
        public Hashtable urls = new Hashtable();

        private void start_Click(object sender, EventArgs e)
        {
            testLable.Text = "开始爬行....";


            WebCrawler myCrawler = new WebCrawler(urls);
            int k = int.Parse(textBox1.Text);
            if (k > 0 && k < 15)
            {
                myCrawler.maxCount = k;
            }
            else
                myCrawler.maxCount = 10;
            myCrawler.label = testLable;
            string startUrl = textForWeb.Text;
            try { 
            myCrawler.urls.Add(startUrl, false);

            }
            catch (ArgumentException ) {
            
            }
            // myCrawler.Crawl();


            lock (urls)
            {
                myCrawler.Crawl();
            }

            Parallel.Invoke(new Action[]
            {
                
                ()=> myCrawler.Crawl(),
                ()=> myCrawler.Crawl()
            });
            testLable.Text += "\n爬行结束";



            // new Thread(myCrawler.Crawl).Start();


        }

        private void testLable_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
