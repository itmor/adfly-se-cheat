using SeproxyTools;
using System.Diagnostics;
using System.Windows.Forms;

namespace AdflySe
{
    public partial class ProgramForm : Form
    {
        public ProgramForm()
        {
            InitializeComponent();
            Seproxy seproxy = new Seproxy();

            if (seproxy.SetServerAddress("http://322.188.53.22:8080"))
            {
                seproxy.Connect();
                seproxy.GetNewProxy(() => {
                    Debug.WriteLine("Proxy changed");
                });
            }

            

        }

        public bool NewProxyHandler (string response)
        {
            return false;
        }

    }
}
