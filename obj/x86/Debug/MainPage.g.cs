﻿#pragma checksum "C:\Users\Bass4Nation\source\repos\StatTrack\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FC8747FAC9E9ABFEF1CBD317C7F0FA3AF23CF6B326503FED9F6DF1D2F850DDC6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StatTrack
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 13
                {
                    this.FrontPageTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.FrontPageTitle).SelectionChanged += this.TextBlock_SelectionChanged;
                }
                break;
            case 3: // MainPage.xaml line 14
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element3 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element3).SelectionChanged += this.TextBlock_SelectionChanged_1;
                }
                break;
            case 4: // MainPage.xaml line 15
                {
                    this.UserNameDisplay = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // MainPage.xaml line 16
                {
                    this.TestInfdoOnline = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // MainPage.xaml line 24
                {
                    this.TestInfoLocal = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // MainPage.xaml line 32
                {
                    this.KillsDisplay = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // MainPage.xaml line 34
                {
                    this.DeathDisplay = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // MainPage.xaml line 36
                {
                    this.LastPlayedCharacter = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // MainPage.xaml line 39
                {
                    this.Username = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.Username).TextChanged += this.UsernameInput;
                }
                break;
            case 11: // MainPage.xaml line 41
                {
                    global::Windows.UI.Xaml.Controls.Button element11 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element11).Click += this.Button_Click_Search;
                }
                break;
            case 12: // MainPage.xaml line 44
                {
                    this.PlayerPlatform = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.PlayerPlatform).SelectionChanged += this.PlayerPlatform_SelectionChanged;
                }
                break;
            case 13: // MainPage.xaml line 49
                {
                    this.DatabaseChoosen = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.DatabaseChoosen).SelectionChanged += this.Database_SelectionChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

