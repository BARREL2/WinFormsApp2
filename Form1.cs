namespace WinFormsApp2
{
    public interface IForm
    {
        string TextBoxValue { get; set; }
    }

    public partial class Form1 : Form, IForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string TextBoxValue { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
    }
}