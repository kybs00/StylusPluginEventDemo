using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StylusPluginEventDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StylusPlugIns.Add(new TestStylusPlugIn(Thread.CurrentThread.ManagedThreadId));
        }
    }
    class TestStylusPlugIn : StylusPlugIn
    {
        private readonly int _uiThreadId;

        public TestStylusPlugIn(int uiThreadId)
        {
            _uiThreadId = uiThreadId;
        }

        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            if (Thread.CurrentThread.ManagedThreadId == _uiThreadId)
            {
                return;
            }
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}:StylusPluginOnStylusDown {rawStylusInput.GetStylusPoints().Count}个点");
            base.OnStylusDown(rawStylusInput);
        }

        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            if (Thread.CurrentThread.ManagedThreadId == _uiThreadId)
            {
                return;
            }
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}:StylusPluginOnStylusMove {rawStylusInput.GetStylusPoints().Count}个点");
            base.OnStylusMove(rawStylusInput);
        }

        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            if (Thread.CurrentThread.ManagedThreadId == _uiThreadId)
            {
                return;
            }
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}:StylusPluginOnStylusUp {rawStylusInput.GetStylusPoints().Count}个点");
            base.OnStylusUp(rawStylusInput);
        }
    }
}