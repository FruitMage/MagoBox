﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDLLVL;

namespace MagoBox.Editors
{
    public partial class SpecialItemEditor : Form
    {
        public RDLLVL.SpecialItem obj;
        Objects objs = new Objects();

        public SpecialItemEditor()
        {
            InitializeComponent();
        }

        private void ObjectEditor_Load(object sender, EventArgs e)
        {
            objDropDown.Items.AddRange(objs.SpecialItemList.Values.ToArray());
            type.Text = obj.Type.ToString();
            appearId.Text = obj.AppearID.ToString();
            movingId.Value = obj.MovingTerrainID;
            respawn.Checked = obj.Respawn;
            xCoord.Value = obj.X;
            xOffs.Value = obj.XOffset;
            yCoord.Value = obj.Y;
            yOffs.Value = obj.YOffset;
        }

        private void save_Click(object sender, EventArgs e)
        {
            obj.Type = uint.Parse(type.Text);
            obj.AppearID = uint.Parse(appearId.Text);
            obj.MovingTerrainID = (int)movingId.Value;
            obj.Respawn = respawn.Checked;
            obj.X = (uint)xCoord.Value;
            obj.XOffset = (uint)xOffs.Value;
            obj.Y = (uint)yCoord.Value;
            obj.YOffset = (uint)yOffs.Value;
            DialogResult = DialogResult.OK;
        }

        private void type_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (objs.SpecialItemList.ContainsKey(uint.Parse(type.Text)))
                {
                    objDropDown.Text = objs.SpecialItemList[uint.Parse(type.Text)];
                }
                else
                {
                    objDropDown.Text = "";
                }
            } catch { }
        }

        private void objDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            type.Text = objs.SpecialItemList.FirstOrDefault(x => x.Value == objDropDown.Text).Key.ToString();
        }
    }
}
