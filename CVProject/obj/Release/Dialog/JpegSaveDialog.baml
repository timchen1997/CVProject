   M S B A M L   `   `   `  ���� D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  %    CVProject.Dialog.JpegSaveDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CVProject.Dialog     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  Save File - JPEG��$��113.334��$	��300�����	#FF363636 � WindowStyle$ 
ToolWindow=� � WindowStartupLocation$ CenterScreen=�.��� .+��� -    ��Name$ label��$0��*JPEG File Quality (The Higher The Better):��$
��Left=�$��	10,10,0,0q�$	��Top=��� -    ��Name$ slider��$
��Left=�$��	10,30,0,0q�$	��Top=�$	��211�� � Minimum$ 1Q� � Maximum$	 100Q� �� IsSnapToTickEnabled .  � Value$	 100Q��� -   $ label1��$
��Left=�$��
226,29,0,0q�$	��Top=�$��56������ 	 �� Path$	 Value�
 �� ElementName$
 slider���� -    ��Name$ btnOK��$��OK��$
��Left=�$��
207,49,0,0q�$	��Top=�$��75��$��23��