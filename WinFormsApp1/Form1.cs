using Microsoft.Win32;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            main_();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Size = new Size(640, 300);
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Location = new Point(20, 60);
            listView1.Size = new Size(580, 180);
            listView1.Columns.Add(null, 250);
            listView1.Columns.Add(null, 310);
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            label1.Location = new Point(560, 20);
            label1.Font = new Font("dotum", 14);
            button1.Text = "all";
            button2.Text = "bank";
            button3.Text = "vaccine";
            button4.Text = "p2p";
            button5.Text = "delete";
            button6.Text = "open";
            button1.Location = new Point(20, 20);
            button2.Location = new Point(110, 20);
            button3.Location = new Point(200, 20);
            button4.Location = new Point(290, 20);
            button5.Location = new Point(380, 20);
            button6.Location = new Point(470, 20);
            /*
            2023. 11.
            net8 / visual studio 2022 ver 17.8
            상업적, 후원, 기부, 유료, 불펌 등등 금지 ( 문의 카톡darkholy0309 )
            http://blog.naver.com/akkril/30115018429
            */
        }

        void main_()
        {
            RegistryKey localmachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var opensubkey = localmachine.OpenSubKey("software\\microsoft\\windows nt\\currentversion");
            int currentbuild = Convert.ToInt32(opensubkey.GetValue("currentbuild"));
            if (currentbuild < 19045)
            {
                MessageBox.Show("windows update 22H2" + Environment.NewLine + "윈도우 업데이트 필요");
            }
            if (currentbuild == 22000)
            {
                MessageBox.Show("windows update 23H2" + Environment.NewLine + "윈도우 업데이트 필요");
            }
            if (currentbuild == 22621)
            {
                MessageBox.Show("windows update 23H2" + Environment.NewLine + "윈도우 업데이트 필요");
            }
            bank();
            bank_all_setup();
            bank_copy();
            hometax();
            vaccine();
            util();
            p2p();
            localmachine.Dispose();
            label1.Text = listView1.Items.Count + "개";
        }

        void bank()//list 10
        {
            string[] string_list = new string[2];
            RegistryKey localmachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var safe_transaction = localmachine.OpenSubKey("software\\ahnlab\\safe transaction");
            if (safe_transaction == null)
            { }
            else if (Directory.Exists(safe_transaction.GetValue("installpath").ToString()))
            {
                string_list[0] = safe_transaction.GetValue("productname").ToString();
                string_list[1] = safe_transaction.GetValue("installpath").ToString();
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string inisafe_web_ex_client = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\initech\\inisafe web ex client";
            if (Directory.Exists(inisafe_web_ex_client))
            {
                string_list[0] = "INISAFE CrossWeb EX";
                string_list[1] = inisafe_web_ex_client;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string crossex = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\iniline\\crossex\\crossex";
            if (File.Exists(crossex + "\\crossexservice.exe"))
            {
                string_list[0] = "iniLINE CrossEX Service";//touchen nxkey 32bit + keysharp
                string_list[1] = crossex;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string touchen_nxkey_x64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\raonsecure\\touchen nxkey";
            if (Directory.Exists(touchen_nxkey_x64))
            {
                string_list[0] = "TouchEn nxKey with E2E for 64bit";
                string_list[1] = touchen_nxkey_x64;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string anysign = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\softforum\\xecureweb\\anysign\\dll";
            if (File.Exists(anysign + "\\anysign4pc.exe"))
            {
                string_list[0] = "AnySign4PC";
                string_list[1] = anysign;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string nprotect_online_security = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\incainternet\\nprotect online security";
            if (Directory.Exists(nprotect_online_security))
            {
                string_list[0] = "nProtect Online Security";
                string_list[1] = nprotect_online_security;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string delfino_g3 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\wizvera\\delfino-g3";
            if (Directory.Exists(delfino_g3))
            {
                string_list[0] = "Delfino G3 (x86)";
                string_list[1] = delfino_g3;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string ipinside_lws = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ipinside_lws";
            if (File.Exists(ipinside_lws + "\\i3gproc.exe"))
            {
                string_list[0] = "IPinside LWS Agent";
                string_list[1] = ipinside_lws;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string vestcert = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\vestcert";
            if (File.Exists(vestcert + "\\vestcert.exe"))
            {
                string_list[0] = "VestCert";//2022 skb
                string_list[1] = vestcert;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string inisafe_web_client = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\initech\\inisafe web client v6.4";
            if (File.Exists(inisafe_web_client + "\\i3gex.exe"))
            {
                string_list[0] = "INISAFE Web v6.4";//2022 skb
                string_list[1] = inisafe_web_client;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            localmachine.Dispose();
        }

        void bank_all_setup()//list 3
        {
            string[] string_list = new string[2];
            string veraport20_x64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\wizvera\\veraport20";
            if (Directory.Exists(veraport20_x64))
            {
                string_list[0] = "Veraport(보안모듈 관리 프로그램) G3 x64";
                string_list[1] = veraport20_x64;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string veraport20 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\wizvera\\veraport20";
            if (Directory.Exists(veraport20))
            {
                string_list[0] = "Veraport(보안모듈 관리 프로그램) G3";
                string_list[1] = veraport20;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string wpmsvc = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\wizvera\\common\\wpmsvc";
            if (Directory.Exists(wpmsvc))
            {
                string_list[0] = "WIZVERA Process Manager";//veraport g3 x64
                string_list[1] = wpmsvc;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
        }

        void bank_copy()//list 3
        {
            string[] string_list = new string[2];
            string unisigncrsv3 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\crosscert\\unisigncrsv3";
            if (Directory.Exists(unisigncrsv3))
            {
                string_list[0] = "CROSSCERT UniCRSV3";//kb국민
                string_list[1] = unisigncrsv3;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string kscertrelay = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\keysharp\\kscertrelay";
            if (File.Exists(kscertrelay + "\\kscertrelay.exe"))
            {
                string_list[0] = "KeySharp CertRelay";//우리
                string_list[1] = kscertrelay;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string certloamingopen = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\btworks\\certloamingopen";
            if (File.Exists(certloamingopen + "\\btwcertloaming.exe"))
            {
                string_list[0] = "인증서 로밍 클라이언트 오픈뱅킹";//nh농협
                string_list[1] = certloamingopen;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
        }

        void hometax()//list 2
        {
            string[] string_list = new string[2];
            string touchen_nxfirewall = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\raonsecure\\touchen nxfirewall";
            if (Directory.Exists(touchen_nxfirewall))
            {
                string_list[0] = "TouchEn nxFirewall32";
                string_list[1] = touchen_nxfirewall;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string touchen_nxkey = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\raonsecure\\touchen nxkey";
            if (Directory.Exists(touchen_nxkey))
            {
                string_list[0] = "TouchEn nxKey with E2E for 32bit";
                string_list[1] = touchen_nxkey;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
        }

        void vaccine()//list 3
        {
            string[] string_list = new string[2];
            RegistryKey localmachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var alyac = localmachine.OpenSubKey("software\\estsoft\\alyac");
            if (alyac == null)
            { }
            else if (Directory.Exists(alyac.GetValue("rootdir").ToString()))
            {
                string_list[0] = alyac.GetValue("product").ToString();
                string_list[1] = alyac.GetValue("rootdir").ToString();
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            RegistryKey localmachine2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var v3lite4 = localmachine2.OpenSubKey("software\\ahnlab\\v3lite4");
            if (v3lite4 == null)
            { }
            else if (Directory.Exists(v3lite4.GetValue("installpath").ToString()))
            {
                string_list[0] = v3lite4.GetValue("productname").ToString();
                string_list[1] = v3lite4.GetValue("installpath").ToString();
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            RegistryKey localmachine3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var navervaccine = localmachine3.OpenSubKey("software\\nhn corporation\\navervaccine");
            if (navervaccine == null)
            { }
            else if (Directory.Exists(navervaccine.GetValue("installdir").ToString()))
            {
                string_list[0] = "네이버 백신";
                string_list[1] = navervaccine.GetValue("installdir").ToString();
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            localmachine.Dispose();
            localmachine2.Dispose();
            localmachine3.Dispose();
        }

        void util()//list 22
        {
            string[] string_list = new string[2];
            RegistryKey localmachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var alzip = localmachine.OpenSubKey("software\\estsoft\\alzip");
            if (alzip == null)
            { }
            else if (Directory.Exists(alzip.GetValue("rootdir").ToString()))
            {
                string_list[0] = "알집";
                string_list[1] = alzip.GetValue("rootdir").ToString();
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            RegistryKey localmachine2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var alupdate = localmachine2.OpenSubKey("software\\estsoft\\alupdate");
            if (alupdate == null)
            { }
            else if (Directory.Exists(alupdate.GetValue("rootdir").ToString()))
            {
                string_list[0] = "알툴즈 업데이트";
                string_list[1] = alupdate.GetValue("rootdir").ToString();
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            RegistryKey localmachine3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var alcapture = localmachine3.OpenSubKey("software\\estsoft\\alcapture");
            if (alcapture == null)
            { }
            else if (Directory.Exists(alcapture.GetValue("rootdir").ToString()))
            {
                string_list[0] = "알캡처";
                string_list[1] = alcapture.GetValue("rootdir").ToString();
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            RegistryKey localmachine4 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var alsong = localmachine4.OpenSubKey("software\\estsoft\\alsong");
            if (alsong == null)
            { }
            else if (Directory.Exists(alsong.GetValue("rootdir").ToString()))
            {
                string_list[0] = "알송";
                string_list[1] = alsong.GetValue("rootdir").ToString();
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            RegistryKey localmachine5 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var gomaudio = localmachine5.OpenSubKey("software\\gretech\\gomaudio");
            if (gomaudio == null)
            { }
            else if (Directory.Exists(gomaudio.GetValue("programfolder").ToString()))
            {
                string_list[0] = "곰오디오";
                string_list[1] = gomaudio.GetValue("programfolder").ToString();
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            RegistryKey localmachine6 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var gomplayer = localmachine6.OpenSubKey("software\\gretech\\gomplayer");
            if (gomplayer == null)
            { }
            else if (Directory.Exists(gomplayer.GetValue("programfolder").ToString()))
            {
                string_list[0] = "곰플레이어";
                string_list[1] = gomplayer.GetValue("programfolder").ToString();
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string onegram = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\1gram";
            if (Directory.Exists(onegram))
            {
                string_list[0] = "1gram player";
                string_list[1] = onegram;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string hancapture = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\hantools\\hancapture";
            if (Directory.Exists(hancapture))
            {
                string_list[0] = "한캡쳐";
                string_list[1] = hancapture;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string hancaptureplus = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\hantools\\hancaptureplus";
            if (Directory.Exists(hancaptureplus))
            {
                string_list[0] = "한캡쳐플러스";
                string_list[1] = hancaptureplus;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string tubedown = Path.GetPathRoot(Environment.SystemDirectory) + "\\tubedown";
            if (Directory.Exists(tubedown))
            {
                string_list[0] = "TubeDown";
                string_list[1] = tubedown;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string cacaoencoder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\cacaoencoder";
            if (File.Exists(cacaoencoder + "\\cacaoencoder.exe"))
            {
                string_list[0] = "CacaoEncoder";
                string_list[1] = cacaoencoder;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string afreeca = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\afreeca";
            if (Directory.Exists(afreeca))
            {
                string_list[0] = "아프리카TV";
                string_list[1] = afreeca;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string kakaoliveagent = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\kakaoliveagent";
            if (Directory.Exists(kakaoliveagent))
            {
                string_list[0] = "라이브 에이전트";
                string_list[1] = kakaoliveagent;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string utorrent = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\utorrent";
            if (Directory.Exists(utorrent))
            {
                string_list[0] = "uTorrent";
                string_list[1] = utorrent;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string utorrent_web = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\utorrent web";
            if (Directory.Exists(utorrent_web))
            {
                string_list[0] = "uTorrent Web";
                string_list[1] = utorrent_web;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string bittorrent = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\bittorrent";
            if (Directory.Exists(bittorrent))
            {
                string_list[0] = "BitTorrent";
                string_list[1] = bittorrent;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string bittorrent_web = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\bittorrent web";
            if (Directory.Exists(bittorrent_web))
            {
                string_list[0] = "BitTorrent Web";
                string_list[1] = bittorrent_web;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string nia = Path.GetPathRoot(Environment.SystemDirectory) + "\\nia";
            if (Directory.Exists(nia))
            {
                string_list[0] = "NIASpeedMeter";
                string_list[1] = nia;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string ktspeedclient = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ktspeedclient";
            if (Directory.Exists(ktspeedclient))
            {
                string_list[0] = "KTSpeedClient";//속도측정
                string_list[1] = ktspeedclient;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string ktsupportclient = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ktsupportclient";
            if (Directory.Exists(ktsupportclient))
            {
                string_list[0] = "KTSupportClient";//속도변경 셀프개통
                string_list[1] = ktsupportclient;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string skbinternetspeed = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\skbinternetspeed";
            if (Directory.Exists(skbinternetspeed))
            {
                string_list[0] = "SKBSpeedMeter";
                string_list[1] = skbinternetspeed;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string modadam = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\modadam";
            if (Directory.Exists(modadam))
            {
                string_list[0] = "MoDaDam";
                string_list[1] = modadam;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            localmachine.Dispose();
            localmachine2.Dispose();
            localmachine3.Dispose();
            localmachine4.Dispose();
            localmachine5.Dispose();
            localmachine6.Dispose();
        }

        void p2p()//list 37
        {
            string[] string_list = new string[2];
            string nat_service = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\nat service";
            if (File.Exists(nat_service + "\\natsvc.exe"))
            {
                string_list[0] = "NAT Service";
                string_list[1] = nat_service;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string etms_ondisk = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\etms ondisk";
            if (File.Exists(etms_ondisk + "\\ondisk_winsvc.exe"))
            {
                string_list[0] = "ONDISK UP-DOWN";
                string_list[1] = etms_ondisk;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string etms_kdisk = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\etms kdisk";
            if (File.Exists(etms_kdisk + "\\kdisk_winsvc.exe"))
            {
                string_list[0] = "KDISK UP-DOWN";
                string_list[1] = etms_kdisk;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string smanager = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\smanager";
            if (File.Exists(smanager + "\\smmgr.exe"))
            {
                string_list[0] = "SManager";
                string_list[1] = smanager;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string filemaru = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\filemaru.com";
            if (File.Exists(filemaru + "\\filemaruprocessormanager.exe"))
            {
                string_list[0] = "파일마루";
                string_list[1] = filemaru;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string ssadafile = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ssadafile";
            if (File.Exists(ssadafile + "\\ssadafilelauncher.exe"))
            {
                string_list[0] = "SsadaFile";
                string_list[1] = ssadafile;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string filebogo = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\filebogo.com";
            if (File.Exists(filebogo + "\\filebogodown.exe"))
            {
                string_list[0] = "파일보고";
                string_list[1] = filebogo;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string v_service = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\v_service";
            if (File.Exists(v_service + "\\v_service.exe"))
            {
                string_list[0] = "v_service";
                string_list[1] = v_service;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string filemong = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\filemong";
            if (File.Exists(filemong + "\\filemonglauncher.exe"))
            {
                string_list[0] = "FileMong";
                string_list[1] = filemong;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string jjinpl = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\jjinpl.com";
            if (File.Exists(jjinpl + "\\jjinpllauncher.exe"))
            {
                string_list[0] = "jjinpl";
                string_list[1] = jjinpl;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string xtorengine = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\xtorengine";
            if (File.Exists(xtorengine + "\\xtorengine.exe"))
            {
                string_list[0] = "XTorEngine";
                string_list[1] = xtorengine;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string todisk = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\todisk.com";
            if (File.Exists(todisk + "\\todiskdown.exe"))
            {
                string_list[0] = "투디스크";
                string_list[1] = todisk;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string smartfile = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\smartfile";
            if (File.Exists(smartfile + "\\smartfilesrv.exe"))
            {
                string_list[0] = "스마트파일";
                string_list[1] = smartfile;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string applefiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\applefiles";
            if (File.Exists(applefiles + "\\applefileservice.exe"))
            {
                string_list[0] = "애플파일";
                string_list[1] = applefiles;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string filesun = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\filesun.com";
            if (File.Exists(filesun + "\\filesunlauncher.exe"))
            {
                string_list[0] = "FileSun";
                string_list[1] = filesun;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string dodofile = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\dodofile";
            if (File.Exists(dodofile + "\\dodofile.exe"))
            {
                string_list[0] = "도도파일 프로그램";
                string_list[1] = dodofile;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string filecast = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\filecast";
            if (File.Exists(filecast + "\\filecast_clientdown.exe"))
            {
                string_list[0] = "파일캐스트";
                string_list[1] = filecast;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string wedisk = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\wedisk";
            if (File.Exists(wedisk + "\\wediskservice.exe"))
            {
                string_list[0] = "Wedisk Plug-in";
                string_list[1] = wedisk;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string filenori = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\filenori";
            if (File.Exists(filenori + "\\filenoriservice.exe"))
            {
                string_list[0] = "FileNori Plug-in";
                string_list[1] = filenori;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string sharebox = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\sharebox";
            if (File.Exists(sharebox + "\\shareboxservice.exe"))
            {
                string_list[0] = "쉐어박스";
                string_list[1] = sharebox;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string pdpopx = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\pdpopx";
            if (File.Exists(pdpopx + "\\pdpop_nanoomidown.exe"))
            {
                string_list[0] = "PDPOP";
                string_list[1] = pdpopx;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string ccdnservice = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ccdnservice";
            if (File.Exists(ccdnservice + "\\ccdnservice.exe"))
            {
                string_list[0] = "CCDNService";
                string_list[1] = ccdnservice;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string exbc = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\exbc";
            if (File.Exists(exbc + "\\exbcsvc.exe"))
            {
                string_list[0] = "확장된 브라우저 컨트롤러";
                string_list[1] = exbc;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string megafile = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\megafile";
            if (File.Exists(megafile + "\\megafilelauncher.exe"))
            {
                string_list[0] = "Megafile";
                string_list[1] = megafile;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string tple = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\tple";
            if (File.Exists(tple + "\\tple_downagent.exe"))
            {
                string_list[0] = "Tple Download";
                string_list[1] = tple;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string iztel = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\iztel";
            if (File.Exists(iztel + "\\iztel_down.exe"))
            {
                string_list[0] = "IZTEL";
                string_list[1] = iztel;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string tomatopang = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\tomatopang";
            if (File.Exists(tomatopang + "\\pang.exe"))
            {
                string_list[0] = "토마토팡";
                string_list[1] = tomatopang;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string lottofile = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\lottofile";
            if (File.Exists(lottofile + "\\lottofile.exe"))
            {
                string_list[0] = "로또파일";
                string_list[1] = lottofile;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string fileis = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\fileis";
            if (File.Exists(fileis + "\\fileisservice.exe"))
            {
                string_list[0] = "파일이즈";
                string_list[1] = fileis;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string filekuki = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\filekuki";
            if (File.Exists(filekuki + "\\filekukiservice.exe"))
            {
                string_list[0] = "파일쿠키 업/다운로더";
                string_list[1] = filekuki;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string yesfile = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\yesfile";
            if (File.Exists(yesfile + "\\yesfileservice.exe"))
            {
                string_list[0] = "예스파일";
                string_list[1] = yesfile;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string filecity = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\filecity\\cb_service";
            if (File.Exists(filecity + "\\filecity_cb_service.exe"))
            {
                string_list[0] = "파일시티";
                string_list[1] = filecity;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string clubnex = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\clubnex.co.kr";
            if (File.Exists(clubnex + "\\clubnexlauncher.exe"))
            {
                string_list[0] = "Clubnex";
                string_list[1] = clubnex;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string bigfile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\bigfile";
            if (File.Exists(bigfile + "\\bigfileservice.exe"))
            {
                string_list[0] = "빅파일 클라이언트";
                string_list[1] = bigfile;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string filestar = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\filestar";
            if (File.Exists(filestar + "\\filestarlauncher.exe"))
            {
                string_list[0] = "FileStar";
                string_list[1] = filestar;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string filestarplayer = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\filestarplayer";
            if (File.Exists(filestarplayer + "\\filestarplayeragent.exe"))
            {
                string_list[0] = "FileStarPlayer";
                string_list[1] = filestarplayer;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
            string hgrid = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\hgrid";
            if (File.Exists(hgrid + "\\hgridengine.exe"))
            {
                string_list[0] = "HGridEngine";
                string_list[1] = hgrid;
                ListViewItem listviewitem = new ListViewItem(string_list);
                listView1.Items.Add(listviewitem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            bank();
            bank_all_setup();
            bank_copy();
            hometax();
            vaccine();
            util();
            p2p();
            label1.Text = listView1.Items.Count + "개";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            bank();
            bank_all_setup();
            bank_copy();
            hometax();
            label1.Text = listView1.Items.Count + "개";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            vaccine();
            label1.Text = listView1.Items.Count + "개";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            p2p();
            label1.Text = listView1.Items.Count + "개";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = "/c" + string.Empty.PadLeft(1) + "appwiz.cpl";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Process process = new Process();
                process.StartInfo.FileName = "explorer";
                process.StartInfo.Arguments = listView1.Items[listView1.FocusedItem.Index].SubItems[1].Text;
                process.Start();
            }
        }
    }
}
