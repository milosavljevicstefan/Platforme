﻿#pragma checksum "..\..\..\Windows\AllSkoleWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1D604094111A7C509F69F9FC8620B393CF48E522D624750677ED94F7F98DBDFB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApp2.Windows;


namespace WpfApp2.Windows {
    
    
    /// <summary>
    /// AllSkoleWindow
    /// </summary>
    public partial class AllSkoleWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Windows\AllSkoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miDodajSkolu;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Windows\AllSkoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miIzmeniSkolu;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Windows\AllSkoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miObrisiSkolu;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Windows\AllSkoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miVratiNaPocetnu;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Windows\AllSkoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgSkole;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/windows/allskolewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AllSkoleWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.miDodajSkolu = ((System.Windows.Controls.MenuItem)(target));
            
            #line 11 "..\..\..\Windows\AllSkoleWindow.xaml"
            this.miDodajSkolu.Click += new System.Windows.RoutedEventHandler(this.miDodajSkolu_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.miIzmeniSkolu = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\..\Windows\AllSkoleWindow.xaml"
            this.miIzmeniSkolu.Click += new System.Windows.RoutedEventHandler(this.miIzmeniSkolu_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.miObrisiSkolu = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\..\Windows\AllSkoleWindow.xaml"
            this.miObrisiSkolu.Click += new System.Windows.RoutedEventHandler(this.miObrisiSkolu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.miVratiNaPocetnu = ((System.Windows.Controls.MenuItem)(target));
            
            #line 14 "..\..\..\Windows\AllSkoleWindow.xaml"
            this.miVratiNaPocetnu.Click += new System.Windows.RoutedEventHandler(this.miVratiNaPocetnu_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgSkole = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

