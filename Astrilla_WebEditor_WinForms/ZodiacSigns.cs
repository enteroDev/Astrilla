using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astrilla_WebEditor_WinForms
{
    public partial class ZodiacSigns : Form
    {
        public ZodiacSigns()
        {
            InitializeComponent();
            InitializePanels();
        }

        private void InitializePanels()
        {
            panel_SelectionAquarius.Visible = false;
            panel_SelectionFish.Visible = false;
            panel_SelectionAries.Visible = false;
            panel_SelectionTaurus.Visible = false;
            panel_SelectionGemini.Visible = false;
            panel_SelectionCancer.Visible = false;
            panel_SelectionLeo.Visible = false;
            panel_SelectionVirgo.Visible = false;
            panel_SelectionLibra.Visible = false;
            panel_SelectionScorpio.Visible = false;
            panel_SelectionSagittarius.Visible = false;
            panel_SelectionCapricorn.Visible = false;

            // Set initial visibility or default view
            panel_SelectionAquarius.Visible = true; // Show the default panel
        }

        private void btn_SelectionAquarius_Click(object sender, EventArgs e)
        {
            ShowPanel(panel_SelectionAquarius);
        }

        private void btn_SelectionFish_Click(object sender, EventArgs e)
        {
            ShowPanel(panel_SelectionFish);
        }

        private void ShowPanel(Panel panel)
        {
            // Hide all panels
            panel_SelectionAquarius.Visible = false;
            panel_SelectionFish.Visible = false;
            panel_SelectionAries.Visible = false;
            panel_SelectionTaurus.Visible = false;
            panel_SelectionGemini.Visible = false;
            panel_SelectionCancer.Visible = false;
            panel_SelectionLeo.Visible = false;
            panel_SelectionVirgo.Visible = false;
            panel_SelectionLibra.Visible = false;
            panel_SelectionScorpio.Visible = false;
            panel_SelectionSagittarius.Visible = false;
            panel_SelectionCapricorn.Visible = false;

            // Show the selected panel
            panel.Visible = true;
        }
    }
}
