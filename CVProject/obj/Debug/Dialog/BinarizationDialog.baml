   M S B A M L   `   `   `  ����D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  5   	   )    #CVProject.Dialog.BinarizationDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CVProject.Dialog     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Binarization��5	   	   $	��232��6   $	��420��6+   ���	#FF363636 � WindowStartupLocation$ CenterScreen=�6N   .��5
      � .+�5   
   	� -   5         	�Name$ radiobtnManaul��5      $�� ��6.   $
��Left=�69   $��	10,10,0,0q�6T   $	��Top=�6g   6   �� 5   
   -   5        $��
gboxManaul��5      $��Manual��6%   $
��Left=�65   $��	31,10,0,0q�6P   $	��Top=�6c   $	��130��6{   $	��371��6�   .��5      �  � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$    � ColumnDefinitions 5      �� 5      $��30 �6'   �� 5      $��50 �6'   �� 5      $��* �6'   �� 5      $��52 �6'   �� 5      $��50 �6'   .+�5      �� $��R��6   $��Center=�6$   $��Center=�6?   $��0��6\   �� 5      -   5        $��RInOut��5   8   $��0��6   $��1��6(    �� SelectedIndex$ 0��6F   $��Center=�6X   $��Center=�6s   .@�5      �� $��in��6   �� 5      $	��out��6   5      #  Xceed.Wpf.Toolkit.RangeSlider  5      -   5        $��RSlider��5   @   $��0��6#   $��2��60   $��Center=�6O   $��Center=�6l      Maximum$	 255Q�6�   $	��170��6�      IsSnapToTickEnabled . 6�   %  Xceed.Wpf.Toolkit.DecimalUpDown  5       -   5        $
��RLow��5    B   $��0��6%   $��3��62   $��Center=�6N   $��Center=�6k   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$	 255X�6�   	   Minimum$	 0X�6�   $��0,0,2,0q�6�   
   Value
 6�   ��  �� ElementName$ RSlider�� �� Path$ 
LowerValue�6�     5!      -   5        $��RHigh��5!   B   $��0��6%   $��4��62   $��Center=�6O   $��Center=�6l   $	 255X�6�   $	 0X�6�   
 6�   �� $ RSlider��$ HigherValue�6�   �� 5"      $��G��6   $��Center=�6$   $��Center=�6?   $��1��6\   �� 5#      -   5        $��GInOut��5#   8   $��1��6   $��1��6(   $ 0��6F   $��Center=�6X   $��Center=�6s   .@�5$      �� $��in��6   �� 5%      $	��out��6   5&        5'      -   5        $��GSlider��5'   @   $��1��6#   $��2��60   $��Center=�6O   $��Center=�6l   $	 255Q�6�   $	��170��6�    . 6�     5(      -	   5        $
��GLow��5(   B   $��1��6%   $��3��62   $��Center=�6N   $��Center=�6k   $	 255X�6�   $	 0X�6�   $��0,0,2,0q�6�   
 6�   �� $ GSlider��$ 
LowerValue�6�     5)      -
   5        $��GHigh��5)   B   $��1��6%   $��4��62   $��Center=�6O   $��Center=�6l   $	 255X�6�   $	 0X�6�   
 6�   �� $ GSlider��$ HigherValue�6�   �� 5*      $��B��6   $��Center=�6$   $��Center=�6?   $��2��6\   �� 5+      -   5        $��BInOut��5+   8   $��2��6   $��1��6(   $ 0��6F   $��Center=�6X   $��Center=�6s   .@�5,      �� $��in��6   �� 5-      $	��out��6   5.        5/      -   5        $��BSlider��5/   @   $��2��6#   $��2��60   $��Center=�6O   $��Center=�6l   $	 255Q�6�   $	��170��6�    . 6�     50      -   5        $
��BLow��50   B   $��2��6%   $��3��62   $��Center=�6N   $��Center=�6k   $	 255X�6�   $	 0X�6�   $��0,0,2,0q�6�   
 6�   �� $ BSlider��$ 
LowerValue�6�     51      -   5        $��BHigh��51   B   $��2��6%   $��4��62   $��Center=�6O   $��Center=�6l   $	 255X�6�   $	 0X�6�   
 6�   �� $ BSlider��$ HigherValue�6�   52      53      	� 54   
   -   5        $ radiobtnOtsu��54      $�� ��6,   $
��Left=�67   $��
10,145,0,0q�6R   $	��Top=�6f   6~   �� 55   
   $
��Otsu��6   $
��Left=�6!   $��
31,145,0,0q�6<   $	��Top=�6P   $	��371��6h   $��24��6t   �� 56   
   -   5         ��Name$ 	btnCancel��56      $��Cancel��6$   $
��Left=�65   $��327,174,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 57   
   -   5        $ btnOK��57      $��OK��6    $
��Left=�6-   $��247,174,0,0q�6H   $	��Top=�6]   $��75��6u   6�   59      5:      