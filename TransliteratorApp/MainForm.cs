
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TransliteratorApp
{
    public partial class MainForm : Form
    {
        private Dictionary<string, string> plToCyr = new Dictionary<string, string>
        {
            {"sz", "ш"},{"cz", "ч"},{"dz", "дз"},{"dź", "дь"},{"rz", "ж"},{"ja", "Я"},{"je", "Е"},{"ie", "Е"},{"e", "Э"},{"a", "а"},{"b", "б"},{"c", "ц"},{"ć", "ч"},{"d", "д"},{"f", "ф"},{"g", "г"},{"h", "х"},{"i", "и"},{"j", "й"},{"k", "к"},{"l", "ль"},{"ł", "л"},{"m", "м"},{"n", "н"},{"ń", "нь"},{"o", "о"},{"p", "п"},{"r", "р"},{"s", "с"},{"t", "т"},{"u", "у"},{"w", "в"},{"y", "ы"},{"z", "з"},{"ź", "зь"},{"ż", "ж"}
        };

        private Dictionary<string, string> cyrToPl = new Dictionary<string, string>
        {
            {"ш", "sz"},{"ч", "ć"},{"дз", "dz"},{"дь", "dź"},{"ж", "ż"},{"Я", "ja"},{"Е", "je"},{"Э", "e"},{"а", "a"},{"б", "b"},{"ц", "c"},{"д", "d"},{"ф", "f"},{"г", "g"},{"х", "h"},{"и", "i"},{"й", "j"},{"к", "k"},{"ль", "l"},{"л", "ł"},{"м", "m"},{"н", "n"},{"нь", "ń"},{"о", "o"},{"п", "p"},{"р", "r"},{"с", "s"},{"т", "t"},{"у", "u"},{"в", "w"},{"ы", "y"},{"з", "z"},{"зь", "ź"}
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnToCyr_Click(object sender, EventArgs e)
        {
            string input = txtPolski.Text.ToLower();
            var keys = plToCyr.Keys.OrderByDescending(k => k.Length);
            foreach (var key in keys)
            {
   input = input.Replace(key, plToCyr[key]);
            }
            txtRosyjski.Text = input;
        }

        private void btnToPl_Click(object sender, EventArgs e)
        {
            string input = txtRosyjski.Text;
            var keys = cyrToPl.Keys.OrderByDescending(k => k.Length);
            foreach (var key in keys)
            {
   input = input.Replace(key, cyrToPl[key]);
            }
            txtPolski.Text = input;
        }
    }
}
