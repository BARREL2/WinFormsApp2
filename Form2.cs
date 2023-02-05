namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        private IForm form1;

        public Form2(IForm form)
        {
            InitializeComponent();
            form1 = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.TextBoxValue = textBox1.Text;
            Close();
        }
    }
}