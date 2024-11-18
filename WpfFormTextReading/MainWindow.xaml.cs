using System.IO;
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

namespace WpfFormTextReading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<ProgressBar> progressBarList;
        private List<string> fileList;
        private static Mutex mutex = new Mutex();
        private string fileText = "";
        public MainWindow()
        {
            InitializeComponent();
            progressBarList = new List<ProgressBar>();
            progressBarList.Add(pgCopyProgress1);


            fileList = new List<string>();
            fileList.Add("file1.txt");
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            startThreads();
        }


        private void Copy(string outFileName, ProgressBar progressBar)
        {
            byte[] buffer = new byte[8];
            long copied = 0;
            long length = new FileInfo(outFileName).Length;

            using (Stream outStream = File.Create("copied" + outFileName))
            using (Stream inStream = File.OpenRead(outFileName))
            while (copied < length)
            {
                int read = inStream.Read(buffer, 0, buffer.Length);
                outStream.Write(buffer, 0, read);
                copied += read;
                this.Dispatcher.Invoke(() => progressBar.Value = 100 * (int)(copied / length));
            }
        }


        private void startThreads()
        {
            Thread[] threads = new Thread[1];
            for (int i = 0; i < threads.Length; i++)
            {
                int index = i;
                threads[i] = new Thread(() => Copy(fileList[index], progressBarList[index]));
                threads[i].Start();
            }
        }
    }
}