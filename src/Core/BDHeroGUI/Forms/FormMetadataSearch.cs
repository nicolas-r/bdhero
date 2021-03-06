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
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BDHero.JobQueue;
using DotNetUtils.Extensions;

namespace BDHeroGUI.Forms
{
    public partial class FormMetadataSearch : Form
    {
        /// <summary>
        /// Gets the user's input.
        /// </summary>
        public readonly SearchQuery SearchQuery = new SearchQuery();

        /// <summary>
        /// Determines whether the form should auto-resize itself when the value of the TextBox changes due to user input.
        /// </summary>
        private bool _autoResize = true;

        /// <summary>
        /// Flag set by <see cref="AutoResize"/> to notify <see cref="OnResize"/> to ignore resize events generated by auto-resizing the form.
        /// </summary>
        private bool _ignoreResize;

        /// <summary>
        /// Constructs a new metadata search form window and copies the specified search query into a new SearchQuery object.
        /// </summary>
        /// <param name="searchQuery"></param>
        public FormMetadataSearch(SearchQuery searchQuery)
        {
            InitializeComponent();

            SearchQuery.CopyFrom(searchQuery);

            textBoxSearchQuery.Text = searchQuery.Title;
            textBoxSearchQuery.TextChanged += TextBoxSearchQueryOnTextChanged;

            textBoxYear.Text = searchQuery.Year.HasValue ? searchQuery.Year.ToString() : "";
            textBoxYear.TextChanged += TextBoxYearOnTextChanged;

            Load += OnLoad;
            Resize += OnResize;
        }

        private void OnLoad(object sender, EventArgs eventArgs)
        {
            AutoResize();

            MinimumSize = new Size(Width, Height);
            MaximumSize = new Size(int.MaxValue, Height);
        }

        private void OnResize(object sender, EventArgs eventArgs)
        {
            if (!_autoResize)
                return;

            // User manually resized the form; stop auto-resizing
            if (!_ignoreResize)
                _autoResize = false;

            _ignoreResize = false;
        }

        /// <summary>
        /// Automatically resizes the form to best fit the text in the TextBox.
        /// Respects upper and lower limits to prevent the form from resizing
        /// too small or taking up the entire width of the screen.
        /// </summary>
        private void AutoResize()
        {
            if (!_autoResize)
                return;

            _ignoreResize = true;

            Width += textBoxSearchQuery.GetAutoSizeDelta(2).Width;
        }

        private void TextBoxSearchQueryOnTextChanged(object sender, EventArgs eventArgs)
        {
            SearchQuery.Title = textBoxSearchQuery.Text;
            AutoResize();
        }

        private void TextBoxYearOnTextChanged(object sender, EventArgs eventArgs)
        {
            if (Regex.IsMatch(textBoxYear.Text, @"^[0-9]{4}$"))
                SearchQuery.Year = int.Parse(textBoxYear.Text);
            else
                SearchQuery.Year = null;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
