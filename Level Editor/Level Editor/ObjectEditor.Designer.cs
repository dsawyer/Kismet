namespace LevelEditor
{
    partial class ObjectEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pctSurface = new System.Windows.Forms.PictureBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.groupBoxLeftClick = new System.Windows.Forms.GroupBox();
            this.toggleAdding = new System.Windows.Forms.CheckBox();
            this.cboObjectTypes = new System.Windows.Forms.ComboBox();
            this.typeOfObject = new System.Windows.Forms.Label();
            this.CurrentLevel = new System.Windows.Forms.Label();
            this.cboLevelIndicator = new System.Windows.Forms.ComboBox();
            this.timerGameUpdate = new System.Windows.Forms.Timer(this.components);
            this.spawnerProperties = new System.Windows.Forms.GroupBox();
            this.cboNumberOfMonsters = new System.Windows.Forms.ComboBox();
            this.numberOfMonsters = new System.Windows.Forms.Label();
            this.cboMonsterType = new System.Windows.Forms.ComboBox();
            this.monsterTypeLabel = new System.Windows.Forms.Label();
            this.generalPropertiesGpbox = new System.Windows.Forms.GroupBox();
            this.objectNameLabel = new System.Windows.Forms.Label();
            this.objectName = new System.Windows.Forms.TextBox();
            this.setButton = new System.Windows.Forms.Button();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.yPositionTextBox = new System.Windows.Forms.TextBox();
            this.xPositionTextBox = new System.Windows.Forms.TextBox();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.yPositionLabel = new System.Windows.Forms.Label();
            this.xPositionLabel = new System.Windows.Forms.Label();
            this.warpProperties = new System.Windows.Forms.GroupBox();
            this.warpDestinationY = new System.Windows.Forms.TextBox();
            this.warpDestinationX = new System.Windows.Forms.TextBox();
            this.warpDestinationYLabel = new System.Windows.Forms.Label();
            this.cboWarpLevel = new System.Windows.Forms.ComboBox();
            this.warpDestinationXLabel = new System.Windows.Forms.Label();
            this.warpDestinationLevel = new System.Windows.Forms.Label();
            this.lightProperties = new System.Windows.Forms.GroupBox();
            this.brightnessTextBox = new System.Windows.Forms.TextBox();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.lightRadiusTextBox = new System.Windows.Forms.TextBox();
            this.lightRadiusLabel = new System.Windows.Forms.Label();
            this.lightCentreYTextBox = new System.Windows.Forms.TextBox();
            this.lightCentreYLabel = new System.Windows.Forms.Label();
            this.lightCentreXTextBox = new System.Windows.Forms.TextBox();
            this.lightCentreXLabel = new System.Windows.Forms.Label();
            this.triggerBoxProperties = new System.Windows.Forms.GroupBox();
            this.triggerBoxTarget = new System.Windows.Forms.TextBox();
            this.triggerBoxTargetLabel = new System.Windows.Forms.Label();
            this.gridCheckBox = new System.Windows.Forms.CheckBox();
            this.mouseXLevelLabel = new System.Windows.Forms.Label();
            this.mouseXLevel = new System.Windows.Forms.Label();
            this.mouseYLevelLabel = new System.Windows.Forms.Label();
            this.mouseYLevel = new System.Windows.Forms.Label();
            this.boundingBoxesCheck = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSurface)).BeginInit();
            this.groupBoxLeftClick.SuspendLayout();
            this.spawnerProperties.SuspendLayout();
            this.generalPropertiesGpbox.SuspendLayout();
            this.warpProperties.SuspendLayout();
            this.lightProperties.SuspendLayout();
            this.triggerBoxProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1582, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMapToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.loadMapToolStripMenuItem.Text = "&Load Map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.saveMapToolStripMenuItem.Text = "&Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMapToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // clearMapToolStripMenuItem
            // 
            this.clearMapToolStripMenuItem.Name = "clearMapToolStripMenuItem";
            this.clearMapToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.clearMapToolStripMenuItem.Text = "&Clear Map";
            this.clearMapToolStripMenuItem.Click += new System.EventHandler(this.clearMapToolStripMenuItem_Click);
            // 
            // pctSurface
            // 
            this.pctSurface.Location = new System.Drawing.Point(280, 27);
            this.pctSurface.Name = "pctSurface";
            this.pctSurface.Size = new System.Drawing.Size(1280, 720);
            this.pctSurface.TabIndex = 1;
            this.pctSurface.TabStop = false;
            this.pctSurface.Click += new System.EventHandler(this.pctSurface_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.LargeChange = 48;
            this.vScrollBar1.Location = new System.Drawing.Point(1562, 27);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 720);
            this.vScrollBar1.TabIndex = 2;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.LargeChange = 48;
            this.hScrollBar1.Location = new System.Drawing.Point(280, 750);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1280, 21);
            this.hScrollBar1.SmallChange = 5;
            this.hScrollBar1.TabIndex = 3;
            // 
            // groupBoxLeftClick
            // 
            this.groupBoxLeftClick.Controls.Add(this.toggleAdding);
            this.groupBoxLeftClick.Controls.Add(this.cboObjectTypes);
            this.groupBoxLeftClick.Controls.Add(this.typeOfObject);
            this.groupBoxLeftClick.Location = new System.Drawing.Point(13, 32);
            this.groupBoxLeftClick.Name = "groupBoxLeftClick";
            this.groupBoxLeftClick.Size = new System.Drawing.Size(261, 86);
            this.groupBoxLeftClick.TabIndex = 4;
            this.groupBoxLeftClick.TabStop = false;
            this.groupBoxLeftClick.Text = "Left Click Mode";
            // 
            // toggleAdding
            // 
            this.toggleAdding.AutoSize = true;
            this.toggleAdding.Checked = true;
            this.toggleAdding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleAdding.Location = new System.Drawing.Point(7, 22);
            this.toggleAdding.Name = "toggleAdding";
            this.toggleAdding.Size = new System.Drawing.Size(216, 21);
            this.toggleAdding.TabIndex = 3;
            this.toggleAdding.Text = "Add (select when unchecked)";
            this.toggleAdding.UseVisualStyleBackColor = true;
            this.toggleAdding.CheckedChanged += new System.EventHandler(this.toggleAdding_CheckedChanged);
            // 
            // cboObjectTypes
            // 
            this.cboObjectTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjectTypes.FormattingEnabled = true;
            this.cboObjectTypes.Location = new System.Drawing.Point(67, 50);
            this.cboObjectTypes.Name = "cboObjectTypes";
            this.cboObjectTypes.Size = new System.Drawing.Size(157, 24);
            this.cboObjectTypes.TabIndex = 2;
            this.cboObjectTypes.SelectedIndexChanged += new System.EventHandler(this.cboObjectTypes_SelectedIndexChanged);
            // 
            // typeOfObject
            // 
            this.typeOfObject.AutoSize = true;
            this.typeOfObject.Location = new System.Drawing.Point(7, 50);
            this.typeOfObject.Name = "typeOfObject";
            this.typeOfObject.Size = new System.Drawing.Size(53, 17);
            this.typeOfObject.TabIndex = 1;
            this.typeOfObject.Text = "Object:";
            // 
            // CurrentLevel
            // 
            this.CurrentLevel.AutoSize = true;
            this.CurrentLevel.Location = new System.Drawing.Point(27, 128);
            this.CurrentLevel.Name = "CurrentLevel";
            this.CurrentLevel.Size = new System.Drawing.Size(46, 17);
            this.CurrentLevel.TabIndex = 5;
            this.CurrentLevel.Text = "Level:";
            // 
            // cboLevelIndicator
            // 
            this.cboLevelIndicator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevelIndicator.FormattingEnabled = true;
            this.cboLevelIndicator.Location = new System.Drawing.Point(79, 125);
            this.cboLevelIndicator.Name = "cboLevelIndicator";
            this.cboLevelIndicator.Size = new System.Drawing.Size(101, 24);
            this.cboLevelIndicator.TabIndex = 6;
            // 
            // timerGameUpdate
            // 
            this.timerGameUpdate.Enabled = true;
            this.timerGameUpdate.Interval = 20;
            this.timerGameUpdate.Tick += new System.EventHandler(this.timerGameUpdate_Tick);
            // 
            // spawnerProperties
            // 
            this.spawnerProperties.Controls.Add(this.cboNumberOfMonsters);
            this.spawnerProperties.Controls.Add(this.numberOfMonsters);
            this.spawnerProperties.Controls.Add(this.cboMonsterType);
            this.spawnerProperties.Controls.Add(this.monsterTypeLabel);
            this.spawnerProperties.Location = new System.Drawing.Point(13, 390);
            this.spawnerProperties.Name = "spawnerProperties";
            this.spawnerProperties.Size = new System.Drawing.Size(260, 86);
            this.spawnerProperties.TabIndex = 7;
            this.spawnerProperties.TabStop = false;
            this.spawnerProperties.Text = "Spawner Properties";
            // 
            // cboNumberOfMonsters
            // 
            this.cboNumberOfMonsters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNumberOfMonsters.FormattingEnabled = true;
            this.cboNumberOfMonsters.Location = new System.Drawing.Point(115, 50);
            this.cboNumberOfMonsters.Name = "cboNumberOfMonsters";
            this.cboNumberOfMonsters.Size = new System.Drawing.Size(121, 24);
            this.cboNumberOfMonsters.TabIndex = 3;
            this.cboNumberOfMonsters.SelectedIndexChanged += new System.EventHandler(this.cboNumberOfMonsters_SelectedIndexChanged);
            // 
            // numberOfMonsters
            // 
            this.numberOfMonsters.AutoSize = true;
            this.numberOfMonsters.Location = new System.Drawing.Point(14, 53);
            this.numberOfMonsters.Name = "numberOfMonsters";
            this.numberOfMonsters.Size = new System.Drawing.Size(62, 17);
            this.numberOfMonsters.TabIndex = 2;
            this.numberOfMonsters.Text = "Number:";
            // 
            // cboMonsterType
            // 
            this.cboMonsterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonsterType.FormattingEnabled = true;
            this.cboMonsterType.Location = new System.Drawing.Point(115, 19);
            this.cboMonsterType.Name = "cboMonsterType";
            this.cboMonsterType.Size = new System.Drawing.Size(121, 24);
            this.cboMonsterType.TabIndex = 1;
            this.cboMonsterType.SelectedIndexChanged += new System.EventHandler(this.cboMonsterType_SelectedIndexChanged);
            // 
            // monsterTypeLabel
            // 
            this.monsterTypeLabel.AutoSize = true;
            this.monsterTypeLabel.Location = new System.Drawing.Point(14, 22);
            this.monsterTypeLabel.Name = "monsterTypeLabel";
            this.monsterTypeLabel.Size = new System.Drawing.Size(99, 17);
            this.monsterTypeLabel.TabIndex = 0;
            this.monsterTypeLabel.Text = "Monster Type:";
            // 
            // generalPropertiesGpbox
            // 
            this.generalPropertiesGpbox.Controls.Add(this.objectNameLabel);
            this.generalPropertiesGpbox.Controls.Add(this.objectName);
            this.generalPropertiesGpbox.Controls.Add(this.setButton);
            this.generalPropertiesGpbox.Controls.Add(this.heightTextBox);
            this.generalPropertiesGpbox.Controls.Add(this.widthTextBox);
            this.generalPropertiesGpbox.Controls.Add(this.yPositionTextBox);
            this.generalPropertiesGpbox.Controls.Add(this.xPositionTextBox);
            this.generalPropertiesGpbox.Controls.Add(this.heightLabel);
            this.generalPropertiesGpbox.Controls.Add(this.widthLabel);
            this.generalPropertiesGpbox.Controls.Add(this.yPositionLabel);
            this.generalPropertiesGpbox.Controls.Add(this.xPositionLabel);
            this.generalPropertiesGpbox.Location = new System.Drawing.Point(12, 181);
            this.generalPropertiesGpbox.Name = "generalPropertiesGpbox";
            this.generalPropertiesGpbox.Size = new System.Drawing.Size(261, 203);
            this.generalPropertiesGpbox.TabIndex = 8;
            this.generalPropertiesGpbox.TabStop = false;
            this.generalPropertiesGpbox.Text = "General Properties";
            // 
            // objectNameLabel
            // 
            this.objectNameLabel.AutoSize = true;
            this.objectNameLabel.Location = new System.Drawing.Point(10, 135);
            this.objectNameLabel.Name = "objectNameLabel";
            this.objectNameLabel.Size = new System.Drawing.Size(49, 17);
            this.objectNameLabel.TabIndex = 10;
            this.objectNameLabel.Text = "Name:";
            // 
            // objectName
            // 
            this.objectName.Location = new System.Drawing.Point(117, 132);
            this.objectName.Name = "objectName";
            this.objectName.Size = new System.Drawing.Size(120, 22);
            this.objectName.TabIndex = 8;
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(116, 170);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 23);
            this.setButton.TabIndex = 9;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(116, 103);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(121, 22);
            this.heightTextBox.TabIndex = 7;
            this.heightTextBox.Text = "0";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(116, 75);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(121, 22);
            this.widthTextBox.TabIndex = 6;
            this.widthTextBox.Text = "0";
            // 
            // yPositionTextBox
            // 
            this.yPositionTextBox.Location = new System.Drawing.Point(116, 47);
            this.yPositionTextBox.Name = "yPositionTextBox";
            this.yPositionTextBox.Size = new System.Drawing.Size(121, 22);
            this.yPositionTextBox.TabIndex = 5;
            this.yPositionTextBox.Text = "0";
            // 
            // xPositionTextBox
            // 
            this.xPositionTextBox.Location = new System.Drawing.Point(116, 19);
            this.xPositionTextBox.Name = "xPositionTextBox";
            this.xPositionTextBox.Size = new System.Drawing.Size(121, 22);
            this.xPositionTextBox.TabIndex = 4;
            this.xPositionTextBox.Text = "0";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(10, 106);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(53, 17);
            this.heightLabel.TabIndex = 3;
            this.heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(10, 78);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(48, 17);
            this.widthLabel.TabIndex = 2;
            this.widthLabel.Text = "Width:";
            // 
            // yPositionLabel
            // 
            this.yPositionLabel.AutoSize = true;
            this.yPositionLabel.Location = new System.Drawing.Point(10, 50);
            this.yPositionLabel.Name = "yPositionLabel";
            this.yPositionLabel.Size = new System.Drawing.Size(75, 17);
            this.yPositionLabel.TabIndex = 1;
            this.yPositionLabel.Text = "Y Position:";
            // 
            // xPositionLabel
            // 
            this.xPositionLabel.AutoSize = true;
            this.xPositionLabel.Location = new System.Drawing.Point(10, 22);
            this.xPositionLabel.Name = "xPositionLabel";
            this.xPositionLabel.Size = new System.Drawing.Size(75, 17);
            this.xPositionLabel.TabIndex = 0;
            this.xPositionLabel.Text = "X Position:";
            // 
            // warpProperties
            // 
            this.warpProperties.Controls.Add(this.warpDestinationY);
            this.warpProperties.Controls.Add(this.warpDestinationX);
            this.warpProperties.Controls.Add(this.warpDestinationYLabel);
            this.warpProperties.Controls.Add(this.cboWarpLevel);
            this.warpProperties.Controls.Add(this.warpDestinationXLabel);
            this.warpProperties.Controls.Add(this.warpDestinationLevel);
            this.warpProperties.Location = new System.Drawing.Point(12, 390);
            this.warpProperties.Name = "warpProperties";
            this.warpProperties.Size = new System.Drawing.Size(260, 116);
            this.warpProperties.TabIndex = 9;
            this.warpProperties.TabStop = false;
            this.warpProperties.Text = "Warp Properties";
            // 
            // warpDestinationY
            // 
            this.warpDestinationY.Location = new System.Drawing.Point(115, 81);
            this.warpDestinationY.Name = "warpDestinationY";
            this.warpDestinationY.Size = new System.Drawing.Size(121, 22);
            this.warpDestinationY.TabIndex = 6;
            // 
            // warpDestinationX
            // 
            this.warpDestinationX.Location = new System.Drawing.Point(115, 50);
            this.warpDestinationX.Name = "warpDestinationX";
            this.warpDestinationX.Size = new System.Drawing.Size(121, 22);
            this.warpDestinationX.TabIndex = 5;
            // 
            // warpDestinationYLabel
            // 
            this.warpDestinationYLabel.AutoSize = true;
            this.warpDestinationYLabel.Location = new System.Drawing.Point(9, 84);
            this.warpDestinationYLabel.Name = "warpDestinationYLabel";
            this.warpDestinationYLabel.Size = new System.Drawing.Size(75, 17);
            this.warpDestinationYLabel.TabIndex = 4;
            this.warpDestinationYLabel.Text = "Y Position:";
            // 
            // cboWarpLevel
            // 
            this.cboWarpLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarpLevel.FormattingEnabled = true;
            this.cboWarpLevel.Location = new System.Drawing.Point(115, 19);
            this.cboWarpLevel.Name = "cboWarpLevel";
            this.cboWarpLevel.Size = new System.Drawing.Size(121, 24);
            this.cboWarpLevel.TabIndex = 2;
            this.cboWarpLevel.SelectedIndexChanged += new System.EventHandler(this.cboWarpLevel_SelectedIndexChanged);
            // 
            // warpDestinationXLabel
            // 
            this.warpDestinationXLabel.AutoSize = true;
            this.warpDestinationXLabel.Location = new System.Drawing.Point(9, 53);
            this.warpDestinationXLabel.Name = "warpDestinationXLabel";
            this.warpDestinationXLabel.Size = new System.Drawing.Size(75, 17);
            this.warpDestinationXLabel.TabIndex = 1;
            this.warpDestinationXLabel.Text = "X Position:";
            // 
            // warpDestinationLevel
            // 
            this.warpDestinationLevel.AutoSize = true;
            this.warpDestinationLevel.Location = new System.Drawing.Point(13, 22);
            this.warpDestinationLevel.Name = "warpDestinationLevel";
            this.warpDestinationLevel.Size = new System.Drawing.Size(46, 17);
            this.warpDestinationLevel.TabIndex = 0;
            this.warpDestinationLevel.Text = "Level:";
            // 
            // lightProperties
            // 
            this.lightProperties.Controls.Add(this.brightnessTextBox);
            this.lightProperties.Controls.Add(this.brightnessLabel);
            this.lightProperties.Controls.Add(this.lightRadiusTextBox);
            this.lightProperties.Controls.Add(this.lightRadiusLabel);
            this.lightProperties.Controls.Add(this.lightCentreYTextBox);
            this.lightProperties.Controls.Add(this.lightCentreYLabel);
            this.lightProperties.Controls.Add(this.lightCentreXTextBox);
            this.lightProperties.Controls.Add(this.lightCentreXLabel);
            this.lightProperties.Location = new System.Drawing.Point(12, 390);
            this.lightProperties.Name = "lightProperties";
            this.lightProperties.Size = new System.Drawing.Size(260, 145);
            this.lightProperties.TabIndex = 10;
            this.lightProperties.TabStop = false;
            this.lightProperties.Text = "Light Source Properties";
            // 
            // brightnessTextBox
            // 
            this.brightnessTextBox.Location = new System.Drawing.Point(113, 108);
            this.brightnessTextBox.Name = "brightnessTextBox";
            this.brightnessTextBox.Size = new System.Drawing.Size(123, 22);
            this.brightnessTextBox.TabIndex = 7;
            this.brightnessTextBox.Text = "0";
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Location = new System.Drawing.Point(9, 111);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(79, 17);
            this.brightnessLabel.TabIndex = 6;
            this.brightnessLabel.Text = "Brightness:";
            // 
            // lightRadiusTextBox
            // 
            this.lightRadiusTextBox.Location = new System.Drawing.Point(113, 79);
            this.lightRadiusTextBox.Name = "lightRadiusTextBox";
            this.lightRadiusTextBox.Size = new System.Drawing.Size(123, 22);
            this.lightRadiusTextBox.TabIndex = 5;
            this.lightRadiusTextBox.Text = "0";
            // 
            // lightRadiusLabel
            // 
            this.lightRadiusLabel.AutoSize = true;
            this.lightRadiusLabel.Location = new System.Drawing.Point(9, 82);
            this.lightRadiusLabel.Name = "lightRadiusLabel";
            this.lightRadiusLabel.Size = new System.Drawing.Size(56, 17);
            this.lightRadiusLabel.TabIndex = 4;
            this.lightRadiusLabel.Text = "Radius:";
            // 
            // lightCentreYTextBox
            // 
            this.lightCentreYTextBox.Location = new System.Drawing.Point(113, 50);
            this.lightCentreYTextBox.Name = "lightCentreYTextBox";
            this.lightCentreYTextBox.Size = new System.Drawing.Size(123, 22);
            this.lightCentreYTextBox.TabIndex = 3;
            this.lightCentreYTextBox.Text = "0";
            // 
            // lightCentreYLabel
            // 
            this.lightCentreYLabel.AutoSize = true;
            this.lightCentreYLabel.Location = new System.Drawing.Point(9, 53);
            this.lightCentreYLabel.Name = "lightCentreYLabel";
            this.lightCentreYLabel.Size = new System.Drawing.Size(67, 17);
            this.lightCentreYLabel.TabIndex = 2;
            this.lightCentreYLabel.Text = "Centre Y:";
            // 
            // lightCentreXTextBox
            // 
            this.lightCentreXTextBox.Location = new System.Drawing.Point(113, 22);
            this.lightCentreXTextBox.Name = "lightCentreXTextBox";
            this.lightCentreXTextBox.Size = new System.Drawing.Size(123, 22);
            this.lightCentreXTextBox.TabIndex = 1;
            this.lightCentreXTextBox.Text = "0";
            // 
            // lightCentreXLabel
            // 
            this.lightCentreXLabel.AutoSize = true;
            this.lightCentreXLabel.Location = new System.Drawing.Point(9, 25);
            this.lightCentreXLabel.Name = "lightCentreXLabel";
            this.lightCentreXLabel.Size = new System.Drawing.Size(67, 17);
            this.lightCentreXLabel.TabIndex = 0;
            this.lightCentreXLabel.Text = "Centre X:";
            // 
            // triggerBoxProperties
            // 
            this.triggerBoxProperties.Controls.Add(this.triggerBoxTarget);
            this.triggerBoxProperties.Controls.Add(this.triggerBoxTargetLabel);
            this.triggerBoxProperties.Location = new System.Drawing.Point(12, 390);
            this.triggerBoxProperties.Name = "triggerBoxProperties";
            this.triggerBoxProperties.Size = new System.Drawing.Size(260, 61);
            this.triggerBoxProperties.TabIndex = 11;
            this.triggerBoxProperties.TabStop = false;
            this.triggerBoxProperties.Text = "Trigger Box Properties";
            // 
            // triggerBoxTarget
            // 
            this.triggerBoxTarget.Location = new System.Drawing.Point(114, 22);
            this.triggerBoxTarget.Name = "triggerBoxTarget";
            this.triggerBoxTarget.Size = new System.Drawing.Size(121, 22);
            this.triggerBoxTarget.TabIndex = 1;
            // 
            // triggerBoxTargetLabel
            // 
            this.triggerBoxTargetLabel.AutoSize = true;
            this.triggerBoxTargetLabel.Location = new System.Drawing.Point(10, 25);
            this.triggerBoxTargetLabel.Name = "triggerBoxTargetLabel";
            this.triggerBoxTargetLabel.Size = new System.Drawing.Size(54, 17);
            this.triggerBoxTargetLabel.TabIndex = 0;
            this.triggerBoxTargetLabel.Text = "Target:";
            // 
            // gridCheckBox
            // 
            this.gridCheckBox.AutoSize = true;
            this.gridCheckBox.Location = new System.Drawing.Point(30, 154);
            this.gridCheckBox.Name = "gridCheckBox";
            this.gridCheckBox.Size = new System.Drawing.Size(95, 21);
            this.gridCheckBox.TabIndex = 12;
            this.gridCheckBox.Text = "Show Grid";
            this.gridCheckBox.UseVisualStyleBackColor = true;
            this.gridCheckBox.CheckedChanged += new System.EventHandler(this.gridCheckBox_CheckedChanged);
            // 
            // mouseXLevelLabel
            // 
            this.mouseXLevelLabel.AutoSize = true;
            this.mouseXLevelLabel.Location = new System.Drawing.Point(13, 700);
            this.mouseXLevelLabel.Name = "mouseXLevelLabel";
            this.mouseXLevelLabel.Size = new System.Drawing.Size(115, 17);
            this.mouseXLevelLabel.TabIndex = 13;
            this.mouseXLevelLabel.Text = "Mouse X (Level):";
            // 
            // mouseXLevel
            // 
            this.mouseXLevel.AutoSize = true;
            this.mouseXLevel.Location = new System.Drawing.Point(135, 700);
            this.mouseXLevel.Name = "mouseXLevel";
            this.mouseXLevel.Size = new System.Drawing.Size(16, 17);
            this.mouseXLevel.TabIndex = 14;
            this.mouseXLevel.Text = "0";
            // 
            // mouseYLevelLabel
            // 
            this.mouseYLevelLabel.AutoSize = true;
            this.mouseYLevelLabel.Location = new System.Drawing.Point(13, 730);
            this.mouseYLevelLabel.Name = "mouseYLevelLabel";
            this.mouseYLevelLabel.Size = new System.Drawing.Size(115, 17);
            this.mouseYLevelLabel.TabIndex = 15;
            this.mouseYLevelLabel.Text = "Mouse Y (Level):";
            // 
            // mouseYLevel
            // 
            this.mouseYLevel.AutoSize = true;
            this.mouseYLevel.Location = new System.Drawing.Point(135, 730);
            this.mouseYLevel.Name = "mouseYLevel";
            this.mouseYLevel.Size = new System.Drawing.Size(16, 17);
            this.mouseYLevel.TabIndex = 16;
            this.mouseYLevel.Text = "0";
            // 
            // boundingBoxesCheck
            // 
            this.boundingBoxesCheck.AutoSize = true;
            this.boundingBoxesCheck.Location = new System.Drawing.Point(10, 676);
            this.boundingBoxesCheck.Name = "boundingBoxesCheck";
            this.boundingBoxesCheck.Size = new System.Drawing.Size(170, 21);
            this.boundingBoxesCheck.TabIndex = 17;
            this.boundingBoxesCheck.Text = "Show Bounding Boxes";
            this.boundingBoxesCheck.UseVisualStyleBackColor = true;
            this.boundingBoxesCheck.CheckedChanged += new System.EventHandler(this.boundingBoxesCheck_CheckedChanged);
            // 
            // ObjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 775);
            this.Controls.Add(this.boundingBoxesCheck);
            this.Controls.Add(this.mouseYLevel);
            this.Controls.Add(this.mouseYLevelLabel);
            this.Controls.Add(this.mouseXLevel);
            this.Controls.Add(this.mouseXLevelLabel);
            this.Controls.Add(this.gridCheckBox);
            this.Controls.Add(this.triggerBoxProperties);
            this.Controls.Add(this.warpProperties);
            this.Controls.Add(this.lightProperties);
            this.Controls.Add(this.generalPropertiesGpbox);
            this.Controls.Add(this.cboLevelIndicator);
            this.Controls.Add(this.CurrentLevel);
            this.Controls.Add(this.groupBoxLeftClick);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.pctSurface);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.spawnerProperties);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ObjectEditor";
            this.Text = "ObjectEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ObjectEditor_FormClosed);
            this.Load += new System.EventHandler(this.ObjectEditor_Load);
            this.Resize += new System.EventHandler(this.ObjectEditor_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSurface)).EndInit();
            this.groupBoxLeftClick.ResumeLayout(false);
            this.groupBoxLeftClick.PerformLayout();
            this.spawnerProperties.ResumeLayout(false);
            this.spawnerProperties.PerformLayout();
            this.generalPropertiesGpbox.ResumeLayout(false);
            this.generalPropertiesGpbox.PerformLayout();
            this.warpProperties.ResumeLayout(false);
            this.warpProperties.PerformLayout();
            this.lightProperties.ResumeLayout(false);
            this.lightProperties.PerformLayout();
            this.triggerBoxProperties.ResumeLayout(false);
            this.triggerBoxProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.PictureBox pctSurface;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMapToolStripMenuItem;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.GroupBox groupBoxLeftClick;
        private System.Windows.Forms.ComboBox cboObjectTypes;
        private System.Windows.Forms.Label typeOfObject;
        private System.Windows.Forms.Label CurrentLevel;
        private System.Windows.Forms.ComboBox cboLevelIndicator;
        private System.Windows.Forms.Timer timerGameUpdate;
        private System.Windows.Forms.GroupBox spawnerProperties;
        private System.Windows.Forms.ComboBox cboMonsterType;
        private System.Windows.Forms.Label monsterTypeLabel;
        private System.Windows.Forms.ComboBox cboNumberOfMonsters;
        private System.Windows.Forms.Label numberOfMonsters;
        private System.Windows.Forms.GroupBox generalPropertiesGpbox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox yPositionTextBox;
        private System.Windows.Forms.TextBox xPositionTextBox;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label yPositionLabel;
        private System.Windows.Forms.Label xPositionLabel;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.CheckBox toggleAdding;
        private System.Windows.Forms.GroupBox warpProperties;
        private System.Windows.Forms.ComboBox cboWarpLevel;
        private System.Windows.Forms.Label warpDestinationXLabel;
        private System.Windows.Forms.Label warpDestinationLevel;
        private System.Windows.Forms.GroupBox lightProperties;
        private System.Windows.Forms.TextBox brightnessTextBox;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.TextBox lightRadiusTextBox;
        private System.Windows.Forms.Label lightRadiusLabel;
        private System.Windows.Forms.TextBox lightCentreYTextBox;
        private System.Windows.Forms.Label lightCentreYLabel;
        private System.Windows.Forms.TextBox lightCentreXTextBox;
        private System.Windows.Forms.Label lightCentreXLabel;
        private System.Windows.Forms.GroupBox triggerBoxProperties;
        private System.Windows.Forms.Label triggerBoxTargetLabel;
        private System.Windows.Forms.Label warpDestinationYLabel;
        private System.Windows.Forms.TextBox warpDestinationY;
        private System.Windows.Forms.TextBox warpDestinationX;
        private System.Windows.Forms.Label objectNameLabel;
        private System.Windows.Forms.TextBox objectName;
        private System.Windows.Forms.TextBox triggerBoxTarget;
        private System.Windows.Forms.CheckBox gridCheckBox;
        private System.Windows.Forms.Label mouseXLevelLabel;
        private System.Windows.Forms.Label mouseXLevel;
        private System.Windows.Forms.Label mouseYLevelLabel;
        private System.Windows.Forms.Label mouseYLevel;
        private System.Windows.Forms.CheckBox boundingBoxesCheck;
    }
}