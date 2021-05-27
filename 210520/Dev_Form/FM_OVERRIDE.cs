using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Form
{
    public partial class FM_OVERRIDE : BaseMDIChildForm
    {
        public FM_OVERRIDE()
        {
            InitializeComponent();
        }

        public override void Save()
        {
            base.Save();
        }
        public override void Inquire()
        {
            base.Inquire();
        }
    }
}
