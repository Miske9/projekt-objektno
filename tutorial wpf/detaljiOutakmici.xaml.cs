﻿using System.Windows.Controls;

namespace tutorial_wpf
{
    public partial class DetaljiOUtakmici : Page
    {
        public DetaljiOUtakmici(Match match)
        {
            InitializeComponent();
            DataContext = match;
        }
    }
}
