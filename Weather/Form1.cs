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
                new City(){ cityid="101200101",citynm="湖北省",pid=""},
                new City(){ cityid="0003",citynm="天津市",pid=""},
                new City(){ cityid="0004",citynm="浙江省",pid=""},
            };
            this.comboBox1.DisplayMember = "citynm";
            this.comboBox1.ValueMember = "cityid";
            this.comboBox1.DataSource = comboxs;
            this.comboBox1.SelectedIndex = 0;
        }
    }
}