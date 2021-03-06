using Win113.Shell.Components;

namespace Win113.Shell.Windows.Sizable
{
    partial class ProgramManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramManager));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("File Manager", "WINFI001.ICO");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Configure Desktop", "desktop_old.ico");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Computer Settings", "settings_gear.ico");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Dockable Task Panel", "windows_button.ico");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("MS-DOS Prompt", "PROGM010.ICO");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Registry Editor", "regedit.ico");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Task Manager", "monitor_application.ico");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Internet Explorer", "msie1.ico");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Altap Salamander", "salam.ico");
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolbarMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accessoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.noSelectButton1 = new Win113.Shell.Components.NoSelectButton();
            this.button1 = new Win113.Shell.Components.NoSelectButton();
            this.button2 = new Win113.Shell.Components.NoSelectButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolbarMenu.SuspendLayout();
            this.toolbarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconsList
            // 
            this.iconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconsList.ImageStream")));
            this.iconsList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconsList.Images.SetKeyName(0, "AB001.ICO");
            this.iconsList.Images.SetKeyName(1, "BOCOF001.ICO");
            this.iconsList.Images.SetKeyName(2, "BOCOL001.ICO");
            this.iconsList.Images.SetKeyName(3, "CALC001.ICO");
            this.iconsList.Images.SetKeyName(4, "CARDF001.ICO");
            this.iconsList.Images.SetKeyName(5, "CLIPB001.ICO");
            this.iconsList.Images.SetKeyName(6, "CLIPB002.ICO");
            this.iconsList.Images.SetKeyName(7, "CLIPB003.ICO");
            this.iconsList.Images.SetKeyName(8, "CLIPB004.ICO");
            this.iconsList.Images.SetKeyName(9, "CLIPB005.ICO");
            this.iconsList.Images.SetKeyName(10, "CLIPB006.ICO");
            this.iconsList.Images.SetKeyName(11, "CLOCK001.ICO");
            this.iconsList.Images.SetKeyName(12, "CMC001.ICO");
            this.iconsList.Images.SetKeyName(13, "CMC002.ICO");
            this.iconsList.Images.SetKeyName(14, "CMC003.ICO");
            this.iconsList.Images.SetKeyName(15, "COMMC001.ICO");
            this.iconsList.Images.SetKeyName(16, "COMMD001.ICO");
            this.iconsList.Images.SetKeyName(17, "COMMD002.ICO");
            this.iconsList.Images.SetKeyName(18, "CONTR001.ICO");
            this.iconsList.Images.SetKeyName(19, "FAXMG001.ICO");
            this.iconsList.Images.SetKeyName(20, "FAXOP001.ICO");
            this.iconsList.Images.SetKeyName(21, "FAXVI001.ICO");
            this.iconsList.Images.SetKeyName(22, "CHARM001.ICO");
            this.iconsList.Images.SetKeyName(23, "KEYVI001.ICO");
            this.iconsList.Images.SetKeyName(24, "LOGON001.ICO");
            this.iconsList.Images.SetKeyName(25, "MAILS001.ICO");
            this.iconsList.Images.SetKeyName(26, "MAILS002.ICO");
            this.iconsList.Images.SetKeyName(27, "MAILS003.ICO");
            this.iconsList.Images.SetKeyName(28, "MAILS004.ICO");
            this.iconsList.Images.SetKeyName(29, "MAILS005.ICO");
            this.iconsList.Images.SetKeyName(30, "MAPI001.ICO");
            this.iconsList.Images.SetKeyName(31, "MAPI002.ICO");
            this.iconsList.Images.SetKeyName(32, "MAPI003.ICO");
            this.iconsList.Images.SetKeyName(33, "MORIC001.ICO");
            this.iconsList.Images.SetKeyName(34, "MORIC002.ICO");
            this.iconsList.Images.SetKeyName(35, "MORIC003.ICO");
            this.iconsList.Images.SetKeyName(36, "MORIC004.ICO");
            this.iconsList.Images.SetKeyName(37, "MORIC005.ICO");
            this.iconsList.Images.SetKeyName(38, "MORIC006.ICO");
            this.iconsList.Images.SetKeyName(39, "MORIC007.ICO");
            this.iconsList.Images.SetKeyName(40, "MORIC008.ICO");
            this.iconsList.Images.SetKeyName(41, "MORIC009.ICO");
            this.iconsList.Images.SetKeyName(42, "MORIC010.ICO");
            this.iconsList.Images.SetKeyName(43, "MORIC011.ICO");
            this.iconsList.Images.SetKeyName(44, "MORIC012.ICO");
            this.iconsList.Images.SetKeyName(45, "MORIC013.ICO");
            this.iconsList.Images.SetKeyName(46, "MORIC014.ICO");
            this.iconsList.Images.SetKeyName(47, "MORIC015.ICO");
            this.iconsList.Images.SetKeyName(48, "MORIC016.ICO");
            this.iconsList.Images.SetKeyName(49, "MORIC017.ICO");
            this.iconsList.Images.SetKeyName(50, "MORIC018.ICO");
            this.iconsList.Images.SetKeyName(51, "MORIC019.ICO");
            this.iconsList.Images.SetKeyName(52, "MORIC020.ICO");
            this.iconsList.Images.SetKeyName(53, "MORIC021.ICO");
            this.iconsList.Images.SetKeyName(54, "MORIC022.ICO");
            this.iconsList.Images.SetKeyName(55, "MORIC023.ICO");
            this.iconsList.Images.SetKeyName(56, "MORIC024.ICO");
            this.iconsList.Images.SetKeyName(57, "MORIC025.ICO");
            this.iconsList.Images.SetKeyName(58, "MORIC026.ICO");
            this.iconsList.Images.SetKeyName(59, "MORIC027.ICO");
            this.iconsList.Images.SetKeyName(60, "MORIC028.ICO");
            this.iconsList.Images.SetKeyName(61, "MORIC029.ICO");
            this.iconsList.Images.SetKeyName(62, "MORIC030.ICO");
            this.iconsList.Images.SetKeyName(63, "MORIC031.ICO");
            this.iconsList.Images.SetKeyName(64, "MORIC032.ICO");
            this.iconsList.Images.SetKeyName(65, "MORIC033.ICO");
            this.iconsList.Images.SetKeyName(66, "MORIC034.ICO");
            this.iconsList.Images.SetKeyName(67, "MORIC035.ICO");
            this.iconsList.Images.SetKeyName(68, "MORIC036.ICO");
            this.iconsList.Images.SetKeyName(69, "MORIC037.ICO");
            this.iconsList.Images.SetKeyName(70, "MORIC038.ICO");
            this.iconsList.Images.SetKeyName(71, "MORIC039.ICO");
            this.iconsList.Images.SetKeyName(72, "MORIC040.ICO");
            this.iconsList.Images.SetKeyName(73, "MORIC041.ICO");
            this.iconsList.Images.SetKeyName(74, "MORIC042.ICO");
            this.iconsList.Images.SetKeyName(75, "MORIC043.ICO");
            this.iconsList.Images.SetKeyName(76, "MORIC044.ICO");
            this.iconsList.Images.SetKeyName(77, "MORIC045.ICO");
            this.iconsList.Images.SetKeyName(78, "MORIC046.ICO");
            this.iconsList.Images.SetKeyName(79, "MORIC047.ICO");
            this.iconsList.Images.SetKeyName(80, "MORIC048.ICO");
            this.iconsList.Images.SetKeyName(81, "MORIC049.ICO");
            this.iconsList.Images.SetKeyName(82, "MORIC050.ICO");
            this.iconsList.Images.SetKeyName(83, "MORIC051.ICO");
            this.iconsList.Images.SetKeyName(84, "MORIC052.ICO");
            this.iconsList.Images.SetKeyName(85, "MORIC053.ICO");
            this.iconsList.Images.SetKeyName(86, "MORIC054.ICO");
            this.iconsList.Images.SetKeyName(87, "MORIC055.ICO");
            this.iconsList.Images.SetKeyName(88, "MORIC056.ICO");
            this.iconsList.Images.SetKeyName(89, "MORIC057.ICO");
            this.iconsList.Images.SetKeyName(90, "MORIC058.ICO");
            this.iconsList.Images.SetKeyName(91, "MORIC059.ICO");
            this.iconsList.Images.SetKeyName(92, "MORIC060.ICO");
            this.iconsList.Images.SetKeyName(93, "MORIC061.ICO");
            this.iconsList.Images.SetKeyName(94, "MORIC062.ICO");
            this.iconsList.Images.SetKeyName(95, "MORIC063.ICO");
            this.iconsList.Images.SetKeyName(96, "MORIC064.ICO");
            this.iconsList.Images.SetKeyName(97, "MORIC065.ICO");
            this.iconsList.Images.SetKeyName(98, "MORIC066.ICO");
            this.iconsList.Images.SetKeyName(99, "MORIC067.ICO");
            this.iconsList.Images.SetKeyName(100, "MORIC068.ICO");
            this.iconsList.Images.SetKeyName(101, "MORIC069.ICO");
            this.iconsList.Images.SetKeyName(102, "MORIC070.ICO");
            this.iconsList.Images.SetKeyName(103, "MORIC071.ICO");
            this.iconsList.Images.SetKeyName(104, "MORIC072.ICO");
            this.iconsList.Images.SetKeyName(105, "MORIC073.ICO");
            this.iconsList.Images.SetKeyName(106, "MORIC074.ICO");
            this.iconsList.Images.SetKeyName(107, "MORIC075.ICO");
            this.iconsList.Images.SetKeyName(108, "MORIC076.ICO");
            this.iconsList.Images.SetKeyName(109, "MORIC077.ICO");
            this.iconsList.Images.SetKeyName(110, "MORIC078.ICO");
            this.iconsList.Images.SetKeyName(111, "MORIC079.ICO");
            this.iconsList.Images.SetKeyName(112, "MORIC080.ICO");
            this.iconsList.Images.SetKeyName(113, "MORIC081.ICO");
            this.iconsList.Images.SetKeyName(114, "MORIC082.ICO");
            this.iconsList.Images.SetKeyName(115, "MORIC083.ICO");
            this.iconsList.Images.SetKeyName(116, "MORIC084.ICO");
            this.iconsList.Images.SetKeyName(117, "MORIC085.ICO");
            this.iconsList.Images.SetKeyName(118, "MORIC086.ICO");
            this.iconsList.Images.SetKeyName(119, "MORIC087.ICO");
            this.iconsList.Images.SetKeyName(120, "MORIC088.ICO");
            this.iconsList.Images.SetKeyName(121, "MORIC089.ICO");
            this.iconsList.Images.SetKeyName(122, "MORIC090.ICO");
            this.iconsList.Images.SetKeyName(123, "MORIC091.ICO");
            this.iconsList.Images.SetKeyName(124, "MORIC092.ICO");
            this.iconsList.Images.SetKeyName(125, "MORIC093.ICO");
            this.iconsList.Images.SetKeyName(126, "MORIC094.ICO");
            this.iconsList.Images.SetKeyName(127, "MORIC095.ICO");
            this.iconsList.Images.SetKeyName(128, "MORIC096.ICO");
            this.iconsList.Images.SetKeyName(129, "MORIC097.ICO");
            this.iconsList.Images.SetKeyName(130, "MORIC098.ICO");
            this.iconsList.Images.SetKeyName(131, "MORIC099.ICO");
            this.iconsList.Images.SetKeyName(132, "MORIC100.ICO");
            this.iconsList.Images.SetKeyName(133, "MORIC101.ICO");
            this.iconsList.Images.SetKeyName(134, "MORIC102.ICO");
            this.iconsList.Images.SetKeyName(135, "MORIC103.ICO");
            this.iconsList.Images.SetKeyName(136, "MORIC104.ICO");
            this.iconsList.Images.SetKeyName(137, "MORIC105.ICO");
            this.iconsList.Images.SetKeyName(138, "MORIC106.ICO");
            this.iconsList.Images.SetKeyName(139, "MPLAY001.ICO");
            this.iconsList.Images.SetKeyName(140, "MSHEA001.ICO");
            this.iconsList.Images.SetKeyName(141, "MSMAI001.ICO");
            this.iconsList.Images.SetKeyName(142, "MSMAI002.ICO");
            this.iconsList.Images.SetKeyName(143, "MSMAI003.ICO");
            this.iconsList.Images.SetKeyName(144, "MSMAI004.ICO");
            this.iconsList.Images.SetKeyName(145, "MSMAI005.ICO");
            this.iconsList.Images.SetKeyName(146, "MSMAI006.ICO");
            this.iconsList.Images.SetKeyName(147, "MSMAI007.ICO");
            this.iconsList.Images.SetKeyName(148, "MSMAI008.ICO");
            this.iconsList.Images.SetKeyName(149, "MSMAI009.ICO");
            this.iconsList.Images.SetKeyName(150, "MSMAI010.ICO");
            this.iconsList.Images.SetKeyName(151, "MSMAI011.ICO");
            this.iconsList.Images.SetKeyName(152, "MSMAI012.ICO");
            this.iconsList.Images.SetKeyName(153, "MSREM001.ICO");
            this.iconsList.Images.SetKeyName(154, "NETWA001.ICO");
            this.iconsList.Images.SetKeyName(155, "NETWA002.ICO");
            this.iconsList.Images.SetKeyName(156, "NOTEP001.ICO");
            this.iconsList.Images.SetKeyName(157, "OLE2001.ICO");
            this.iconsList.Images.SetKeyName(158, "PACKA001.ICO");
            this.iconsList.Images.SetKeyName(159, "PBRUS001.ICO");
            this.iconsList.Images.SetKeyName(160, "PIFED001.ICO");
            this.iconsList.Images.SetKeyName(161, "PRINT001.ICO");
            this.iconsList.Images.SetKeyName(162, "PROGM001.ICO");
            this.iconsList.Images.SetKeyName(163, "PROGM002.ICO");
            this.iconsList.Images.SetKeyName(164, "PROGM003.ICO");
            this.iconsList.Images.SetKeyName(165, "PROGM004.ICO");
            this.iconsList.Images.SetKeyName(166, "PROGM005.ICO");
            this.iconsList.Images.SetKeyName(167, "PROGM006.ICO");
            this.iconsList.Images.SetKeyName(168, "PROGM007.ICO");
            this.iconsList.Images.SetKeyName(169, "PROGM008.ICO");
            this.iconsList.Images.SetKeyName(170, "PROGM009.ICO");
            this.iconsList.Images.SetKeyName(171, "PROGM010.ICO");
            this.iconsList.Images.SetKeyName(172, "PROGM011.ICO");
            this.iconsList.Images.SetKeyName(173, "PROGM012.ICO");
            this.iconsList.Images.SetKeyName(174, "PROGM013.ICO");
            this.iconsList.Images.SetKeyName(175, "PROGM014.ICO");
            this.iconsList.Images.SetKeyName(176, "PROGM015.ICO");
            this.iconsList.Images.SetKeyName(177, "PROGM016.ICO");
            this.iconsList.Images.SetKeyName(178, "PROGM017.ICO");
            this.iconsList.Images.SetKeyName(179, "PROGM018.ICO");
            this.iconsList.Images.SetKeyName(180, "PROGM019.ICO");
            this.iconsList.Images.SetKeyName(181, "PROGM020.ICO");
            this.iconsList.Images.SetKeyName(182, "PROGM021.ICO");
            this.iconsList.Images.SetKeyName(183, "PROGM022.ICO");
            this.iconsList.Images.SetKeyName(184, "PROGM023.ICO");
            this.iconsList.Images.SetKeyName(185, "PROGM024.ICO");
            this.iconsList.Images.SetKeyName(186, "PROGM025.ICO");
            this.iconsList.Images.SetKeyName(187, "PROGM026.ICO");
            this.iconsList.Images.SetKeyName(188, "PROGM027.ICO");
            this.iconsList.Images.SetKeyName(189, "PROGM028.ICO");
            this.iconsList.Images.SetKeyName(190, "PROGM029.ICO");
            this.iconsList.Images.SetKeyName(191, "PROGM030.ICO");
            this.iconsList.Images.SetKeyName(192, "PROGM031.ICO");
            this.iconsList.Images.SetKeyName(193, "PROGM032.ICO");
            this.iconsList.Images.SetKeyName(194, "PROGM033.ICO");
            this.iconsList.Images.SetKeyName(195, "PROGM034.ICO");
            this.iconsList.Images.SetKeyName(196, "PROGM035.ICO");
            this.iconsList.Images.SetKeyName(197, "PROGM036.ICO");
            this.iconsList.Images.SetKeyName(198, "PROGM037.ICO");
            this.iconsList.Images.SetKeyName(199, "PROGM038.ICO");
            this.iconsList.Images.SetKeyName(200, "PROGM039.ICO");
            this.iconsList.Images.SetKeyName(201, "PROGM040.ICO");
            this.iconsList.Images.SetKeyName(202, "PROGM041.ICO");
            this.iconsList.Images.SetKeyName(203, "PROGM042.ICO");
            this.iconsList.Images.SetKeyName(204, "PROGM043.ICO");
            this.iconsList.Images.SetKeyName(205, "PROGM044.ICO");
            this.iconsList.Images.SetKeyName(206, "PROGM045.ICO");
            this.iconsList.Images.SetKeyName(207, "PROGM046.ICO");
            this.iconsList.Images.SetKeyName(208, "RASST001.ICO");
            this.iconsList.Images.SetKeyName(209, "RECOR001.ICO");
            this.iconsList.Images.SetKeyName(210, "REGED001.ICO");
            this.iconsList.Images.SetKeyName(211, "SCHDP001.ICO");
            this.iconsList.Images.SetKeyName(212, "SCHDP002.ICO");
            this.iconsList.Images.SetKeyName(213, "SCHDP003.ICO");
            this.iconsList.Images.SetKeyName(214, "SCHDP004.ICO");
            this.iconsList.Images.SetKeyName(215, "SCHDP005.ICO");
            this.iconsList.Images.SetKeyName(216, "SCHDP006.ICO");
            this.iconsList.Images.SetKeyName(217, "SCHDP007.ICO");
            this.iconsList.Images.SetKeyName(218, "SCHDP008.ICO");
            this.iconsList.Images.SetKeyName(219, "SIGVI001.ICO");
            this.iconsList.Images.SetKeyName(220, "SOL001.ICO");
            this.iconsList.Images.SetKeyName(221, "SOUND001.ICO");
            this.iconsList.Images.SetKeyName(222, "STORE001.ICO");
            this.iconsList.Images.SetKeyName(223, "SYSED001.ICO");
            this.iconsList.Images.SetKeyName(224, "SYSED002.ICO");
            this.iconsList.Images.SetKeyName(225, "TERMI001.ICO");
            this.iconsList.Images.SetKeyName(226, "UNIDR001.ICO");
            this.iconsList.Images.SetKeyName(227, "UNIDR002.ICO");
            this.iconsList.Images.SetKeyName(228, "UNIDR003.ICO");
            this.iconsList.Images.SetKeyName(229, "UNIDR004.ICO");
            this.iconsList.Images.SetKeyName(230, "UNIDR005.ICO");
            this.iconsList.Images.SetKeyName(231, "UNIDR006.ICO");
            this.iconsList.Images.SetKeyName(232, "UNIDR007.ICO");
            this.iconsList.Images.SetKeyName(233, "UNIDR008.ICO");
            this.iconsList.Images.SetKeyName(234, "UNINS001.ICO");
            this.iconsList.Images.SetKeyName(235, "UNWIS001.ICO");
            this.iconsList.Images.SetKeyName(236, "USER001.ICO");
            this.iconsList.Images.SetKeyName(237, "VBRUN001.ICO");
            this.iconsList.Images.SetKeyName(238, "VBRUN002.ICO");
            this.iconsList.Images.SetKeyName(239, "VBRUN003.ICO");
            this.iconsList.Images.SetKeyName(240, "VFORM001.ICO");
            this.iconsList.Images.SetKeyName(241, "VFORM002.ICO");
            this.iconsList.Images.SetKeyName(242, "VFORM003.ICO");
            this.iconsList.Images.SetKeyName(243, "WFWSE001.ICO");
            this.iconsList.Images.SetKeyName(244, "WFWSE002.ICO");
            this.iconsList.Images.SetKeyName(245, "WFWSE003.ICO");
            this.iconsList.Images.SetKeyName(246, "WFWSE004.ICO");
            this.iconsList.Images.SetKeyName(247, "WFWSE005.ICO");
            this.iconsList.Images.SetKeyName(248, "WFWSE006.ICO");
            this.iconsList.Images.SetKeyName(249, "WFWSE007.ICO");
            this.iconsList.Images.SetKeyName(250, "WINFI001.ICO");
            this.iconsList.Images.SetKeyName(251, "WINFI002.ICO");
            this.iconsList.Images.SetKeyName(252, "WINFI003.ICO");
            this.iconsList.Images.SetKeyName(253, "WINFI004.ICO");
            this.iconsList.Images.SetKeyName(254, "WINHE001.ICO");
            this.iconsList.Images.SetKeyName(255, "WINHL001.ICO");
            this.iconsList.Images.SetKeyName(256, "WINHL002.ICO");
            this.iconsList.Images.SetKeyName(257, "WINHL003.ICO");
            this.iconsList.Images.SetKeyName(258, "WINCH001.ICO");
            this.iconsList.Images.SetKeyName(259, "WINCH002.ICO");
            this.iconsList.Images.SetKeyName(260, "WINCH003.ICO");
            this.iconsList.Images.SetKeyName(261, "WINME001.ICO");
            this.iconsList.Images.SetKeyName(262, "WINMI001.ICO");
            this.iconsList.Images.SetKeyName(263, "WINPO001.ICO");
            this.iconsList.Images.SetKeyName(264, "WINPO002.ICO");
            this.iconsList.Images.SetKeyName(265, "WINPO003.ICO");
            this.iconsList.Images.SetKeyName(266, "WINSE001.ICO");
            this.iconsList.Images.SetKeyName(267, "WINSE002.ICO");
            this.iconsList.Images.SetKeyName(268, "WINSE003.ICO");
            this.iconsList.Images.SetKeyName(269, "WINSE004.ICO");
            this.iconsList.Images.SetKeyName(270, "WINSE005.ICO");
            this.iconsList.Images.SetKeyName(271, "WINTU001.ICO");
            this.iconsList.Images.SetKeyName(272, "WINTU002.ICO");
            this.iconsList.Images.SetKeyName(273, "WINTU003.ICO");
            this.iconsList.Images.SetKeyName(274, "WINTU004.ICO");
            this.iconsList.Images.SetKeyName(275, "WINTU005.ICO");
            this.iconsList.Images.SetKeyName(276, "WINTU006.ICO");
            this.iconsList.Images.SetKeyName(277, "WINTU007.ICO");
            this.iconsList.Images.SetKeyName(278, "WINVE001.ICO");
            this.iconsList.Images.SetKeyName(279, "WRITE001.ICO");
            this.iconsList.Images.SetKeyName(280, "ac_plug.ico");
            this.iconsList.Images.SetKeyName(281, "accesibility_window_abc.ico");
            this.iconsList.Images.SetKeyName(282, "access_wheelchair_big.ico");
            this.iconsList.Images.SetKeyName(283, "accessibility.ico");
            this.iconsList.Images.SetKeyName(284, "accessibility_big_keys.ico");
            this.iconsList.Images.SetKeyName(285, "accessibility_contrast.ico");
            this.iconsList.Images.SetKeyName(286, "accessibility_kbd_mouse.ico");
            this.iconsList.Images.SetKeyName(287, "accessibility_key_pointer.ico");
            this.iconsList.Images.SetKeyName(288, "accessibility_stopwatch.ico");
            this.iconsList.Images.SetKeyName(289, "accessibility_toggle.ico");
            this.iconsList.Images.SetKeyName(290, "accessibility_toggle2.ico");
            this.iconsList.Images.SetKeyName(291, "accessibility_toggle3.ico");
            this.iconsList.Images.SetKeyName(292, "accessibility_two_windows.ico");
            this.iconsList.Images.SetKeyName(293, "accessibility_window_objs.ico");
            this.iconsList.Images.SetKeyName(294, "accessibility_window_signal.ico");
            this.iconsList.Images.SetKeyName(295, "accessibility_window_speak.ico");
            this.iconsList.Images.SetKeyName(296, "active_movie.ico");
            this.iconsList.Images.SetKeyName(297, "address_book.ico");
            this.iconsList.Images.SetKeyName(298, "address_book_card.ico");
            this.iconsList.Images.SetKeyName(299, "address_book_card_copy.ico");
            this.iconsList.Images.SetKeyName(300, "address_book_card_users.ico");
            this.iconsList.Images.SetKeyName(301, "address_book_cards.ico");
            this.iconsList.Images.SetKeyName(302, "address_book_copy.ico");
            this.iconsList.Images.SetKeyName(303, "address_book_home.ico");
            this.iconsList.Images.SetKeyName(304, "address_book_pad.ico");
            this.iconsList.Images.SetKeyName(305, "address_book_pad_users.ico");
            this.iconsList.Images.SetKeyName(306, "address_book_user.ico");
            this.iconsList.Images.SetKeyName(307, "address_book_users.ico");
            this.iconsList.Images.SetKeyName(308, "amplify.ico");
            this.iconsList.Images.SetKeyName(309, "application_hammer_grouppol.ico");
            this.iconsList.Images.SetKeyName(310, "application_hourglass.ico");
            this.iconsList.Images.SetKeyName(311, "application_hourglass_small.ico");
            this.iconsList.Images.SetKeyName(312, "application_hourglass_small_cool.ico");
            this.iconsList.Images.SetKeyName(313, "appwiz_file.ico");
            this.iconsList.Images.SetKeyName(314, "appwizard.ico");
            this.iconsList.Images.SetKeyName(315, "appwizard_list.ico");
            this.iconsList.Images.SetKeyName(316, "audio_compression.ico");
            this.iconsList.Images.SetKeyName(317, "backup_devices.ico");
            this.iconsList.Images.SetKeyName(318, "backup_devices_2.ico");
            this.iconsList.Images.SetKeyName(319, "bar_graph.ico");
            this.iconsList.Images.SetKeyName(320, "bar_graph_default.ico");
            this.iconsList.Images.SetKeyName(321, "battery.ico");
            this.iconsList.Images.SetKeyName(322, "battery_alt.ico");
            this.iconsList.Images.SetKeyName(323, "briefcase.ico");
            this.iconsList.Images.SetKeyName(324, "cable.ico");
            this.iconsList.Images.SetKeyName(325, "cable_2.ico");
            this.iconsList.Images.SetKeyName(326, "cable_3.ico");
            this.iconsList.Images.SetKeyName(327, "calculator.ico");
            this.iconsList.Images.SetKeyName(328, "calendar.ico");
            this.iconsList.Images.SetKeyName(329, "calendar2.ico");
            this.iconsList.Images.SetKeyName(330, "camera.ico");
            this.iconsList.Images.SetKeyName(331, "camera_2.ico");
            this.iconsList.Images.SetKeyName(332, "camera_vid.ico");
            this.iconsList.Images.SetKeyName(333, "camera_vid_ms.ico");
            this.iconsList.Images.SetKeyName(334, "camera3.ico");
            this.iconsList.Images.SetKeyName(335, "camera3_network.ico");
            this.iconsList.Images.SetKeyName(336, "camera3_plus.ico");
            this.iconsList.Images.SetKeyName(337, "camera3_vid.ico");
            this.iconsList.Images.SetKeyName(338, "card_reader.ico");
            this.iconsList.Images.SetKeyName(339, "card_reader_empty.ico");
            this.iconsList.Images.SetKeyName(340, "card_reader_not.ico");
            this.iconsList.Images.SetKeyName(341, "card_reader_restr.ico");
            this.iconsList.Images.SetKeyName(342, "cardfile.ico");
            this.iconsList.Images.SetKeyName(343, "cassette_tape.ico");
            this.iconsList.Images.SetKeyName(344, "catalog.ico");
            this.iconsList.Images.SetKeyName(345, "catalog_excl.ico");
            this.iconsList.Images.SetKeyName(346, "catalog_no.ico");
            this.iconsList.Images.SetKeyName(347, "c-clamp.ico");
            this.iconsList.Images.SetKeyName(348, "cd_audio_cd.ico");
            this.iconsList.Images.SetKeyName(349, "cd_audio_cd_a.ico");
            this.iconsList.Images.SetKeyName(350, "cd_drive.ico");
            this.iconsList.Images.SetKeyName(351, "cd_drive_purple.ico");
            this.iconsList.Images.SetKeyName(352, "certificate.ico");
            this.iconsList.Images.SetKeyName(353, "certificate_2.ico");
            this.iconsList.Images.SetKeyName(354, "certificate_2_excl.ico");
            this.iconsList.Images.SetKeyName(355, "certificate_2_no.ico");
            this.iconsList.Images.SetKeyName(356, "certificate_3.ico");
            this.iconsList.Images.SetKeyName(357, "certificate_application.ico");
            this.iconsList.Images.SetKeyName(358, "certificate_envelope_key.ico");
            this.iconsList.Images.SetKeyName(359, "certificate_excl.ico");
            this.iconsList.Images.SetKeyName(360, "certificate_gear.ico");
            this.iconsList.Images.SetKeyName(361, "certificate_checklist.ico");
            this.iconsList.Images.SetKeyName(362, "certificate_multiple.ico");
            this.iconsList.Images.SetKeyName(363, "certificate_no.ico");
            this.iconsList.Images.SetKeyName(364, "certificate_red_line.ico");
            this.iconsList.Images.SetKeyName(365, "certificate_seal.ico");
            this.iconsList.Images.SetKeyName(366, "certificate_seal_lock.ico");
            this.iconsList.Images.SetKeyName(367, "certificate_server.ico");
            this.iconsList.Images.SetKeyName(368, "circle_question.ico");
            this.iconsList.Images.SetKeyName(369, "clean_drive.ico");
            this.iconsList.Images.SetKeyName(370, "clock.ico");
            this.iconsList.Images.SetKeyName(371, "color_profile.ico");
            this.iconsList.Images.SetKeyName(372, "color_profile_gray.ico");
            this.iconsList.Images.SetKeyName(373, "computer.ico");
            this.iconsList.Images.SetKeyName(374, "computer_2.ico");
            this.iconsList.Images.SetKeyName(375, "computer_2_cool.ico");
            this.iconsList.Images.SetKeyName(376, "computer_explorer.ico");
            this.iconsList.Images.SetKeyName(377, "computer_explorer_2k.ico");
            this.iconsList.Images.SetKeyName(378, "computer_explorer_cool.ico");
            this.iconsList.Images.SetKeyName(379, "computer_gear.ico");
            this.iconsList.Images.SetKeyName(380, "computer_musical_keyboard.ico");
            this.iconsList.Images.SetKeyName(381, "computer_padlock.ico");
            this.iconsList.Images.SetKeyName(382, "computer_search.ico");
            this.iconsList.Images.SetKeyName(383, "computer_sound.ico");
            this.iconsList.Images.SetKeyName(384, "computer_taskmgr.ico");
            this.iconsList.Images.SetKeyName(385, "computer_user_pencil.ico");
            this.iconsList.Images.SetKeyName(386, "computer_win.ico");
            this.iconsList.Images.SetKeyName(387, "computer_win_lock.ico");
            this.iconsList.Images.SetKeyName(388, "conn_cloud.ico");
            this.iconsList.Images.SetKeyName(389, "conn_cloud_ok.ico");
            this.iconsList.Images.SetKeyName(390, "conn_dialup.ico");
            this.iconsList.Images.SetKeyName(391, "conn_dialup_alt.ico");
            this.iconsList.Images.SetKeyName(392, "conn_dialup_ok.ico");
            this.iconsList.Images.SetKeyName(393, "conn_dialup_recbin_phone.ico");
            this.iconsList.Images.SetKeyName(394, "conn_dialup_recbin_phones.ico");
            this.iconsList.Images.SetKeyName(395, "conn_network_no_phone.ico");
            this.iconsList.Images.SetKeyName(396, "conn_pcs_no_network.ico");
            this.iconsList.Images.SetKeyName(397, "conn_pcs_off_off.ico");
            this.iconsList.Images.SetKeyName(398, "conn_pcs_off_on.ico");
            this.iconsList.Images.SetKeyName(399, "conn_pcs_on_off.ico");
            this.iconsList.Images.SetKeyName(400, "conn_pcs_on_on.ico");
            this.iconsList.Images.SetKeyName(401, "connected_world.ico");
            this.iconsList.Images.SetKeyName(402, "console_prompt.ico");
            this.iconsList.Images.SetKeyName(403, "cylinder_database.ico");
            this.iconsList.Images.SetKeyName(404, "defragment.ico");
            this.iconsList.Images.SetKeyName(405, "desktop.ico");
            this.iconsList.Images.SetKeyName(406, "desktop_old.ico");
            this.iconsList.Images.SetKeyName(407, "desktop_w95.ico");
            this.iconsList.Images.SetKeyName(408, "device_rhombic_chip.ico");
            this.iconsList.Images.SetKeyName(409, "direct_cable_conn.ico");
            this.iconsList.Images.SetKeyName(410, "directory_admin_tools.ico");
            this.iconsList.Images.SetKeyName(411, "directory_business_calendar.ico");
            this.iconsList.Images.SetKeyName(412, "directory_closed.ico");
            this.iconsList.Images.SetKeyName(413, "directory_closed_cool.ico");
            this.iconsList.Images.SetKeyName(414, "directory_closed_history.ico");
            this.iconsList.Images.SetKeyName(415, "directory_computer.ico");
            this.iconsList.Images.SetKeyName(416, "directory_control_panel.ico");
            this.iconsList.Images.SetKeyName(417, "directory_control_panel_cool.ico");
            this.iconsList.Images.SetKeyName(418, "directory_dial-up_networking.ico");
            this.iconsList.Images.SetKeyName(419, "directory_dial-up_networking_cool.ico");
            this.iconsList.Images.SetKeyName(420, "directory_e.ico");
            this.iconsList.Images.SetKeyName(421, "directory_e_open.ico");
            this.iconsList.Images.SetKeyName(422, "directory_explorer.ico");
            this.iconsList.Images.SetKeyName(423, "directory_favorites.ico");
            this.iconsList.Images.SetKeyName(424, "directory_favorites_small.ico");
            this.iconsList.Images.SetKeyName(425, "directory_folder_options.ico");
            this.iconsList.Images.SetKeyName(426, "directory_fonts.ico");
            this.iconsList.Images.SetKeyName(427, "directory_fonts_cool.ico");
            this.iconsList.Images.SetKeyName(428, "directory_fonts_shortcut.ico");
            this.iconsList.Images.SetKeyName(429, "directory_channels.ico");
            this.iconsList.Images.SetKeyName(430, "directory_check.ico");
            this.iconsList.Images.SetKeyName(431, "directory_movie.ico");
            this.iconsList.Images.SetKeyName(432, "directory_net_web.ico");
            this.iconsList.Images.SetKeyName(433, "directory_network_conn.ico");
            this.iconsList.Images.SetKeyName(434, "directory_network_conn_shortcut.ico");
            this.iconsList.Images.SetKeyName(435, "directory_open.ico");
            this.iconsList.Images.SetKeyName(436, "directory_open_cabinet.ico");
            this.iconsList.Images.SetKeyName(437, "directory_open_cabinet_fc.ico");
            this.iconsList.Images.SetKeyName(438, "directory_open_cool.ico");
            this.iconsList.Images.SetKeyName(439, "directory_open_file_mydocs.ico");
            this.iconsList.Images.SetKeyName(440, "directory_open_file_mydocs_2k.ico");
            this.iconsList.Images.SetKeyName(441, "directory_open_file_mydocs_cool.ico");
            this.iconsList.Images.SetKeyName(442, "directory_open_file_mydocs_small.ico");
            this.iconsList.Images.SetKeyName(443, "directory_open_history.ico");
            this.iconsList.Images.SetKeyName(444, "directory_open_net_web_documents.ico");
            this.iconsList.Images.SetKeyName(445, "directory_open_network.ico");
            this.iconsList.Images.SetKeyName(446, "directory_open_refresh.ico");
            this.iconsList.Images.SetKeyName(447, "directory_pictures.ico");
            this.iconsList.Images.SetKeyName(448, "directory_printer.ico");
            this.iconsList.Images.SetKeyName(449, "directory_printer_cool.ico");
            this.iconsList.Images.SetKeyName(450, "directory_printer_shortcut.ico");
            this.iconsList.Images.SetKeyName(451, "directory_program_group.ico");
            this.iconsList.Images.SetKeyName(452, "directory_program_group_cool.ico");
            this.iconsList.Images.SetKeyName(453, "directory_program_group_small.ico");
            this.iconsList.Images.SetKeyName(454, "directory_program_group_small_c.ico");
            this.iconsList.Images.SetKeyName(455, "directory_scanner_camera.ico");
            this.iconsList.Images.SetKeyName(456, "directory_seven.ico");
            this.iconsList.Images.SetKeyName(457, "directory_shared.ico");
            this.iconsList.Images.SetKeyName(458, "directory_sched_tasks.ico");
            this.iconsList.Images.SetKeyName(459, "directory_web.ico");
            this.iconsList.Images.SetKeyName(460, "directory_zipper.ico");
            this.iconsList.Images.SetKeyName(461, "directory_zipper_alt.ico");
            this.iconsList.Images.SetKeyName(462, "directx.ico");
            this.iconsList.Images.SetKeyName(463, "directx_alt.ico");
            this.iconsList.Images.SetKeyName(464, "diskettes_copy.ico");
            this.iconsList.Images.SetKeyName(465, "display_properties.ico");
            this.iconsList.Images.SetKeyName(466, "doctor_watson.ico");
            this.iconsList.Images.SetKeyName(467, "document.ico");
            this.iconsList.Images.SetKeyName(468, "download.ico");
            this.iconsList.Images.SetKeyName(469, "drum_onestick.ico");
            this.iconsList.Images.SetKeyName(470, "eject_pc.ico");
            this.iconsList.Images.SetKeyName(471, "eject_pc_2.ico");
            this.iconsList.Images.SetKeyName(472, "eject_pc_cool.ico");
            this.iconsList.Images.SetKeyName(473, "eject_pc_shell32.ico");
            this.iconsList.Images.SetKeyName(474, "entire_network_globe.ico");
            this.iconsList.Images.SetKeyName(475, "envelope_closed.ico");
            this.iconsList.Images.SetKeyName(476, "envelope_open_sheet.ico");
            this.iconsList.Images.SetKeyName(477, "erase_file.ico");
            this.iconsList.Images.SetKeyName(478, "event_log.ico");
            this.iconsList.Images.SetKeyName(479, "executable.ico");
            this.iconsList.Images.SetKeyName(480, "executable_gear.ico");
            this.iconsList.Images.SetKeyName(481, "executable_script.ico");
            this.iconsList.Images.SetKeyName(482, "executable_sound.ico");
            this.iconsList.Images.SetKeyName(483, "expand_hierarchial_array.ico");
            this.iconsList.Images.SetKeyName(484, "expansion_board.ico");
            this.iconsList.Images.SetKeyName(485, "expansion_board_modem.ico");
            this.iconsList.Images.SetKeyName(486, "fax_machine.ico");
            this.iconsList.Images.SetKeyName(487, "fax_machine_exclam.ico");
            this.iconsList.Images.SetKeyName(488, "fax_machine_paperstack.ico");
            this.iconsList.Images.SetKeyName(489, "file_blue_grad_paint.ico");
            this.iconsList.Images.SetKeyName(490, "file_cd.ico");
            this.iconsList.Images.SetKeyName(491, "file_eye.ico");
            this.iconsList.Images.SetKeyName(492, "file_gears.ico");
            this.iconsList.Images.SetKeyName(493, "file_lines.ico");
            this.iconsList.Images.SetKeyName(494, "file_padlock.ico");
            this.iconsList.Images.SetKeyName(495, "file_program_group.ico");
            this.iconsList.Images.SetKeyName(496, "file_question.ico");
            this.iconsList.Images.SetKeyName(497, "file_set.ico");
            this.iconsList.Images.SetKeyName(498, "file_sorted_lock.ico");
            this.iconsList.Images.SetKeyName(499, "file_win_shortcut.ico");
            this.iconsList.Images.SetKeyName(500, "file_windows.ico");
            this.iconsList.Images.SetKeyName(501, "filepack.ico");
            this.iconsList.Images.SetKeyName(502, "floppy_drive_3-5.ico");
            this.iconsList.Images.SetKeyName(503, "floppy_drive_3-5_cool.ico");
            this.iconsList.Images.SetKeyName(504, "floppy_drive_5-25.ico");
            this.iconsList.Images.SetKeyName(505, "floppy_drive_5-25_cool.ico");
            this.iconsList.Images.SetKeyName(506, "font_adobe.ico");
            this.iconsList.Images.SetKeyName(507, "font_bitmap.ico");
            this.iconsList.Images.SetKeyName(508, "font_opentype.ico");
            this.iconsList.Images.SetKeyName(509, "font_tt.ico");
            this.iconsList.Images.SetKeyName(510, "font_tt_green.ico");
            this.iconsList.Images.SetKeyName(511, "frame_web.ico");
            this.iconsList.Images.SetKeyName(512, "game_freecell.ico");
            this.iconsList.Images.SetKeyName(513, "game_hearts.ico");
            this.iconsList.Images.SetKeyName(514, "game_mine_1.ico");
            this.iconsList.Images.SetKeyName(515, "game_mine_2.ico");
            this.iconsList.Images.SetKeyName(516, "game_solitaire.ico");
            this.iconsList.Images.SetKeyName(517, "game_spider.ico");
            this.iconsList.Images.SetKeyName(518, "gears.ico");
            this.iconsList.Images.SetKeyName(519, "gears_3.ico");
            this.iconsList.Images.SetKeyName(520, "gears_tweakui_a.ico");
            this.iconsList.Images.SetKeyName(521, "gears_tweakui_b.ico");
            this.iconsList.Images.SetKeyName(522, "globe_map.ico");
            this.iconsList.Images.SetKeyName(523, "gps.ico");
            this.iconsList.Images.SetKeyName(524, "graphedit.ico");
            this.iconsList.Images.SetKeyName(525, "graphedit_file.ico");
            this.iconsList.Images.SetKeyName(526, "graphedit_file_2.ico");
            this.iconsList.Images.SetKeyName(527, "hard_disk_drive.ico");
            this.iconsList.Images.SetKeyName(528, "hard_disk_drive_cool.ico");
            this.iconsList.Images.SetKeyName(529, "hard_disk_drive_pie.ico");
            this.iconsList.Images.SetKeyName(530, "hard_disk_drive_tools.ico");
            this.iconsList.Images.SetKeyName(531, "hard_disk_drives.ico");
            this.iconsList.Images.SetKeyName(532, "hardware.ico");
            this.iconsList.Images.SetKeyName(533, "help_book_big.ico");
            this.iconsList.Images.SetKeyName(534, "help_book_computer.ico");
            this.iconsList.Images.SetKeyName(535, "help_book_cool.ico");
            this.iconsList.Images.SetKeyName(536, "help_book_cool_small.ico");
            this.iconsList.Images.SetKeyName(537, "help_book_small.ico");
            this.iconsList.Images.SetKeyName(538, "help_question_mark.ico");
            this.iconsList.Images.SetKeyName(539, "help_sheet.ico");
            this.iconsList.Images.SetKeyName(540, "history.ico");
            this.iconsList.Images.SetKeyName(541, "homepage.ico");
            this.iconsList.Images.SetKeyName(542, "homepage_alt.ico");
            this.iconsList.Images.SetKeyName(543, "html.ico");
            this.iconsList.Images.SetKeyName(544, "html2.ico");
            this.iconsList.Images.SetKeyName(545, "html2_new.ico");
            this.iconsList.Images.SetKeyName(546, "channels.ico");
            this.iconsList.Images.SetKeyName(547, "channels_file.ico");
            this.iconsList.Images.SetKeyName(548, "charmap.ico");
            this.iconsList.Images.SetKeyName(549, "charmap_w2k.ico");
            this.iconsList.Images.SetKeyName(550, "chart1.ico");
            this.iconsList.Images.SetKeyName(551, "check.ico");
            this.iconsList.Images.SetKeyName(552, "chip_ramdrive.ico");
            this.iconsList.Images.SetKeyName(553, "chm.ico");
            this.iconsList.Images.SetKeyName(554, "image_old_gif.ico");
            this.iconsList.Images.SetKeyName(555, "image_old_jpeg.ico");
            this.iconsList.Images.SetKeyName(556, "imagGIF.ico");
            this.iconsList.Images.SetKeyName(557, "imagJPEG.ico");
            this.iconsList.Images.SetKeyName(558, "imagKoda.ico");
            this.iconsList.Images.SetKeyName(559, "imagOthe.ico");
            this.iconsList.Images.SetKeyName(560, "imagPNG.ico");
            this.iconsList.Images.SetKeyName(561, "imagWMF.ico");
            this.iconsList.Images.SetKeyName(562, "infrared.ico");
            this.iconsList.Images.SetKeyName(563, "input_devices.ico");
            this.iconsList.Images.SetKeyName(564, "installer.ico");
            this.iconsList.Images.SetKeyName(565, "installer_file_gear.ico");
            this.iconsList.Images.SetKeyName(566, "installer_generic_old.ico");
            this.iconsList.Images.SetKeyName(567, "internet_connection_wiz.ico");
            this.iconsList.Images.SetKeyName(568, "internet_options.ico");
            this.iconsList.Images.SetKeyName(569, "internet_options_old_e.ico");
            this.iconsList.Images.SetKeyName(570, "ipconfig.ico");
            this.iconsList.Images.SetKeyName(571, "java.ico");
            this.iconsList.Images.SetKeyName(572, "java_dpf.ico");
            this.iconsList.Images.SetKeyName(573, "java_ocx.ico");
            this.iconsList.Images.SetKeyName(574, "joystick.ico");
            this.iconsList.Images.SetKeyName(575, "joystick_alt.ico");
            this.iconsList.Images.SetKeyName(576, "joystick_button.ico");
            this.iconsList.Images.SetKeyName(577, "key_gray.ico");
            this.iconsList.Images.SetKeyName(578, "key_padlock.ico");
            this.iconsList.Images.SetKeyName(579, "key_padlock_help.ico");
            this.iconsList.Images.SetKeyName(580, "key_webfile.ico");
            this.iconsList.Images.SetKeyName(581, "key_win.ico");
            this.iconsList.Images.SetKeyName(582, "key_win_alt.ico");
            this.iconsList.Images.SetKeyName(583, "key_world.ico");
            this.iconsList.Images.SetKeyName(584, "keyboard.ico");
            this.iconsList.Images.SetKeyName(585, "keyboard_delay.ico");
            this.iconsList.Images.SetKeyName(586, "keyboard_musical.ico");
            this.iconsList.Images.SetKeyName(587, "keyboard_musical_midi.ico");
            this.iconsList.Images.SetKeyName(588, "keyboard_repeat_rate.ico");
            this.iconsList.Images.SetKeyName(589, "keys.ico");
            this.iconsList.Images.SetKeyName(590, "kodak_imaging.ico");
            this.iconsList.Images.SetKeyName(591, "kodak_imaging_file.ico");
            this.iconsList.Images.SetKeyName(592, "laptop.ico");
            this.iconsList.Images.SetKeyName(593, "laptop_infrared.ico");
            this.iconsList.Images.SetKeyName(594, "laptop_infrared_2.ico");
            this.iconsList.Images.SetKeyName(595, "laptop_small.ico");
            this.iconsList.Images.SetKeyName(596, "loudspeaker_muted.ico");
            this.iconsList.Images.SetKeyName(597, "loudspeaker_rays.ico");
            this.iconsList.Images.SetKeyName(598, "loudspeaker_rays_green.ico");
            this.iconsList.Images.SetKeyName(599, "loudspeaker_wave.ico");
            this.iconsList.Images.SetKeyName(600, "magnifying_glass.ico");
            this.iconsList.Images.SetKeyName(601, "magnifying_glass_3.ico");
            this.iconsList.Images.SetKeyName(602, "magnifying_glass_4.ico");
            this.iconsList.Images.SetKeyName(603, "mailbox_world.ico");
            this.iconsList.Images.SetKeyName(604, "mci_devices.ico");
            this.iconsList.Images.SetKeyName(605, "media_player.ico");
            this.iconsList.Images.SetKeyName(606, "media_player_file.ico");
            this.iconsList.Images.SetKeyName(607, "media_player_stream_conn1.ico");
            this.iconsList.Images.SetKeyName(608, "media_player_stream_conn2.ico");
            this.iconsList.Images.SetKeyName(609, "media_player_stream_mono.ico");
            this.iconsList.Images.SetKeyName(610, "media_player_stream_no.ico");
            this.iconsList.Images.SetKeyName(611, "media_player_stream_no2.ico");
            this.iconsList.Images.SetKeyName(612, "media_player_stream_stereo.ico");
            this.iconsList.Images.SetKeyName(613, "media_player_stream_sun0.ico");
            this.iconsList.Images.SetKeyName(614, "media_player_stream_sun1.ico");
            this.iconsList.Images.SetKeyName(615, "media_player_stream_sun2.ico");
            this.iconsList.Images.SetKeyName(616, "media_player_stream_sun3.ico");
            this.iconsList.Images.SetKeyName(617, "media_player_stream_sun4.ico");
            this.iconsList.Images.SetKeyName(618, "memory.ico");
            this.iconsList.Images.SetKeyName(619, "message_empty_tack.ico");
            this.iconsList.Images.SetKeyName(620, "message_envelope_open.ico");
            this.iconsList.Images.SetKeyName(621, "message_file.ico");
            this.iconsList.Images.SetKeyName(622, "message_tack.ico");
            this.iconsList.Images.SetKeyName(623, "microphone.ico");
            this.iconsList.Images.SetKeyName(624, "microphone_2.ico");
            this.iconsList.Images.SetKeyName(625, "midi_bl.ico");
            this.iconsList.Images.SetKeyName(626, "midi_gr.ico");
            this.iconsList.Images.SetKeyName(627, "midi_mg.ico");
            this.iconsList.Images.SetKeyName(628, "midi_tl.ico");
            this.iconsList.Images.SetKeyName(629, "minesweeper.ico");
            this.iconsList.Images.SetKeyName(630, "mixer_cd_sound.ico");
            this.iconsList.Images.SetKeyName(631, "mixer_keyboard_musical.ico");
            this.iconsList.Images.SetKeyName(632, "mixer_sound.ico");
            this.iconsList.Images.SetKeyName(633, "modem.ico");
            this.iconsList.Images.SetKeyName(634, "monitor_application.ico");
            this.iconsList.Images.SetKeyName(635, "monitor_black.ico");
            this.iconsList.Images.SetKeyName(636, "monitor_blue_grad.ico");
            this.iconsList.Images.SetKeyName(637, "monitor_gear.ico");
            this.iconsList.Images.SetKeyName(638, "monitor_moon.ico");
            this.iconsList.Images.SetKeyName(639, "monitor_tweakui.ico");
            this.iconsList.Images.SetKeyName(640, "monitor_windows.ico");
            this.iconsList.Images.SetKeyName(641, "mouse.ico");
            this.iconsList.Images.SetKeyName(642, "mouse_hide.ico");
            this.iconsList.Images.SetKeyName(643, "mouse_location.ico");
            this.iconsList.Images.SetKeyName(644, "mouse_ms.ico");
            this.iconsList.Images.SetKeyName(645, "mouse_padlock.ico");
            this.iconsList.Images.SetKeyName(646, "mouse_snap.ico");
            this.iconsList.Images.SetKeyName(647, "mouse_speed.ico");
            this.iconsList.Images.SetKeyName(648, "mouse_trails.ico");
            this.iconsList.Images.SetKeyName(649, "mouse_wireless.ico");
            this.iconsList.Images.SetKeyName(650, "move_system_file.ico");
            this.iconsList.Images.SetKeyName(651, "movie_maker.ico");
            this.iconsList.Images.SetKeyName(652, "msagent.ico");
            this.iconsList.Images.SetKeyName(653, "msagent_file.ico");
            this.iconsList.Images.SetKeyName(654, "msconfig.ico");
            this.iconsList.Images.SetKeyName(655, "ms-dos.ico");
            this.iconsList.Images.SetKeyName(656, "ms-dos_2.ico");
            this.iconsList.Images.SetKeyName(657, "msg_error.ico");
            this.iconsList.Images.SetKeyName(658, "msg_information.ico");
            this.iconsList.Images.SetKeyName(659, "msg_question.ico");
            this.iconsList.Images.SetKeyName(660, "msg_warning.ico");
            this.iconsList.Images.SetKeyName(661, "msg_warning_inv.ico");
            this.iconsList.Images.SetKeyName(662, "mshearts.ico");
            this.iconsList.Images.SetKeyName(663, "msie_box.ico");
            this.iconsList.Images.SetKeyName(664, "msie1.ico");
            this.iconsList.Images.SetKeyName(665, "msie2.ico");
            this.iconsList.Images.SetKeyName(666, "msinfo32.ico");
            this.iconsList.Images.SetKeyName(667, "msn.ico");
            this.iconsList.Images.SetKeyName(668, "msn_cool.ico");
            this.iconsList.Images.SetKeyName(669, "msn2.ico");
            this.iconsList.Images.SetKeyName(670, "msn3.ico");
            this.iconsList.Images.SetKeyName(671, "multimedia.ico");
            this.iconsList.Images.SetKeyName(672, "nail.ico");
            this.iconsList.Images.SetKeyName(673, "netmeeting.ico");
            this.iconsList.Images.SetKeyName(674, "netmeeting_share.ico");
            this.iconsList.Images.SetKeyName(675, "netshow.ico");
            this.iconsList.Images.SetKeyName(676, "netshow_arrow.ico");
            this.iconsList.Images.SetKeyName(677, "netshow_notransm.ico");
            this.iconsList.Images.SetKeyName(678, "network.ico");
            this.iconsList.Images.SetKeyName(679, "network_cool_two_pcs.ico");
            this.iconsList.Images.SetKeyName(680, "network_drive.ico");
            this.iconsList.Images.SetKeyName(681, "network_drive_cool.ico");
            this.iconsList.Images.SetKeyName(682, "network_drive_unavailable.ico");
            this.iconsList.Images.SetKeyName(683, "network_drive_unavailable_cool.ico");
            this.iconsList.Images.SetKeyName(684, "network_drive_world.ico");
            this.iconsList.Images.SetKeyName(685, "network_internet_pcs_installer.ico");
            this.iconsList.Images.SetKeyName(686, "network_normal_two_pcs.ico");
            this.iconsList.Images.SetKeyName(687, "network_television.ico");
            this.iconsList.Images.SetKeyName(688, "network_televisons.ico");
            this.iconsList.Images.SetKeyName(689, "network_three_pcs.ico");
            this.iconsList.Images.SetKeyName(690, "newspaper.ico");
            this.iconsList.Images.SetKeyName(691, "newspaper_mail.ico");
            this.iconsList.Images.SetKeyName(692, "no.ico");
            this.iconsList.Images.SetKeyName(693, "no2.ico");
            this.iconsList.Images.SetKeyName(694, "note.ico");
            this.iconsList.Images.SetKeyName(695, "notepad.ico");
            this.iconsList.Images.SetKeyName(696, "notepad_file.ico");
            this.iconsList.Images.SetKeyName(697, "notepad_file_gear.ico");
            this.iconsList.Images.SetKeyName(698, "odbc.ico");
            this.iconsList.Images.SetKeyName(699, "ole.ico");
            this.iconsList.Images.SetKeyName(700, "ole2.ico");
            this.iconsList.Images.SetKeyName(701, "outlook_express.ico");
            this.iconsList.Images.SetKeyName(702, "outlook_express_tack.ico");
            this.iconsList.Images.SetKeyName(703, "outlook_express_tack_drive.ico");
            this.iconsList.Images.SetKeyName(704, "outlook_express_tack_folder.ico");
            this.iconsList.Images.SetKeyName(705, "overlay_black.ico");
            this.iconsList.Images.SetKeyName(706, "overlay_refresh.ico");
            this.iconsList.Images.SetKeyName(707, "overlay_share.ico");
            this.iconsList.Images.SetKeyName(708, "overlay_share_cool.ico");
            this.iconsList.Images.SetKeyName(709, "overlay_shortcut.ico");
            this.iconsList.Images.SetKeyName(710, "package.ico");
            this.iconsList.Images.SetKeyName(711, "paint.ico");
            this.iconsList.Images.SetKeyName(712, "paint_file.ico");
            this.iconsList.Images.SetKeyName(713, "paint_old.ico");
            this.iconsList.Images.SetKeyName(714, "paint_window.ico");
            this.iconsList.Images.SetKeyName(715, "paintbrush.ico");
            this.iconsList.Images.SetKeyName(716, "palm_computer.ico");
            this.iconsList.Images.SetKeyName(717, "paper_roll.ico");
            this.iconsList.Images.SetKeyName(718, "pci_card.ico");
            this.iconsList.Images.SetKeyName(719, "pci_card_alt.ico");
            this.iconsList.Images.SetKeyName(720, "pcx.ico");
            this.iconsList.Images.SetKeyName(721, "pcx_alt.ico");
            this.iconsList.Images.SetKeyName(722, "phone_desk.ico");
            this.iconsList.Images.SetKeyName(723, "pictures.ico");
            this.iconsList.Images.SetKeyName(724, "pie_chart_drvspace.ico");
            this.iconsList.Images.SetKeyName(725, "pifedit.ico");
            this.iconsList.Images.SetKeyName(726, "power_management.ico");
            this.iconsList.Images.SetKeyName(727, "print_server.ico");
            this.iconsList.Images.SetKeyName(728, "printer.ico");
            this.iconsList.Images.SetKeyName(729, "printer_big.ico");
            this.iconsList.Images.SetKeyName(730, "printer_cool.ico");
            this.iconsList.Images.SetKeyName(731, "printer_def.ico");
            this.iconsList.Images.SetKeyName(732, "printer_def_diskette.ico");
            this.iconsList.Images.SetKeyName(733, "printer_def_network.ico");
            this.iconsList.Images.SetKeyName(734, "printer_desk.ico");
            this.iconsList.Images.SetKeyName(735, "printer_diskette.ico");
            this.iconsList.Images.SetKeyName(736, "printer_feeding_slot.ico");
            this.iconsList.Images.SetKeyName(737, "printer_network.ico");
            this.iconsList.Images.SetKeyName(738, "printer_pause.ico");
            this.iconsList.Images.SetKeyName(739, "printer_play.ico");
            this.iconsList.Images.SetKeyName(740, "printer_plotter.ico");
            this.iconsList.Images.SetKeyName(741, "printer_question.ico");
            this.iconsList.Images.SetKeyName(742, "printer_shared.ico");
            this.iconsList.Images.SetKeyName(743, "printer_slim.ico");
            this.iconsList.Images.SetKeyName(744, "printer_slot_filled.ico");
            this.iconsList.Images.SetKeyName(745, "processor.ico");
            this.iconsList.Images.SetKeyName(746, "program_manager.ico");
            this.iconsList.Images.SetKeyName(747, "ram_drive.ico");
            this.iconsList.Images.SetKeyName(748, "recycle_bin_directory.ico");
            this.iconsList.Images.SetKeyName(749, "recycle_bin_empty.ico");
            this.iconsList.Images.SetKeyName(750, "recycle_bin_empty_2k.ico");
            this.iconsList.Images.SetKeyName(751, "recycle_bin_empty_cool.ico");
            this.iconsList.Images.SetKeyName(752, "recycle_bin_file.ico");
            this.iconsList.Images.SetKeyName(753, "recycle_bin_file_directory.ico");
            this.iconsList.Images.SetKeyName(754, "recycle_bin_full.ico");
            this.iconsList.Images.SetKeyName(755, "recycle_bin_full_2k.ico");
            this.iconsList.Images.SetKeyName(756, "recycle_bin_full_cool.ico");
            this.iconsList.Images.SetKeyName(757, "regedit.ico");
            this.iconsList.Images.SetKeyName(758, "regedit_binary.ico");
            this.iconsList.Images.SetKeyName(759, "regedit_binary_lock.ico");
            this.iconsList.Images.SetKeyName(760, "regedit_file.ico");
            this.iconsList.Images.SetKeyName(761, "regedit_string.ico");
            this.iconsList.Images.SetKeyName(762, "registration.ico");
            this.iconsList.Images.SetKeyName(763, "registration_no.ico");
            this.iconsList.Images.SetKeyName(764, "removable_disk_drive.ico");
            this.iconsList.Images.SetKeyName(765, "removable_disk_drive_alt.ico");
            this.iconsList.Images.SetKeyName(766, "rename.ico");
            this.iconsList.Images.SetKeyName(767, "replace_directory.ico");
            this.iconsList.Images.SetKeyName(768, "replace_file.ico");
            this.iconsList.Images.SetKeyName(769, "restrict.ico");
            this.iconsList.Images.SetKeyName(770, "rj_jack.ico");
            this.iconsList.Images.SetKeyName(771, "Roland_GS.ico");
            this.iconsList.Images.SetKeyName(772, "scandisk.ico");
            this.iconsList.Images.SetKeyName(773, "scanner.ico");
            this.iconsList.Images.SetKeyName(774, "scanner_alt.ico");
            this.iconsList.Images.SetKeyName(775, "scanner_alt_network.ico");
            this.iconsList.Images.SetKeyName(776, "scanner_camera.ico");
            this.iconsList.Images.SetKeyName(777, "scanner_video_cam.ico");
            this.iconsList.Images.SetKeyName(778, "scanregw.ico");
            this.iconsList.Images.SetKeyName(779, "screen_keyboard.ico");
            this.iconsList.Images.SetKeyName(780, "script_file_blue.ico");
            this.iconsList.Images.SetKeyName(781, "script_file_teal.ico");
            this.iconsList.Images.SetKeyName(782, "script_file_yellow.ico");
            this.iconsList.Images.SetKeyName(783, "scsi.ico");
            this.iconsList.Images.SetKeyName(784, "search_computer.ico");
            this.iconsList.Images.SetKeyName(785, "search_directory.ico");
            this.iconsList.Images.SetKeyName(786, "search_file.ico");
            this.iconsList.Images.SetKeyName(787, "search_file_2.ico");
            this.iconsList.Images.SetKeyName(788, "search_file_2_cool.ico");
            this.iconsList.Images.SetKeyName(789, "search_file_3.ico");
            this.iconsList.Images.SetKeyName(790, "search_laptop_1.ico");
            this.iconsList.Images.SetKeyName(791, "search_laptop_2.ico");
            this.iconsList.Images.SetKeyName(792, "search_laptop_3.ico");
            this.iconsList.Images.SetKeyName(793, "search_laptop_4.ico");
            this.iconsList.Images.SetKeyName(794, "search_server.ico");
            this.iconsList.Images.SetKeyName(795, "search_web.ico");
            this.iconsList.Images.SetKeyName(796, "server_gear.ico");
            this.iconsList.Images.SetKeyName(797, "server_to_desktop.ico");
            this.iconsList.Images.SetKeyName(798, "server_window.ico");
            this.iconsList.Images.SetKeyName(799, "settings_gear.ico");
            this.iconsList.Images.SetKeyName(800, "settings_gear_cool.ico");
            this.iconsList.Images.SetKeyName(801, "shell_window1.ico");
            this.iconsList.Images.SetKeyName(802, "shell_window2.ico");
            this.iconsList.Images.SetKeyName(803, "shell_window3.ico");
            this.iconsList.Images.SetKeyName(804, "shell_window4.ico");
            this.iconsList.Images.SetKeyName(805, "shell_window5.ico");
            this.iconsList.Images.SetKeyName(806, "shell_window6.ico");
            this.iconsList.Images.SetKeyName(807, "shut_down_cool.ico");
            this.iconsList.Images.SetKeyName(808, "shut_down_normal.ico");
            this.iconsList.Images.SetKeyName(809, "shut_down_with_computer.ico");
            this.iconsList.Images.SetKeyName(810, "sched_tasks.ico");
            this.iconsList.Images.SetKeyName(811, "signature.ico");
            this.iconsList.Images.SetKeyName(812, "signature_excl.ico");
            this.iconsList.Images.SetKeyName(813, "signature_no.ico");
            this.iconsList.Images.SetKeyName(814, "sndvol32_input.ico");
            this.iconsList.Images.SetKeyName(815, "sndvol32_main.ico");
            this.iconsList.Images.SetKeyName(816, "sndvol32_output.ico");
            this.iconsList.Images.SetKeyName(817, "SoundGrn.ico");
            this.iconsList.Images.SetKeyName(818, "SoundPu2.ico");
            this.iconsList.Images.SetKeyName(819, "SoundPur.ico");
            this.iconsList.Images.SetKeyName(820, "SoundTel.ico");
            this.iconsList.Images.SetKeyName(821, "SoundVor.ico");
            this.iconsList.Images.SetKeyName(822, "SoundYel.ico");
            this.iconsList.Images.SetKeyName(823, "spider.ico");
            this.iconsList.Images.SetKeyName(824, "standby_monitor_moon.ico");
            this.iconsList.Images.SetKeyName(825, "standby_monitor_moon_cool.ico");
            this.iconsList.Images.SetKeyName(826, "start_menu_shortcuts.ico");
            this.iconsList.Images.SetKeyName(827, "start_menu_xp.ico");
            this.iconsList.Images.SetKeyName(828, "system_restore.ico");
            this.iconsList.Images.SetKeyName(829, "telephony.ico");
            this.iconsList.Images.SetKeyName(830, "template_directory_net_web.ico");
            this.iconsList.Images.SetKeyName(831, "template_empty.ico");
            this.iconsList.Images.SetKeyName(832, "template_nework_conn.ico");
            this.iconsList.Images.SetKeyName(833, "template_nework_places.ico");
            this.iconsList.Images.SetKeyName(834, "template_printer.ico");
            this.iconsList.Images.SetKeyName(835, "template_scanner_camera.ico");
            this.iconsList.Images.SetKeyName(836, "template_sched_task.ico");
            this.iconsList.Images.SetKeyName(837, "template_world.ico");
            this.iconsList.Images.SetKeyName(838, "themes.ico");
            this.iconsList.Images.SetKeyName(839, "time_and_date.ico");
            this.iconsList.Images.SetKeyName(840, "tip.ico");
            this.iconsList.Images.SetKeyName(841, "tools_gear.ico");
            this.iconsList.Images.SetKeyName(842, "tree.ico");
            this.iconsList.Images.SetKeyName(843, "true_type_paint.ico");
            this.iconsList.Images.SetKeyName(844, "trust0.ico");
            this.iconsList.Images.SetKeyName(845, "trust1_restrict.ico");
            this.iconsList.Images.SetKeyName(846, "tune-up.ico");
            this.iconsList.Images.SetKeyName(847, "unplug_eject_pc.ico");
            this.iconsList.Images.SetKeyName(848, "unplug_storage.ico");
            this.iconsList.Images.SetKeyName(849, "ups.ico");
            this.iconsList.Images.SetKeyName(850, "url1.ico");
            this.iconsList.Images.SetKeyName(851, "url1a.ico");
            this.iconsList.Images.SetKeyName(852, "url2.ico");
            this.iconsList.Images.SetKeyName(853, "usb.ico");
            this.iconsList.Images.SetKeyName(854, "usb_port.ico");
            this.iconsList.Images.SetKeyName(855, "user_calendar.ico");
            this.iconsList.Images.SetKeyName(856, "user_card.ico");
            this.iconsList.Images.SetKeyName(857, "user_card_view.ico");
            this.iconsList.Images.SetKeyName(858, "user_computer.ico");
            this.iconsList.Images.SetKeyName(859, "user_computer_pair.ico");
            this.iconsList.Images.SetKeyName(860, "user_network.ico");
            this.iconsList.Images.SetKeyName(861, "user_world.ico");
            this.iconsList.Images.SetKeyName(862, "users.ico");
            this.iconsList.Images.SetKeyName(863, "users_green.ico");
            this.iconsList.Images.SetKeyName(864, "users_key.ico");
            this.iconsList.Images.SetKeyName(865, "utopia_smiley.ico");
            this.iconsList.Images.SetKeyName(866, "video_.ico");
            this.iconsList.Images.SetKeyName(867, "video_compression.ico");
            this.iconsList.Images.SetKeyName(868, "video_gr.ico");
            this.iconsList.Images.SetKeyName(869, "video_mg.ico");
            this.iconsList.Images.SetKeyName(870, "video_mk.ico");
            this.iconsList.Images.SetKeyName(871, "video_tl.ico");
            this.iconsList.Images.SetKeyName(872, "web_file.ico");
            this.iconsList.Images.SetKeyName(873, "web_file_set.ico");
            this.iconsList.Images.SetKeyName(874, "wia_img_a.ico");
            this.iconsList.Images.SetKeyName(875, "wia_img_color.ico");
            this.iconsList.Images.SetKeyName(876, "wia_img_color_sound.ico");
            this.iconsList.Images.SetKeyName(877, "wia_img_gray.ico");
            this.iconsList.Images.SetKeyName(878, "wia_img_check.ico");
            this.iconsList.Images.SetKeyName(879, "window_red_hilights.ico");
            this.iconsList.Images.SetKeyName(880, "windows.ico");
            this.iconsList.Images.SetKeyName(881, "windows_button.ico");
            this.iconsList.Images.SetKeyName(882, "windows_movie.ico");
            this.iconsList.Images.SetKeyName(883, "windows_slanted.ico");
            this.iconsList.Images.SetKeyName(884, "windows_three.ico");
            this.iconsList.Images.SetKeyName(885, "windows_title.ico");
            this.iconsList.Images.SetKeyName(886, "windows_update_large.ico");
            this.iconsList.Images.SetKeyName(887, "windows_update_old.ico");
            this.iconsList.Images.SetKeyName(888, "windows_update_small.ico");
            this.iconsList.Images.SetKeyName(889, "winhelp_small_icons.png");
            this.iconsList.Images.SetKeyName(890, "WinRep.ico");
            this.iconsList.Images.SetKeyName(891, "winrep_mag_glass.ico");
            this.iconsList.Images.SetKeyName(892, "wm.ico");
            this.iconsList.Images.SetKeyName(893, "wm_file.ico");
            this.iconsList.Images.SetKeyName(894, "world.ico");
            this.iconsList.Images.SetKeyName(895, "world_address_book.ico");
            this.iconsList.Images.SetKeyName(896, "world_lock.ico");
            this.iconsList.Images.SetKeyName(897, "world_network_directories.ico");
            this.iconsList.Images.SetKeyName(898, "world_phonereceiver.ico");
            this.iconsList.Images.SetKeyName(899, "world_star.ico");
            this.iconsList.Images.SetKeyName(900, "write_card_phone.ico");
            this.iconsList.Images.SetKeyName(901, "write_file.ico");
            this.iconsList.Images.SetKeyName(902, "write_red.ico");
            this.iconsList.Images.SetKeyName(903, "write_wordpad.ico");
            this.iconsList.Images.SetKeyName(904, "write_yellow.ico");
            this.iconsList.Images.SetKeyName(905, "xml.ico");
            this.iconsList.Images.SetKeyName(906, "xml_gear.ico");
            this.iconsList.Images.SetKeyName(907, "salam.ico");
            this.iconsList.Images.SetKeyName(908, "cruel.ico");
            this.iconsList.Images.SetKeyName(909, "freecell.ico");
            this.iconsList.Images.SetKeyName(910, "golf.ico");
            this.iconsList.Images.SetKeyName(911, "paint.ico");
            this.iconsList.Images.SetKeyName(912, "pegged.ico");
            this.iconsList.Images.SetKeyName(913, "reversi.ico");
            this.iconsList.Images.SetKeyName(914, "snake.ico");
            this.iconsList.Images.SetKeyName(915, "tictac.ico");
            this.iconsList.Images.SetKeyName(916, "taipei.ico");
            this.iconsList.Images.SetKeyName(917, "tetris.ico");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(3, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 397);
            this.panel1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(793, 397);
            this.splitContainer1.SplitterDistance = 535;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.listView1.LargeImageList = this.iconsList;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(791, 395);
            this.listView1.SmallImageList = this.iconsList;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // toolbarMenu
            // 
            this.toolbarMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolbarMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbarMenu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolbarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.toolbarMenu.Location = new System.Drawing.Point(2, 0);
            this.toolbarMenu.Name = "toolbarMenu";
            this.toolbarMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolbarMenu.Size = new System.Drawing.Size(197, 22);
            this.toolbarMenu.TabIndex = 4;
            this.toolbarMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 18);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeyDisplayString = "Win+R";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.runToolStripMenuItem.Text = "&Run...";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(144, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exitToolStripMenuItem.Text = "E&xit Windows";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 18);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accessoriesToolStripMenuItem,
            this.networkToolStripMenuItem,
            this.gamesToolStripMenuItem,
            this.mainToolStripMenuItem,
            this.toolStripSeparator1,
            this.reloadShortcutsToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 18);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // accessoriesToolStripMenuItem
            // 
            this.accessoriesToolStripMenuItem.Name = "accessoriesToolStripMenuItem";
            this.accessoriesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.accessoriesToolStripMenuItem.Text = "&1 Accessories";
            this.accessoriesToolStripMenuItem.Click += new System.EventHandler(this.accessoriesToolStripMenuItem_Click);
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.networkToolStripMenuItem.Text = "&2 Network";
            this.networkToolStripMenuItem.Click += new System.EventHandler(this.networkToolStripMenuItem_Click);
            // 
            // gamesToolStripMenuItem
            // 
            this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
            this.gamesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.gamesToolStripMenuItem.Text = "&3 Games";
            this.gamesToolStripMenuItem.Click += new System.EventHandler(this.gamesToolStripMenuItem_Click);
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Checked = true;
            this.mainToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.mainToolStripMenuItem.Text = "&4 Main";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.mainToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // reloadShortcutsToolStripMenuItem
            // 
            this.reloadShortcutsToolStripMenuItem.Name = "reloadShortcutsToolStripMenuItem";
            this.reloadShortcutsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.reloadShortcutsToolStripMenuItem.Text = "&Reload Shortcuts";
            this.reloadShortcutsToolStripMenuItem.Click += new System.EventHandler(this.reloadShortcutsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 18);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(155, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.aboutToolStripMenuItem.Text = "&About Windows";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolbarPanel
            // 
            this.toolbarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolbarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolbarPanel.Controls.Add(this.toolbarMenu);
            this.toolbarPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolbarPanel.Location = new System.Drawing.Point(3, 24);
            this.toolbarPanel.MinimumSize = new System.Drawing.Size(3, 25);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(793, 25);
            this.toolbarPanel.TabIndex = 5;
            // 
            // noSelectButton1
            // 
            this.noSelectButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.noSelectButton1.BackgroundImage = global::Win113.Shell.Properties.Resources.main;
            this.noSelectButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.noSelectButton1.FlatAppearance.BorderSize = 0;
            this.noSelectButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noSelectButton1.Location = new System.Drawing.Point(4, 4);
            this.noSelectButton1.Name = "noSelectButton1";
            this.noSelectButton1.Size = new System.Drawing.Size(20, 20);
            this.noSelectButton1.TabIndex = 2;
            this.noSelectButton1.UseVisualStyleBackColor = false;
            this.noSelectButton1.Click += new System.EventHandler(this.noSelectButton1_Click);
            this.noSelectButton1.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.BackgroundImage = global::Win113.Shell.Properties.Resources.maximize;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(776, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button2.BackgroundImage = global::Win113.Shell.Properties.Resources.minimize;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(756, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint);
            // 
            // ProgramManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolbarPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.noSelectButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.toolbarMenu;
            this.Name = "ProgramManager";
            this.Text = "Program Manager";
            this.Activated += new System.EventHandler(this.Form1_Deactivate);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramManager_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolbarMenu.ResumeLayout(false);
            this.toolbarMenu.PerformLayout();
            this.toolbarPanel.ResumeLayout(false);
            this.toolbarPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NoSelectButton button1;
        private NoSelectButton button2;
        private NoSelectButton noSelectButton1;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip toolbarMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accessoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem reloadShortcutsToolStripMenuItem;
    }
}

