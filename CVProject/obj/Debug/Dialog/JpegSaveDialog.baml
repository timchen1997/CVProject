   M S B A M L   `   `   `  ����D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  5   	   %    CVProject.Dialog.JpegSaveDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CVProject.Dialog     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Save File - JPEG��5	   	   $��113.334��6"   $	��300��63   ���	#FF363636 � WindowStyle$ 
ToolWindow=�6V    � WindowStartupLocation$ CenterScreen=�6o   .��5
      � .+�5   
   �� -   5         ��Name$ label��5      $0��*JPEG File Quality (The Higher The Better):��6   $
��Left=�6T   $��	10,10,0,0q�6o   $	��Top=�6�   �� 5   
   -   5         ��Name$ slider��5      $
��Left=�6!   $��	10,30,0,0q�6<   $	��Top=�6O   $	��211��6g    � Minimum$ 1Q�6s    � Maximum$	 100Q�6    �� IsSnapToTickEnabled .  � Value$	 100Q�6�   �� 5   
   -   5        $ label1��5      $
��Left=�6S   $��
226,29,0,0q�6n   $	��Top=�6�   $��56��6�   ��6    �� 	 �� Path$	 Value�
 �� ElementName$
 slider��6�   �� 5   
   -   5         ��Name$ btnOK��5      $��OK��6    $
��Left=�6-   $��
207,49,0,0q�6H   $	��Top=�6\   $��75��6t   $��23��6   6�   5      5      