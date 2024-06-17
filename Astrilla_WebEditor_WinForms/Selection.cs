namespace Astrilla_WebEditor_WinForms
{
    public partial class Selection : Form
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void btn_zodiacSigns_Click(object sender, EventArgs e)
        {
            ZodiacSigns zodiacSignsForm = new ZodiacSigns();
            zodiacSignsForm.Show();
        }

        private void btn_aboutUs_Click(object sender, EventArgs e)
        {

        }
    }
}
