using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObservableCollectionDemo
{
    public partial class Form1 : Form
    {
        private ModelController controller = new ModelController();
        private ProjectModel projectModel = null;        
        public Form1()
        {
            InitializeComponent();
            string  path = "sample.xml";
            projectModel = controller.Load(path);

            propertyGrid1.SelectedObject = controller.ProjectModel; 
        }
    }
}
