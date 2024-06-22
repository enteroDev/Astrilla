using Astrilla_Logic;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Astrilla_WebEditor_WinForms
{
    public partial class ZodiacSigns : Form
    {
        WebEditorHandler webEditorHandler;
        string _zodiacSignID = String.Empty;

        public ZodiacSigns()
        {
            InitializeComponent();
            webEditorHandler = new WebEditorHandler();
        }

        private async void btn_SelectionAquarius_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionCancer_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionFish_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionAries_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionTaurus_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionGemini_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionLeo_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionVirgo_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionLibra_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionScorpio_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionSagittarius_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SelectionCapricorn_Click(object sender, EventArgs e)
        {
            await LoadZodiacInfo(sender);
        }

        private async void btn_SaveChanges_Zodiac_Click(object sender, EventArgs e)
        {
            var zodiacSignInfo = new ZodiacInformation
            {
                ID = _zodiacSignID, // Store the current ID when loading the data
                Summary = tb_SummaryZodiac.Text,
                Text1 = tb_TextZodiac1.Text,
                Text2 = tb_TextZodiac2.Text,
                Text3 = tb_TextZodiac3.Text,
                Text4 = tb_TextZodiac4.Text,
                Text5 = tb_TextZodiac5.Text,
                Text6 = tb_TextZodiac6.Text
            };

            var result = await UpdateZodiacSignInfo(zodiacSignInfo);
            MessageBox.Show(result ? "Update successful!" : "Update failed.");
        }

        // Fetch Texts from clicked Zodiac
        private async Task LoadZodiacInfo(object sender)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                webEditorHandler.ChangeButtonStateActive(clickedButton);
                _zodiacSignID = GetZodiacSignIdFromButtonName(clickedButton.Name).ToLower();

                if (!string.IsNullOrEmpty(_zodiacSignID))
                {
                    var zodiacSignInfo = await GetZodiacSignInfo(_zodiacSignID);

                    if (zodiacSignInfo != null)
                    {
                        tb_SummaryZodiac.Text = FormatText(zodiacSignInfo.Summary);
                        tb_TextZodiac1.Text = FormatText(zodiacSignInfo.Text1);
                        tb_TextZodiac2.Text = FormatText(zodiacSignInfo.Text2);
                        tb_TextZodiac3.Text = FormatText(zodiacSignInfo.Text3);
                        tb_TextZodiac4.Text = FormatText(zodiacSignInfo.Text4);
                        tb_TextZodiac5.Text = FormatText(zodiacSignInfo.Text5);
                        tb_TextZodiac6.Text = FormatText(zodiacSignInfo.Text6);
                    }
                }
                else
                {
                    MessageBox.Show("No zodiac sign ID found.");
                }
            }
        }

        // Format text for better view in WebEditor
        private string FormatText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            // Clean and trim the text
            text = text.Trim();

            // Replace multiple spaces with a single space
            text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ");

            return text;
        }

        // Fetch Zodiac Texts via Controller
        private async Task<ZodiacInformation> GetZodiacSignInfo(string id)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = "https://localhost:7030"; // Make sure this URL is correct
                var response = await client.GetStringAsync($"{baseUrl}/Partial/GetZodiacInfo?id={id}");

                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response);

                if (jsonResponse.success == true)
                {
                    var zodiacInfoJson = jsonResponse.data.ToString();
                    return JsonConvert.DeserializeObject<ZodiacInformation>(zodiacInfoJson);
                }

                return null;
            }
        }

        // Update Zodiac Texts via Controller
        private async Task<bool> UpdateZodiacSignInfo(ZodiacInformation zodiacSignInfo)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = "https://localhost:7030"; // Ensure this URL is correct
                var json = JsonConvert.SerializeObject(zodiacSignInfo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{baseUrl}/Partial/UpdateZodiacInfo", content);
                return response.IsSuccessStatusCode;
            }
        }

        // Extract zodiac name from buttonName
        private string GetZodiacSignIdFromButtonName(string buttonName)
        {
            if (buttonName.StartsWith("btn_Selection"))
            {
                return buttonName.Substring("btn_Selection".Length);
            }
            return null;
        }
    }
}
