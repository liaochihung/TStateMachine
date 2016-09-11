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
            this.tStateMachine1 = new TStateMachineLibrary.TStateMachine();
            this.SuspendLayout();
            // 
            // tStateMachine1
            // 
            this.tStateMachine1.Active = false;
            this.tStateMachine1.Location = new System.Drawing.Point(155, 37);
            this.tStateMachine1.Margin = new System.Windows.Forms.Padding(4);
            this.tStateMachine1.Name = "tStateMachine1";
            this.tStateMachine1.Options = TStateMachineLibrary.TStateMachineOptions.Interactive;
            this.tStateMachine1.Size = new System.Drawing.Size(408, 396);
            this.tStateMachine1.State = null;
            this.tStateMachine1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 542);
            this.Controls.Add(this.tStateMachine1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TStateMachineLibrary.TStateMachine tStateMachine1;
    }
}

