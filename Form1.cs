using System.Threading.Tasks;

namespace A1_TaskList
{
    public partial class Form1 : Form
    {
        string save = "TaskList.txt";
        List<TaskInfo> tasks = new List<TaskInfo>();

        public Form1()
        {
            InitializeComponent();

            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TaskInfo ti = new TaskInfo();
            ti.NewName(txtTaskName.Text);
            lstTasks.Items.Add(ti);
            ti.NewDate(dtpDate.Value);
            ti.NewTime(dtpTime.Value);
            if (rbAM.Checked)
            {
                ti.NewAmPm(rbAM.Text);
            }
            else
            {
                ti.NewAmPm(rbPM.Text);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lstTasks.Items.Remove(lstTasks.SelectedItem);
            lblDate.Text = "";
            lblTime.Text = "";
            lblAmPm.Text = "";
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var taskInfo in lstTasks.Items)
            {
                TaskInfo Task = taskInfo as TaskInfo;

                save += Task.GetName() + "\n"; // + ":" + Task.GetDate();
            }

            File.WriteAllText("TaskList.txt", save);

            MessageBox.Show("Task list saved");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            List<string> tasks = File.ReadAllLines("TaskList.txt").ToList();

            foreach (string task in tasks)
            {
                lstTasks.Items.Add(task);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem == null) return; // <---- FailSafe to prevent application crashing
            TaskInfo selected = lstTasks.SelectedItem as TaskInfo;
            if (selected != null) // <---- FailSafe to prevent application crashing as app cant return null data
            {
                lblDate.Text = Convert.ToString(selected.GetDate());
                //Console.WriteLine(selected.GetDate());
                lblTime.Text = Convert.ToString(selected.GetTime());
                lblAmPm.Text = selected.GetAmPm();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About About = new About();
            About.ShowDialog();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstTasks.Items.Clear();
            txtTaskName.Text = "";
            lblDate.Text = "";
            lblTime.Text = "";
            lblAmPm.Text = "";
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstTasks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 127) //ascii for del
            {
                btnRemove_Click(sender, e);
            }
        }

        private void txtTaskName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)  //ascii for enter
            {
                btnAdd_Click(sender, e);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}