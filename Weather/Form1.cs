using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using Weather.Model;

namespace Weather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<City> comboxs = new List<City>()
            {
                new City(){ cityid="101010100",citynm="北京市",pid=""},
                new City(){ cityid="101200101",citynm="湖北省",pid=""}
            };
            this.comboBox1.DisplayMember = "citynm";
            this.comboBox1.ValueMember = "cityid";
            this.comboBox1.DataSource = comboxs;
            this.comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            List<City> comboxs2 = new List<City>()
            {
                new City(){ cityid="101010300",citynm="朝阳",pid="101010100"},
                new City(){ cityid="101010400",citynm="顺义",pid="101010100"},
                new City(){ cityid="101010500",citynm="怀柔",pid="101010100"},
                new City(){ cityid="101010600",citynm="通州",pid="101010100"},
                new City(){ cityid="101010700",citynm="昌平",pid="101010100"},
                new City(){ cityid="101010900",citynm="丰台",pid="101010100"},

                new City(){ cityid="101010300",citynm="朝阳",pid="101200101"},
                new City(){ cityid="101010400",citynm="顺义",pid="101200101"},
                new City(){ cityid="101010500",citynm="怀柔",pid="101200101"},
                new City(){ cityid="101010600",citynm="通州",pid="101200101"},
                new City(){ cityid="101010700",citynm="昌平",pid="101200101"},
                new City(){ cityid="101010900",citynm="丰台",pid="101200101"}
            };
            this.comboBox2.DisplayMember = "citynm";
            this.comboBox2.ValueMember = "cityid";
            if (this.comboBox1.SelectedValue != null)
            {
                var currlist = comboxs2.Where(p => p.pid == this.comboBox1.SelectedValue.ToString()).ToList();
                this.comboBox2.DataSource = currlist;
                this.comboBox2.SelectedIndex = 0;
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            #region 读取当前的天气
            if (this.comboBox2.SelectedValue != null)
            {
                //接受天气数据
                Weathers w = new Weathers();
                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    //天气的aip地址
                    string serviceAddress = "http://api.k780.com/?app=weather.realtime&weaId=1&ag=today,futureDay,lifeIndex,futureHour&appkey=10003&sign=b59bc3ef6191eb9f747dd4e83c99f2a4&format=jsondeeeew";
                    //通过WebClient实例化对象后，下载网页数据
                    var data = client.DownloadString(serviceAddress);

                    //将数据序列化为Weathers对象
                    w = JsonConvert.DeserializeObject<Weathers>(data) ?? new Weathers();
                }

                if (w.success == "1")
                {
                    label1.Text = DateTime.Now.ToString("HH:mm");
                    label2.Text = w.result.week;
                    label3.Text = w.result.weather_curr;
                    label4.Text = w.result.temp_low + "C-" + w.result.temp_high + "C";

                    //设置图片
                    //pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/weather/" + w.result.weather_curr + ".png");
                }
                else
                {
                    if (w.msg == "EXCEED_LIMIT")
                    {
                        MessageBox.Show("使用次数超限");
                    }
                    else
                    {
                        MessageBox.Show("无法查询到当前城市天气消息");
                    }
                }
            }
            #endregion
        }
    }
}