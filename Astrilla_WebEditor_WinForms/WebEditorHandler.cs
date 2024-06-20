using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrilla_WebEditor_WinForms
{
    internal class WebEditorHandler
    {
        Button _lastButton;

        public void ChangeButtonStateActive (Button button)
        {
            // If there was a previously active button, reset its appearance
            if (_lastButton != null)
            {
                ResetButtonState(_lastButton);
            }

            // Set the new button's appearance to active state
            button.BackColor = SystemColors.GradientActiveCaption;
            button.FlatStyle = FlatStyle.Flat;
            _lastButton = button;
        }

        private void ResetButtonState(Button button)
        {
            // Reset the button's properties to their defaults
            button.BackColor = SystemColors.ControlLight;
            button.FlatStyle = FlatStyle.Standard;
        }
    }
}
