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
            this.tStateMachine1 = new TStateMachineLibrary.TStateMachine();
            this.tStateBoolean1 = new TStateMachineLibrary.TStateBoolean();
            this.tStateNode3 = new TStateMachineLibrary.TStateNode();
            this.tStateNode4 = new TStateMachineLibrary.TStateNode();
            this.tStateNode2 = new TStateMachineLibrary.TStateNode();
            this.tStateNode1 = new TStateMachineLibrary.TStateNode();
            this.tStateStart1 = new TStateMachineLibrary.TStateStart();
            this.tStateMachine1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 367);
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
            this.label1.Location = new System.Drawing.Point(57, 372);
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
            this.button2.Location = new System.Drawing.Point(274, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tStateMachine1
            // 
            this.tStateMachine1.Active = false;
            this.tStateMachine1.Controls.Add(this.tStateBoolean1);
            this.tStateMachine1.Controls.Add(this.tStateNode4);
            this.tStateMachine1.Controls.Add(this.tStateNode3);
            this.tStateMachine1.Controls.Add(this.tStateNode2);
            this.tStateMachine1.Controls.Add(this.tStateNode1);
            this.tStateMachine1.Controls.Add(this.tStateStart1);
            this.tStateMachine1.Location = new System.Drawing.Point(10, 10);
            this.tStateMachine1.Name = "tStateMachine1";
            this.tStateMachine1.Options = TStateMachineLibrary.TStateMachineOptions.Interactive;
            this.tStateMachine1.Size = new System.Drawing.Size(359, 339);
            this.tStateMachine1.State = this.tStateStart1;
            this.tStateMachine1.TabIndex = 0;
            this.tStateMachine1.OnStop += new System.EventHandler(this.tStateMachine1_OnStop);
            // 
            // tStateBoolean1
            // 
            this.tStateBoolean1.Active = false;
            this.tStateBoolean1.DefaultState = true;
            this.tStateBoolean1.FalseState = this.tStateNode3;
            this.tStateBoolean1.Hint = "";
            this.tStateBoolean1.Location = new System.Drawing.Point(165, 175);
            this.tStateBoolean1.Name = "tStateBoolean1";
            this.tStateBoolean1.Size = new System.Drawing.Size(117, 52);
            this.tStateBoolean1.StateMachine = this.tStateMachine1;
            this.tStateBoolean1.Synchronize = false;
            this.tStateBoolean1.TabIndex = 6;
            this.tStateBoolean1.Text = "tStateBoolean1";
            this.tStateBoolean1.TrueState = this.tStateNode4;
            this.tStateBoolean1.OnEnterState += new System.EventHandler<TStateMachineLibrary.BooleanStateArgs>(this.tStateBoolean1_OnEnterState);
            // 
            // tStateNode3
            // 
            this.tStateNode3.Active = false;
            this.tStateNode3.DefaultTransition = null;
            this.tStateNode3.Hint = "";
            this.tStateNode3.Location = new System.Drawing.Point(40, 186);
            this.tStateNode3.Name = "tStateNode3";
            this.tStateNode3.Size = new System.Drawing.Size(69, 41);
            this.tStateNode3.StateMachine = this.tStateMachine1;
            this.tStateNode3.Synchronize = false;
            this.tStateNode3.TabIndex = 4;
            this.tStateNode3.Text = "tStateNode3";
            this.tStateNode3.OnEnterState += new System.EventHandler(this.tStateNode3_OnEnterState);
            // 
            // tStateNode4
            // 
            this.tStateNode4.Active = false;
            this.tStateNode4.DefaultTransition = null;
            this.tStateNode4.Hint = "";
            this.tStateNode4.Location = new System.Drawing.Point(189, 280);
            this.tStateNode4.Name = "tStateNode4";
            this.tStateNode4.Size = new System.Drawing.Size(69, 41);
            this.tStateNode4.StateMachine = this.tStateMachine1;
            this.tStateNode4.Synchronize = false;
            this.tStateNode4.TabIndex = 5;
            this.tStateNode4.Text = "tStateNode4";
            this.tStateNode4.OnEnterState += new System.EventHandler(this.tStateNode4_OnEnterState);
            // 
            // tStateNode2
            // 
            this.tStateNode2.Active = false;
            this.tStateNode2.DefaultTransition = this.tStateBoolean1;
            this.tStateNode2.Hint = "";
            this.tStateNode2.Location = new System.Drawing.Point(165, 83);
            this.tStateNode2.Name = "tStateNode2";
            this.tStateNode2.Size = new System.Drawing.Size(93, 41);
            this.tStateNode2.StateMachine = this.tStateMachine1;
            this.tStateNode2.Synchronize = false;
            this.tStateNode2.TabIndex = 2;
            this.tStateNode2.Text = "Node2";
            this.tStateNode2.OnEnterState += new System.EventHandler(this.n2_OnEnterState);
            // 
            // tStateNode1
            // 
            this.tStateNode1.Active = false;
            this.tStateNode1.DefaultTransition = this.tStateNode2;
            this.tStateNode1.Hint = "";
            this.tStateNode1.Location = new System.Drawing.Point(165, 18);
            this.tStateNode1.Name = "tStateNode1";
            this.tStateNode1.Size = new System.Drawing.Size(93, 41);
            this.tStateNode1.StateMachine = this.tStateMachine1;
            this.tStateNode1.Synchronize = false;
            this.tStateNode1.TabIndex = 1;
            this.tStateNode1.Text = "Node1";
            this.tStateNode1.OnEnterState += new System.EventHandler(this.n1_OnEnterState);
            // 
            // tStateStart1
            // 
            this.tStateStart1.Active = true;
            this.tStateStart1.DefaultTransition = this.tStateNode1;
            this.tStateStart1.Hint = "";
            this.tStateStart1.Location = new System.Drawing.Point(16, 18);
            this.tStateStart1.Name = "tStateStart1";
            this.tStateStart1.Size = new System.Drawing.Size(93, 41);
            this.tStateStart1.StateMachine = this.tStateMachine1;
            this.tStateStart1.Synchronize = false;
            this.tStateStart1.TabIndex = 0;
            this.tStateStart1.Text = "Start1";
            this.tStateStart1.OnEnterState += new System.EventHandler(this.start_OnEnterState);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 420);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tStateMachine1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StateMachine Test";
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
        private TStateMachineLibrary.TStateNode tStateNode4;
        private TStateMachineLibrary.TStateNode tStateNode3;
        private TStateMachineLibrary.TStateBoolean tStateBoolean1;
    }
}

