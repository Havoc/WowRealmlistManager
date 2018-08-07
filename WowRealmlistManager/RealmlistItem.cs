using System;
using System.IO;
using System.Windows.Forms;

namespace WowRealmlistManager
{
    public enum Expansion : int
    {
        Classic,
        TheBurningCrusade,
        WrathOfTheLichKing,
        Cataclysm,
        MistsOfPandaria,
        WarlordsOfDraenor,
        Legion,
        BattleForAzeroth
    }

    public class RealmlistItem : ListViewItem
    {
        public RealmlistItem(string name, string website, string address, string version, string gamePath) : base(name)
        {

            Website = website;
            Address = address;
            Version = version;
            GamePath = gamePath;

            int addon;
            if (Int32.TryParse(Version[0].ToString(), out addon))
                Addon = (Expansion)(--addon);
            else
                Addon = Expansion.Classic;

            SubItems.Add(Address);
            SubItems.Add(Version);
            ImageIndex = (int)Addon;
        }

        public string Website { get; private set; }
        public string Address { get; private set; }
        public string Version { get; private set; }
        public Expansion Addon { get; private set; }
        public string GamePath { get; private set; }

        public string GetRealmlistPath(string language)
        {
            switch (Addon)
            {
                case Expansion.Classic:
                case Expansion.TheBurningCrusade:
                    return Path.Combine(GamePath, "realmlist.wtf");
                case Expansion.WrathOfTheLichKing:
                case Expansion.Cataclysm:
                    return Path.Combine(GamePath, "Data", language, "realmlist.wtf");
                case Expansion.MistsOfPandaria:
                case Expansion.WarlordsOfDraenor:
                case Expansion.Legion:
                case Expansion.BattleForAzeroth:
                    return Path.Combine(GamePath, "WTF", "Config.wtf");
                default:
                    return "";
            }
        }

        public string GetWowPath(bool is64bit)
        {
            if (Addon > Expansion.Cataclysm && is64bit)
                return Path.Combine(GamePath, "Wow-64.exe");
            else
                return Path.Combine(GamePath, "Wow.exe");
        }
    }
}