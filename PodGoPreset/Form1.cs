using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PodGoPresetTool
{
    public partial class Form1 : Form
    {
        string preset_name;
        JObject json;
        int BlockPedalVol;
        int BlockPedalWah;
        int BlockFxLoop;
        int BlockAmp;
        int BlockCab;
        int BlockEq;



        public Form1()
        {
            InitializeComponent();
            ResetFile();
            FormRefresh();
        }



        private void btn_AbrirPreset_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Line 6 POD Go Edit json_preset (.pgp)|*.pgp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ResetFile();
                if (!CheckFile(openFileDialog1.FileName))
                {
                    MessageBox.Show("Fichero no válido", "Error fichero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                preset_name = System.IO.Path.GetFileName(openFileDialog1.FileName);
                using (StreamReader r = new StreamReader(openFileDialog1.FileName))
                {
                    json = JObject.Parse(r.ReadToEnd());
                    FormRefresh();
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {

            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Line 6 POD Go Edit json_preset (.pgp)|*.pgp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, json.ToString());
            }
        }

        private void btn_PedalVol_Click(object sender, EventArgs e)
        {
            EliminarBloque(BlockPedalVol);
        }

        private void btn_PedalWah_Click(object sender, EventArgs e)
        {
            EliminarBloque(BlockPedalWah);
        }

        private void btn_FxLoop_Click(object sender, EventArgs e)
        {
            EliminarBloque(BlockFxLoop);
        }

        private void btn_Amp_Click(object sender, EventArgs e)
        {
            EliminarBloque(BlockAmp);
        }

        private void btn_Cab_Click(object sender, EventArgs e)
        {
            EliminarBloque(BlockCab);
        }

        private void btn_Eq_Click(object sender, EventArgs e)
        {
            EliminarBloque(BlockEq);
        }

        private void EliminarBloque(int block)
        {
            this.Enabled = false;
            int block_number;

            for (int i = 0; i < json["data"]["tone"]["controller"]["dsp0"].Count(); i++)
            {
                block_number = GetBlockNumber(((JObject)json["data"]["tone"]["controller"]["dsp0"]).Properties().ElementAt(i).Name);
                if (block_number == block)
                {
                    ((JObject)json["data"]["tone"]["controller"]["dsp0"]).Properties().ElementAt(i).Remove();
                    break;
                }
            }
            for (int i = 0; i < json["data"]["tone"]["dsp0"].Count(); i++)
            {
                block_number = GetBlockNumber(((JObject)json["data"]["tone"]["dsp0"]).Properties().ElementAt(i).Name);
                if (block_number == block)
                {
                    string block_name = ((JObject)json["data"]["tone"]["dsp0"]).Properties().ElementAt(i).Name;
                    for (int j = ((JObject)json["data"]["tone"]["dsp0"][block_name]).Properties().Count() - 1; j >= 0; j--)
                    {
                        if (!((JObject)json["data"]["tone"]["dsp0"][block_name]).Properties().ElementAt(j).Name.Contains("position"))
                        {
                            ((JObject)json["data"]["tone"]["dsp0"][block_name]).Properties().ElementAt(j).Remove();
                        }
                    }
                    break;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = ((JObject)json["data"]["tone"]["snapshot" + i.ToString()]["controllers"]["dsp0"]).Properties().Count() - 1; j >= 0; j--)
                {
                    string text = ((JObject)json["data"]["tone"]["snapshot" + i.ToString()]["controllers"]["dsp0"]).Properties().ElementAt(j).Name;
                    block_number = GetBlockNumber(((JObject)json["data"]["tone"]["snapshot" + i.ToString()]["controllers"]["dsp0"]).Properties().ElementAt(j).Name);
                    if (block_number == block)
                    {
                        ((JObject)json["data"]["tone"]["snapshot" + i.ToString()]["controllers"]["dsp0"]).Properties().ElementAt(j).Remove();
                    }
                }

            }
            FormRefresh();
            this.Enabled = true;
        }

        private void FormRefresh()
        {
            bool file_existe = false;

            if (preset_name != null)
            {
                AnalisisJson();
                btn_Guardar.Enabled = true;
                btn_PedalVol.Enabled = false; lbl_PedalVol.Text = "Pedal Vol. NO detectado";
                btn_PedalWah.Enabled = false; lbl_PedalWah.Text = "Pedal Wah NO detectado";
                btn_FxLoop.Enabled = false; lbl_FxLoop.Text = "FxLoop NO detectado";
                btn_Amp.Enabled = false; lbl_Amp.Text = "Amp NO detectado";
                btn_Cab.Enabled = false; lbl_Cab.Text = "Cab NO detectado";
                btn_Eq.Enabled = false; lbl_Eq.Text = "Eq NO detectado";

                if (BlockPedalVol > -1)
                {
                    lbl_PedalVol.Text = "Pedal Vol. detectado";
                    btn_PedalVol.Enabled = true;
                }
                if (BlockPedalWah > -1)
                {
                    lbl_PedalWah.Text = "Pedal Wah detectado";
                    btn_PedalWah.Enabled = true;
                }
                if (BlockFxLoop > -1)
                {
                    lbl_FxLoop.Text = "FxLoop detectado";
                    btn_FxLoop.Enabled = true;
                }
                if (BlockAmp > -1)
                {
                    lbl_Amp.Text = "Amp detectado";
                    btn_Amp.Enabled = true;
                }
                if (BlockCab > -1)
                {
                    lbl_Cab.Text = "Cab detectado";
                    btn_Cab.Enabled = true;
                }
                if (BlockEq > -1)
                {
                    lbl_Eq.Text = "Eq detectado";
                    btn_Eq.Enabled = true;
                }
                lbl_PresetAbierto.Text = "Preset seleccionado: " + preset_name;
                lbl_PedalVol.Visible = true; lbl_PedalVol.Enabled = true; btn_PedalVol.Visible = true;
                lbl_PedalWah.Visible = true; lbl_PedalWah.Enabled = true; btn_PedalWah.Visible = true;
                lbl_FxLoop.Visible = true; lbl_FxLoop.Enabled = true; btn_FxLoop.Visible = true;
                lbl_Amp.Visible = true; lbl_Amp.Enabled = true; btn_Amp.Visible = true;
                lbl_Cab.Visible = true; lbl_Cab.Enabled = true; btn_Cab.Visible = true;
                lbl_Eq.Visible = true; lbl_Eq.Enabled = true; btn_Eq.Visible = true;
            }
            else
            {
                btn_Guardar.Enabled = false;
                lbl_PresetAbierto.Text = "Ningún preset seleccionado.";
                lbl_PedalVol.Visible = false; lbl_PedalVol.Enabled = false; btn_PedalVol.Visible = false; btn_PedalVol.Enabled = false;
                lbl_PedalWah.Visible = false; lbl_PedalWah.Enabled = false; btn_PedalWah.Visible = false; btn_PedalWah.Enabled = false;
                lbl_FxLoop.Visible = false; lbl_FxLoop.Enabled = false; btn_FxLoop.Visible = false; btn_FxLoop.Enabled = false;
                lbl_Amp.Visible = false; lbl_Amp.Enabled = false; btn_Amp.Visible = false; btn_Amp.Enabled = false;
                lbl_Cab.Visible = false; lbl_Cab.Enabled = false; btn_Cab.Visible = false; btn_Cab.Enabled = false;
                lbl_Eq.Visible = false; lbl_Eq.Enabled = false; btn_Eq.Visible = false; btn_Eq.Enabled = false;
            }
        }

        private void ResetFile()
        {

            preset_name = null;
            json = null;
            BlockPedalVol = -1;
            BlockPedalWah = -1;
            BlockFxLoop = -1;
            BlockAmp = -1;
            BlockCab = -1;
            BlockEq = -1;
        }

        private void ResetBlocks()
        {

            BlockPedalVol = -1;
            BlockPedalWah = -1;
            BlockFxLoop = -1;
            BlockAmp = -1;
            BlockCab = -1;
            BlockEq = -1;
        }

        private void AnalisisJson()
        {
            ResetBlocks();
            // Comprobar si existe algún pedal asignado
            if (PathExists(json, "data.tone.controller.dsp0"))
            {



                for (int i = 0; i < json["data"]["tone"]["controller"]["dsp0"].Count(); i++) {
                    int block_number = GetBlockNumber(((JObject)json["data"]["tone"]["controller"]["dsp0"]).Properties().ElementAt(i).Name);
                    string block_name = ((JObject)json["data"]["tone"]["controller"]["dsp0"]).Properties().ElementAt(i).Name;
                    if (PathExists(json, "data.tone.controller.dsp0." + block_name + ".Pedal")){ 
                        for (int j = 0; j < ((JObject)json["data"]["tone"]["controller"]["dsp0"][block_name]["Pedal"]).Properties().Count(); j++) {
                            if (((JObject)json["data"]["tone"]["controller"]["dsp0"][block_name]["Pedal"]).Properties().ElementAt(j).Name.Contains("controller")) {
                                int valor = Convert.ToInt32(((JObject)json["data"]["tone"]["controller"]["dsp0"][block_name]["Pedal"]).Properties().ElementAt(j).Value);
                                if (valor == 1){
                                    BlockPedalWah = block_number;
                                    break;
    
                                }
                                if (valor == 2) {
                                    BlockPedalVol = block_number;
                                    break;
                                }
                            }
                        }
                    }
                }






                for (int i = 0; i < json["data"]["tone"]["dsp0"].Count(); i++)
                {
                    int block_number = GetBlockNumber(((JObject)json["data"]["tone"]["dsp0"]).Properties().ElementAt(i).Name);
                    string block_name = ((JObject)json["data"]["tone"]["dsp0"]).Properties().ElementAt(i).Name;
                    for (int j = 0; j < ((JObject)json["data"]["tone"]["dsp0"][block_name]).Properties().Count(); j++)
                    {
                        if (((JObject)json["data"]["tone"]["dsp0"][block_name]).Properties().ElementAt(j).Name.Contains("model"))
                        {
                            string modelo = ((JObject)json["data"]["tone"]["dsp0"][block_name]).Properties().ElementAt(j).Value.ToString();
                            if (modelo.Contains("HD2_FXLoop"))
                            {
                                BlockFxLoop = block_number;
                            }
                            else if (modelo.Contains("HD2_Amp"))
                            {
                                BlockAmp = block_number;
                            }
                            else if (modelo.Contains("HD2_Cab"))
                            {
                                BlockCab = block_number;
                            }
                            else if (modelo.Contains("HD2_EQ"))
                            {
                                BlockEq = block_number;
                            }
                        }
                    }
                }
            }
        }

        private bool CheckFile(string filename)
        {
            using (StreamReader r = new StreamReader(openFileDialog1.FileName))
            {
                string contenido = r.ReadToEnd();
                if ((!contenido.Contains("\"application\"")) || (!contenido.Contains("\"POD Go Edit\",")))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool PathExists(JObject obj, string path)
        {
            var tokens = obj.SelectTokens(path);
            return tokens.Any();
        }

        private int GetBlockNumber(string text)
        {

            if (text.Contains("block"))
            {
                return Convert.ToInt32(text.Substring("block".Length, 1));
            }
            else if (text.Contains("snapshot"))
            {
                return Convert.ToInt32(text.Substring("snapshot".Length, 1));
            }
            else
            {
                return -1;
            }
        }
    }
}
