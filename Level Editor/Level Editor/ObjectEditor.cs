using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using System.IO;
using KismetDataTypes;

namespace LevelEditor
{
    public partial class ObjectEditor : Form
    {
        public Game1 game;

        public ObjectEditor()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Exit();
            Application.Exit();
        }

        private void ObjectEditor_Load(object sender, EventArgs e)
        {
            FixScrollBarScales();

            // Hide the specific property boxes
            spawnerProperties.Hide();
            warpProperties.Hide();
            lightProperties.Hide();
            triggerBoxProperties.Hide();

            // Available tech data objects
            cboObjectTypes.Items.Clear();
            cboObjectTypes.Items.Add("Warp");
            cboObjectTypes.Items.Add("Spawner");
            cboObjectTypes.Items.Add("Light Source");
            cboObjectTypes.Items.Add("Trigger Box");

            // Available monsters
            cboMonsterType.Items.Clear();
            cboMonsterType.Items.Add("Goblin");
            cboMonsterType.Items.Add("Demon Archer");

            // Available levels for warping to
            cboWarpLevel.Items.Clear();
            cboWarpLevel.Items.Add("Level01_A");
            cboWarpLevel.Items.Add("Level01_B");
            cboWarpLevel.Items.Add("Level01_C");

            for (int i = 1; i <= 4; i += 1)
            {
                cboNumberOfMonsters.Items.Add(i.ToString());
            }

            // The level being worked on
            cboLevelIndicator.Items.Add("Level01_A");
            cboLevelIndicator.Items.Add("Level01_B");
            cboLevelIndicator.Items.Add("Level01_C");
            cboLevelIndicator.SelectedIndex = 0;
        }

        // Change the values of the scroll bars
        private void FixScrollBarScales()
        {
            Camera.ViewPortWidth = pctSurface.Width;
            Camera.ViewPortHeight = pctSurface.Height;
            Camera.Move(Vector2.Zero);

            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = Camera.WorldRectangle.Height - Camera.ViewPortHeight;

            hScrollBar1.Minimum = 0;
            hScrollBar1.Maximum = Camera.WorldRectangle.Width - Camera.ViewPortWidth;
        }

        private void ObjectEditor_Resize(object sender, EventArgs e)
        {
            FixScrollBarScales();
        }

        private void ObjectEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            game.Exit();
            Application.Exit();
        }

        private void timerGameUpdate_Tick(object sender, EventArgs e)
        {
            if (hScrollBar1.Maximum != game.level01.Width || vScrollBar1.Maximum != game.level01.Height)
            {
                FixScrollBarScales();
            }
            game.Tick();
        }

        // Choose what type of object to deal with
        private void cboObjectTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboObjectTypes.Items[cboObjectTypes.SelectedIndex].ToString())
            {
                case "Warp" :
                    game.CurrentCodeValue = "Warp";
                    spawnerProperties.Hide();
                    warpProperties.Show();
                    lightProperties.Hide();
                    triggerBoxProperties.Hide();
                    break;
                case "Spawner" :
                    game.CurrentCodeValue = "Spawner";
                    spawnerProperties.Show();
                    warpProperties.Hide();
                    lightProperties.Hide();
                    triggerBoxProperties.Hide();
                    break;
                case "Light Source" :
                    game.CurrentCodeValue = "Light Source";
                    spawnerProperties.Hide();
                    warpProperties.Hide();
                    lightProperties.Show();
                    triggerBoxProperties.Hide();
                    break;
                case "Trigger Box" :
                    game.CurrentCodeValue = "Trigger Box";
                    spawnerProperties.Hide();
                    warpProperties.Hide();
                    lightProperties.Hide();
                    triggerBoxProperties.Show();
                    break;
            }
        }

        // Chose to save the level
        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GV.Level.Save();
        }

        // Load a map
        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GV.Level = Level.Load("Level01_A.xml");
            }
            catch
            {
                System.Diagnostics.Debug.Print("Unable to load map file");
            }
        }

        // Choose a type of monster (Spawner)
        private void cboMonsterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboMonsterType.Items[cboMonsterType.SelectedIndex].ToString())
            {
                case "Goblin" :
                    game.MonsterType = "Goblin";
                    break;
                case "Demon Archer" :
                    game.MonsterType = "Demon Archer";
                    break;
            }
        }

        // Choose the number of monsters (Spawner)
        private void cboNumberOfMonsters_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboNumberOfMonsters.Items[cboNumberOfMonsters.SelectedIndex].ToString())
            {
                case "1" :
                    game.numberOfMonsters = 1;
                    break;
                case "2":
                    game.numberOfMonsters = 2;
                    break;
                case "3":
                    game.numberOfMonsters = 3;
                    break;
                case "4":
                    game.numberOfMonsters = 4;
                    break;
            }
        }

        // Save changes
        private void setButton_Click(object sender, EventArgs e)
        {
            game.currentObject.BoundingBox = new Microsoft.Xna.Framework.Rectangle(
                                                           Convert.ToInt32(xPositionTextBox.Text),
                                                           Convert.ToInt32(yPositionTextBox.Text),
                                                           Convert.ToInt32(widthTextBox.Text),
                                                           Convert.ToInt32(heightTextBox.Text));
            game.currentObject.Position = new Vector2(Convert.ToInt32(xPositionTextBox.Text),
                                                      Convert.ToInt32(yPositionTextBox.Text));
            game.currentObject.Name = objectName.Text;
            // Add a warp object to the level's list
            if (game.CurrentCodeValue == "Warp")
            {
                Warp warp = new Warp((int)game.currentObject.Position.X, (int)game.currentObject.Position.Y,
                                     game.currentObject.BoundingBox.Width, game.currentObject.BoundingBox.Height,
                                     warpDestinationLevel.Text, new Vector2(Convert.ToInt32(warpDestinationX.Text),
                                     Convert.ToInt32(warpDestinationY.Text)));
                warp.Name = game.currentObject.Name;
                GV.Level.AddWarp(warp);
                Console.WriteLine("Added: " + warp.Name);
            }
            else if (game.CurrentCodeValue == "Spawner")
            {
                SpawnPoint spawner = new SpawnPoint(game.MonsterType, game.currentObject.Name, game.currentObject.Position);
                GV.Level.AddSpawnPoint(spawner);
                Console.WriteLine("Added: " + spawner.Name);
            }
            else if (game.CurrentCodeValue == "Light Source")
            {
                LightSource light = new LightSource((int)game.currentObject.Position.X, (int)game.currentObject.Position.Y,
                                                    Convert.ToInt32(lightCentreXTextBox.Text), Convert.ToInt32(lightCentreYTextBox.Text),
                                                    Convert.ToInt32(lightRadiusTextBox.Text), Convert.ToInt32(brightnessTextBox.Text));
                light.Name = game.currentObject.Name;
                GV.Level.AddLight(light);
            }
            else if (game.CurrentCodeValue == "Trigger Box")
            {
                Console.WriteLine("Adding a Trigger Box");
                TriggerBox trigger = new TriggerBox(triggerBoxTarget.Text, triggerBoxTarget.Text, game.currentObject.BoundingBox);
                trigger.Name = game.currentObject.Name;
                GV.Level.AddTriggerBox(trigger);
            }
        }

        // Clear the map
        private void clearMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.level01.ClearLevel();
        }

        private void toggleAdding_CheckedChanged(object sender, EventArgs e)
        {
            game.addObject = toggleAdding.Checked;
        }

        private void pctSurface_Click(object sender, EventArgs e)
        {
            if (!toggleAdding.Checked)
            {
                xPositionTextBox.Text = game.positionX.ToString();
                yPositionTextBox.Text = game.positionY.ToString();
                widthTextBox.Text = game.width.ToString();
                heightTextBox.Text = game.height.ToString();
            }
            // Shows the mouse's position (where it was last clicked)
            // relative to the level's coordinates
            mouseXLevel.Text = game.mouseLocationLevel.X.ToString();
            mouseYLevel.Text = game.mouseLocationLevel.Y.ToString();
        }

        // Choose which level to set as a destination for the current warp point
        private void cboWarpLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboWarpLevel.Items[cboWarpLevel.SelectedIndex].ToString())
            {
                case "Level01_A" :
                    
                    break;
                case "Level01_B" :

                    break;
                case "Level01_C" :

                    break;
            }
        }

        // Show hide the grid on the editor
        private void gridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GV.ShowGrid = gridCheckBox.Checked;
        }

    }
}
