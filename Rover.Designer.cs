
namespace Mars_Rover
{
    partial class Rover
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputLabel = new System.Windows.Forms.Label();
            this.inputTB = new System.Windows.Forms.RichTextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.outputTB = new System.Windows.Forms.RichTextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(12, 9);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(38, 15);
            this.inputLabel.TabIndex = 0;
            this.inputLabel.Text = "Input:";
            // 
            // inputTB
            // 
            this.inputTB.Location = new System.Drawing.Point(16, 37);
            this.inputTB.Name = "inputTB";
            this.inputTB.Size = new System.Drawing.Size(537, 216);
            this.inputTB.TabIndex = 1;
            this.inputTB.Text = "";
            this.inputTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTB_KeyDown);
            this.inputTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputTB_KeyPress);
            this.inputTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.inputTB_PreviewKeyDown);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(12, 276);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(48, 15);
            this.outputLabel.TabIndex = 2;
            this.outputLabel.Text = "Output:";
            // 
            // outputTB
            // 
            this.outputTB.Location = new System.Drawing.Point(16, 309);
            this.outputTB.Name = "outputTB";
            this.outputTB.ReadOnly = true;
            this.outputTB.Size = new System.Drawing.Size(537, 216);
            this.outputTB.TabIndex = 3;
            this.outputTB.Text = "";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(16, 556);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(398, 61);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(433, 556);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(119, 60);
            this.quitButton.TabIndex = 5;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // Rover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 674);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.outputTB);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.inputTB);
            this.Controls.Add(this.inputLabel);
            this.MaximizeBox = false;
            this.Name = "Rover";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mars Rover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.RichTextBox inputTB;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button startButton;
        public System.Windows.Forms.RichTextBox outputTB;
        private System.Windows.Forms.Button quitButton;
    }
}

