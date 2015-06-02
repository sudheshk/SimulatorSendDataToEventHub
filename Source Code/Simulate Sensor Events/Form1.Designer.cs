namespace Simulate_Sensor_Events
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
            this.btnSimulateEvent = new System.Windows.Forms.Button();
            this.btnSpike = new System.Windows.Forms.Button();
            this.richtextStatus = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSimulateEvent
            // 
            this.btnSimulateEvent.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSimulateEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimulateEvent.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSimulateEvent.Location = new System.Drawing.Point(42, 37);
            this.btnSimulateEvent.Name = "btnSimulateEvent";
            this.btnSimulateEvent.Size = new System.Drawing.Size(366, 56);
            this.btnSimulateEvent.TabIndex = 0;
            this.btnSimulateEvent.Text = "Send simulated Sensor Data";
            this.btnSimulateEvent.UseVisualStyleBackColor = false;
            this.btnSimulateEvent.Click += new System.EventHandler(this.btnSimulateEvent_Click);
            // 
            // btnSpike
            // 
            this.btnSpike.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSpike.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpike.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSpike.Location = new System.Drawing.Point(42, 138);
            this.btnSpike.Name = "btnSpike";
            this.btnSpike.Size = new System.Drawing.Size(366, 56);
            this.btnSpike.TabIndex = 1;
            this.btnSpike.Text = "Simulate Spike in temp and humidity";
            this.btnSpike.UseVisualStyleBackColor = false;
            this.btnSpike.Click += new System.EventHandler(this.btnSpike_Click);
            // 
            // richtextStatus
            // 
            this.richtextStatus.Location = new System.Drawing.Point(427, 37);
            this.richtextStatus.Name = "richtextStatus";
            this.richtextStatus.Size = new System.Drawing.Size(366, 164);
            this.richtextStatus.TabIndex = 2;
            this.richtextStatus.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 232);
            this.Controls.Add(this.richtextStatus);
            this.Controls.Add(this.btnSpike);
            this.Controls.Add(this.btnSimulateEvent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSimulateEvent;
        private System.Windows.Forms.Button btnSpike;
        private System.Windows.Forms.RichTextBox richtextStatus;
    }
}

