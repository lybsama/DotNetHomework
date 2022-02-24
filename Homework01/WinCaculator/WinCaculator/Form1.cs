namespace WinCaculator
{
    public partial class Form1 : Form
    {
        int x, y, z = 0;
        int result = 0;
        private object label;

        public Form1()
        {
            InitializeComponent();
        }

        private void textbox1(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            x = Convert.ToInt32(text.Text);
        }
        private void textbox2(object sender, EventArgs e)
        {
            TextBox text =(TextBox)sender;
            y = Convert.ToInt32(text.Text);
        }
        private void listbox(object sender,EventArgs e)
        {
            ListBox list = (ListBox)sender;
            z=list.SelectedIndex;
        }
        private void button(object sender,EventArgs e)
        {
            switch (z)
            {
                case 0: result = x+y; break;
                case 1: result = x-y; break;
                case 2: result = x*y; break;
                case 3: result = x/y; break;
            }
            label.Text = "" + result;
        }

    }
}