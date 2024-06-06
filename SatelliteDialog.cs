using System;
using System.Drawing;
using System.Windows.Forms;

public class SatelliteDialog : Form
{
    public string SatelliteName { get; private set; }
    public Satellite.SatelliteType SatelliteType { get; private set; }
    public double CenterX { get; private set; }
    public double CenterY { get; private set; }
    public double OrbitRadius { get; private set; }
    public double InitialAngle { get; private set; }
    public double AngularVelocity { get; private set; }

    private TextBox txtName;
    private ComboBox cmbType;
    private TextBox txtCenterX;
    private TextBox txtCenterY;
    private TextBox txtOrbitRadius;
    private TextBox txtInitialAngle;
    private TextBox txtAngularVelocity;
    private Button btnOK;

    public SatelliteDialog()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.txtName = new TextBox { Location = new System.Drawing.Point(15, 25), Width = 200 };
        this.cmbType = new ComboBox { Location = new System.Drawing.Point(15, 55), Width = 200 };
        this.txtCenterX = new TextBox { Location = new System.Drawing.Point(15, 85), Width = 200 };
        this.txtCenterY = new TextBox { Location = new System.Drawing.Point(15, 115), Width = 200 };
        this.txtOrbitRadius = new TextBox { Location = new System.Drawing.Point(15, 145), Width = 200 };
        this.txtInitialAngle = new TextBox { Location = new System.Drawing.Point(15, 175), Width = 200 };
        this.txtAngularVelocity = new TextBox { Location = new System.Drawing.Point(15, 205), Width = 200 };
        this.btnOK = new Button { Location = new System.Drawing.Point(15, 235), Text = "OK" };

        this.cmbType.Items.AddRange(Enum.GetNames(typeof(Satellite.SatelliteType)));
        this.btnOK.Click += BtnOK_Click;

        // Add placeholder text
        AddPlaceholder(txtName, "Enter satellite name");
        AddPlaceholder(txtCenterX, "Enter center X position (400)");
        AddPlaceholder(txtCenterY, "Enter center Y position (225)");
        AddPlaceholder(txtOrbitRadius, "Enter orbit radius");
        AddPlaceholder(txtInitialAngle, "Enter initial angle (radians)");
        AddPlaceholder(txtAngularVelocity, "Enter angular velocity");

        this.Controls.Add(new Label { Text = "Name", Location = new System.Drawing.Point(15, 5) });
        this.Controls.Add(this.txtName);
        this.Controls.Add(new Label { Text = "Type", Location = new System.Drawing.Point(15, 35) });
        this.Controls.Add(this.cmbType);
        this.Controls.Add(new Label { Text = "Center X", Location = new System.Drawing.Point(15, 65) });
        this.Controls.Add(this.txtCenterX);
        this.Controls.Add(new Label { Text = "Center Y", Location = new System.Drawing.Point(15, 95) });
        this.Controls.Add(this.txtCenterY);
        this.Controls.Add(new Label { Text = "Orbit Radius", Location = new System.Drawing.Point(15, 125) });
        this.Controls.Add(this.txtOrbitRadius);
        this.Controls.Add(new Label { Text = "Initial Angle", Location = new System.Drawing.Point(15, 155) });
        this.Controls.Add(this.txtInitialAngle);
        this.Controls.Add(new Label { Text = "Angular Velocity", Location = new System.Drawing.Point(15, 185) });
        this.Controls.Add(this.txtAngularVelocity);
        this.Controls.Add(this.btnOK);

        this.Text = "Add Satellite";
        this.ClientSize = new System.Drawing.Size(230, 270);
    }

    private void AddPlaceholder(TextBox textBox, string placeholder)
    {
        textBox.Text = placeholder;
        textBox.ForeColor = Color.Gray;
        textBox.Enter += (sender, e) =>
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        };
        textBox.Leave += (sender, e) =>
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
        };
    }

    private void BtnOK_Click(object sender, EventArgs e)
    {
        SatelliteName = txtName.Text;
        SatelliteType = (Satellite.SatelliteType)Enum.Parse(typeof(Satellite.SatelliteType), cmbType.SelectedItem.ToString());
        CenterX = ParseDouble(txtCenterX, "Enter center X position");
        CenterY = ParseDouble(txtCenterY, "Enter center Y position");
        OrbitRadius = ParseDouble(txtOrbitRadius, "Enter orbit radius");
        InitialAngle = ParseDouble(txtInitialAngle, "Enter initial angle (radians)");
        AngularVelocity = ParseDouble(txtAngularVelocity, "Enter angular velocity");

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private double ParseDouble(TextBox textBox, string placeholder)
    {
        if (textBox.Text == placeholder || string.IsNullOrWhiteSpace(textBox.Text))
        {
            return 0.0;
        }
        return double.Parse(textBox.Text);
    }
}
