using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ObservableCollectionDemo
{
    [XmlRoot("projectModel")]
    [Serializable()]
    public class ProjectModel
    {
        private Accounts _accounts = new Accounts();
        [XmlArray("accounts")]
        public Accounts Accounts
        {
            get { return this._accounts; }
            set { this._accounts = value; }
        }

        public static ProjectModel Load(string path, out ProjectModel project)
        {

            project = null;

            try
            {                
                Type[] extendedTypes = new Type[] { typeof(Account), typeof(Accounts) };

                Stream stream = File.Open(path, FileMode.Open);
                XmlSerializer xs = new XmlSerializer(typeof(ProjectModel));
                project = (ProjectModel)xs.Deserialize(stream);
                stream.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //error loging
                return project;
            }
            project.InitializeNotification();
            return project;            
        }

        private void InitializeNotification()
        {
            Accounts.CollectionChanged +=Accounts_CollectionChanged;
        }

        private void Accounts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    MessageBox.Show("Add");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    MessageBox.Show("Remove");
                    break;
                case NotifyCollectionChangedAction.Reset:
                    MessageBox.Show("Reset");                    
                    break;
                case NotifyCollectionChangedAction.Replace:
                    MessageBox.Show("Replace");
                    break;
            }
        }
    }
}
