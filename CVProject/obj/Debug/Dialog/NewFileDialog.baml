   M S B A M L   `   `   `  ����D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  5   	   $    CVProject.Dialog.NewFileDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CVProject.Dialog     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  New File��5	   	   $	��114��6   $	��319��6'   ���	#FF363636 � WindowStyle$ 
ToolWindow=�6J    � WindowStartupLocation$ CenterScreen=�6c   .��5
      � .+�5   
   %  Xceed.Wpf.Toolkit.DecimalUpDown  -   5          Name$ Width��5      $
��Left=�6,   $��	52,10,0,0q�6G   $	��Top=�6Z   $��54��6r   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 65535X�6}      Minimum$ 1X�6�      Value$
 1920X�6�   �� 5   
   -   5         ��Name$ label��5      $��Width��6   $
��Left=�6/   $��	12,12,0,0q�6J   $	��Top=�6]     5   
   -   5        $ Height��5      $
��Left=�6-   $��
156,10,0,0q�6H   $	��Top=�6\   $��54��6t   $ 65535X�6   $ 1X�6�   $
 1080X�6�   �� 5   
   -   5        $ 
label_Copy��5      $��Height��6$   $
��Left=�65   $��
115,12,0,0q�6P   $	��Top=�6d     5   
   -   5        $	 Dpi��5      $
��Left=�6*   $��
246,10,0,0q�6E   $	��Top=�6Y   $��54��6q   $ 65535X�6|   $ 1X�6�   $ 72X�6�   �� 5   
   -   5        $ label_Copy1��5      $	��DPI��6%   $
��Left=�63   $��
219,12,0,0q�6N   $	��Top=�6b   �� 5   
   -   5         ��Name$ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��
226,51,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ btnOK��5      $��OK��6    $
��Left=�6-   $��
135,51,0,0q�6H   $	��Top=�6\   $��75��6t   	 �� 	IsDefault	 . 6�   5      5      