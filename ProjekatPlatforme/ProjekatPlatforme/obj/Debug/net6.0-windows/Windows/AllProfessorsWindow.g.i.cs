﻿#pragma checksum "..\..\..\..\Windows\AllProfessorsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08C8A0322098B8C313D91058BC23C6C1AFCA89FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjekatPlatforme.Services;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ProjekatPlatforme.Services {
    
    
    /// <summary>
    /// AllProfessorsWindow
    /// </summary>
    public partial class AllProfessorsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dodaj_button;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button izmeni_button;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button izbrisi_button;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miNekeOpcije;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProfesori;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPretraga;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjekatPlatforme;component/windows/allprofessorswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dodaj_button = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
            this.dodaj_button.Click += new System.Windows.RoutedEventHandler(this.dodaj_button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.izmeni_button = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
            this.izmeni_button.Click += new System.Windows.RoutedEventHandler(this.izmeni_button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.izbrisi_button = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
            this.izbrisi_button.Click += new System.Windows.RoutedEventHandler(this.izbrisi_button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.miNekeOpcije = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 5:
            this.dgProfesori = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
            this.dgProfesori.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgProfesori_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtPretraga = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\..\Windows\AllProfessorsWindow.xaml"
            this.txtPretraga.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtPretraga_KeyUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

