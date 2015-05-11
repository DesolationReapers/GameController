using System;
using System.ServiceProcess;
using System.Timers;
using System.Windows.Forms;

namespace GameController
{
    public partial class Form1 : Form
    {
        private ServiceController[] services = System.ServiceProcess.ServiceController.GetServices();
        private ServiceController selectedService = new ServiceController();

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
            timeclock.Elapsed += OnTimedEvent; // https://goo.gl/nOvmlw
            outputTextBox.Clear();
            //TODO remove hardcoding
            //listBox1.Items.Add("Teamviewer");

            foreach (ServiceController serController in services)
            {
                listBox1.Items.Add(serController.ServiceName); // TODO decide on ServiceName or DisplayName
            }
        
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
            if (selectedService.ServiceName == null || selectedService.ServiceName == "")
            {
                print("You must select a service to manage" + "\n");
            }
            else
            {
                //print(services.ServiceName);
                selectedService.Refresh();
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
                if (selectedService.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    try
                    {
                        print("Starting " + selectedService.ServiceName + "\n");
                        selectedService.Start();
                        programState = true;
                        timeclock.Start();
                    }
                    catch (Exception ex)
                    {
                        print(ex.ToString());
                    }
                }
                else if (selectedService.Status.Equals(ServiceControllerStatus.Running))
                {
                    print(selectedService.ServiceName + " is already running\n");
                }
                else if (selectedService.Status.Equals(ServiceControllerStatus.StartPending))
                {
                    print(selectedService.ServiceName + " is in the process of starting\n");
                }
                else if (selectedService.Status.Equals(ServiceControllerStatus.StopPending))
                {
                    print(selectedService.ServiceName + " is in the process of stopping\n");
                }
                else
                {
                    print(selectedService.ServiceName + " is " + selectedService.Status + "\n");
                }
            }
        }

        private void btnManualStop_Click(object sender, EventArgs e)
        {
            if (checkSelection())
            {
                if (selectedService.Status.Equals(ServiceControllerStatus.Running))
                {
                    try
                    {
                        print("Stopping " + selectedService.ServiceName + "\n");
                        selectedService.Stop();
                        programState = false;
                        timeclock.Start();
                    }
                    catch (Exception ex)
                    {
                        print(ex.ToString());
                    }
                }
                else if (selectedService.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    print(selectedService.ServiceName + " is not running\n");
                }
                else if (selectedService.Status.Equals(ServiceControllerStatus.StopPending))
                {
                    print(selectedService.ServiceName + " is in the process of stopping\n");
                }
                else if (selectedService.Status.Equals(ServiceControllerStatus.StartPending))
                {
                    print(selectedService.ServiceName + " is in the process of starting\n");
                }
                else
                {
                    print(selectedService.ServiceName + " is " + selectedService.Status + "\n");
                }
            }
        }

        private void btnManualStatus_Click(object sender, EventArgs e)
        {
            if (checkSelection())
            {
                selectedService.Refresh();
                print("[INFO] " + selectedService.ServiceName + " " + selectedService.Status + "\n");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null) //Because Microsoft
            {
                selectedService.ServiceName = listBox1.SelectedItem.ToString();
               // if (listBox1.SelectedItem.Equals("Teamviewer"))
               // {
               //     selectedService.ServiceName = "Teamviewer";
               // }
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
            selectedService.Refresh();
            if (programState && selectedService.Status.Equals(ServiceControllerStatus.Running))
            {
                print(selectedService.ServiceName + " : Is Started\n");
                timeclock.Stop();
            }
            else if (!programState && selectedService.Status.Equals(ServiceControllerStatus.Stopped))
            {
                print(selectedService.ServiceName + " : Is Stopped\n");
                timeclock.Stop();
            }
        }
    }
}
