﻿#pragma checksum "..\..\..\Windows\AddEditProfessorWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0DC300E7AA40318E63D9056F2FD410225D58AE07CF74294AF9E63111F0226237"
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
    /// AddEditProfessorWindow
    /// </summary>
    public partial class AddEditProfessorWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Windows\AddEditProfessorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbSkole;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Windows\AddEditProfessorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbJezici;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\AddEditProfessorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbCasovi;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Windows\AddEditProfessorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIme;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Windows\AddEditProfessorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrezime;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Windows\AddEditProfessorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJmbg;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\AddEditProfessorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLozinka;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Windows\AddEditProfessorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Windows\AddEditProfessorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPol;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\AddEditProfessorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbAdresa;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/windows/addeditprofessorwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AddEditProfessorWindow.xaml"
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
            this.lbSkole = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.lbJezici = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.lbCasovi = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            
            #line 21 "..\..\..\Windows\AddEditProfessorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnOdustani_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 22 "..\..\..\Windows\AddEditProfessorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtPrezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtJmbg = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtLozinka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.cbPol = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.cbAdresa = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

