   M S B A M L   `   `   `  ����D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  5   	   '    !CVProject.Dialog.ArithmeticDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CVProject.Dialog     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Arithmetic Operation��5	   	   $	��169��6&   $	��300��63   ���	#FF363636 � WindowStartupLocation$ CenterScreen=�6V   .��5
      � .+�5   
   �� -   5         ��Name$ label��5      $��Image A��6   $
��Left=�61   $��	10,13,0,0q�6L   $	��Top=�6_   �� 5   
   -   5        $ 	lblImageA��5      $��Label��6#   $
��Left=�63   $��	74,13,0,0q�6N   $	��Top=�6a   �� 5   
   -   5        $ 
label_Copy��5      $��Image B��6$   $
��Left=�66   $��	10,36,0,0q�6Q   $	��Top=�6d   �� 5   
   -   5         ��Name$ 	cboxImage��5      $
��Left=�6&   $��	74,33,0,0q�6A   $	��Top=�6T   $	��180��6l   6{   �� 5   
   -   5        $ label2��5      $
��A = ��6    $
��Left=�6/   $��	10,68,0,0q�6J   $	��Top=�6]   $��20(�6u   $  Xceed.Wpf.Toolkit.DoubleUpDown  5   
   -   5        $��ratioA��5      $
��Left=�6*   $��	56,70,0,0q�6E   $	��Top=�6X   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 1X�6p      Minimum$
 -255X�6z      Maximum$	 255X�6�   6�   �� 5   
   -   5        $ label2_Copy��5      $�� * A ��6%   $
��Left=�65   $��
104,68,0,0q�6P   $	��Top=�6d   $��20(�6|   �� 5   
   -   5        $ cboxOp��5      $
��Left=�6#   $��
150,70,0,0q�6>   $	��Top=�6R    �� SelectedIndex$ 0��6j   .@�5      �� $��+��6   �� 5      $��*��6   5        5   
   -	   5        $��ratioB��5      $
��Left=�6*   $��
193,70,0,0q�6E   $	��Top=�6Y   $ 1X�6q   $
 -255X�6{   $	 255X�6�   6�   �� 5   
   -
   5        $ label2_Copy1��5      $�� * B ��6&   $
��Left=�66   $��
241,68,0,0q�6Q   $	��Top=�6e   $��20(�6}   �� 5   
   -   5         ��Name$ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��207,110,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ btnOK��5      $��OK��6    $
��Left=�6-   $��127,110,0,0q�6H   $	��Top=�6]   $��75��6u   6�   5      5      