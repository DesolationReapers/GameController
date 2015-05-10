using System;
using System.ServiceProcess;
using System.Timers;
using System.Windows.Forms;

namespace GameController
{
    public partial class Form1 : Form
    {
        private ServiceController services = new ServiceController();

        //http://stackoverflow.com/a/1113006 service controller info

        private AddProgram newProgram;
        private System.Timers.Timer timeclock;
        private bool programState = false; //desired state: true = running, false = stopped
        private int sleeptime = 100; //milliseconds for the timer to sleep

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            setup();
        }

        private void setup()
        {
            newProgram = new AddProgram();
            timeclock = new System.Timers.Timer(sleeptime);
            timeclock.Elapsed += OnTimedEvent; //https://msdn.microsoft.com/en-us/library/system.timers.timer(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2
            outputTextBox.Clear();
            //TODO remove hardcoding
            listBox1.Items.Add("Teamviewer");
        }

        //TODO Colored messages
        public void print(string text)
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

        //TODO add settings for handling as process or service (kill or stop)
        //TODO wait for process start/stop and output message that it stopped  - Hack Fix complete
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
                        programState = true;
                        timeclock.Start();
                    }
                    catch (Exception ex)
                    {
                        print(ex.ToString());
                    }
                }
                else if (services.Status.Equals(ServiceControllerStatus.Running))
                {
                    print(services.ServiceName + " is already running\n");
                }
                else if (services.Status.Equals(ServiceControllerStatus.StartPending))
                {
                    print(services.ServiceName + " is in the process of starting\n");
                }
                else if (services.Status.Equals(ServiceControllerStatus.StopPending))
                {
                    print(services.ServiceName + " is in the process of stopping\n");
                }
                else
                {
                    print(services.ServiceName + " is " + services.Status + "\n");
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
                        programState = false;
                        timeclock.Start();
                    }
                    catch (Exception ex)
                    {
                        print(ex.ToString());
                    }
                }
                else if (services.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    print(services.ServiceName + " is not running\n");
                }
                else if (services.Status.Equals(ServiceControllerStatus.StopPending))
                {
                    print(services.ServiceName + " is in the process of stopping\n");
                }
                else if (services.Status.Equals(ServiceControllerStatus.StartPending))
                {
                    print(services.ServiceName + " is in the process of starting\n");
                }
                else
                {
                    print(services.ServiceName + " is " + services.Status + "\n");
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
            if (listBox1.SelectedItem != null) //Because Microsoft
            {
                //TODO remove hardcoding
                if (listBox1.SelectedItem.Equals("Teamviewer"))
                {
                    services.ServiceName = "Teamviewer";
                }
            }
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            try
            {
                newProgram.Show();  //Try to show the AddProgram window
                newProgram.Focus(); //Try to focus the AddProgram window
            }
            catch (ObjectDisposedException) //If object was destroyed (opened previously then closed)
            {
                newProgram = new AddProgram(); //Create a new one
                newProgram.Show(); //Show it
                newProgram.Focus(); //Focus it
            }
        }

        //TODO maybe we want to inform the user that they should not be spamming the button?
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            services.Refresh(); //desired state: true = running, false = stopped
            if (programState && services.Status.Equals(ServiceControllerStatus.Running))
            {
                print(services.ServiceName + " : Is Started\n");
                timeclock.Stop();
            }
            else if (!programState && services.Status.Equals(ServiceControllerStatus.Stopped))
            {
                print(services.ServiceName + " : Is Stopped\n");
                timeclock.Stop();
            }
        }
    }
}
