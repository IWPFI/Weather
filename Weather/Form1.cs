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
    }
}