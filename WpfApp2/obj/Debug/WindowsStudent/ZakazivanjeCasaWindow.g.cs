﻿#pragma checksum "..\..\..\WindowsStudent\ZakazivanjeCasaWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C792D0D605589D17F8AA51D0DEDDD262E3279E7D545432F44C7E21F86FEC962E"
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
using WpfApp2.WindowsStudent;


namespace WpfApp2.WindowsStudent {
    
    
    /// <summary>
    /// ZakazivanjeCasaWindow
    /// </summary>
    public partial class ZakazivanjeCasaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\WindowsStudent\ZakazivanjeCasaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbCasovi;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\WindowsStudent\ZakazivanjeCasaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sacuvajButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\WindowsStudent\ZakazivanjeCasaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button odustaniButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/windowsstudent/zakazivanjecasawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowsStudent\ZakazivanjeCasaWindow.xaml"
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
            this.lbCasovi = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.sacuvajButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\WindowsStudent\ZakazivanjeCasaWindow.xaml"
            this.sacuvajButton.Click += new System.Windows.RoutedEventHandler(this.sacuvajButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.odustaniButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\WindowsStudent\ZakazivanjeCasaWindow.xaml"
            this.odustaniButton.Click += new System.Windows.RoutedEventHandler(this.odustaniButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

