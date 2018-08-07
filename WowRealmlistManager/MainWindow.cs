using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WowRealmlistManager
{
    public partial class MainForm : Form
    {
        private string language_ = "";
        private bool is64bit_ = false;

        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                XDocument xmldocument = XDocument.Load("settings.xml");

                language_ = xmldocument.Descendants("Language").Select(x => x.Value).FirstOrDefault();
                string architecture = xmldocument.Descendants("Architecture").Select(x => x.Value).FirstOrDefault();
                if (architecture.Contains("64"))
                    is64bit_ = true;

                var serverEntries = from server in xmldocument.Descendants("Server")
                                    select new
                                    {
                                        Name = server.Descendants("Name").First().Value,
                                        Website = server.Descendants("Website").First().Value,
                                        Address = server.Descendants("Address").First().Value,
                                        Version = server.Descendants("Version").First().Value,
                                        GamePath = server.Descendants("GamePath").First().Value
                                    };

                foreach (var serverEntry in serverEntries)
                {
                    RealmlistItem item = new RealmlistItem(serverEntry.Name, serverEntry.Website, serverEntry.Address, serverEntry.Version, serverEntry.GamePath);
                    lvRealmlist.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Failed to load settings.xml. Application will close.", "WowRealmlistManager");
                Environment.Exit(-1);
            }
        }

        private void ChangeRealmlist(RealmlistItem item)
        {
            if (item.Addon < Expansion.MistsOfPandaria)
            {
                string[] realmlistLines = File.ReadAllLines(item.GetRealmlistPath(language_));
                string firstLine = "set realmlist " + item.Address;
                realmlistLines[0] = firstLine;
                File.WriteAllLines(item.GetRealmlistPath(language_), realmlistLines);
            }
            else
            {
                string realmlistLine = "SET realmlist \"" + item.Address + "\"";
                string[] configLines = File.ReadAllLines(item.GetRealmlistPath(language_));

                bool replaced = false;
                for (int i = 0; i < configLines.Length; i++)
                {
                    if (configLines[i].Contains("SET realmlist"))
                    {
                        configLines[i] = realmlistLine;
                        replaced = true;
                        break;
                    }
                }

                if (replaced)
                    File.WriteAllLines(item.GetRealmlistPath(language_), configLines);
                else
                    File.AppendAllText(item.GetRealmlistPath(language_), Environment.NewLine + realmlistLine);
            }
        }

        private void DeleteRealmlistFromConfig(RealmlistItem item)
        {
            if (item.Addon > Expansion.Cataclysm)
            {
                List<string> configLines = File.ReadAllLines(item.GetRealmlistPath(language_)).ToList<String>();

                bool removed = false;
                for (int i = 0; i < configLines.Count; i++)
                {
                    if (configLines[i].Contains("SET realmlist"))
                    {
                        configLines.RemoveAt(i);
                        removed = true;
                    }
                }

                if (removed)
                    File.WriteAllLines(item.GetRealmlistPath(language_), configLines);
            }
        }

        private void StartClickEvent(object sender, EventArgs e)
        {
            try
            {
                if (lvRealmlist.SelectedItems.Count > 0)
                {
                    RealmlistItem item = lvRealmlist.SelectedItems[0] as RealmlistItem;

                    if (item.Text.Contains("Retail"))
                        DeleteRealmlistFromConfig(item);
                    else
                        ChangeRealmlist(item);

                    System.Diagnostics.Process.Start(item.GetWowPath(is64bit_));
                }
            }
            catch
            {
                MessageBox.Show("Failed to start wow. Check your settings.", "WowRealmlistManager");
            }
        }

        private void WebsiteClickEvent(object sender, EventArgs e)
        {
            try
            {
                if (lvRealmlist.SelectedItems.Count > 0)
                {
                    RealmlistItem item = lvRealmlist.SelectedItems[0] as RealmlistItem;
                    if (item.Website != null)
                        System.Diagnostics.Process.Start(item.Website);
                }
            }
            catch
            {
                
            }
        }

        private void cmsRealmList_Opening(object sender, CancelEventArgs e)
        {
            if (lvRealmlist.SelectedItems.Count < 1)
                e.Cancel = true;
        }
    }
}