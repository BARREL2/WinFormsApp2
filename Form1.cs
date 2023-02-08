using System.Windows.Forms;
using System;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource();
        private readonly Dictionary<string, bool> _textBoxValues = new Dictionary<string, bool>
        {
            { "textBox1", false },
            { "textBox2", false },
            { "textBox3", false }
        };

        public Form1()
        {
            InitializeComponent();

            textBox1.KeyPress += CheckKeyPress;
            textBox2.KeyPress += CheckKeyPress;
            textBox3.KeyPress += CheckKeyPress;

            _bindingSource.DataSource = typeof(DatabindTest);

            // TextBox と Label にデータバインドします
            textBox1.DataBindings.Add("Text", _bindingSource, "Name");
            label1.DataBindings.Add("Text", _bindingSource, "Value");
        }

        private void HandleButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.LightGreen;
        }

        private void UpdateTextBox(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _textBoxValues[textBox.Name] = !string.IsNullOrEmpty(textBox.Text);

            button4.BackColor = _textBoxValues.Values.All(value => value)
                ? Color.GreenYellow
                : SystemColors.ControlLight;
        }

        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null)
                return;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // データソースに新しい Person オブジェクトを追加します
            _bindingSource.Add(new DatabindTest { Name = "John Doe", Value = 30 });
        }
    }

    class DatabindTest
    {
        public string Name {get; set;}
        public int Value { get; set;}
    }
}
