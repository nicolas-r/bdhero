﻿// Copyright 2012-2014 Andrew C. Dvorak
//
// This file is part of BDHero.
//
// BDHero is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// BDHero is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with BDHero.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDHero.BDROM;
using BDHeroGUI.Properties;

namespace BDHeroGUI.Components
{
    public partial class DiscInfoFeaturesPanel : UserControl
    {
        public DiscInfoFeaturesPanel()
        {
            InitializeComponent();
        }

        public void SetDisc(Disc disc)
        {
            var features = disc.Features;

            SetFeature(iconBDPlus, labelBDPlus, features.IsBDPlus);
            SetFeature(iconBDJava, labelBDJava, features.IsBDJava);
            SetFeature(icon3D, label3D, features.Is3D);
            SetFeature(iconDbox, labelDbox, features.IsDbox);
            SetFeature(iconDCopy, labelDCopy, features.IsDCopy);
            SetFeature(iconPSP, labelPSP, features.IsPSP);
        }

        private void SetFeature(PictureBox icon, Label label, bool enabled)
        {
            icon.Image = enabled ? Resources.tick : Resources.cross_red;
            label.Text = enabled ? "Yes" : "No";
        }
    }
}
