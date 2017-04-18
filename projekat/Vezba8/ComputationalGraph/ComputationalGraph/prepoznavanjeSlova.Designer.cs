namespace ComputationalGraph
{
	partial class prepoznavanjeSlova
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
			this.buttonObuci = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonObuci
			// 
			this.buttonObuci.Location = new System.Drawing.Point(88, 25);
			this.buttonObuci.Name = "buttonObuci";
			this.buttonObuci.Size = new System.Drawing.Size(282, 23);
			this.buttonObuci.TabIndex = 0;
			this.buttonObuci.Text = "Обучи мрежу";
			this.buttonObuci.UseVisualStyleBackColor = true;
			this.buttonObuci.Click += new System.EventHandler(this.buttonObuci_Click_1);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(88, 68);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(282, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Тестирај мрежу";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(421, 23);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 100);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(88, 113);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(282, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Прикажи проценат тачности";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// prepoznavanjeSlova
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::ComputationalGraph.Properties.Resources.azbuka;
			this.ClientSize = new System.Drawing.Size(692, 342);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.buttonObuci);
			this.Name = "prepoznavanjeSlova";
			this.Text = "Програм за препознавање слова А и Б";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.prepoznavanjeSlova_FormClosing);
			this.Load += new System.EventHandler(this.prepoznavanjeSlova_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonObuci;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;

	}
}