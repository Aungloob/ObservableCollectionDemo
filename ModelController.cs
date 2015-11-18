using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableCollectionDemo
{
    [Serializable()]
    public class ModelController
    {
        private ProjectModel projectModel = new ProjectModel();
        public ProjectModel ProjectModel
        {
            get { return this.projectModel; }
            set { this.projectModel = value; }
        }

        public ProjectModel Load(string path)        
        {          
            return ProjectModel.Load(path, out projectModel);
        }
    }
}
