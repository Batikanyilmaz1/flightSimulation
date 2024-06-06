using System;
using System.Drawing;
using System.Windows.Forms;

public class GroundStationDialog : Form
{
    public string GroundStationName { get; private set; }
    public GroundStation.StationType GroundStationType { get; private set; }
    public double InitialX { get; private set; }
    public double InitialY { get; private set; }
    public double CommunicationRadius { get; private set; }

    private TextBox txtName;
    private ComboBox cmbType;
    private TextBox txtInitialX;
    private TextBox txtInitialY;
    private TextBox txtCommunicationRadius;
    private Button btnOK;

    public GroundStationDialog()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.txtName = new TextBox { Location = new System.Drawing.Point(15, 25), Width = 200 };
        this.cmbType = new ComboBox { Location = new System.Drawing.Point(15, 55), Width = 200 };
        this.txtInitialX = new TextBox { Location = new System.Drawing.Point(15, 85), Width = 200 };
        this.txtInitialY = new TextBox { Location = new System.Drawing.Point(15, 115), Width = 200 };
        this.txtCommunicationRadius = new TextBox { Location = new System.Drawing.Point(15, 145), Width = 200 };
        this.btnOK = new Button { Location = new System.Drawing.Point(15, 175), Text = "OK" };

        this.cmbType.Items.AddRange(Enum.GetNames(typeof(GroundStation.StationType)));
        this.btnOK.Click += BtnOK_Click;

        // Add placeholder text
        AddPlaceholder(txtName, "Enter ground station name");
        AddPlaceholder(txtInitialX, "Enter initial X position");
        AddPlaceholder(txtInitialY, "Enter initial Y position");
        AddPlaceholder(txtCommunicationRadius, "Enter communication radius");

        this.Controls.Add(new Label { Text = "Name", Location = new System.Drawing.Point(15, 5) });
        this.Controls.Add(this.txtName);
        this.Controls.Add(new Label { Text = "Type", Location = new System.Drawing.Point(15, 35) });
        this.Controls.Add(this.cmbType);
        this.Controls.Add(new Label { Text = "Initial X", Location = new System.Drawing.Point(15, 65) });
        this.Controls.Add(this.txtInitialX);
        this.Controls.Add(new Label { Text = "Initial Y", Location = new System.Drawing.Point(15, 95) });
        this.Controls.Add(this.txtInitialY);
        this.Controls.Add(new Label { Text = "Communication Radius", Location = new System.Drawing.Point(15, 125) });
        this.Controls.Add(this.txtCommunicationRadius);
        this.Controls.Add(this.btnOK);

        this.Text = "Add Ground Station";
        this.ClientSize = new System.Drawing.Size(230, 210);
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
        GroundStationName = txtName.Text;
        GroundStationType = (GroundStation.StationType)Enum.Parse(typeof(GroundStation.StationType), cmbType.SelectedItem.ToString());
        InitialX = ParseDouble(txtInitialX, "Enter initial X position");
        InitialY = ParseDouble(txtInitialY, "Enter initial Y position");
        CommunicationRadius = ParseDouble(txtCommunicationRadius, "Enter communication radius");

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
