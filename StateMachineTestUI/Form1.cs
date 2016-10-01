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
        }

        private int _value = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            //FunctionTest();
            tStateMachine1.State = tStateStart1;
            tStateMachine1.OnThreadStart += tStateMachine1_OnThreadStart;
            tStateMachine1.Execute();
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

    }
}
