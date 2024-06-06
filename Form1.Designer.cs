partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private Button btnStartSimulation;
    private Button btnAddSatellite;
    private Button btnAddGroundStation;
    private PictureBox pictureBox1;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.btnStartSimulation = new Button();
        this.btnAddSatellite = new Button();
        this.btnAddGroundStation = new Button();
        this.pictureBox1 = new PictureBox();

        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();

        // btnStartSimulation
        this.btnStartSimulation.Location = new System.Drawing.Point(10, 10);
        this.btnStartSimulation.Name = "btnStartSimulation";
        this.btnStartSimulation.Size = new System.Drawing.Size(150, 23);
        this.btnStartSimulation.TabIndex = 0;
        this.btnStartSimulation.Text = "Start Simulation";
        this.btnStartSimulation.UseVisualStyleBackColor = true;
        this.btnStartSimulation.Click += new System.EventHandler(this.btnStartSimulation_Click);

        // btnAddSatellite
        this.btnAddSatellite.Location = new System.Drawing.Point(170, 10);
        this.btnAddSatellite.Name = "btnAddSatellite";
        this.btnAddSatellite.Size = new System.Drawing.Size(150, 23);
        this.btnAddSatellite.TabIndex = 1;
        this.btnAddSatellite.Text = "Add Satellite";
        this.btnAddSatellite.UseVisualStyleBackColor = true;
        this.btnAddSatellite.Click += new System.EventHandler(this.btnAddSatellite_Click);

        // btnAddGroundStation
        this.btnAddGroundStation.Location = new System.Drawing.Point(330, 10);
        this.btnAddGroundStation.Name = "btnAddGroundStation";
        this.btnAddGroundStation.Size = new System.Drawing.Size(150, 23);
        this.btnAddGroundStation.TabIndex = 2;
        this.btnAddGroundStation.Text = "Add Ground Station";
        this.btnAddGroundStation.UseVisualStyleBackColor = true;
        this.btnAddGroundStation.Click += new System.EventHandler(this.btnAddGroundStation_Click);

        // pictureBox1
        this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pictureBox1.Location = new System.Drawing.Point(10, 40);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(780, 450);
        this.pictureBox1.TabIndex = 3;
        this.pictureBox1.TabStop = false;
        this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);

        // Form1
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 500);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.btnAddGroundStation);
        this.Controls.Add(this.btnAddSatellite);
        this.Controls.Add(this.btnStartSimulation);
        this.Name = "Form1";
        this.Text = "Space System Simulation";

        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
}
