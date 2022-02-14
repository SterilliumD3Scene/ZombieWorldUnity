﻿using System;
using System.IO;
using System.Windows.Forms;

namespace ZombieWorld3 {

    public partial class challengesScreen : UserControl {

        public challengesScreen() {
            InitializeComponent();
        }

        public string filePath = string.Empty;
        public void InsertStuff() {
            Methods.InsertLine(filePath,@"    </Section>",2);
            EditBank(@"""CLShieldProblems""");
            EditBank(@"""CLTorture1""");
            EditBank(@"""CLInfantry""");
            EditBank(@"""CLEvasive""");
            EditBank(@"""CLConstructor""");
            EditBank(@"""CLWarpspeed""");
            EditBank(@"""CLNextToDead""");
            EditBank(@"""CLTeamGame""");
            Methods.InsertLine(filePath,@"    <Section name=""Challenges"">",2);
        }

        public void EditBank(string Name) {
            Methods.InsertLine(filePath,@"        </Key>",2);
            Methods.InsertLine(filePath,@"            <Value flag=""1""/>",2);
            Methods.InsertLine(filePath,@"        <Key name=" + Name + ">",2);
        }

        public void WriteStuff() {
            rTB.AppendText("Writing Values to Bankfile..." + Environment.NewLine);
            rTB.AppendText("Writing Done." + Environment.NewLine);
            rTB.AppendText(" " + Environment.NewLine);
        }
        public void WriteStuff2() {
            rTB.AppendText("Writing Signature..." + Environment.NewLine);
            rTB.AppendText("Signature Done." + Environment.NewLine);
            rTB.AppendText(" " + Environment.NewLine);
            rTB.AppendText("Ready to Play!" + Environment.NewLine);
        }

        public void WriteBank(string BankFile,string HandleOwner) {
                string[] accountNumbers = Directory.GetDirectories(Main.path,Main.playerHandle,SearchOption.AllDirectories);
                filePath = accountNumbers[0] + @"\Banks\" + BankFile;
                Methods.RemoveChallenges(filePath);
                InsertStuff();
                string[] array = File.ReadAllLines(filePath);
                WriteStuff();
                for (int y = 0;y < array.Length;y++) {
                    string line = array[y];
                    if (line.Contains("Signature value")) {
                        BankSign.Sign(HandleOwner,Main.playerHandle,"zombieworldu",filePath);
                        Methods.lineChanger("    <Signature value=\"" + BankSign.signString + "\"/>",filePath,y);
                    }
                }
                WriteStuff2();
            }

        private void rjButton1_Click(object sender,EventArgs e) {
            rTB.Clear();
            if (Main.playerHandle.StartsWith("1-")) { WriteBank(Main.USBankFile,"1-S2-1-8298616"); }
            if (Main.playerHandle.StartsWith("2-")) { WriteBank(Main.EUBankFile,"2-S2-1-7593740"); }
        }

    }
}