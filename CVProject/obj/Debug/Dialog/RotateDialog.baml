   M S B A M L   `   `   `  ����D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  5   	   #    CVProject.Dialog.RotateDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CVProject.Dialog     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Rotate��5	   	   $��94��6   $	��300��6$   ���	#FF363636 � WindowStartupLocation$ CenterScreen=�6G   .��5
      � .+�5   
   �� -   5         ��Name$ label��5      $��Degree��6   $
��Left=�60   $��	10,12,0,0q�6K   $	��Top=�6^   %  Xceed.Wpf.Toolkit.DecimalUpDown  5   
   -   5        $��degree��5      $
��Left=�6+   $��	90,10,0,0q�6F   $	��Top=�6Y   $��60��6q   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$	 360X�6|      Minimum$ 0X�6�   �� 5   
   -   5        $ label_Copy1��5      $��Resize Mode��6%   $
��Left=�6;   $��9,37,0,0q�6V   $	��Top=�6h   �� 5   
   -   5         ��Name$ cboxMode��5      $
��Left=�6%   $��	87,35,0,0q�6@   $	��Top=�6S   $��60��6k    �� SelectedIndex$ 0��6y   .@�5      �� $��Nearest��6   �� 5      $��Linear��6   5      �� 5   
   -   5         ��Name$ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��
207,35,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ btnOK��5      $��OK��6    $
��Left=�6-   $��
207,10,0,0q�6H   $	��Top=�6\   $��75��6t   6   �� 5   
   -   5        $ 
label_Copy��5      $��°��6$   $
��Left=�60   $��
155,12,0,0q�6K   $	��Top=�6_   5      5      