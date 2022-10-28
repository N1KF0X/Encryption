using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    partial class AboutBox : System.Windows.Forms.Form
    {
        public AboutBox()
        {
            InitializeComponent();
            textBox1.Text = "           Для того чтобы зашифровать текст введите его в поле «Текст для обработки» и нажмите кнопку «Зашифровать». " +
                "После программа выведет обработанный текст в поле «Результат», а так же выведет ключ для расшифровки в поле «Ключ». " +
                "Если вы хотите зашифровать текст по готовому ключу, то введите его в поле  «Ключ» и нажмите «Шифровать по ключу»." +
                Environment.NewLine + Environment.NewLine +
                "           Для того чтобы расшифровать текст введите его в поле «Текст для обработки», введите ключ в поле «Ключ» и нажмите кнопку «Расшифровать». " +
                "После программа выведет обработанный текст в поле «Результат»." +
                Environment.NewLine + Environment.NewLine +
                "       Для того чтобы копировать результат шифровки/расшифровки нажмите на кнопку «Скопировать» под полем «Результат»." +
                Environment.NewLine + Environment.NewLine +
                "       Для того чтобы копировать ключ нажмите на кнопку «Скопировать» под полем «Ключ».";
        }
    }
}
