   M S B A M L   `   `   `  ����D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  5   	   "    CVProject.Dialog.PasteDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CVProject.Dialog     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Paste Image��5	   	   $��112.5��6   $	��300��6,   ���	#FF363636 � WindowStyle$ 
ToolWindow=�6O    � WindowStartupLocation$ CenterScreen=�6h   .��5
      � .+�5   
   �� -   5         ��Name$ label��5      $��OffsetX��6   $
��Left=�61   $��	28,10,0,0q�6L   $	��Top=�6_   %  Xceed.Wpf.Toolkit.IntegerUpDown  5   
   -   5        $
��OffX��5      $
��Left=�6)   $��77,7,0,0q�6D   $	��Top=�6V   $��50��6n   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 0X�6y   6�   �� 5   
   -   5        $ 
label_Copy��5      $��OffsetY��6$   $
��Left=�66   $��	167,9,0,0q�6Q   $	��Top=�6d     5   
   -   5        $
��OffY��5      $
��Left=�6)   $��	216,6,0,0q�6D   $	��Top=�6W   $��50��6o   $ 0X�6z   6�   �� 5   
   -   5         ��Name$ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��
207,46,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ btnOK��5      $��OK��6    $
��Left=�6-   $��
110,46,0,0q�6H   $	��Top=�6\   $��75��6t    �� 	IsDefault . 6�   5      5      