using AudioController;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Un4seen.Bass;

namespace PitchAndShiftAudio
{

    public partial class UserControlEffectsPanel : UserControl
    {        
        public UserControlEffectsPanel()
        {
            InitializeComponent();
        }

        private enum FX { DISTORTION, CHORUS, FLANGER, ECHO, REVERB  };

        //Dictionary<FX, string> dictListEffects = new Dictionary<FX, string>();                
        List<KeyValuePair<FX, string>> dictListEffects = new List<KeyValuePair<FX, string>>();
        
        private void UserControlEffectsPanel_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> dictComboBoxWaveform = new Dictionary<int, string>();
            Dictionary<BASSFXPhase, string> dictComboBoxPhase = new Dictionary<BASSFXPhase, string>();
            Dictionary<bool, string> dictComboBoxPanDelay = new Dictionary<bool, string>();            

            // comboBoxWaveform
            dictComboBoxWaveform.Add(1, "triangle");
            dictComboBoxWaveform.Add(2, "sine");

            comboBoxWaveform.DataSource = new BindingSource(dictComboBoxWaveform, null);
            comboBoxWaveform.DisplayMember = "Value";
            comboBoxWaveform.ValueMember = "Key";

            // comboBoxWaveformFlanger
            comboBoxWaveformFlanger.DataSource = new BindingSource(dictComboBoxWaveform, null);
            comboBoxWaveformFlanger.DisplayMember = "Value";
            comboBoxWaveformFlanger.ValueMember = "Key";

            // comboBoxPhase
            dictComboBoxPhase.Add(BASSFXPhase.BASS_FX_PHASE_NEG_180, "-180");
            dictComboBoxPhase.Add(BASSFXPhase.BASS_FX_PHASE_NEG_90, "-90");
            dictComboBoxPhase.Add(BASSFXPhase.BASS_FX_PHASE_ZERO, "+/-0");
            dictComboBoxPhase.Add(BASSFXPhase.BASS_FX_PHASE_90, "+90");
            dictComboBoxPhase.Add(BASSFXPhase.BASS_FX_PHASE_180, "+180");

            comboBoxPhase.DataSource = new BindingSource(dictComboBoxPhase, null);
            comboBoxPhase.DisplayMember = "Value";
            comboBoxPhase.ValueMember = "Key";

            comboBoxPhase.SelectedValue = BASSFXPhase.BASS_FX_PHASE_ZERO;

            // comboBoxPhaseFlanger
            comboBoxPhaseFlanger.DataSource = new BindingSource(dictComboBoxPhase, null);
            comboBoxPhaseFlanger.DisplayMember = "Value";
            comboBoxPhaseFlanger.ValueMember = "Key";

            comboBoxPhaseFlanger.SelectedValue = BASSFXPhase.BASS_FX_PHASE_ZERO;

            // dictComboBoxPanDelay
            dictComboBoxPanDelay.Add(false, "Disabled");
            dictComboBoxPanDelay.Add(true, "Enabled");

            this.comboBoxPanDelay.DataSource = new BindingSource(dictComboBoxPanDelay, null);
            this.comboBoxPanDelay.DisplayMember = "Value";
            this.comboBoxPanDelay.ValueMember = "Key";


            // listEffects
            //dictListEffects.Add(FX.CHORUS, FX.CHORUS.ToString());
            //dictListEffects.Add(FX.ECHO, FX.ECHO.ToString());
            //dictListEffects.Add(FX.REVERB, FX.REVERB.ToString());
            foreach (FX fx in Enum.GetValues(typeof(FX)))
            {
                dictListEffects.Add(new KeyValuePair<FX, string>(fx, fx.ToString()));
            }

            this.listBoxEffects.DataSource = new BindingSource(dictListEffects, null);
            this.listBoxEffects.DisplayMember = "Value";
            this.listBoxEffects.ValueMember = "Key";

            AddEventOnChanges(this.tabPageDistortion, new EffectChanged(EventDistortionChanged));
            AddEventOnChanges(this.tabPageChorus, new EffectChanged(EventChorusChanged));
            AddEventOnChanges(this.tabPageFlanger, new EffectChanged(EventFlangerChanged));
            AddEventOnChanges(this.tabPageReverb, new EffectChanged(EventReverbChanged));
            AddEventOnChanges(this.tabPageEcho, new EffectChanged(EventEchoChanged));            
        }

        private void AddEventOnChanges(Control obj, EffectChanged delEffectChanged)
        {
            foreach (Control control in obj.Controls)
            {
                Type objType = control.GetType();

                if (objType == typeof(UserControlTrackBar) || objType.BaseType == typeof(UserControlTrackBar))
                {
                    ((UserControlTrackBar)control).TrackBarScroll += new EventHandler(delEffectChanged);
                }
                else if (objType == typeof(ComboBox))
                {
                    ((ComboBox)control).SelectedValueChanged += new EventHandler(delEffectChanged);
                }

                if (control.Controls.Count > 0)
                    AddEventOnChanges(control, delEffectChanged);
            }
        }

        public void UpdateModuleTab(bool isModule)
        {
            this.listBoxChannels.Items.Clear();

            if (isModule)
            {
                if (tabControlEffects.TabPages.Contains(tabPageModules) == false)
                    tabControlEffects.TabPages.Add(tabPageModules);
                int channels = 0;
                float dummy = 0;
                while (Bass.BASS_ChannelGetAttribute(AudioPlayer.Instance.CurrentAudioHandle.Handle, (BASSAttribute)((int)BASSAttribute.BASS_ATTRIB_MUSIC_VOL_CHAN + channels), ref dummy))
                {
                    this.listBoxChannels.Items.Add((channels+1).ToString());
                    channels++;
                }
            }
            else
            {
                if (tabControlEffects.TabPages.Contains(tabPageModules))
                    tabControlEffects.TabPages.Remove(tabPageModules);
            }
        }

        public void EventDistortionChanged(object sender, EventArgs e)
        {

            SetDistortion(AudioPlayer.Instance.CurrentAudioHandle);

        }

        public void EventChorusChanged(object sender, EventArgs e)
        {
            SetChorus(AudioPlayer.Instance.CurrentAudioHandle);
        }

        public void EventFlangerChanged(object sender, EventArgs e)
        {
            SetFlanger(AudioPlayer.Instance.CurrentAudioHandle);

        }

        public void EventEchoChanged(object sender, EventArgs e)
        {

            SetEcho(AudioPlayer.Instance.CurrentAudioHandle);
            
        }


        public void EventReverbChanged(object sender, EventArgs e)
        {

            SetReverb(AudioPlayer.Instance.CurrentAudioHandle);

        }


        private void SetEcho(AudioHandle audioController)
        {
            bool panDelay = ((KeyValuePair<bool, string>)GetSelectedComboItem(comboBoxPanDelay)).Key;

            audioController.SetEchoFX((float)GetValueUserControl(usrCntWetDryMixEcho), 
                (float)GetValueUserControl(usrCntFeedbackEcho),
                (float)GetValueUserControl(usrCntLeftDelay), (float)GetValueUserControl(usrCntRightDelay), panDelay);
        }


        private void SetDistortion(AudioHandle audioController)
        {
            audioController.SetDistortionFX((float)GetValueUserControl(usrCntGainDist),
                (float)GetValueUserControl(usrCntEdge),
                (float)GetValueUserControl(usrCntPostEQBandwidth), (float)GetValueUserControl(usrCntPostEQCenterFrequency),
                (float)GetValueUserControl(usrCntPreLowpassCutoff));
        }

        private void SetChorus(AudioHandle audioController)
        {
            int waveForm = ((KeyValuePair<int, string>)GetSelectedComboItem(comboBoxWaveform)).Key;
            BASSFXPhase phase = ((KeyValuePair<BASSFXPhase, string>)GetSelectedComboItem(comboBoxPhase)).Key;

            audioController.SetChorusFX((float)GetValueUserControl(usrCntWetDryMix),
                (float)GetValueUserControl(usrCntDepth), (float)GetValueUserControl(usrCntFeedback),
                (float)GetValueUserControl(usrCntFrequency), waveForm, (float)GetValueUserControl(usrCntDelay), phase);
        }


        private void SetFlanger(AudioHandle audioController)
        {
            int waveForm = ((KeyValuePair<int, string>)GetSelectedComboItem(comboBoxWaveformFlanger)).Key;
            BASSFXPhase phase = ((KeyValuePair<BASSFXPhase, string>)GetSelectedComboItem(comboBoxPhaseFlanger)).Key;

            audioController.SetFlangerFX((float)GetValueUserControl(usrCntWetDryMixFlanger),
                (float)GetValueUserControl(usrCntDepthFlanger), (float)GetValueUserControl(usrCntFeedbackFlanger),
                (float)GetValueUserControl(usrCntFrequencyFlanger), waveForm, (float)GetValueUserControl(usrCntDelayFlanger), phase);
        }

        private void SetReverb(AudioHandle audioController)
        {
            audioController.SetReverbFX((float)GetValueUserControl(usrCntInGain),
                (float)GetValueUserControl(usrCntReverbMix), (float)GetValueUserControl(usrCntRevTime),
                (float)GetValueUserControl(usrCntHighFreqRatio));
        }


        // thread safe operation
        public void InjectFX(AudioHandle audioController)
        {
            SetDistortion(audioController);
            SetChorus(audioController);
            SetFlanger(audioController);
            SetEcho(audioController);
            SetReverb(audioController);

            audioController.ToggleDistortion(checkBoxDistortion.Checked, GetFXPriorityInList(FX.DISTORTION));
            audioController.ToggleChorus(checkBoxChorus.Checked, GetFXPriorityInList(FX.CHORUS));
            audioController.ToggleFlanger(checkBoxFlanger.Checked, GetFXPriorityInList(FX.FLANGER));
            audioController.ToggleEcho(checkBoxEcho.Checked, GetFXPriorityInList(FX.ECHO));
            audioController.ToggleReverb(checkBoxReverb.Checked, GetFXPriorityInList(FX.REVERB));
        }

        


        public delegate void EffectChanged(object sender, EventArgs e);

        private void checkBoxChorus_CheckedChanged(object sender, EventArgs e)
        {
            bool isChorusChecked = ((CheckBox)sender).Checked;

            AudioPlayer.Instance.CurrentAudioHandle.ToggleChorus(isChorusChecked, GetFXPriorityInList(FX.CHORUS));

            UpdateEffectPanel( this.labelChorusEnabled, isChorusChecked );
        }



        private void checkBoxReverb_CheckedChanged(object sender, EventArgs e)
        {
            bool isReverbChecked = ((CheckBox)sender).Checked;

            AudioPlayer.Instance.CurrentAudioHandle.ToggleReverb(isReverbChecked, GetFXPriorityInList(FX.REVERB));

            UpdateEffectPanel(this.labelReverbEnabled, isReverbChecked);
        }


        private void UpdateEffectPanel(LinkLabel label, bool isActive)
        {
            label.Text = isActive ? "ON" : "OFF";
            label.ForeColor = isActive ? Color.Green : Color.Red;
            label.LinkColor = isActive ? Color.Green : Color.Red;
        }

        private void checkBoxEcho_CheckedChanged(object sender, EventArgs e)
        {
            bool isEchoChecked = ((CheckBox)sender).Checked;

            AudioPlayer.Instance.CurrentAudioHandle.ToggleEcho(isEchoChecked, GetFXPriorityInList(FX.ECHO));

            UpdateEffectPanel(this.labelEchoEnabled, isEchoChecked);
        }






        // thread safe operation for combobox
        private delegate object DelGetComoboItem(ComboBox combobox);

        private object GetSelectedComboItem(ComboBox combobox)
        {
            if (combobox.InvokeRequired)
            {
                DelGetComoboItem gci = new DelGetComoboItem(GetSelectedComboItem);
                return combobox.Invoke(gci, combobox);
            }
            else
                return combobox.SelectedItem;
        }


        // thread safe operation for userControl
        private delegate double DelGetValueUserControl(UserControlTrackBar usrCnt);

        private double GetValueUserControl(UserControlTrackBar usrCnt)
        {
            if (usrCnt.InvokeRequired)
            {
                DelGetValueUserControl gci = new DelGetValueUserControl(GetValueUserControl);
                return (double)usrCnt.Invoke(gci, usrCnt);
            }
            else
                return usrCnt.Value;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxEffects.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < (listBoxEffects.Items.Count - 1))
            {
                SwapListBoxEffects(selectedIndex, selectedIndex + 1);

                listBoxEffects.SelectedIndex = selectedIndex + 1;

                RefreshFXChains();
            }

            
        }


        private void buttonUp_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxEffects.SelectedIndex;

            if (selectedIndex > 0)
            {
                SwapListBoxEffects(selectedIndex, selectedIndex - 1);

                listBoxEffects.SelectedIndex = selectedIndex - 1;

                RefreshFXChains();
            }
            
        }


        private void RefreshFXChains()
        {
            if (checkBoxDistortion.Checked)
            {
                AudioPlayer.Instance.CurrentAudioHandle.ToggleDistortion(false);
                AudioPlayer.Instance.CurrentAudioHandle.ToggleDistortion(true, GetFXPriorityInList(FX.DISTORTION));
            }
            if (checkBoxChorus.Checked)
            {
                AudioPlayer.Instance.CurrentAudioHandle.ToggleChorus(false);
                AudioPlayer.Instance.CurrentAudioHandle.ToggleChorus(true, GetFXPriorityInList(FX.CHORUS));
            }
            if (checkBoxFlanger.Checked)
            {
                AudioPlayer.Instance.CurrentAudioHandle.ToggleFlanger(false);
                AudioPlayer.Instance.CurrentAudioHandle.ToggleFlanger(true, GetFXPriorityInList(FX.FLANGER));
            }
            if (checkBoxEcho.Checked)
            {
                AudioPlayer.Instance.CurrentAudioHandle.ToggleEcho(false);
                AudioPlayer.Instance.CurrentAudioHandle.ToggleEcho(true, GetFXPriorityInList(FX.ECHO));
            }
            if (checkBoxReverb.Checked)
            {
                AudioPlayer.Instance.CurrentAudioHandle.ToggleReverb(false);
                AudioPlayer.Instance.CurrentAudioHandle.ToggleReverb(true, GetFXPriorityInList(FX.REVERB));
            }
        }

        private int GetFXPriorityInList(FX fx)
        {
            int index = -(dictListEffects.FindIndex(o => o.Key == fx));

            int fxCount = dictListEffects.Count;

            return index + fxCount;
        }

        private void SwapListBoxEffects(int indexA, int indexB)
        {
            object tmp = dictListEffects[indexA];

            dictListEffects[indexA] = dictListEffects[indexB];
            dictListEffects[indexB] = (KeyValuePair<FX, string>)tmp;

            this.listBoxEffects.DataSource = new BindingSource(dictListEffects, null);
            this.listBoxEffects.DisplayMember = "Value";
            this.listBoxEffects.ValueMember = "Key";
        }

        private void checkBoxDistortion_CheckedChanged(object sender, EventArgs e)
        {
            bool isDistortionChecked = ((CheckBox)sender).Checked;

            AudioPlayer.Instance.CurrentAudioHandle.ToggleDistortion(isDistortionChecked, GetFXPriorityInList(FX.DISTORTION));

            UpdateEffectPanel(this.labelDistortionEnabled, isDistortionChecked);
        }

        private void checkBoxFlanger_CheckedChanged(object sender, EventArgs e)
        {
            bool isFlangerChecked = ((CheckBox)sender).Checked;

            AudioPlayer.Instance.CurrentAudioHandle.ToggleFlanger(isFlangerChecked, GetFXPriorityInList(FX.FLANGER));

            UpdateEffectPanel(this.labelFlangerEnabled, isFlangerChecked);
        }

        private void listBoxChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int inst = this.listBoxChannels.SelectedIndex;

            float value = 0;

            Bass.BASS_ChannelGetAttribute(AudioPlayer.Instance.CurrentAudioHandle.Handle, BASSAttribute.BASS_ATTRIB_MUSIC_VOL_CHAN + inst, ref value);

            this.usrCntVolInst.Value = value;
        }

        private void usrCntVolInst_TrackBarScroll(object sender, EventArgs e)
        {
            
        }

        private void usrCntVolInst_ValueChanged(object sender, EventArgs e)
        {
            int chan = this.listBoxChannels.SelectedIndex;

            float value = (float)this.usrCntVolInst.Value;

            Bass.BASS_ChannelSetAttribute(AudioPlayer.Instance.CurrentAudioHandle.Handle, BASSAttribute.BASS_ATTRIB_MUSIC_VOL_CHAN + chan, value);
        }

        private void linkLabelDistortion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool isDistortionChecked = checkBoxDistortion.Checked == false;

            checkBoxDistortion.Checked = isDistortionChecked;
        }

        private void labelChorusEnabled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool isChorusChecked = checkBoxChorus.Checked == false;

            checkBoxChorus.Checked = isChorusChecked;
        }

        private void labelFlangerEnabled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool isFlangerChecked = checkBoxFlanger.Checked == false;

            checkBoxFlanger.Checked = isFlangerChecked;
        }

        private void labelEchoEnabled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool isEchoChecked = checkBoxEcho.Checked == false;

            checkBoxEcho.Checked = isEchoChecked;
        }

        private void labelReverbEnabled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool isReverbChecked = checkBoxReverb.Checked == false;

            checkBoxReverb.Checked = isReverbChecked;
        }




    }
}
