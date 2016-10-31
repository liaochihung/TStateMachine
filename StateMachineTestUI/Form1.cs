using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TStateMachineLibrary;

namespace StateMachineTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tStateMachine1.OnThreadStart += tStateMachine1_OnThreadStart;
        }

        private int _value = 0;
        private bool _runningStateMachine = false;

        private void button1_Click(object sender, EventArgs e)
        {
            EnableRunStateMachine(false);

            tStateMachine1.State = tStateStart1;
            tStateMachine1.Execute();
            _runningStateMachine = true;
        }

        private void FunctionTest()
        {
            var start = new TStateStart();
            var n1 = new TStateNode();
            var n2 = new TStateNode();
            var n3 = new TStateNode();
            var stop = new TStateStop();

            start.OnEnterState += start_OnEnterState;
            n1.OnEnterState += n1_OnEnterState;
            n2.OnEnterState += n2_OnEnterState;
            n3.OnEnterState += n3_OnEnterState;
            stop.OnEnterState += stop_OnEnterState;

            start.DefaultTransition = n1;
            n1.DefaultTransition = n2;
            n2.DefaultTransition = n3;
            n3.DefaultTransition = stop;

            tStateMachine1.State = start;
        }

        void tStateMachine1_OnThreadStart(object sender, EventArgs e)
        {
            _value = 11;
        }

        void stop_OnEnterState(object sender, EventArgs e)
        {
            _value = 333;
        }

        void n3_OnEnterState(object sender, EventArgs e)
        {
            _value += 10;
        }

        void n2_OnEnterState(object sender, EventArgs e)
        {
            _value += 10;

            tStateMachine1.Pause();
        }

        void n1_OnEnterState(object sender, EventArgs e)
        {
            _value += 10;
        }

        void start_OnEnterState(object sender, EventArgs e)
        {
            _value += 10;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = _value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tStateMachine1.Stop();

            EnableRunStateMachine(true);

            _runningStateMachine = false;
        }

        private void tStateMachine1_OnStop(object sender, EventArgs e)
        {
            //EnableRunStateMachine(true);
        }

        private void EnableRunStateMachine(bool enable)
        {
            if (button1.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = enable;
                    button2.Enabled = !enable;
                }));
            }
            else
            {
                button1.Enabled = enable;
                button2.Enabled = !enable;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tStateMachine1.State = tStateNode3;
            tStateMachine1.Resume();
        }

        private void tStateNode3_OnEnterState(object sender, EventArgs e)
        {

        }

        private void tStateBoolean1_OnEnterState(object sender, BooleanStateArgs e)
        {
            e.Result = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_runningStateMachine)
            {
                tStateMachine1.Stop();
                _runningStateMachine = false;
            }
        }
    }
}
