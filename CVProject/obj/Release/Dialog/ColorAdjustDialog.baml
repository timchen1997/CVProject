   M S B A M L   `   `   `  ���� D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  (    "CVProject.Dialog.ColorAdjustDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CVProject.Dialog     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  ColorAdjust��$	��159��$	��300�����	#FF363636 � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $��* ��� $��30 �.+�� $��0�� �� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��70 ��� $��* ��� $��60 �.+��� $��0��$��0��$	��Hue��$��Center=�$��Center=��� -    ��Name$ HSlider��$��0��$��1��$��Center=�$��Center=�$	��150�� � Minimum$
 -180Q� � Maximum$	 180Q� �� IsSnapToTickEnabled . %  Xceed.Wpf.Toolkit.DecimalUpDown  -   $	��Hue��$��0��$��2��$��Center=�$��Center=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$	 180X�	   Minimum$
	 -180X�
   Value
 ��  �� ElementName$ HSlider�� �� Path$ Value��� $��1��$��0��$��
Saturation��$��Center=�$��Center=��� -   $ SSlider��$��1��$��1��$��Center=�$��Center=�$	��150��$
 -100Q�$	 100Q� .   -   $��
Saturation��$��1��$��2��$��Center=�$��Center=�$	 100X�$
	 -100X�
 �� $ SSlider��$ Value��� $��2��$��0��$��	Lightness��$��Center=�$��Center=��� -   $ LSlider��$��2��$��1��$��Center=�$��Center=�$	��150��$
 -100Q�$	 100Q� .   -   $��	Lightness��$��2��$��2��$��Center=�$��Center=�$	 100X�$
	 -100X�
 �� $ LSlider��$ Value�� $��1��.+��� -    ��Name$ 	btnCancel��$��Cancel��$
��Left=�$��	207,5,0,0q�$	��Top=�$��75���� -   $ btnOK��$��OK��$
��Left=�$��	127,5,0,0q�$	��Top=�$��75��