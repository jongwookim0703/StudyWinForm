using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_Form
{
    public partial class BaseMDIChildForm : Form , ChildInterface
    {
        public BaseMDIChildForm()
        {
            InitializeComponent();
        }

        public virtual void Inquire()         //오버라이드를 할수있게해주는 가상함수 virtual
        {
        }
        public virtual void DoNew()
        {
        }
        public virtual void Delete()
        {
        }
        public virtual void Save()
        {
        }
    }
}
