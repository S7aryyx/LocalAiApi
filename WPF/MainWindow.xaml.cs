using LocalAiApi.Controllers;
using LocalAiApi.Models;
using LocalAiApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            public HttpClient client = new HttpClient();
            public OllamaService olms = new OllamaService(clie);
            //client.Dispose(); //При закрытии WPF -> Разорвёт соединение с LocalAI_API , теим самым закроет подключения.
            InitializeComponent();
        }

        public async Task OnButtonSendClick(object sender, RoutedEventArgs e)
        {
            var выбранная_заметка;
            //или
            var выбранные_заметки; 
            //Если заметок много (>1) Выбранные заметки будут лежать в [] массиве

            //Перед отправкой , через TRY-Catch , конвертим все заметки\заметку в JSON

            await 

        }

        public async string Chat(CancellationToken cancellationToken)
        {
            
            
        }

        private void VisabilityButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient(); //Посмотреть параметры httpClient , 
                                                          //Если получится дать соединению ИМЯ (или клиенту) , будет круто.

                var Note_Json = "Привет Qwen , ты живой ?";
                var result = await olms.ChatAsync(Note_Json, "analyse", cancellationToken);
                return result;

                //Вызываем через ссыылку метод ЧАТА.
                //Для удобства можно сделать ChatWithWPF -> такой-же по смыслу метод на AI сервере
                //Но который , будет принимать заметку в обработку, а ен просто входную строчку

            }

            catch (InvalidOperationException ex)
            {
                MessageBox.Show("ИИ Вернула неккоректный ответ");
            }
        }
    }
}
}