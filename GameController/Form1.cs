using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace GameController
{
    public partial class Form1 : Form
    {
        private ServiceController services = new ServiceController();

        //http://stackoverflow.com/a/1113006
        private int n = new int();

        private AddProgram newProgram;

        public Form1()
        {
            InitializeComponent();
            setup();
        }

        private void setup()
        {
            newProgram = new AddProgram();
            outputTextBox.Clear();
            listBox1.Items.Add("Teamviewer");
        }

        private void print(string text)
        {
            outputTextBox.AppendText(text); //print the received string
            outputTextBox.ScrollToCaret(); //Scroll the window to the newly printed line
        }

        private bool checkSelection()
        {
            bool selection = false;
            if (services.ServiceName == null || services.ServiceName == "")
            {
                print("You must select a service to manage" + "\n");
            }
            else
            {
                //print(services.ServiceName);
                services.Refresh();
                selection = true;
            }

            return selection;
        }

        private void btnManualStart_Click(object sender, EventArgs e)
        {
            if (checkSelection())
            {
                if (services.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    try
                    {
                        print("Starting " + services.ServiceName + "\n");
                        services.Start();
                    }
                    catch (Exception ex)
                    {
                        print(ex.ToString());
                    }
                }
                else if (services.Status.Equals(ServiceControllerStatus.Running))
                {
                    print(services.ServiceName + " is already running." + "\n");
                }
                else
                {
                    print(services.ServiceName + " is " + services.Status);
                }
            }
        }

        private void btnManualStop_Click(object sender, EventArgs e)
        {
            if (checkSelection())
            {
                if (services.Status.Equals(ServiceControllerStatus.Running))
                {
                    try
                    {
                        print("Stopping " + services.ServiceName + "\n");
                        services.Stop();
                    }
                    catch (Exception ex)
                    {
                        print(ex.ToString());
                    }
                }
                else if (services.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    print(services.ServiceName + " is not running." + "\n");
                }
                else
                {
                    print(services.ServiceName + " is " + services.Status);
                }
            }
        }

        private void btnManualStatus_Click(object sender, EventArgs e)
        {
            if (checkSelection())
            {
                services.Refresh();
                print("[INFO] " + services.ServiceName + " " + services.Status + "\n");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && listBox1.SelectedItem.Equals("Teamviewer"))
            {
                services.ServiceName = "Teamviewer";
            }
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            try
            {
                newProgram.Show();
                newProgram.Focus();
            }
            catch (ObjectDisposedException)
            {
                newProgram = new AddProgram();
                newProgram.Show();
                newProgram.Focus();
            }
        }
    }
}