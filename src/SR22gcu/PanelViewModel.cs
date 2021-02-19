using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media;
using XPlaneConnector;

namespace SR22gcu
{
    public class PanelViewModel : ViewModelBase
    {
        public Connector connector;

        protected void SendCommand(string text)
        {
            if (connector == null) return;
            connector.SendCommand(new XPlaneCommand(text, ""));
        }

        protected RelayCommand _HdgLeft;
        protected RelayCommand _HdgRight;
        protected RelayCommand _HdgSync;
        protected RelayCommand _CrsLeft;
        protected RelayCommand _CrsRight;
        protected RelayCommand _CrsCenter;
        protected RelayCommand _AltLeft;
        protected RelayCommand _AltRight;
        protected RelayCommand _AltSync;
        protected RelayCommand _FmsCursor12;
        protected RelayCommand _FmsInnerLeft;
        protected RelayCommand _FmsInnerRight;
        protected RelayCommand _FmsOuterLeft;
        protected RelayCommand _FmsOuterRight;
        protected RelayCommand _RangeLeft;
        protected RelayCommand _RangeRight;
        protected RelayCommand _Direct;
        protected RelayCommand _Fpl;
        protected RelayCommand _Clr;
        protected RelayCommand _Menu;
        protected RelayCommand _Proc;
        protected RelayCommand _Ent;
        protected RelayCommand _Fms;
        protected RelayCommand _Com;
        protected RelayCommand _Flip;
        protected RelayCommand _Xpdr;
        protected RelayCommand _Nav;
        protected RelayCommand _Keyboard_A;
        protected RelayCommand _Keyboard_B;
        protected RelayCommand _Keyboard_C;
        protected RelayCommand _Keyboard_D;
        protected RelayCommand _Keyboard_E;
        protected RelayCommand _Keyboard_F;
        protected RelayCommand _Keyboard_G;
        protected RelayCommand _Keyboard_H;
        protected RelayCommand _Keyboard_I;
        protected RelayCommand _Keyboard_J;
        protected RelayCommand _Keyboard_K;
        protected RelayCommand _Keyboard_L;
        protected RelayCommand _Keyboard_M;
        protected RelayCommand _Keyboard_N;
        protected RelayCommand _Keyboard_O;
        protected RelayCommand _Keyboard_P;
        protected RelayCommand _Keyboard_Q;
        protected RelayCommand _Keyboard_R;
        protected RelayCommand _Keyboard_S;
        protected RelayCommand _Keyboard_T;
        protected RelayCommand _Keyboard_U;
        protected RelayCommand _Keyboard_V;
        protected RelayCommand _Keyboard_W;
        protected RelayCommand _Keyboard_X;
        protected RelayCommand _Keyboard_Y;
        protected RelayCommand _Keyboard_Z;
        protected RelayCommand _Keyboard_Space;
        protected RelayCommand _Keyboard_Bksp;
        protected RelayCommand _Keyboard_1;
        protected RelayCommand _Keyboard_4;
        protected RelayCommand _Keyboard_7;
        protected RelayCommand _Keyboard_Dot;
        protected RelayCommand _Keyboard_2;
        protected RelayCommand _Keyboard_5;
        protected RelayCommand _Keyboard_8;
        protected RelayCommand _Keyboard_0;
        protected RelayCommand _Keyboard_3;
        protected RelayCommand _Keyboard_6;
        protected RelayCommand _Keyboard_9;
        protected RelayCommand _Keyboard_PlusMinus;
        protected RelayCommand _AutoPilot_Hdg;
        protected RelayCommand _AutoPilot_Nav;
        protected RelayCommand _AutoPilot_Apr;
        protected RelayCommand _AutoPilot_Ap;
        protected RelayCommand _AutoPilot_Fd;
        protected RelayCommand _AutoPilot_Lvl;
        protected RelayCommand _AutoPilot_Yd;
        protected RelayCommand _AutoPilot_Up;
        protected RelayCommand _AutoPilot_Dn;
        protected RelayCommand _AutoPilot_Ias;
        protected RelayCommand _AutoPilot_Vs;
        protected RelayCommand _AutoPilot_Alt;
        protected RelayCommand _AutoPilot_Vnv;
        protected RelayCommand _Audio_Com1;
        protected RelayCommand _Audio_Mic1;
        protected RelayCommand _Audio_Com2;
        protected RelayCommand _Audio_Mic2;
        protected RelayCommand _Audio_Nav1;
        protected RelayCommand _Audio_Nav2;

        ///
        public RelayCommand HdgLeft => _HdgLeft ?? (_HdgLeft = new RelayCommand(() => SendCommand("sim/GPS/gcu478/hdg_down"), () => true));
        public RelayCommand HdgRight => _HdgRight ?? (_HdgRight = new RelayCommand(() => SendCommand("sim/GPS/gcu478/hdg_up"), () => true));
        public RelayCommand HdgSync => _HdgSync ?? (_HdgSync = new RelayCommand(() => SendCommand("sim/GPS/gcu478/hdg_sync"), () => true));
        public RelayCommand CrsLeft => _CrsLeft ?? (_CrsLeft = new RelayCommand(() => SendCommand("sim/GPS/gcu478/crs_up"), () => true));
        public RelayCommand CrsRight => _CrsRight ?? (_CrsRight = new RelayCommand(() => SendCommand("sim/GPS/gcu478/crs_down"), () => true));
        public RelayCommand CrsCenter => _CrsCenter ?? (_CrsCenter = new RelayCommand(() => SendCommand("sim/GPS/gcu478/crs_sync"), () => true));
        public RelayCommand AltLeft => _AltLeft ?? (_AltLeft = new RelayCommand(() => SendCommand("sim/GPS/gcu478/alt_down"), () => true));
        public RelayCommand AltRight => _AltRight ?? (_AltRight = new RelayCommand(() => SendCommand("sim/GPS/gcu478/alt_up"), () => true));
        public RelayCommand AltSync => _AltSync ?? (_AltSync = new RelayCommand(() => SendCommand("sim/GPS/gcu478/alt_sync"), () => true));
        public RelayCommand FmsCursor12 => _FmsCursor12 ?? (_FmsCursor12 = new RelayCommand(() => SendCommand("sim/GPS/gcu478/cursor"), () => true));
        public RelayCommand FmsInnerLeft => _FmsInnerLeft ?? (_FmsInnerLeft = new RelayCommand(() => SendCommand("sim/GPS/gcu478/inner_down"), () => true));
        public RelayCommand FmsInnerRight => _FmsInnerRight ?? (_FmsInnerRight = new RelayCommand(() => SendCommand("sim/GPS/gcu478/inner_up"), () => true));
        public RelayCommand FmsOuterLeft => _FmsOuterLeft ?? (_FmsOuterLeft = new RelayCommand(() => SendCommand("sim/GPS/gcu478/outer_down"), () => true));
        public RelayCommand FmsOuterRight => _FmsOuterRight ?? (_FmsOuterRight = new RelayCommand(() => SendCommand("sim/GPS/gcu478/outer_up"), () => true));
        public RelayCommand RangeLeft => _RangeLeft ?? (_RangeLeft = new RelayCommand(() => SendCommand("sim/GPS/gcu478/range_down"), () => true));
        public RelayCommand RangeRight => _RangeRight ?? (_RangeRight = new RelayCommand(() => SendCommand("sim/GPS/gcu478/range_up"), () => true));
        public RelayCommand Direct => _Direct ?? (_Direct = new RelayCommand(() => SendCommand("sim/GPS/gcu478/direct"), () => true));
        public RelayCommand Fpl => _Fpl ?? (_Fpl = new RelayCommand(() => SendCommand("sim/GPS/gcu478/fpl"), () => true));
        public RelayCommand Clr => _Clr ?? (_Clr = new RelayCommand(() => SendCommand("sim/GPS/gcu478/clr"), () => true));
        public RelayCommand Menu => _Menu ?? (_Menu = new RelayCommand(() => SendCommand("sim/GPS/gcu478/menu"), () => true));
        public RelayCommand Proc => _Proc ?? (_Proc = new RelayCommand(() => SendCommand("sim/GPS/gcu478/proc"), () => true));
        public RelayCommand Ent => _Ent ?? (_Ent = new RelayCommand(() => SendCommand("sim/GPS/gcu478/ent"), () => true));
        public RelayCommand Fms => _Fms ?? (_Fms = new RelayCommand(() => SendCommand("sim/GPS/gcu478/fms"), () => true));
        public RelayCommand Com => _Com ?? (_Com = new RelayCommand(() => SendCommand("sim/GPS/gcu478/com"), () => true));
        public RelayCommand Flip => _Flip ?? (_Flip = new RelayCommand(() => SendCommand("sim/GPS/gcu478/ff"), () => true));
        public RelayCommand Xpdr => _Xpdr ?? (_Xpdr = new RelayCommand(() => SendCommand("sim/GPS/gcu478/xpdr"), () => true));
        public RelayCommand Nav => _Nav ?? (_Nav = new RelayCommand(() => SendCommand("sim/GPS/gcu478/nav"), () => true));
        public RelayCommand Keyboard_A => _Keyboard_A ?? (_Keyboard_A = new RelayCommand(() => SendCommand(CharCommand('a')), () => true));
        public RelayCommand Keyboard_B => _Keyboard_B ?? (_Keyboard_B = new RelayCommand(() => SendCommand(CharCommand('b')), () => true));
        public RelayCommand Keyboard_C => _Keyboard_C ?? (_Keyboard_C = new RelayCommand(() => SendCommand(CharCommand('c')), () => true));
        public RelayCommand Keyboard_D => _Keyboard_D ?? (_Keyboard_D = new RelayCommand(() => SendCommand(CharCommand('d')), () => true));
        public RelayCommand Keyboard_E => _Keyboard_E ?? (_Keyboard_E = new RelayCommand(() => SendCommand(CharCommand('e')), () => true));
        public RelayCommand Keyboard_F => _Keyboard_F ?? (_Keyboard_F = new RelayCommand(() => SendCommand(CharCommand('f')), () => true));
        public RelayCommand Keyboard_G => _Keyboard_G ?? (_Keyboard_G = new RelayCommand(() => SendCommand(CharCommand('g')), () => true));
        public RelayCommand Keyboard_H => _Keyboard_H ?? (_Keyboard_H = new RelayCommand(() => SendCommand(CharCommand('h')), () => true));
        public RelayCommand Keyboard_I => _Keyboard_I ?? (_Keyboard_I = new RelayCommand(() => SendCommand(CharCommand('i')), () => true));
        public RelayCommand Keyboard_J => _Keyboard_J ?? (_Keyboard_J = new RelayCommand(() => SendCommand(CharCommand('j')), () => true));
        public RelayCommand Keyboard_K => _Keyboard_K ?? (_Keyboard_K = new RelayCommand(() => SendCommand(CharCommand('k')), () => true));
        public RelayCommand Keyboard_L => _Keyboard_L ?? (_Keyboard_L = new RelayCommand(() => SendCommand(CharCommand('l')), () => true));
        public RelayCommand Keyboard_M => _Keyboard_M ?? (_Keyboard_M = new RelayCommand(() => SendCommand(CharCommand('m')), () => true));
        public RelayCommand Keyboard_N => _Keyboard_N ?? (_Keyboard_N = new RelayCommand(() => SendCommand(CharCommand('n')), () => true));
        public RelayCommand Keyboard_O => _Keyboard_O ?? (_Keyboard_O = new RelayCommand(() => SendCommand(CharCommand('o')), () => true));
        public RelayCommand Keyboard_P => _Keyboard_P ?? (_Keyboard_P = new RelayCommand(() => SendCommand(CharCommand('p')), () => true));
        public RelayCommand Keyboard_Q => _Keyboard_Q ?? (_Keyboard_Q = new RelayCommand(() => SendCommand(CharCommand('q')), () => true));
        public RelayCommand Keyboard_R => _Keyboard_R ?? (_Keyboard_R = new RelayCommand(() => SendCommand(CharCommand('r')), () => true));
        public RelayCommand Keyboard_S => _Keyboard_S ?? (_Keyboard_S = new RelayCommand(() => SendCommand(CharCommand('s')), () => true));
        public RelayCommand Keyboard_T => _Keyboard_T ?? (_Keyboard_T = new RelayCommand(() => SendCommand(CharCommand('t')), () => true));
        public RelayCommand Keyboard_U => _Keyboard_U ?? (_Keyboard_U = new RelayCommand(() => SendCommand(CharCommand('u')), () => true));
        public RelayCommand Keyboard_V => _Keyboard_V ?? (_Keyboard_V = new RelayCommand(() => SendCommand(CharCommand('v')), () => true));
        public RelayCommand Keyboard_W => _Keyboard_W ?? (_Keyboard_W = new RelayCommand(() => SendCommand(CharCommand('w')), () => true));
        public RelayCommand Keyboard_X => _Keyboard_X ?? (_Keyboard_X = new RelayCommand(() => SendCommand(CharCommand('x')), () => true));
        public RelayCommand Keyboard_Y => _Keyboard_Y ?? (_Keyboard_Y = new RelayCommand(() => SendCommand(CharCommand('y')), () => true));
        public RelayCommand Keyboard_Z => _Keyboard_Z ?? (_Keyboard_Z = new RelayCommand(() => SendCommand(CharCommand('z')), () => true));
        public RelayCommand Keyboard_Space => _Keyboard_Space ?? (_Keyboard_Space = new RelayCommand(() => SendCommand(CharCommand(' ')), () => true));
        public RelayCommand Keyboard_Bksp => _Keyboard_Bksp ?? (_Keyboard_Bksp = new RelayCommand(() => SendCommand("sim/GPS/gcu478/bksp"), () => true));
        public RelayCommand Keyboard_1 => _Keyboard_1 ?? (_Keyboard_1 = new RelayCommand(() => SendCommand(CharCommand('1')), () => true));
        public RelayCommand Keyboard_4 => _Keyboard_4 ?? (_Keyboard_4 = new RelayCommand(() => SendCommand(CharCommand('4')), () => true));
        public RelayCommand Keyboard_7 => _Keyboard_7 ?? (_Keyboard_7 = new RelayCommand(() => SendCommand(CharCommand('7')), () => true));
        public RelayCommand Keyboard_Dot => _Keyboard_Dot ?? (_Keyboard_Dot = new RelayCommand(() => SendCommand(CharCommand('.')), () => true));
        public RelayCommand Keyboard_2 => _Keyboard_2 ?? (_Keyboard_2 = new RelayCommand(() => SendCommand(CharCommand('2')), () => true));
        public RelayCommand Keyboard_5 => _Keyboard_5 ?? (_Keyboard_5 = new RelayCommand(() => SendCommand(CharCommand('5')), () => true));
        public RelayCommand Keyboard_8 => _Keyboard_8 ?? (_Keyboard_8 = new RelayCommand(() => SendCommand(CharCommand('8')), () => true));
        public RelayCommand Keyboard_0 => _Keyboard_0 ?? (_Keyboard_0 = new RelayCommand(() => SendCommand(CharCommand('0')), () => true));
        public RelayCommand Keyboard_3 => _Keyboard_3 ?? (_Keyboard_3 = new RelayCommand(() => SendCommand(CharCommand('3')), () => true));
        public RelayCommand Keyboard_6 => _Keyboard_6 ?? (_Keyboard_6 = new RelayCommand(() => SendCommand(CharCommand('6')), () => true));
        public RelayCommand Keyboard_9 => _Keyboard_9 ?? (_Keyboard_9 = new RelayCommand(() => SendCommand(CharCommand('9')), () => true));
        public RelayCommand Keyboard_PlusMinus => _Keyboard_PlusMinus ?? (_Keyboard_PlusMinus = new RelayCommand(() => SendCommand(CharCommand('-')), () => true));
        public RelayCommand AutoPilot_Hdg => _AutoPilot_Hdg ?? (_AutoPilot_Hdg = new RelayCommand(() => SendCommand("sim/autopilot/heading"), () => true));
        public RelayCommand AutoPilot_Nav => _AutoPilot_Nav ?? (_AutoPilot_Nav = new RelayCommand(() => SendCommand("sim/autopilot/NAV"), () => true));
        public RelayCommand AutoPilot_Apr => _AutoPilot_Apr ?? (_AutoPilot_Apr = new RelayCommand(() => SendCommand("sim/autopilot/approach"), () => true));
        public RelayCommand AutoPilot_Ap => _AutoPilot_Ap ?? (_AutoPilot_Ap = new RelayCommand(() => SendCommand("afm/sr/cmd/ap/ap"), () => true));
        public RelayCommand AutoPilot_Fd => _AutoPilot_Fd ?? (_AutoPilot_Fd = new RelayCommand(() => SendCommand("sim/autopilot/fdir_toggle"), () => true));
        public RelayCommand AutoPilot_Lvl => _AutoPilot_Lvl ?? (_AutoPilot_Lvl = new RelayCommand(() => SendCommand("afm/sr/cmd/ap/lvl"), () => true));
        public RelayCommand AutoPilot_Yd => _AutoPilot_Yd ?? (_AutoPilot_Yd = new RelayCommand(() => SendCommand(""), () => true)); // Missing
        public RelayCommand AutoPilot_Up => _AutoPilot_Up ?? (_AutoPilot_Up = new RelayCommand(() => SendCommand("sim/autopilot/altitude_up"), () => true));
        public RelayCommand AutoPilot_Dn => _AutoPilot_Dn ?? (_AutoPilot_Dn = new RelayCommand(() => SendCommand("sim/autopilot/altitude_down"), () => true));
        public RelayCommand AutoPilot_Ias => _AutoPilot_Ias ?? (_AutoPilot_Ias = new RelayCommand(() => SendCommand("sim/autopilot/level_change"), () => true));
        public RelayCommand AutoPilot_Vs => _AutoPilot_Vs ?? (_AutoPilot_Vs = new RelayCommand(() => SendCommand("sim/autopilot/vertical_speed"), () => true));
        public RelayCommand AutoPilot_Alt => _AutoPilot_Alt ?? (_AutoPilot_Alt = new RelayCommand(() => SendCommand("sim/autopilot/altitude_hold"), () => true));
        public RelayCommand AutoPilot_Vnv => _AutoPilot_Vnv ?? (_AutoPilot_Vnv = new RelayCommand(() => SendCommand("sim/autopilot/vnav"), () => true));
        public RelayCommand Audio_Com1 => _Audio_Com1 ?? (_Audio_Com1 = new RelayCommand(() => SendCommand("sim/audio_panel/monitor_audio_com1"), () => true));
        public RelayCommand Audio_Mic1 => _Audio_Mic1 ?? (_Audio_Mic1 = new RelayCommand(() => SendCommand("sim/audio_panel/transmit_audio_com1"), () => true));
        public RelayCommand Audio_Com2 => _Audio_Com2 ?? (_Audio_Com2 = new RelayCommand(() => SendCommand("sim/audio_panel/monitor_audio_com2"), () => true));
        public RelayCommand Audio_Mic2 => _Audio_Mic2 ?? (_Audio_Mic2 = new RelayCommand(() => SendCommand("sim/audio_panel/transmit_audio_com2"), () => true));
        public RelayCommand Audio_Nav1 => _Audio_Nav1 ?? (_Audio_Nav1 = new RelayCommand(() => SendCommand("sim/audio_panel/monitor_audio_nav1"), () => true));
        public RelayCommand Audio_Nav2 => _Audio_Nav2 ?? (_Audio_Nav2 = new RelayCommand(() => SendCommand("sim/audio_panel/monitor_audio_nav2"), () => true));

        public string CharCommand(char c)
        {
            switch (char.ToUpper(c))
            {
                case 'A': return "sim/GPS/gcu478/A";
                case 'B': return "sim/GPS/gcu478/B";
                case 'C': return "sim/GPS/gcu478/C";
                case 'D': return "sim/GPS/gcu478/D";
                case 'E': return "sim/GPS/gcu478/E";
                case 'F': return "sim/GPS/gcu478/F";
                case 'G': return "sim/GPS/gcu478/G";
                case 'H': return "sim/GPS/gcu478/H";
                case 'I': return "sim/GPS/gcu478/I";
                case 'J': return "sim/GPS/gcu478/J";
                case 'K': return "sim/GPS/gcu478/K";
                case 'L': return "sim/GPS/gcu478/L";
                case 'M': return "sim/GPS/gcu478/M";
                case 'N': return "sim/GPS/gcu478/N";
                case 'O': return "sim/GPS/gcu478/O";
                case 'P': return "sim/GPS/gcu478/P";
                case 'Q': return "sim/GPS/gcu478/Q";
                case 'R': return "sim/GPS/gcu478/R";
                case 'S': return "sim/GPS/gcu478/S";
                case 'T': return "sim/GPS/gcu478/T";
                case 'U': return "sim/GPS/gcu478/U";
                case 'V': return "sim/GPS/gcu478/V";
                case 'W': return "sim/GPS/gcu478/W";
                case 'X': return "sim/GPS/gcu478/X";
                case 'Y': return "sim/GPS/gcu478/Y";
                case 'Z': return "sim/GPS/gcu478/Z";
                case ' ': return "sim/GPS/gcu478/spc";
                case '.': return "sim/GPS/gcu478/dot";
                case '-': return "sim/GPS/gcu478/minus";
                case '1': return "sim/GPS/gcu478/1";
                case '2': return "sim/GPS/gcu478/2";
                case '3': return "sim/GPS/gcu478/3";
                case '4': return "sim/GPS/gcu478/4";
                case '5': return "sim/GPS/gcu478/5";
                case '6': return "sim/GPS/gcu478/6";
                case '7': return "sim/GPS/gcu478/7";
                case '8': return "sim/GPS/gcu478/8";
                case '9': return "sim/GPS/gcu478/9";
                case '0': return "sim/GPS/gcu478/0";
            }
            return null;
        }

        public void Subscribe(string dataRef, Action<DataRefElement, float> action)
        {
            connector.Subscribe(new DataRefElement()
            {
                DataRef = dataRef,
                Units = "boolean",
                Description = "The light",
                Frequency = 5
            },
            onchange: action);
        }

        public Brush TransparentBrush;
        public Brush WhiteBrush;
        public Brush LedValue(float value) => value > 0.5 ? WhiteBrush : TransparentBrush;

        public Brush _FmsLed;
        public Brush _ComLed;
        public Brush _XpdrLed;
        public Brush _NavLed;
        public Brush _AutopilotHdgLed;
        public Brush _AutopilotNavLed;
        public Brush _AutopilotAprLed;
        public Brush _AutopilotApLed;
        public Brush _AutopilotFdLed;
        public Brush _AutopilotLvlLed;
        public Brush _AutopilotYdLed;
        public Brush _AutopilotIasLed;
        public Brush _AutopilotVsLed;
        public Brush _AutopilotAltLed;
        public Brush _AutopilotVnvLed;
        public Brush _Com1Led;
        public Brush _Mic1Led;
        public Brush _Com2Led;
        public Brush _Mic2Led;
        public Brush _Nav1Led;
        public Brush _Nav2Led;

        public Brush FmsLed { get => _FmsLed; set => Set(nameof(FmsLed), ref _FmsLed, value); }
        public Brush ComLed { get => _ComLed; set => Set(nameof(ComLed), ref _ComLed, value); }
        public Brush XpdrLed { get => _XpdrLed; set => Set(nameof(XpdrLed), ref _XpdrLed, value); }
        public Brush NavLed { get => _NavLed; set => Set(nameof(NavLed), ref _NavLed, value); }
        public Brush AutopilotHdgLed { get => _AutopilotHdgLed; set => Set(nameof(AutopilotHdgLed), ref _AutopilotHdgLed, value); }
        public Brush AutopilotNavLed { get => _AutopilotNavLed; set => Set(nameof(AutopilotNavLed), ref _AutopilotNavLed, value); }
        public Brush AutopilotAprLed { get => _AutopilotAprLed; set => Set(nameof(AutopilotAprLed), ref _AutopilotAprLed, value); }
        public Brush AutopilotApLed { get => _AutopilotApLed; set => Set(nameof(AutopilotApLed), ref _AutopilotApLed, value); }
        public Brush AutopilotFdLed { get => _AutopilotFdLed; set => Set(nameof(AutopilotFdLed), ref _AutopilotFdLed, value); }
        public Brush AutopilotLvlLed { get => _AutopilotLvlLed; set => Set(nameof(AutopilotLvlLed), ref _AutopilotLvlLed, value); }
        public Brush AutopilotYdLed { get => _AutopilotYdLed; set => Set(nameof(AutopilotYdLed), ref _AutopilotYdLed, value); }
        public Brush AutopilotIasLed { get => _AutopilotIasLed; set => Set(nameof(AutopilotIasLed), ref _AutopilotIasLed, value); }
        public Brush AutopilotVsLed { get => _AutopilotVsLed; set => Set(nameof(AutopilotVsLed), ref _AutopilotVsLed, value); }
        public Brush AutopilotAltLed { get => _AutopilotAltLed; set => Set(nameof(AutopilotAltLed), ref _AutopilotAltLed, value); }
        public Brush AutopilotVnvLed { get => _AutopilotVnvLed; set => Set(nameof(AutopilotVnvLed), ref _AutopilotVnvLed, value); }
        public Brush Com1Led { get => _Com1Led; set => Set(nameof(Com1Led), ref _Com1Led, value); }
        public Brush Mic1Led { get => _Mic1Led; set => Set(nameof(Mic1Led), ref _Mic1Led, value); }
        public Brush Com2Led { get => _Com2Led; set => Set(nameof(Com2Led), ref _Com2Led, value); }
        public Brush Mic2Led { get => _Mic2Led; set => Set(nameof(Mic2Led), ref _Mic2Led, value); }
        public Brush Nav1Led { get => _Nav1Led; set => Set(nameof(Nav1Led), ref _Nav1Led, value); }
        public Brush Nav2Led { get => _Nav2Led; set => Set(nameof(Nav2Led), ref _Nav2Led, value); }

        public PanelViewModel()
        {
            TransparentBrush = new SolidColorBrush(Colors.Transparent);
            WhiteBrush = new SolidColorBrush(Colors.White);

            _FmsLed = TransparentBrush;
            _ComLed = TransparentBrush;
            _XpdrLed = TransparentBrush;
            _NavLed = TransparentBrush;
            _AutopilotHdgLed = TransparentBrush;
            _AutopilotNavLed = TransparentBrush;
            _AutopilotAprLed = TransparentBrush;
            _AutopilotApLed = TransparentBrush;
            _AutopilotFdLed = TransparentBrush;
            _AutopilotLvlLed = TransparentBrush;
            _AutopilotYdLed = TransparentBrush;
            _AutopilotIasLed = TransparentBrush;
            _AutopilotVsLed = TransparentBrush;
            _AutopilotAltLed = TransparentBrush;
            _AutopilotVnvLed = TransparentBrush;
            _Com1Led = TransparentBrush;
            _Mic1Led = TransparentBrush;
            _Com2Led = TransparentBrush;
            _Mic2Led = TransparentBrush;
            _Nav1Led = TransparentBrush;
            _Nav2Led = TransparentBrush;
        }
    }
}
