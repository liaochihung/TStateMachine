namespace StateMachineTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tStateMachine1 = new TStateMachineLibrary.TStateMachine();
            this.tStateLink5 = new TStateMachineLibrary.TStateLink();
            this.tStateNode13 = new TStateMachineLibrary.TStateNode();
            this.tStateNode7 = new TStateMachineLibrary.TStateNode();
            this.tStateNode1 = new TStateMachineLibrary.TStateNode();
            this.tStateNode2 = new TStateMachineLibrary.TStateNode();
            this.tStateLink4 = new TStateMachineLibrary.TStateLink();
            this.tStateLink3 = new TStateMachineLibrary.TStateLink();
            this.tStateTransition3 = new TStateMachineLibrary.TStateTransition();
            this.tStateNode5 = new TStateMachineLibrary.TStateNode();
            this.tStateBoolean1 = new TStateMachineLibrary.TStateBoolean();
            this.tStateNode6 = new TStateMachineLibrary.TStateNode();
            this.tStateBoolean3 = new TStateMachineLibrary.TStateBoolean();
            this.tStateTransition1 = new TStateMachineLibrary.TStateTransition();
            this.tStateNode8 = new TStateMachineLibrary.TStateNode();
            this.tStateBoolean4 = new TStateMachineLibrary.TStateBoolean();
            this.tStateTransition2 = new TStateMachineLibrary.TStateTransition();
            this.tStateNode9 = new TStateMachineLibrary.TStateNode();
            this.tStateBoolean5 = new TStateMachineLibrary.TStateBoolean();
            this.tStateNode12 = new TStateMachineLibrary.TStateNode();
            this.tStateLink2 = new TStateMachineLibrary.TStateLink();
            this.tStateNode10 = new TStateMachineLibrary.TStateNode();
            this.tStateNode11 = new TStateMachineLibrary.TStateNode();
            this.tStateLink1 = new TStateMachineLibrary.TStateLink();
            this.tStateBoolean2 = new TStateMachineLibrary.TStateBoolean();
            this.tStateNode4 = new TStateMachineLibrary.TStateNode();
            this.tStateNode3 = new TStateMachineLibrary.TStateNode();
            this.tStateStart1 = new TStateMachineLibrary.TStateStart();
            this.tStateMachine1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Value";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(518, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Make a call";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tStateMachine1
            // 
            this.tStateMachine1.Active = false;
            this.tStateMachine1.Controls.Add(this.tStateLink5);
            this.tStateMachine1.Controls.Add(this.tStateNode13);
            this.tStateMachine1.Controls.Add(this.tStateNode7);
            this.tStateMachine1.Controls.Add(this.tStateLink4);
            this.tStateMachine1.Controls.Add(this.tStateLink3);
            this.tStateMachine1.Controls.Add(this.tStateTransition3);
            this.tStateMachine1.Controls.Add(this.tStateLink2);
            this.tStateMachine1.Controls.Add(this.tStateNode12);
            this.tStateMachine1.Controls.Add(this.tStateLink1);
            this.tStateMachine1.Controls.Add(this.tStateNode11);
            this.tStateMachine1.Controls.Add(this.tStateNode10);
            this.tStateMachine1.Controls.Add(this.tStateBoolean5);
            this.tStateMachine1.Controls.Add(this.tStateNode9);
            this.tStateMachine1.Controls.Add(this.tStateTransition2);
            this.tStateMachine1.Controls.Add(this.tStateBoolean4);
            this.tStateMachine1.Controls.Add(this.tStateTransition1);
            this.tStateMachine1.Controls.Add(this.tStateNode8);
            this.tStateMachine1.Controls.Add(this.tStateBoolean3);
            this.tStateMachine1.Controls.Add(this.tStateNode6);
            this.tStateMachine1.Controls.Add(this.tStateBoolean2);
            this.tStateMachine1.Controls.Add(this.tStateBoolean1);
            this.tStateMachine1.Controls.Add(this.tStateNode5);
            this.tStateMachine1.Controls.Add(this.tStateNode4);
            this.tStateMachine1.Controls.Add(this.tStateNode3);
            this.tStateMachine1.Controls.Add(this.tStateNode2);
            this.tStateMachine1.Controls.Add(this.tStateNode1);
            this.tStateMachine1.Controls.Add(this.tStateStart1);
            this.tStateMachine1.Location = new System.Drawing.Point(25, 44);
            this.tStateMachine1.Name = "tStateMachine1";
            this.tStateMachine1.Options = TStateMachineLibrary.TStateMachineOptions.Interactive;
            this.tStateMachine1.Size = new System.Drawing.Size(577, 613);
            this.tStateMachine1.State = this.tStateStart1;
            this.tStateMachine1.TabIndex = 0;
            this.tStateMachine1.OnStop += new System.EventHandler(this.tStateMachine1_OnStop);
            // 
            // tStateLink5
            // 
            this.tStateLink5.Active = false;
            this.tStateLink5.Destination = this.tStateNode13;
            this.tStateLink5.Direction = TStateMachineLibrary.TLinkDirection.Incoming;
            this.tStateLink5.Hint = "";
            this.tStateLink5.Location = new System.Drawing.Point(512, 18);
            this.tStateLink5.Name = "tStateLink5";
            this.tStateLink5.Size = new System.Drawing.Size(41, 41);
            this.tStateLink5.StateMachine = this.tStateMachine1;
            this.tStateLink5.Synchronize = false;
            this.tStateLink5.TabIndex = 27;
            this.tStateLink5.Text = "Bye";
            // 
            // tStateNode13
            // 
            this.tStateNode13.Active = false;
            this.tStateNode13.DefaultTransition = this.tStateNode7;
            this.tStateNode13.Hint = "";
            this.tStateNode13.Location = new System.Drawing.Point(407, 18);
            this.tStateNode13.Name = "tStateNode13";
            this.tStateNode13.Size = new System.Drawing.Size(69, 41);
            this.tStateNode13.StateMachine = this.tStateMachine1;
            this.tStateNode13.Synchronize = false;
            this.tStateNode13.TabIndex = 26;
            this.tStateNode13.Text = "Goodbye (no order)";
            // 
            // tStateNode7
            // 
            this.tStateNode7.Active = false;
            this.tStateNode7.DefaultTransition = this.tStateNode1;
            this.tStateNode7.Hint = "";
            this.tStateNode7.Location = new System.Drawing.Point(293, 18);
            this.tStateNode7.Name = "tStateNode7";
            this.tStateNode7.Size = new System.Drawing.Size(69, 41);
            this.tStateNode7.StateMachine = this.tStateMachine1;
            this.tStateNode7.Synchronize = false;
            this.tStateNode7.TabIndex = 25;
            this.tStateNode7.Text = "Reset";
            // 
            // tStateNode1
            // 
            this.tStateNode1.Active = false;
            this.tStateNode1.DefaultTransition = this.tStateNode2;
            this.tStateNode1.Hint = "";
            this.tStateNode1.Location = new System.Drawing.Point(112, 18);
            this.tStateNode1.Name = "tStateNode1";
            this.tStateNode1.Size = new System.Drawing.Size(82, 30);
            this.tStateNode1.StateMachine = this.tStateMachine1;
            this.tStateNode1.Synchronize = false;
            this.tStateNode1.TabIndex = 1;
            this.tStateNode1.Text = "Initialize";
            this.tStateNode1.OnEnterState += new System.EventHandler(this.n1_OnEnterState);
            // 
            // tStateNode2
            // 
            this.tStateNode2.Active = false;
            this.tStateNode2.DefaultTransition = null;
            this.tStateNode2.Hint = "";
            this.tStateNode2.Location = new System.Drawing.Point(116, 79);
            this.tStateNode2.Name = "tStateNode2";
            this.tStateNode2.Size = new System.Drawing.Size(78, 30);
            this.tStateNode2.StateMachine = this.tStateMachine1;
            this.tStateNode2.Synchronize = false;
            this.tStateNode2.TabIndex = 2;
            this.tStateNode2.Text = "Wait for call";
            this.tStateNode2.OnEnterState += new System.EventHandler(this.n2_OnEnterState);
            // 
            // tStateLink4
            // 
            this.tStateLink4.Active = false;
            this.tStateLink4.Destination = this.tStateNode7;
            this.tStateLink4.Direction = TStateMachineLibrary.TLinkDirection.Incoming;
            this.tStateLink4.Hint = "";
            this.tStateLink4.Location = new System.Drawing.Point(342, 89);
            this.tStateLink4.Name = "tStateLink4";
            this.tStateLink4.Size = new System.Drawing.Size(64, 51);
            this.tStateLink4.StateMachine = this.tStateMachine1;
            this.tStateLink4.Synchronize = false;
            this.tStateLink4.TabIndex = 24;
            this.tStateLink4.Text = "Hangup detected";
            // 
            // tStateLink3
            // 
            this.tStateLink3.Active = false;
            this.tStateLink3.Destination = this.tStateNode7;
            this.tStateLink3.Direction = TStateMachineLibrary.TLinkDirection.Incoming;
            this.tStateLink3.Hint = "";
            this.tStateLink3.Location = new System.Drawing.Point(246, 100);
            this.tStateLink3.Name = "tStateLink3";
            this.tStateLink3.Size = new System.Drawing.Size(45, 30);
            this.tStateLink3.StateMachine = this.tStateMachine1;
            this.tStateLink3.Synchronize = false;
            this.tStateLink3.TabIndex = 23;
            this.tStateLink3.Text = "Reset";
            // 
            // tStateTransition3
            // 
            this.tStateTransition3.Active = false;
            this.tStateTransition3.FromState = null;
            this.tStateTransition3.Hint = "";
            this.tStateTransition3.Location = new System.Drawing.Point(18, 249);
            this.tStateTransition3.Name = "tStateTransition3";
            this.tStateTransition3.Size = new System.Drawing.Size(67, 41);
            this.tStateTransition3.StateMachine = this.tStateMachine1;
            this.tStateTransition3.Synchronize = false;
            this.tStateTransition3.TabIndex = 22;
            this.tStateTransition3.Text = "Reject choice";
            this.tStateTransition3.ToState = this.tStateNode5;
            // 
            // tStateNode5
            // 
            this.tStateNode5.Active = false;
            this.tStateNode5.DefaultTransition = this.tStateBoolean1;
            this.tStateNode5.Hint = "";
            this.tStateNode5.Location = new System.Drawing.Point(116, 196);
            this.tStateNode5.Name = "tStateNode5";
            this.tStateNode5.Size = new System.Drawing.Size(78, 39);
            this.tStateNode5.StateMachine = this.tStateMachine1;
            this.tStateNode5.Synchronize = false;
            this.tStateNode5.TabIndex = 5;
            this.tStateNode5.Text = "Prompt for pizza";
            // 
            // tStateBoolean1
            // 
            this.tStateBoolean1.Active = false;
            this.tStateBoolean1.DefaultState = true;
            this.tStateBoolean1.FalseState = this.tStateNode6;
            this.tStateBoolean1.Hint = "";
            this.tStateBoolean1.Location = new System.Drawing.Point(279, 249);
            this.tStateBoolean1.Name = "tStateBoolean1";
            this.tStateBoolean1.Size = new System.Drawing.Size(83, 46);
            this.tStateBoolean1.StateMachine = this.tStateMachine1;
            this.tStateBoolean1.Synchronize = false;
            this.tStateBoolean1.TabIndex = 6;
            this.tStateBoolean1.Text = "More?";
            this.tStateBoolean1.TrueState = this.tStateBoolean2;
            this.tStateBoolean1.OnEnterState += new System.EventHandler<TStateMachineLibrary.BooleanStateArgs>(this.tStateBoolean1_OnEnterState);
            // 
            // tStateNode6
            // 
            this.tStateNode6.Active = false;
            this.tStateNode6.DefaultTransition = this.tStateBoolean3;
            this.tStateNode6.Hint = "";
            this.tStateNode6.Location = new System.Drawing.Point(293, 167);
            this.tStateNode6.Name = "tStateNode6";
            this.tStateNode6.Size = new System.Drawing.Size(96, 46);
            this.tStateNode6.StateMachine = this.tStateMachine1;
            this.tStateNode6.Synchronize = false;
            this.tStateNode6.TabIndex = 8;
            this.tStateNode6.Text = "Get delivery address street";
            // 
            // tStateBoolean3
            // 
            this.tStateBoolean3.Active = false;
            this.tStateBoolean3.DefaultState = true;
            this.tStateBoolean3.FalseState = this.tStateTransition1;
            this.tStateBoolean3.Hint = "";
            this.tStateBoolean3.Location = new System.Drawing.Point(475, 249);
            this.tStateBoolean3.Name = "tStateBoolean3";
            this.tStateBoolean3.Size = new System.Drawing.Size(78, 46);
            this.tStateBoolean3.StateMachine = this.tStateMachine1;
            this.tStateBoolean3.Synchronize = false;
            this.tStateBoolean3.TabIndex = 10;
            this.tStateBoolean3.Text = "Street valid?";
            this.tStateBoolean3.TrueState = this.tStateNode8;
            // 
            // tStateTransition1
            // 
            this.tStateTransition1.Active = false;
            this.tStateTransition1.FromState = null;
            this.tStateTransition1.Hint = "";
            this.tStateTransition1.Location = new System.Drawing.Point(493, 146);
            this.tStateTransition1.Name = "tStateTransition1";
            this.tStateTransition1.Size = new System.Drawing.Size(52, 41);
            this.tStateTransition1.StateMachine = this.tStateMachine1;
            this.tStateTransition1.Synchronize = false;
            this.tStateTransition1.TabIndex = 12;
            this.tStateTransition1.Text = "Reject street";
            this.tStateTransition1.ToState = this.tStateNode6;
            // 
            // tStateNode8
            // 
            this.tStateNode8.Active = false;
            this.tStateNode8.DefaultTransition = this.tStateBoolean4;
            this.tStateNode8.Hint = "";
            this.tStateNode8.Location = new System.Drawing.Point(475, 358);
            this.tStateNode8.Name = "tStateNode8";
            this.tStateNode8.Size = new System.Drawing.Size(70, 65);
            this.tStateNode8.StateMachine = this.tStateMachine1;
            this.tStateNode8.Synchronize = false;
            this.tStateNode8.TabIndex = 11;
            this.tStateNode8.Text = "Get delivery address number";
            // 
            // tStateBoolean4
            // 
            this.tStateBoolean4.Active = false;
            this.tStateBoolean4.DefaultState = true;
            this.tStateBoolean4.FalseState = this.tStateTransition2;
            this.tStateBoolean4.Hint = "";
            this.tStateBoolean4.Location = new System.Drawing.Point(342, 450);
            this.tStateBoolean4.Name = "tStateBoolean4";
            this.tStateBoolean4.Size = new System.Drawing.Size(69, 41);
            this.tStateBoolean4.StateMachine = this.tStateMachine1;
            this.tStateBoolean4.Synchronize = false;
            this.tStateBoolean4.TabIndex = 13;
            this.tStateBoolean4.Text = "Street valid?";
            this.tStateBoolean4.TrueState = this.tStateNode9;
            // 
            // tStateTransition2
            // 
            this.tStateTransition2.Active = false;
            this.tStateTransition2.FromState = null;
            this.tStateTransition2.Hint = "";
            this.tStateTransition2.Location = new System.Drawing.Point(493, 498);
            this.tStateTransition2.Name = "tStateTransition2";
            this.tStateTransition2.Size = new System.Drawing.Size(60, 41);
            this.tStateTransition2.StateMachine = this.tStateMachine1;
            this.tStateTransition2.Synchronize = false;
            this.tStateTransition2.TabIndex = 14;
            this.tStateTransition2.Text = "Reject number";
            this.tStateTransition2.ToState = this.tStateNode8;
            // 
            // tStateNode9
            // 
            this.tStateNode9.Active = false;
            this.tStateNode9.DefaultTransition = this.tStateBoolean5;
            this.tStateNode9.Hint = "";
            this.tStateNode9.Location = new System.Drawing.Point(246, 394);
            this.tStateNode9.Name = "tStateNode9";
            this.tStateNode9.Size = new System.Drawing.Size(69, 41);
            this.tStateNode9.StateMachine = this.tStateMachine1;
            this.tStateNode9.Synchronize = false;
            this.tStateNode9.TabIndex = 15;
            this.tStateNode9.Text = "Verify order";
            // 
            // tStateBoolean5
            // 
            this.tStateBoolean5.Active = false;
            this.tStateBoolean5.DefaultState = true;
            this.tStateBoolean5.FalseState = this.tStateNode12;
            this.tStateBoolean5.Hint = "";
            this.tStateBoolean5.Location = new System.Drawing.Point(112, 382);
            this.tStateBoolean5.Name = "tStateBoolean5";
            this.tStateBoolean5.Size = new System.Drawing.Size(116, 66);
            this.tStateBoolean5.StateMachine = this.tStateMachine1;
            this.tStateBoolean5.Synchronize = false;
            this.tStateBoolean5.TabIndex = 16;
            this.tStateBoolean5.Text = "Order confirmed?";
            this.tStateBoolean5.TrueState = this.tStateNode10;
            // 
            // tStateNode12
            // 
            this.tStateNode12.Active = false;
            this.tStateNode12.DefaultTransition = this.tStateLink2;
            this.tStateNode12.Hint = "";
            this.tStateNode12.Location = new System.Drawing.Point(116, 534);
            this.tStateNode12.Name = "tStateNode12";
            this.tStateNode12.Size = new System.Drawing.Size(63, 35);
            this.tStateNode12.StateMachine = this.tStateMachine1;
            this.tStateNode12.Synchronize = false;
            this.tStateNode12.TabIndex = 20;
            this.tStateNode12.Text = "Cancel order";
            // 
            // tStateLink2
            // 
            this.tStateLink2.Active = false;
            this.tStateLink2.Destination = this.tStateLink5;
            this.tStateLink2.Direction = TStateMachineLibrary.TLinkDirection.Outgoing;
            this.tStateLink2.Hint = "";
            this.tStateLink2.Location = new System.Drawing.Point(209, 531);
            this.tStateLink2.Name = "tStateLink2";
            this.tStateLink2.Size = new System.Drawing.Size(41, 41);
            this.tStateLink2.StateMachine = this.tStateMachine1;
            this.tStateLink2.Synchronize = false;
            this.tStateLink2.TabIndex = 21;
            this.tStateLink2.Text = "Bye";
            // 
            // tStateNode10
            // 
            this.tStateNode10.Active = false;
            this.tStateNode10.DefaultTransition = this.tStateNode11;
            this.tStateNode10.Hint = "";
            this.tStateNode10.Location = new System.Drawing.Point(16, 394);
            this.tStateNode10.Name = "tStateNode10";
            this.tStateNode10.Size = new System.Drawing.Size(69, 41);
            this.tStateNode10.StateMachine = this.tStateMachine1;
            this.tStateNode10.Synchronize = false;
            this.tStateNode10.TabIndex = 17;
            this.tStateNode10.Text = "Save order";
            // 
            // tStateNode11
            // 
            this.tStateNode11.Active = false;
            this.tStateNode11.DefaultTransition = this.tStateLink1;
            this.tStateNode11.Hint = "";
            this.tStateNode11.Location = new System.Drawing.Point(16, 459);
            this.tStateNode11.Name = "tStateNode11";
            this.tStateNode11.Size = new System.Drawing.Size(69, 41);
            this.tStateNode11.StateMachine = this.tStateMachine1;
            this.tStateNode11.Synchronize = false;
            this.tStateNode11.TabIndex = 18;
            this.tStateNode11.Text = "Thanks & Goodbye";
            // 
            // tStateLink1
            // 
            this.tStateLink1.Active = false;
            this.tStateLink1.Destination = this.tStateLink3;
            this.tStateLink1.Direction = TStateMachineLibrary.TLinkDirection.Outgoing;
            this.tStateLink1.Hint = "";
            this.tStateLink1.Location = new System.Drawing.Point(27, 528);
            this.tStateLink1.Name = "tStateLink1";
            this.tStateLink1.Size = new System.Drawing.Size(41, 41);
            this.tStateLink1.StateMachine = this.tStateMachine1;
            this.tStateLink1.Synchronize = false;
            this.tStateLink1.TabIndex = 19;
            this.tStateLink1.Text = "Reset";
            // 
            // tStateBoolean2
            // 
            this.tStateBoolean2.Active = false;
            this.tStateBoolean2.DefaultState = true;
            this.tStateBoolean2.FalseState = this.tStateTransition3;
            this.tStateBoolean2.Hint = "";
            this.tStateBoolean2.Location = new System.Drawing.Point(112, 299);
            this.tStateBoolean2.Name = "tStateBoolean2";
            this.tStateBoolean2.Size = new System.Drawing.Size(76, 53);
            this.tStateBoolean2.StateMachine = this.tStateMachine1;
            this.tStateBoolean2.Synchronize = false;
            this.tStateBoolean2.TabIndex = 7;
            this.tStateBoolean2.Text = "Valid choice?";
            this.tStateBoolean2.TrueState = this.tStateNode5;
            // 
            // tStateNode4
            // 
            this.tStateNode4.Active = false;
            this.tStateNode4.DefaultTransition = this.tStateNode5;
            this.tStateNode4.Hint = "";
            this.tStateNode4.Location = new System.Drawing.Point(16, 126);
            this.tStateNode4.Name = "tStateNode4";
            this.tStateNode4.Size = new System.Drawing.Size(63, 30);
            this.tStateNode4.StateMachine = this.tStateMachine1;
            this.tStateNode4.Synchronize = false;
            this.tStateNode4.TabIndex = 4;
            this.tStateNode4.Text = "Greet caller";
            // 
            // tStateNode3
            // 
            this.tStateNode3.Active = false;
            this.tStateNode3.DefaultTransition = this.tStateNode4;
            this.tStateNode3.Hint = "";
            this.tStateNode3.Location = new System.Drawing.Point(16, 79);
            this.tStateNode3.Name = "tStateNode3";
            this.tStateNode3.Size = new System.Drawing.Size(63, 30);
            this.tStateNode3.StateMachine = this.tStateMachine1;
            this.tStateNode3.Synchronize = false;
            this.tStateNode3.TabIndex = 3;
            this.tStateNode3.Text = "Accept call";
            this.tStateNode3.OnEnterState += new System.EventHandler(this.tStateNode3_OnEnterState);
            // 
            // tStateStart1
            // 
            this.tStateStart1.Active = true;
            this.tStateStart1.DefaultTransition = this.tStateNode1;
            this.tStateStart1.Hint = "";
            this.tStateStart1.Location = new System.Drawing.Point(16, 18);
            this.tStateStart1.Name = "tStateStart1";
            this.tStateStart1.Size = new System.Drawing.Size(63, 30);
            this.tStateStart1.StateMachine = this.tStateMachine1;
            this.tStateStart1.Synchronize = false;
            this.tStateStart1.TabIndex = 0;
            this.tStateStart1.Text = "Start";
            this.tStateStart1.OnEnterState += new System.EventHandler(this.start_OnEnterState);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 669);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tStateMachine1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StateMachine Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tStateMachine1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TStateMachineLibrary.TStateMachine tStateMachine1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private TStateMachineLibrary.TStateNode tStateNode2;
        private TStateMachineLibrary.TStateNode tStateNode1;
        private TStateMachineLibrary.TStateStart tStateStart1;
        private System.Windows.Forms.Button button2;
        private TStateMachineLibrary.TStateNode tStateNode6;
        private TStateMachineLibrary.TStateBoolean tStateBoolean2;
        private TStateMachineLibrary.TStateNode tStateNode5;
        private TStateMachineLibrary.TStateBoolean tStateBoolean1;
        private TStateMachineLibrary.TStateNode tStateNode4;
        private TStateMachineLibrary.TStateNode tStateNode3;
        private TStateMachineLibrary.TStateTransition tStateTransition3;
        private TStateMachineLibrary.TStateLink tStateLink2;
        private TStateMachineLibrary.TStateNode tStateNode12;
        private TStateMachineLibrary.TStateLink tStateLink1;
        private TStateMachineLibrary.TStateNode tStateNode11;
        private TStateMachineLibrary.TStateNode tStateNode10;
        private TStateMachineLibrary.TStateBoolean tStateBoolean5;
        private TStateMachineLibrary.TStateNode tStateNode9;
        private TStateMachineLibrary.TStateTransition tStateTransition2;
        private TStateMachineLibrary.TStateNode tStateNode8;
        private TStateMachineLibrary.TStateBoolean tStateBoolean4;
        private TStateMachineLibrary.TStateTransition tStateTransition1;
        private TStateMachineLibrary.TStateBoolean tStateBoolean3;
        private TStateMachineLibrary.TStateLink tStateLink5;
        private TStateMachineLibrary.TStateNode tStateNode13;
        private TStateMachineLibrary.TStateNode tStateNode7;
        private TStateMachineLibrary.TStateLink tStateLink4;
        private TStateMachineLibrary.TStateLink tStateLink3;
        private System.Windows.Forms.Button button3;
    }
}

